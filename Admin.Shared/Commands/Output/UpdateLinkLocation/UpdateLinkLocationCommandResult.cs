using Global.Shared.Commands;

namespace Admin.Shared.Commands.Output.UpdateLinkLocation;

public class UpdateLinkLocationCommandResult : GenericCommandResult
{
    public UpdateLinkLocationCommandResult(string message = "Localização atualizada com sucesso!") : base(message, true)
    {
    }
}