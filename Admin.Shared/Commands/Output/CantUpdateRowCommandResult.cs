using Global.Shared.Commands;

namespace Admin.Shared.Commands.Output;

public class CantUpdateRowCommandResult : GenericCommandResult
{
    public CantUpdateRowCommandResult(string message = "Não foi possível atualizar o registro no banco de dados.") : base(message, false)
    {
    }
}