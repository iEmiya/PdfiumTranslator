using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PdfiumViewer;

namespace PdfiumTranslator
{
    delegate void PdfiumPageTranslated(PdfiumPage p);

    delegate void PdfiumPageTranslate();

    class PdfuimDocument : IDisposable
    {
        private readonly PdfDocument _document;
        private readonly string _fileName;
        private readonly Dictionary<int, PdfiumPage> _pages;
        private readonly ConcurrentQueue<int> _queue;
        private Task _translate;

        public PdfuimDocument(PdfDocument document, string fileName)
        {
            TranslateCurrentPage = false;
            _document = document;
            _fileName = Path.ChangeExtension(fileName, ".xml");
            _pages = PdfiumBook.Load(_fileName);
            HasSave = true;

            _queue = new ConcurrentQueue<int>();
        }

        public void Dispose()
        {
            PdfiumPageEvent = null;
            PdfiumPageTranslateBegin = null;
            PdfiumPageTranslateEnd = null;
        }

        public bool TranslateCurrentPage { get; set; }
        public bool HasZoomToFit { get; private set; }
        public bool HasZoomToWidth { get; private set; }
        public bool HasZoomToHeight { get; private set; }
        public bool HasSave { get; private set; }

        public void OnPageToText(int page)
        {
            var p = CreateOrGetPage(page);

            p.SourceText = _document.GetPDFText(page);
            HasSave = false;

            PdfiumPageEvent?.Invoke(p);
        }

        public void OnTranslatePage(int page)
        {
            AddTranslatePage(page);
        }

        public void OnTranslateDocumentChanged()
        {
            TranslateCurrentPage = !TranslateCurrentPage;
        }

        public void OnZoomPageChanged(int page, float zoom)
        {
            OnDisplayRectangleChanged(page);
        }

        public void OnFitPageChanged(int page, PdfViewerZoomMode zoomMode)
        {
            OnDisplayRectangleChanged(page);

            HasZoomToFit = HasZoomToWidth = HasZoomToHeight = false;
            switch (zoomMode)
            {
                case PdfViewerZoomMode.FitBest:
                    HasZoomToFit = true;
                    break;
                case PdfViewerZoomMode.FitWidth:
                    HasZoomToWidth = true;
                    break;
                case PdfViewerZoomMode.FitHeight:
                    HasZoomToHeight = true;
                    break;
            }
        }

        public void OnDisplayRectangleChanged(int page)
        {
            var p = CreateOrGetPage(page);
            if (!p.Translated && TranslateCurrentPage) AddTranslatePage(page);
            PdfiumPageEvent?.Invoke(p);
        }

        private PdfiumPage CreateOrGetPage(int page)
        {
            if (!_pages.ContainsKey(page))
            {
                var p = new PdfiumPage();
                p.No = page;
                p.SourceText = _document.GetPDFText(page);
                _pages[page] = p;

                HasSave = false;
            }
            return _pages[page];
        }
        
        public event PdfiumPageTranslate PdfiumPageTranslateBegin;
        public event PdfiumPageTranslate PdfiumPageTranslateEnd;

        private void AddTranslatePage(int page)
        {
            if (_queue.Contains(page)) return;

            _queue.Enqueue(page);
            lock (_queue)
            {
                if (_translate == null) _translate = Task.Factory.StartNew(TranslateWorker);
            }
        }

        private void TranslateWorker()
        {
            int page;
            PdfiumPage p = null;
            while (_queue.TryDequeue(out page))
            {
                HasSave = false;
                PdfiumPageTranslateBegin?.Invoke();

                p = _pages[page];
                TranslatePage(p);

                PdfiumPageEvent?.Invoke(p);
            }

            _translate = null;
            PdfiumPageTranslateEnd?.Invoke();
        }

        private static readonly char[] tochka = { '.', '?', '!' };

        private void TranslatePage(PdfiumPage p)
        {
            if (string.IsNullOrEmpty(p.SourceText))
            {
                p.Translated = true;
                p.TargetText = p.SourceText;
                return;
            }

            var sourceCollection = SplitePageText(p);
            var t = new GoogleTranslate();
            var targetBuilder = new StringBuilder();

            int i = 0;
            foreach (var sourceLine in sourceCollection)
            {
                i++;
                if (string.IsNullOrEmpty(sourceLine))
                {
                    targetBuilder.AppendLine();
                    continue;
                }
                var source = sourceLine.Trim();
                if (string.IsNullOrEmpty(source))
                {
                    targetBuilder.AppendLine();
                    continue;
                }
                
                string[] words = source.Split(tochka);

                var target = new StringBuilder();
                var pos = 0;
                for (int j = 0; j < words.Length; j++)
                {
                    var word = words[j];
                    var w = t.Translate(word, "English", "Russian");
                    if (t.Error != null)
                    {
                        MessageBox.Show(t.Error.Message, nameof(GoogleTranslate), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        break;
                    }
                    target.Append(w);

                    pos += word.Length;
                    if (pos < source.Length)
                    {
                        var e = source[pos];
                        pos++;
                        target.Append(e);
                    }
                }
                targetBuilder.AppendLine(target.ToString());

            }
            p.TargetText = targetBuilder.ToString();
            p.Translated = true;
        }

        private static readonly string[] matchSplite = {"\r\n", "\n"};

        private static string[] SplitePageText(PdfiumPage p)
        {
            var lines = p.SourceText.Split(matchSplite, StringSplitOptions.None);
            var sourceCollection = new List<string>(lines);

            int i = -1;
            while (i < sourceCollection.Count - 2)
            {
                i++;

                var rightLine = sourceCollection[i].TrimEnd();
                var leftLine = sourceCollection[i + 1].TrimStart();

                if (rightLine.Length < 1) continue;
                if (leftLine.Length < 1) continue;

                var rightCh = rightLine[rightLine.Length - 1];
                var leftCh = leftLine[0];

                if (!char.IsLetter(rightCh) || !char.IsLower(rightCh)) continue;
                if (!char.IsLetter(leftCh) || !char.IsLower(leftCh)) continue;

                var line = sourceCollection[i];
                if ('-'.Equals(rightCh))
                {
                    line = line.Substring(0, line.Length - 1);
                }
                if (!char.IsWhiteSpace(leftCh))
                {
                    line = line + " ";
                }
                sourceCollection[i] = line + sourceCollection[i + 1];
                sourceCollection.RemoveAt(i + 1);
                i--;
            }

            return sourceCollection.ToArray();
        }

        public event PdfiumPageTranslated PdfiumPageEvent;

        public void Save()
        {
            PdfiumBook.Save(_pages, _fileName);
            HasSave = true;
        }

        public void OnSourceTextChanged(int page, string text)
        {
            var p = CreateOrGetPage(page);
            p.SourceText = text;
            HasSave = false;
            PdfiumPageEvent?.Invoke(p);
        }

        public void OnTargetTextChanged(int page, string text)
        {
            var p = CreateOrGetPage(page);
            p.TargetText = text;
            HasSave = false;
            PdfiumPageEvent?.Invoke(p);
        }
    }
}
