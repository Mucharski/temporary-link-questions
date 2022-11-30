using System.ComponentModel.DataAnnotations;
using Flunt.Notifications;
using Flunt.Validations;
using Global.Shared.Commands.Contracts;

namespace Admin.Shared.Commands.Input;

public class UpdateLinkLocationCommand : Notifiable<Notification>, ICommand
{
    [Required] public string Guid { get; set; }
    [Required] public string Location { get; set; }
    public void Validate()
    {
        AddNotifications(new Contract<Notification>()
            .Requires()
            .IsNotNullOrEmpty(Guid, "Guid", "Informe o Guid do link.")
            .IsNotNullOrEmpty(Location, "Location", "Informe a localização."));
    }
}