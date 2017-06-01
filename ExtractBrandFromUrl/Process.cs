using System;
using System.Collections.Generic;

namespace ExtractBrandFromUrl
{
    class Process
    {
        private List<string> Urls { get; set; }
        public List<string> BrandTemplateUrls { get; private set; }
        public List<string> CleansedUrls { get; private set; }

        public Process(List<string> csvUrls)
        {
            Urls = new List<string>(csvUrls);
            CleansedUrls = new List<string>();
        }
        public Process(List<string> csvUrls, List<string> csvBrandTemplate)
        {
            Urls = new List<string>(csvUrls);
            BrandTemplateUrls = new List<string>(csvBrandTemplate);
            CleansedUrls = new List<string>();
        }

        public void SeperateUrls()
        {
            foreach (var line in Urls)
            {
                var commaIndx = line.IndexOf(',');
                if (commaIndx > -1)
                {
                    var url = line.Substring(0, commaIndx);
                    CleansedUrls.Add(url);
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
                    var lastSlash = CleansedUrls[i].LastIndexOf('/');
                    CleansedUrls[i] = CleansedUrls[i].Substring(lastSlash);
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