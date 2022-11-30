using System.ComponentModel.DataAnnotations;
using Flunt.Notifications;
using Flunt.Validations;
using Global.Shared.Commands.Contracts;

namespace Admin.Shared.Commands.Input;

public class LinkQuestionsCommand : Notifiable<Notification>, ICommand
{
    public LinkQuestionsCommand(string guid)
    {
        Guid = guid;
    }

    [Required] public string Guid { get; set; }
    public void Validate()
    {
        AddNotifications(new Contract<Notification>()
            .Requires()
            .IsNotNullOrEmpty(Guid, "Guid", "Informe o Guid do link."));
    }
}