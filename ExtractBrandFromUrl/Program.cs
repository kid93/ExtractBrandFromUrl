namespace ExtractBrandFromUrl
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            
            Files files = new Files("urls.csv", "brand-tmpl.csv");

            Process process = new Process(files.CsvUrls, files.CsvBrandTemplate);
            process.SeperateUrls();
            process.RemoveTrailingSlash();
            process.RemoveSkuNumber();
            process.ExtractBrandName();
            process.MakeIntoBoltUrl();

            Compare compare = new Compare(process.CleansedUrls, process.BrandTemplateUrls);
            compare.CompareUrls();

            Export export = new Export();
            export.ToCSV(files.CsvUrls, process.CleansedUrls, compare.ComparisonResult);

        }
    }
}
