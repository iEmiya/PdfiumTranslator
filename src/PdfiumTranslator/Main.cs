using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using PdfiumViewer;

namespace PdfiumTranslator
{
    public partial class Main : Form
    {
        private readonly string _templateMarkdown;

        private readonly frmRuler _ruler;

        private string _title = "PdfiumTranslator";
        private PdfuimDocument _document;

        private string _sourceText;
        private string _targetText;
        private bool _rukerEnabled;
        private bool _autoScrollEnabled;

        public Main()
        {
            var loader = ResourceLoader.GetLoader<Main>();
            
            InitializeComponent();
            pdfViewer.Renderer.DisplayRectangleChanged += Renderer_DisplayRectangleChanged;

            webTargetText.PreviewKeyDown += WebTargetText_PreviewKeyDown;


            // https://sindresorhus.com/github-markdown-css/
            _templateMarkdown = loader.LoadAsString("PdfiumTranslator.Template.index.html");
            var markdownCss = loader.LoadAsString("PdfiumTranslator.Template.github-markdown.css");
            _templateMarkdown = _templateMarkdown.Replace("<link rel=\"stylesheet\" href=\"github-markdown.css\">",
                $"<style>{markdownCss}</style>");

            _rukerEnabled = false;
            _autoScrollEnabled = true;

            _ruler = new frmRuler();
            OnChangePdfuimDocument();
        }

        private void WebTargetText_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Q)
            {
                e.IsInputKey = true;
                OnTabTargetChanged();
            }
        }

        #region Menu

        #region &File

        private void btnFileExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnFileOpen_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        #endregion

        #region View

        private void btnViewZoomToFit_Click(object sender, EventArgs e)
        {
            FitPage(PdfViewerZoomMode.FitBest);
        }

        private void btnFitWidth_Click(object sender, EventArgs e)
        {
            FitPage(PdfViewerZoomMode.FitWidth);
        }

        private void btnFitHeight_Click(object sender, EventArgs e)
        {
            FitPage(PdfViewerZoomMode.FitHeight);
        }

        private void btnRuler_Click(object sender, EventArgs e)
        {
            OnViewRuler();
        }

        private void btnAutoScroll_Click(object sender, EventArgs e)
        {
            OnViewAutoScroll();
        }

        #endregion

        #region Tools

        private void btnPageToText_Click(object sender, EventArgs e)
        {
            OnPageToText();
        }

        private void btnToolTranslatePage_Click(object sender, EventArgs e)
        {
            OnTranslatePage();
        }

        private void btnToolsTranlateDocument_Click(object sender, EventArgs e)
        {
            OnTranslateDocumentChanged();
        }

        #endregion

        #endregion

        #region Tools

        private void btnZoomOriginalSize_Click(object sender, EventArgs e)
        {
            ZoomPage(1.0f);
        }

        private void btnZoomToFit_Click(object sender, EventArgs e)
        {
            FitPage(PdfViewerZoomMode.FitBest);
        }

        private void btnZoomToWidth_Click(object sender, EventArgs e)
        {
            FitPage(PdfViewerZoomMode.FitWidth);
        }

        private void btnZoomToHeight_Click(object sender, EventArgs e)
        {
            FitPage(PdfViewerZoomMode.FitHeight);
        }

        private void btnViewRuler_Click(object sender, EventArgs e)
        {
            OnViewRuler();
        }

        private void btnViewAutoScroll_Click(object sender, EventArgs e)
        {
            OnViewAutoScroll();
        }

        private void btnTranslatePageToText_Click(object sender, EventArgs e)
        {
            OnPageToText();
        }

        private void btnTranslatePage_Click(object sender, EventArgs e)
        {
            OnTranslatePage();
        }

        private void btnTranslateDocument_Click(object sender, EventArgs e)
        {
            OnTranslateDocumentChanged();
        }

        #endregion

        #region ShortCuts

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.Q))
            {
                OnTabTargetChanged();
                return true;
            }

            if (tbSourceText.Focused)
            {
                if (keyData == (Keys.Control | Keys.L))
                {
                    OnSourceSelectTextToLower();
                    return true;
                }

                if (keyData == (Keys.Shift | Keys.OemQuestion))
                {
                    OnSourceSelectTextToCommentOut();
                    return true;
                }
            }

            if (tbTargetText.Focused)
            {
                if (keyData == (Keys.Control | Keys.B))
                {
                    OnTargetSelectTextToBold();
                    return true;
                }

                if (keyData == (Keys.Control | Keys.I))
                {
                    OnTargetSelectTextToItalic();
                    return true;
                }
            }
            
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void OnTabTargetChanged()
        {
            this.InvokeIfRequired(() =>
            {
                if (tabTargetText.SelectedTab == tpMarkDown)
                {
                    tabTargetText.SelectedTab = tpTargetText;
                    return;
                }

                tabTargetText.SelectedTab = tpMarkDown;
            });
        }

        #endregion

        private void OpenFile()
        {
            using (var form = new OpenFileDialog())
            {
                form.Filter = "PDF Files (*.pdf)|*.pdf|All Files (*.*)|*.*";
                form.RestoreDirectory = true;
                form.Title = "Open PDF File";

                if (form.ShowDialog(this) != DialogResult.OK) return;

                _document?.Dispose();
                pdfViewer.Document?.Dispose();
                pdfViewer.Document = OpenDocument(form.FileName);

                _title = Path.GetFileNameWithoutExtension(form.FileName);
                this.Text = _title;
                _document = new PdfuimDocument(pdfViewer.Document, form.FileName);
                _document.PdfiumPageTranslateBegin += OnPdfiumPageTranslateBegin;
                _document.PdfiumPageTranslateEnd += OnPdfiumPageTranslateEnd;
                _document.PdfiumPageEvent += OnPdfiumPageTranslatedEvent;
                _document.TranslateCurrentPage = true;
                _document.OnDisplayRectangleChanged(0);
                OnChangePdfuimDocument();
            }
        }

        private void OnPdfiumPageTranslateBegin()
        {
            this.InvokeIfRequired(() =>
            {
                pbRun.Visible = true;
                OnChangePdfuimDocument();
            });
        }

        private void OnPdfiumPageTranslateEnd()
        {
            this.InvokeIfRequired(() =>
            {
                pbRun.Visible = false;
                OnChangePdfuimDocument();
            });
        }

        private void OnPdfiumPageTranslatedEvent(PdfiumPage p)
        {
            int page = pdfViewer.Renderer.Page;
            if (p.No != page) return;

            this.InvokeIfRequired(() =>
            {
                if (!string.Equals(p.SourceText, _sourceText))
                {
                    tbSourceText.TextChanged -= tbSourceText_TextChanged;
                    tbSourceText.Text = p.SourceText;
                    tbSourceText.TextChanged += tbSourceText_TextChanged;
                    _sourceText = p.SourceText;
                }
                if (!string.Equals(p.TargetText, _targetText))
                {
                    tbTargetText.TextChanged -= tbTargetText_TextChanged;
                    tbTargetText.Text = p.TargetText;
                    tbTargetText.TextChanged += tbTargetText_TextChanged;

                    var text = p.TargetText;
                    UpdateMarkdown(text);

                    _targetText = p.TargetText;
                }
            });
        }

        private void UpdateMarkdown(string text)
        {
            var htmlBody = CommonMark.CommonMarkConverter.Convert(text);
            webTargetText.DocumentText = _templateMarkdown.Replace("#BODY#", htmlBody);
        }

        #region

        #endregion

        private PdfDocument OpenDocument(string fileName)
        {
            try
            {
                return PdfDocument.Load(this, fileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private void SaveFile()
        {
            _document?.Save();
            OnChangePdfuimDocument();
        }

        private void ZoomPage(float zoom)
        {
            int page = pdfViewer.Renderer.Page;
            pdfViewer.Renderer.Zoom = zoom;
            pdfViewer.Renderer.Page = page;
            _document?.OnZoomPageChanged(page, zoom);
            OnChangePdfuimDocument();
        }

        private void FitPage(PdfViewerZoomMode zoomMode)
        {
            int page = pdfViewer.Renderer.Page;
            pdfViewer.ZoomMode = zoomMode;
            pdfViewer.Renderer.Zoom = 1;
            pdfViewer.Renderer.Page = page;
            _document?.OnFitPageChanged(page, zoomMode);
            OnChangePdfuimDocument();
        }

        private void OnPageToText()
        {
            int page = pdfViewer.Renderer.Page;
            _document?.OnPageToText(page);
            OnChangePdfuimDocument();
        }

        private void OnTranslatePage()
        {
            int page = pdfViewer.Renderer.Page;
            _document?.OnTranslatePage(page);
            OnChangePdfuimDocument();
        }

        private void OnTranslateDocumentChanged()
        {
            _document?.OnTranslateDocumentChanged();
            OnChangePdfuimDocument();
        }

        private void OnChangePdfuimDocument()
        {
            btnToolsTranlateDocument.Checked = btnTranslateDocument.Checked = _document?.TranslateCurrentPage ?? false;
            btnViewZoomToFit.Checked = btnZoomToFit.Checked = _document?.HasZoomToFit ?? false;
            btnFitWidth.Checked = btnZoomToWidth.Checked = _document?.HasZoomToWidth ?? false;
            btnFitHeight.Checked = btnZoomToHeight.Checked = _document?.HasZoomToHeight ?? false;

            btnRuler.Checked = btnViewRuler.Checked = _rukerEnabled;
            if (_ruler.Visible && !_rukerEnabled)
            {
                _ruler.Hide();
            }
            else if (!_ruler.Visible && _rukerEnabled)
            {
                _ruler.Show(this);
                this.Focus();
            }
            btnAutoScroll.Checked = btnViewAutoScroll.Checked = _autoScrollEnabled;

            this.Text = _title;
            if (_document != null && !_document.HasSave) this.Text += "*";
        }

        private void Renderer_DisplayRectangleChanged(object sender, EventArgs e)
        {
            var page = pdfViewer.Renderer.Page;
            var pages = pdfViewer.Document?.PageCount ?? 1;
            tbPage.Text = $"{page + 1} of {pages}";

            _document?.OnDisplayRectangleChanged(page);
            OnChangePdfuimDocument();


            if (!_autoScrollEnabled) return;
            this.InvokeIfRequired(() =>
            {
                tbSourceText.SelectionStart = GetSelectionStart(tbSourceText, page);
                tbSourceText.ScrollToCaret();

                tbTargetText.SelectionStart = GetSelectionStart(tbTargetText, page);
                tbTargetText.ScrollToCaret();
                
                WebScrollRectangle(page);
            });
        }

        private void WebScrollRectangle(int page)
        {
            var pageCache = pdfViewer.Renderer.GetOuterBounds(page);
            int y = -pdfViewer.Renderer.DisplayRectangle.Top - pageCache.Top;

            if (pageCache.Height <= 0 || y <= 0) return;

            var htmlDocument = webTargetText.Document;
            if (htmlDocument == null) return;

            var htmlWindow = htmlDocument.Window;
            var htmlBody = htmlDocument.Body;
            if (htmlWindow == null) return;
            if (htmlBody == null) return;

            var height = (int)(1.0d * y * htmlBody.ScrollRectangle.Height / pageCache.Height);
            htmlWindow.ScrollTo(0, height);
        }

        private int GetSelectionStart(TextBox control, int page)
        {
            var pageCache = pdfViewer.Renderer.GetOuterBounds(page);
            int y = -pdfViewer.Renderer.DisplayRectangle.Top - pageCache.Top;

            if (pageCache.Height <= 0 || y <= 0) return 0;

            int chars, lines;
            using (var g = Graphics.FromHwnd(this.Handle))
            {
                g.MeasureString(control.Text,
                    control.Font, new SizeF(control.Width - 4, control.Height - 4), null,
                    out chars, out lines);
            }

            return (int)(1.0d * y * (tbSourceText.TextLength + 2 * chars) / pageCache.Height);
        }

        private void tbSourceText_TextChanged(object sender, EventArgs e)
        {
            var renderer = pdfViewer.Renderer;
            var page = renderer.Page;
            _document?.OnSourceTextChanged(page, tbSourceText.Text);
            OnChangePdfuimDocument();
        }

        private void tbTargetText_TextChanged(object sender, EventArgs e)
        {
            var renderer = pdfViewer.Renderer;
            var page = renderer.Page;
            _document?.OnTargetTextChanged(page, tbTargetText.Text);
            OnChangePdfuimDocument();
        }

        private void btnSourceSelectTextToLower_Click(object sender, EventArgs e)
        {
            OnSourceSelectTextToLower();
        }

        private void btnSourceSelectTextCommentOut_Click(object sender, EventArgs e)
        {
            OnSourceSelectTextToCommentOut();
        }

        #region tbSourceText

        private void OnSourceSelectTextToCommentOut()
        {
            var control = tbSourceText;

            var selectionStart = control.SelectionStart;
            var selectionLength = control.SelectionLength;
            if (selectionLength <= 0) return;

            var text = new StringBuilder(control.Text);
            var t = text.ToString(selectionStart, selectionLength);
            text.Remove(selectionStart, selectionLength);
            text.Insert(selectionStart, $"[ {t} ]");

            using (control.WatchSelection(2, 2))
            {
                UpdateSourceText(text.ToString());
            }
        }

        private void OnSourceSelectTextToLower()
        {
            var control = tbSourceText;

            var selectionStart = control.SelectionStart;
            var selectionLength = control.SelectionLength;
            if (selectionLength <= 0) return;

            var text = new StringBuilder(control.Text);
            var t = text.ToString(selectionStart, selectionLength);
            text.Remove(selectionStart, selectionLength);
            text.Insert(selectionStart, t.ToLower());

            using (control.WatchSelection())
            {
                UpdateSourceText(text.ToString());
            }
        }

        private void UpdateSourceText(string text)
        {
            tbSourceText.TextChanged -= tbSourceText_TextChanged;
            tbSourceText.Text = text;
            tbSourceText.TextChanged += tbSourceText_TextChanged;
        }

        #endregion

        private void btnTargetSelectTextToBold_Click(object sender, EventArgs e)
        {
            OnTargetSelectTextToBold();
        }

        private void btnTargetSelectTextToItalic_Click(object sender, EventArgs e)
        {
            OnTargetSelectTextToItalic();
        }

        #region tbTargetText

        private void OnTargetSelectTextToBold()
        {
            var control = tbTargetText;

            var selectionStart = control.SelectionStart;
            var selectionLength = control.SelectionLength;
            if (selectionLength <= 0) return;

            var text = new StringBuilder(control.Text);
            var t = text.ToString(selectionStart, selectionLength);
            text.Remove(selectionStart, selectionLength);
            text.Insert(selectionStart, $"**{t}**");

            using (control.WatchSelection(2, 2))
            {
                UpdateTargetText(text.ToString());
            }
        }

        private void OnTargetSelectTextToItalic()
        {
            var control = tbTargetText;

            var selectionStart = control.SelectionStart;
            var selectionLength = control.SelectionLength;
            if (selectionLength <= 0) return;

            var text = new StringBuilder(control.Text);
            var t = text.ToString(selectionStart, selectionLength);
            text.Remove(selectionStart, selectionLength);
            text.Insert(selectionStart, $"*{t}*");

            using (control.WatchSelection(1, 1))
            {
                UpdateTargetText(text.ToString());
            }
        }

        private void UpdateTargetText(string text)
        {
            tbTargetText.TextChanged -= tbTargetText_TextChanged;
            tbTargetText.Text = text;
            UpdateMarkdown(text);
            tbTargetText.TextChanged += tbTargetText_TextChanged;
        }

        #endregion

        private void tbPage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;

                int page;
                if (int.TryParse(tbPage.Text, out page))
                    pdfViewer.Renderer.Page = page - 1;
            }
        }

        private void OnViewAutoScroll()
        {
            _autoScrollEnabled = !_autoScrollEnabled;
            OnChangePdfuimDocument();
        }

        private void OnViewRuler()
        {
            _rukerEnabled = !_rukerEnabled;
            OnChangePdfuimDocument();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            _ruler.CanClose = true;
            _ruler.Close();
            e.Cancel = false;
        }
    }
}
