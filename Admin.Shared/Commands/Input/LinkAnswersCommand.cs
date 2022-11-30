using System.ComponentModel.DataAnnotations;
using Flunt.Notifications;
using Flunt.Validations;
using Global.Shared.Commands.Contracts;

namespace Admin.Shared.Commands.Input;

public class LinkAnswersCommand: Notifiable<Notification>, ICommand
{
    [Required] public string Guid { get; set; }
    [Required] public string TicketId { get; set; }
    [Required] public List<string> Answers { get; set; }
    public void Validate()
    {
        AddNotifications(new Contract<Notification>()
            .Requires()
            .IsNotNullOrEmpty(Guid, "Guid", "Informe o guid do link.")
            .IsNotNullOrEmpty(TicketId, "TicketId", "Informe o ID do ticket.")
            .IsTrue(Answers.Count > 0, "Answers", "Envie as respostas do questinário."));
    }
}