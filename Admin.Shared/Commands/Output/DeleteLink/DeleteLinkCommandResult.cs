using Global.Shared.Commands;

namespace Admin.Shared.Commands.Output.DeleteLink;

public class DeleteLinkCommandResult : GenericCommandResult
{
    public DeleteLinkCommandResult(string message = "Registro excluído com sucesso!") : base(message, true)
    {
    }
}