using System.ComponentModel.DataAnnotations;

namespace Admin.Shared.Entities;

public class EmailLinkTemplateData
{
    public EmailLinkTemplateData(string name, string link, DateTime expiresAt)
    {
        Name = name;
        Link = link;
        ExpiresAt = expiresAt;
    }

    [Required] public string Name { get; }
    [Required] public string Link { get; }
    [Required] public DateTime ExpiresAt { get; }
}