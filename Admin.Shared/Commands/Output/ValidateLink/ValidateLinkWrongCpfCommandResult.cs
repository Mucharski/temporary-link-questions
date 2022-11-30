using Global.Shared.Commands;

namespace Admin.Shared.Commands.Output.ValidateLink;

public class ValidateLinkWrongCpfCommandResult : GenericCommandResult
{
    public ValidateLinkWrongCpfCommandResult(string message = "Verificação de CPF incorreta.") : base(message, false)
    {
    }
}