namespace Admin.Shared.Entities;

public class GenerateLinkReturn
{
    public GenerateLinkReturn(string link, DateTime expiresAt)
    {
        Link = link;
        ExpiresAt = expiresAt;
    }

    public string Link { get; }
    public DateTime ExpiresAt { get; }
}