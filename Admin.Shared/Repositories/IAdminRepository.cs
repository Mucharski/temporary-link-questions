using Admin.Shared.Entities.Database;
using Admin.Shared.Entities.Parameters;

namespace Admin.Shared.Repositories;

public interface IAdminRepository
{
    public Task<int> CreateQuestionnaireLink(GenerateLinkParams parameters);
    public Task<string> GetQuestionnaireCpf(Guid guid);
    public Task<QuestionnaireLinksTable> GetLinkClientData(Guid guid);
    public Task<QuestionnaireLinksTable> GetLinkDataByGuid(Guid guid);
    public Task<int> UpdateLinkLocation(Guid guid, string location);
    public Task<int> UpdateQuestionnaireResult(Guid guid, string ticketId, string result);
    public Task<List<QuestionnaireLinksTable>> GetLinksByCpf(string cpf);
    public Task<int> DeleteLink(Guid guid);
}