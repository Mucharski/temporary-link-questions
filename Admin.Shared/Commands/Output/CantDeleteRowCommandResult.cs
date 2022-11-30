using Global.Shared.Commands;

namespace Admin.Shared.Commands.Output;

public class CantDeleteRowCommandResult : GenericCommandResult
{
    public CantDeleteRowCommandResult(string message = "Não foi possível excluir o registro do banco de dados.") : base(message, false)
    {
    }
}