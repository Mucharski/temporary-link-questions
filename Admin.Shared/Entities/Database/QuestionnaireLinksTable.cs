using Admin.Shared.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Admin.Shared.Entities.Database;

public class QuestionnaireLinksTable
{
    public string LinkGuid { get; set; }
    public string Cpf { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string Location { get; set; }
    public string QuestionnaireTicketId { get; set; }
    public string QuestionnaireResult { get; set; }
    [JsonConverter(typeof(StringEnumConverter))]
    public ELinkStatus Status { get; set; }
    public string Operator { get; set; }
    public DateTime ExpiresAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime BirthDate { get; set; }
}