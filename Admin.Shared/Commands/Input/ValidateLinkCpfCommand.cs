using Flunt.Notifications;
using Flunt.Validations;
using Global.Shared.Commands.Contracts;

namespace Admin.Shared.Commands.Input;

public class ValidateLinkCpfCommand : Notifiable<Notification>, ICommand
{
    public string Guid { get; set; }
    public string FirstThreeDigitsCpf { get; set; }
    public void Validate()
    {
        AddNotifications(new Contract<Notification>()
            .Requires()
            .IsNotNullOrEmpty(Guid, "Guid", "Informe o GUID do link.")
            .IsNotNullOrEmpty(FirstThreeDigitsCpf, "FirstThreeDigitsCpf", "Informe os três primeiros dígitos do cpf."));
    }
}