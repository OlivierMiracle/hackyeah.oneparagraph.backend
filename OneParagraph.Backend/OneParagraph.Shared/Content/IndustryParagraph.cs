using OneParagraph.Shared.Enums;

namespace OneParagraph.Shared.Content;

public class IndustryParagraph
{
    public Guid Id { get; set; }
    public Industries Industry { get; set; }
    public string Paragraph { get; set; }
    public Stock Stock { get; set; }
    public DateTime DateTime { get; set; }
    public List<string> SourceUrls { get; set; }
}