using Admin.Shared.Commands.Input;
using Admin.Shared.Commands.Output;
using Admin.Shared.Commands.Output.DeleteLink;
using Admin.Shared.Commands.Output.FilterLinksByCpf;
using Admin.Shared.Commands.Output.GenerateLink;
using Admin.Shared.Commands.Output.IsValidLink;
using Admin.Shared.Commands.Output.LinkAnswers;
using Admin.Shared.Commands.Output.UpdateLinkLocation;
using Admin.Shared.Commands.Output.ValidateLink;
using Admin.Shared.Entities;
using Admin.Shared.Entities.Database;
using Admin.Shared.Entities.Parameters;
using Admin.Shared.Enums;
using Admin.Shared.Handlers.Contracts;
using Admin.Shared.Repositories;
using Global.Shared.Commands;
using Global.Shared.Commands.Contracts;
using Global.Shared.Entities;
using Microsoft.Extensions.Configuration;

namespace Admin.Shared.Handlers;

public class AdminHandler : IAdminHandler
{
    private readonly IAdminRepository _repo;
    private readonly string _baseUrlTemporaryLink;

    public AdminHandler(IAdminRepository repo, IConfiguration config)
    {
        _repo = repo;
        _baseUrlTemporaryLink = config["Admin:BaseUrlTemporaryLink"];
    }

    public async Task<ICommandResult> Handler(GenerateLinkCommand command)
    {
        try
        {
            command.Validate();

            if (!command.IsValid)
            {
                return new InvalidCommandResult(new InvalidCommandData(command.Notifications));
            }

            GenerateLinkParams parameters = new(command);

            int rowsInserted = await _repo.CreateQuestionnaireLink(parameters);

            if (rowsInserted == 0)
            {
                return new FailedToGenerateLinkCommandResult();
            }

            string completeLink = $"{_baseUrlTemporaryLink}/{parameters.Guid}";
            
            return new GenerateLinkCommandResult(new GenerateLinkReturn(completeLink, parameters.ExpiresAt));
        }
        catch (Exception e)
        {
            object parameters = new
            {
                command
            };

            e.Data.Add($"{GetType().Name}::Handle(GenerateLinkCommand)", parameters);

            throw;
        }
    }

    public async Task<ICommandResult> Handler(ValidateLinkCpfCommand command)
    {
        try
        {
            command.Validate();

            if (!command.IsValid)
            {
                return new InvalidCommandResult(new InvalidCommandData(command.Notifications));
            }

            string cpfTable = await _repo.GetQuestionnaireCpf(Guid.Parse(command.Guid));

            string firstThreeDigitsOfCpfTable = cpfTable[..3];

            if (firstThreeDigitsOfCpfTable != command.FirstThreeDigitsCpf)
            {
                return new ValidateLinkWrongCpfCommandResult();
            }

            return new ValidateLinkCpfCommandResult();
        }
        catch (Exception e)
        {
            object parameters = new { command };

            e.Data.Add($"{GetType().Name}::Handler(VerifyLinkCpfCommand)", parameters);

            throw;
        }
    }

    public async Task<ICommandResult> Handler(LinkQuestionsCommand command)
    {
        try
        {
            command.Validate();

            if (!command.IsValid)
            {
                return new InvalidCommandResult(new InvalidCommandData(command.Notifications));
            }

            QuestionnaireLinksTable clientData = await _repo.GetLinkClientData(Guid.Parse(command.Guid));

            return null;
        }
        catch (Exception e)
        {
            object parameters = new { command };

            e.Data.Add($"{GetType().Name}::Handler(LinkQuestionsCommand)", parameters);

            throw;
        }
    }

    public async Task<ICommandResult> Handler(IsValidLinkCommand command)
    {
        try
        {
            command.Validate();

            if (!command.IsValid)
            {
                return new InvalidCommandResult(new InvalidCommandData(command.Notifications));
            }

            QuestionnaireLinksTable questionnaireLinksTable = await _repo.GetLinkDataByGuid(Guid.Parse(command.Guid));
            
            if (questionnaireLinksTable.Status == ELinkStatus.Answered)
            {
                return new LinkAlreadyAnsweredCommandResult();
            }
            
            if (DateTime.Now > questionnaireLinksTable.ExpiresAt)
            {
                return new LinkExpiredCommandResult();
            }

            return new ValidLinkCommandResult();
        }
        catch (Exception e)
        {
            object parameters = new { command };

            e.Data.Add($"{GetType().Name}::Handler(IsLinkExpiredCommand)", parameters);

            throw;
        }
    }

    public async Task<ICommandResult> Handler(UpdateLinkLocationCommand command)
    {
        try
        {
            command.Validate();

            if (!command.IsValid)
            {
                return new InvalidCommandResult(new InvalidCommandData(command.Notifications));
            }

            int rowsUpdated = await _repo.UpdateLinkLocation(Guid.Parse(command.Guid), command.Location);

            if (rowsUpdated == 0)
            {
                return new CantUpdateRowCommandResult();
            }

            return new UpdateLinkLocationCommandResult();
        }
        catch (Exception e)
        {
            object parameters = new { command };

            e.Data.Add($"{GetType().Name}::Handler(UpdateLinkLocationCommand)", parameters);

            throw;
        }
    }

    public async Task<ICommandResult> Handler(LinkAnswersCommand command)
    {
        try
        {
            command.Validate();

            if (!command.IsValid)
            {
                return new InvalidCommandResult(new InvalidCommandData(command.Notifications));
            }

            string cpf = await _repo.GetQuestionnaireCpf(Guid.Parse(command.Guid));
            

            int rowsUpdated = await _repo.UpdateQuestionnaireResult(Guid.Parse(command.Guid), command.TicketId,
                "Approved");

            if (rowsUpdated == 0)
            {
                return new CantUpdateRowCommandResult();
            }

            return new LinkAnswersCommandResult();
        }
        catch (Exception e)
        {
            object parameters = new { command };

            e.Data.Add($"{GetType().Name}::Handler(LinkAnswersCommand)", parameters);

            throw;
        }
    }

    public async Task<ICommandResult> Handler(FilterLinksByCpfCommand command)
    {
        try
        {
            command.Validate();

            if (!command.IsValid)
            {
                return new InvalidCommandResult(new InvalidCommandData(command.Notifications));
            }

            List<QuestionnaireLinksTable> links = await _repo.GetLinksByCpf(command.Cpf);

            return new FilterLinksByCpfCommandResult(links);
        }
        catch (Exception e)
        {
            object parameters = new { command };

            e.Data.Add($"{GetType().Name}::Handler(FilterLinksByCpfCommand)", parameters);

            throw;
        }
    }

    public async Task<ICommandResult> Handler(DeleteLinkCommand command)
    {
        try
        {
            command.Validate();

            if (!command.IsValid)
            {
                return new InvalidCommandResult(new InvalidCommandData(command.Notifications));
            }

            int rowsDeleted = await _repo.DeleteLink(Guid.Parse(command.Guid));

            if (rowsDeleted == 0)
            {
                return new CantDeleteRowCommandResult();
            }

            return new DeleteLinkCommandResult();
        }
        catch (Exception e)
        {
            object parameters = new { command };

            e.Data.Add($"{GetType().Name}::Handler(DeleteLinkCommand)", parameters);

            throw;
        }
    }
}