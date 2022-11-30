using Global.Shared.Commands;

namespace Admin.Shared.Commands.Output.IsValidLink;

public class LinkAlreadyAnsweredCommandResult : GenericCommandResult
{
    public LinkAlreadyAnsweredCommandResult(string message = "Questionário já respondido!") : base(message, false)
    {
    }
}