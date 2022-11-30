using System.ComponentModel.DataAnnotations;
using Flunt.Notifications;
using Flunt.Validations;
using Global.Shared.Commands.Contracts;

namespace Admin.Shared.Commands.Input;

public class GenerateLinkCommand : Notifiable<Notification>, ICommand
{
    public GenerateLinkCommand(string cpf, string name, string email, string @operator, string phone, DateTime birthDate, bool sendBySms)
    {
        Cpf = cpf;
        Name = name;
        Email = email;
        Operator = @operator;
        Phone = phone;
        BirthDate = birthDate;
        SendBySms = sendBySms;
    }

    [Required] public string Cpf { get; set; }
    [Required] public string Name { get; set; }
    [Required] public string Email { get; set; }
    [Required] public string Operator { get; set; }
    [Required] public string Phone { get; set; }
    [Required] public DateTime BirthDate { get; set; }
    public bool SendBySms { get; set; }

    public void Validate()
    {
        AddNotifications(new Contract<Notification>()
            .Requires()
            .IsNotNullOrEmpty(Cpf, "Cpf", "Cpf é obrigatório.")
            .IsNotNullOrEmpty(Name, "Name", "Informe o nome do cliente.")
            .IsNotNullOrEmpty(Email, "Email", "Informe o email do cliente.")
            .IsNotNullOrEmpty(Operator, "Operator", "Informe o nome do operador.")
            .IsNotNullOrEmpty(Phone, "Phone", "Informe o telefone do cliente.")
            .IsFalse(BirthDate == DateTime.MinValue, "BirthDate", "Informe a data de nascimento."));
    }
}
