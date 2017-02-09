using System.IO;
using System.Reflection;

namespace PdfiumTranslator
{
    class ResourceLoader
    {
        public static ResourceLoader GetLoader<T>()
        {
            var assem = typeof(T).Assembly;
            return new ResourceLoader(assem);
        }

        public ResourceLoader(Assembly assem)
        {
            _assem = assem;
            _names = _assem.GetManifestResourceNames();
        }

        private readonly Assembly _assem;
        private readonly string[] _names;

        public string[] Names => _names;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2202:Do not dispose objects multiple times")]
        public string LoadAsString(string sFile)
        {
            using (var resource = LoadAsStream(sFile))
            using (var resourceReader = new StreamReader(resource))
            {
                return resourceReader.ReadToEnd();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sFile"></param>
        /// <returns></returns>
        /// <exception cref="FileNotFoundException">Не найден искомый объект</exception>
        public Stream LoadAsStream(string sFile)
        {
            var resource = _assem.GetManifestResourceStream(sFile);
            if (resource == null)
                throw new FileNotFoundException("sFile", sFile);
            return resource;
        }
    }
}
