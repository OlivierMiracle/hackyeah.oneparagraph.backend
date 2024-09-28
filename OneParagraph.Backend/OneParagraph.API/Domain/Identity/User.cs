namespace OneParagraph.API.Domain.Identity;

public class User
{
    public string Email { get; set; }
    public string AccountKey { get; set; }
    public string VerificationKey { get; set; }
}