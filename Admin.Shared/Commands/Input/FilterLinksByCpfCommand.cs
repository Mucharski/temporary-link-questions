using System.ComponentModel.DataAnnotations;
using Flunt.Notifications;
using Flunt.Validations;
using Global.Shared.Commands.Contracts;

namespace Admin.Shared.Commands.Input;

public class FilterLinksByCpfCommand : Notifiable<Notification>, ICommand
{
    public FilterLinksByCpfCommand(string cpf)
    {
        Cpf = cpf;
    }

    [Required] public string Cpf { get; set; }
    public void Validate()
    {
        AddNotifications(new Contract<Notification>()
            .Requires()
            .IsNotNullOrEmpty(Cpf, "Cpf", "Informe o CPF."));
    }
}