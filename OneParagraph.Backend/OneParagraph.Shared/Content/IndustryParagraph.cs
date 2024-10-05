using OneParagraph.Shared.Enums;

namespace OneParagraph.Shared.Content;

public class IndustryParagraph
{
    public Guid Id { get; set; }
    public Industry Industry { get; set; }
    public string Paragraph { get; set; }
    public DateTime DateTime { get; set; }
    public List<string> Stocks { get; set; }
    public List<string> SourceUrls { get; set; }
    public List<string> SourceNames { get; set; }
}