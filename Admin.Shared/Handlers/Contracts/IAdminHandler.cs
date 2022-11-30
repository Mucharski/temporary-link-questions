using Admin.Shared.Commands.Input;
using Global.Shared.Handlers.Contracts;

namespace Admin.Shared.Handlers.Contracts;

public interface IAdminHandler : IHandler<GenerateLinkCommand>, IHandler<ValidateLinkCpfCommand>,
    IHandler<LinkQuestionsCommand>, IHandler<IsValidLinkCommand>, IHandler<UpdateLinkLocationCommand>,
    IHandler<LinkAnswersCommand>, IHandler<FilterLinksByCpfCommand>, IHandler<DeleteLinkCommand>
{
    
}