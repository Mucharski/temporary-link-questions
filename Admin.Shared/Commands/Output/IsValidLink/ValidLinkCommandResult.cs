using Global.Shared.Commands;

namespace Admin.Shared.Commands.Output.IsValidLink;

public class ValidLinkCommandResult : GenericCommandResult
{
    public ValidLinkCommandResult(string message = "Link válido!") : base(message, true)
    {
    }
}