using Global.Shared.Commands;

namespace Admin.Shared.Commands.Output.ValidateLink;

public class ValidateLinkCpfCommandResult : GenericCommandResult
{
    public ValidateLinkCpfCommandResult(string message = "Verificação de CPF bem-sucedida!") : base(message, true)
    {
    }
}