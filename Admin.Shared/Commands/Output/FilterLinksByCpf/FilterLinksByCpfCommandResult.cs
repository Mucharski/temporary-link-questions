using Admin.Shared.Entities.Database;
using Global.Shared.Commands;

namespace Admin.Shared.Commands.Output.FilterLinksByCpf;

public class FilterLinksByCpfCommandResult : GenericCommandResult
{
    public FilterLinksByCpfCommandResult(List<QuestionnaireLinksTable> data, string message = "Dados obtidos com sucesso!") : base(message, true)
    {
        Data = data;
    }
    
    public List<QuestionnaireLinksTable> Data { get; }
}