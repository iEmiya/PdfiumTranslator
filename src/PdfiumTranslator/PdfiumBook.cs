using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace PdfiumTranslator
{
    public class PdfiumBook
    {
        private static readonly XmlSerializer Serializer = new XmlSerializer(typeof(PdfiumBook));

        public static void Save(Dictionary<int, PdfiumPage> pages, string fileName)
        {
            var name = Path.GetFileNameWithoutExtension(fileName);
            var book = new PdfiumBook();
            book.Name = name;
            book.Pages = new PdfiumPage[pages.Count];

            int no = 0;
            foreach (var p in pages.Values) book.Pages[no++] = PdfiumPage.Encode(p);
            
            if (File.Exists(fileName)) File.Delete(fileName);

            using (var file = new StreamWriter(fileName))
            {
                Serializer.Serialize(file, book);
            }
        }

        public static Dictionary<int, PdfiumPage> Load(string fileName)
        {
            var pages = new Dictionary<int, PdfiumPage>();
            if (!File.Exists(fileName)) return pages;

            PdfiumBook book;
            using (var file = new StreamReader(fileName))
            {
                book = (PdfiumBook)Serializer.Deserialize(file);
            }
            foreach (var p in book.Pages)
            {
                var page = PdfiumPage.Decode(p);
                pages.Add(page.No, page);
            }
            return pages;
        }

        public string Name { get; set; }
        public PdfiumPage[] Pages { get; set; } = new PdfiumPage[0];
    }

    public class PdfiumPage
    {
        private static string Base64Encode(string plainText)
        {
            if (string.IsNullOrEmpty(plainText)) return plainText;
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        private static string Base64Decode(string base64EncodedData)
        {
            if (string.IsNullOrEmpty(base64EncodedData)) return base64EncodedData;
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

        public static PdfiumPage Encode(PdfiumPage p)
        {
            var page = new PdfiumPage();
            page.No = p.No;
            page.SourceText = Base64Encode(p.SourceText);
            page.Translated = p.Translated;
            page.TargetText = Base64Encode(p.TargetText);
            return page;
        }

        public static PdfiumPage Decode(PdfiumPage p)
        {
            var page = new PdfiumPage();
            page.No = p.No;
            page.SourceText = Base64Decode(p.SourceText);
            page.Translated = p.Translated;
            page.TargetText = Base64Decode(p.TargetText);
            return page;
        }


        public int No { get; set; }
        public string SourceText { get; set; }
        public bool Translated { get; set; }
        public string TargetText { get; set; }
    }
}
