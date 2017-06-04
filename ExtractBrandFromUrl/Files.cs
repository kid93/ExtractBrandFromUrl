using System.IO;
using System.Collections.Generic;
using System.Text;

namespace ExtractBrandFromUrl
{
    class Files
    {
        
        public List<string> CsvUrls { get; private set; }
        public List<string> CsvBrandTemplate { get; private set; }

        public Files(string urlPath, string brandPath)
        {
            CsvUrls = new List<string>(File.ReadAllLines(urlPath, Encoding.Default));
            CsvBrandTemplate = new List<string>(File.ReadAllLines(brandPath, Encoding.Default));
        }

    }
}
