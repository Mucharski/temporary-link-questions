using Global.Shared.Commands;

namespace Admin.Shared.Commands.Output.IsValidLink;

public class LinkExpiredCommandResult : GenericCommandResult
{
    public LinkExpiredCommandResult(string message = "Link expirado.") : base(message, false)
    {
    }
}