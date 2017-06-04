using System.Collections.Generic;

namespace ExtractBrandFromUrl
{
    class Compare
    {
        
        public List<string> ComparisonResult { get; private set; }
        public List<string> CleansedUrls { get; private set; }
        public List<string> BrandTemplateUrls { get; private set; }

        public Compare(List<string> cleansedUrls, List<string> brandTemplateUrls)
        {
            ComparisonResult = new List<string>();
            CleansedUrls = new List<string>(cleansedUrls);
            BrandTemplateUrls = new List<string>(brandTemplateUrls);
        }


        public void CompareUrls()
        {
            foreach (var url in CleansedUrls)
            {
                if (BrandTemplateUrls.Contains(url))
                {
                    ComparisonResult.Add("exists in brand template");
                }
                else
                {
                    ComparisonResult.Add("does not exist");
                }
            }
        }

    }
}
