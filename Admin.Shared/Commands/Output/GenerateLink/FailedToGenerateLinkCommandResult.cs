using Global.Shared.Commands;

namespace Admin.Shared.Commands.Output.GenerateLink;

public class FailedToGenerateLinkCommandResult : GenericCommandResult
{
    public FailedToGenerateLinkCommandResult(string message = "Houve um erro ao gerar o link. Tente novamente.") : base(message, false)
    {
    }
}