using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ExtractBrandFromUrl
{
    class Export
    {
        private List<string> _finalUrls = new List<string>();

        public void ToCSV(List<string> original, List<string> cleansed, List<string> comparisonResult)
        {
            for (var i = 0; i < original.Count; i++)
            {
                _finalUrls.Add(original[i] + "," + cleansed[i] + "," + comparisonResult[i]);
            }

            File.WriteAllLines("new.csv", _finalUrls, Encoding.Default);
        }
    }
}
