using CSV_Parser.Processors;

namespace CSV_Parser.Factories
{
    public class CSVProcessorFactory
    {
        public static IRowProcessor GetProcessor(string filetype)
        {
            return filetype.ToLower() switch
            {
                "facebook" => new FacebookCSVProcessor(),
                "google" => new GoogleCSVProcessor(),
                "website" => new WebsiteCSVProcessor(),
                _ => throw new InvalidOperationException($"No processor found for filetype: {filetype}"),
            };
        }
    }
}