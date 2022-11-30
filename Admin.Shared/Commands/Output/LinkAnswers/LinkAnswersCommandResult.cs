using Global.Shared.Commands;

namespace Admin.Shared.Commands.Output.LinkAnswers;

public class LinkAnswersCommandResult : GenericCommandResult
{
    public LinkAnswersCommandResult(string message = "Questionário respondido com sucesso!") : base(message, true)
    {
    }
}