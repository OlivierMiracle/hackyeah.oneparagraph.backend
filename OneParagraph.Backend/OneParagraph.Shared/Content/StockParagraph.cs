namespace OneParagraph.Shared.Content;

public sealed class StockParagraph
{
    public Guid Id { get; set; }
    public Stock Stock { get; set; }
    public string Paragraph { get; set; }
}