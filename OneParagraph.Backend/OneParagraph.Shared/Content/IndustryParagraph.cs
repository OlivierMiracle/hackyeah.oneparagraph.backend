using OneParagraph.Shared.Enums;

namespace OneParagraph.Shared.Content;

public class IndustryParagraph
{
    public Industries Industry { get; set; }
    public string Paragraph { get; set; }
    public Stock Stock { get; set; }
    public List<string> SourceUrls { get; set; }
}