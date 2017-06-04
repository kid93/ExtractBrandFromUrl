using System.Collections.Generic;

namespace ExtractBrandFromUrl
{
    class Process
    {
        
        private List<string> _urls;
        public List<string> BrandTemplateUrls { get; private set; }
        public List<string> CleansedUrls { get; private set; }

        public Process(List<string> csvUrls, List<string> csvBrandTemplate)
        {
            _urls = new List<string>(csvUrls);
            BrandTemplateUrls = new List<string>(csvBrandTemplate);
            CleansedUrls = new List<string>();
        }


        public void SeperateUrls()
        {
            foreach (var line in _urls)
            {
                var commaIndx = line.IndexOf(',');
                if (commaIndx > -1)
                {
                    var url = line.Substring(0, commaIndx);
                    CleansedUrls.Add(url.ToLower());
                }
            }
        }

        public void RemoveTrailingSlash()
        {
            for (var i = 0; i < CleansedUrls.Count; i++)
            {
                CleansedUrls[i] = CleansedUrls[i].TrimEnd('/');
            }
        }

        public void RemoveSkuNumber()
        {
            for (var i = 0; i < CleansedUrls.Count; i++)
            {
                if (!string.IsNullOrWhiteSpace(CleansedUrls[i]))
                {
                    var lastSlashIndx = CleansedUrls[i].LastIndexOf('/');
                    CleansedUrls[i] = CleansedUrls[i].Substring(0, lastSlashIndx);
                }
            }
        }

        public void ExtractBrandName()
        {
            for (var i = 0; i < CleansedUrls.Count; i++)
            {
                if (!string.IsNullOrWhiteSpace(CleansedUrls[i]))
                {
                    var lastSlashIndx = CleansedUrls[i].LastIndexOf('/');
                    CleansedUrls[i] = CleansedUrls[i].Substring(lastSlashIndx);
                }
            }
        }

        public void MakeIntoBoltUrl()
        {
            for (var i = 0; i < CleansedUrls.Count; i++)
            {
                if (!string.IsNullOrWhiteSpace(CleansedUrls[i]))
                {
                    CleansedUrls[i] = string.Concat("/designers" + CleansedUrls[i]);
                }
            }
        }

    }
}
