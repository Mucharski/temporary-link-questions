using Admin.Shared.Entities;
using Global.Shared.Commands;

namespace Admin.Shared.Commands.Output.GenerateLink;

public class GenerateLinkCommandResult : GenericCommandResult
{
    public GenerateLinkCommandResult(GenerateLinkReturn data, string message = "Link gerado com sucesso!") : base(message, true)
    {
        Data = data;
    }
    
    public GenerateLinkReturn Data { get; }
}