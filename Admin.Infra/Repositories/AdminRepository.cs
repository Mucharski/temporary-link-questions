using Admin.Infra.Queries;
using Admin.Shared.Entities.Database;
using Admin.Shared.Entities.Parameters;
using Admin.Shared.Enums;
using Admin.Shared.Repositories;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Admin.Infra.Repositories;

public class AdminRepository : IAdminRepository
{
    private readonly AdminQueries _queries;

    public AdminRepository(AdminQueries queries)
    {
        _queries = queries;
    }

    public async Task<int> CreateQuestionnaireLink(GenerateLinkParams allParams)
    {
        try
        {
            await using SqlConnection conn = new("");

            return (await conn.ExecuteAsync("", new
            {
                allParams.Guid,
                allParams.Cpf,
                allParams.Name,
                allParams.Email,
                allParams.Phone,
                allParams.BirthDate,
                allParams.Operator,
                Status = ELinkStatus.NotAnswered.ToString(),
                allParams.CreatedAt,
                allParams.ExpiresAt
            }));
        }
        catch (Exception ex)
        {
            object parameters = new
            {
                allParams
            };

            ex.Data.Add($"{GetType().Name}::CreateQuestionnaireLink", parameters);

            throw;
        }
    }

    public async Task<string> GetQuestionnaireCpf(Guid guid)
    {
        try
        {
            await using SqlConnection conn = new("");

            return await conn.QuerySingleAsync<string>("", new
            {
                Guid = guid
            });
        }
        catch (Exception ex)
        {
            object parameters = new
            {
                guid
            };

            ex.Data.Add($"{GetType().Name}::GetQuestionnaireCpf", parameters);

            throw;
        }
    }

    public async Task<QuestionnaireLinksTable> GetLinkClientData(Guid guid)
    {
        try
        {
            await using SqlConnection conn = new("");

            return await conn.QuerySingleAsync<QuestionnaireLinksTable>("", new
            {
                Guid = guid
            });
        }
        catch (Exception ex)
        {
            object parameters = new
            {
                guid
            };

            ex.Data.Add($"{GetType().Name}::GetLinkClientData", parameters);

            throw;
        }
    }

    public async Task<QuestionnaireLinksTable> GetLinkDataByGuid(Guid guid)
    {
        try
        {
            await using SqlConnection conn = new("");

            return await conn.QuerySingleAsync<QuestionnaireLinksTable>("", new
            {
                Guid = guid
            });
        }
        catch (Exception ex)
        {
            object parameters = new
            {
                guid
            };

            ex.Data.Add($"{GetType().Name}::GetLinkDataByGuid", parameters);

            throw;
        }
    }

    public async Task<int> UpdateLinkLocation(Guid guid, string location)
    {
        try
        {
            await using SqlConnection conn = new("");

            return await conn.ExecuteAsync("", new
            {
                Guid = guid,
                Location = location,
                UpdatedAt = DateTime.Now
            });
        }
        catch (Exception ex)
        {
            object parameters = new
            {
                guid
            };

            ex.Data.Add($"{GetType().Name}::UpdateLinkLocation", parameters);

            throw;
        }
    }

    public async Task<int> UpdateQuestionnaireResult(Guid guid, string ticketId, string result)
    {
        try
        {
            await using SqlConnection conn = new("");

            return await conn.ExecuteAsync("", new
            {
                Guid = guid,
                TicketId = ticketId,
                Result = result,
                Status = ELinkStatus.Answered.ToString(),
                UpdatedAt = DateTime.Now
            });
        }
        catch (Exception ex)
        {
            object parameters = new
            {
                guid
            };

            ex.Data.Add($"{GetType().Name}::UpdateQuestionnaireResult", parameters);

            throw;
        }
    }

    public async Task<List<QuestionnaireLinksTable>> GetLinksByCpf(string cpf)
    {
        try
        {
            await using SqlConnection conn = new("");

            return (await conn.QueryAsync<QuestionnaireLinksTable>("", new
                    {
                        Cpf = cpf
                    })
                ).ToList();
        }
        catch (Exception ex)
        {
            object parameters = new
            {
                cpf
            };

            ex.Data.Add($"{GetType().Name}::GetLinksByCpf", parameters);

            throw;
        }
    }

    public async Task<int> DeleteLink(Guid guid)
    {
        try
        {
            await using SqlConnection conn = new("");

            return await conn.ExecuteAsync("", new
            {
                Guid = guid
            });
        }
        catch (Exception ex)
        {
            object parameters = new
            {
                guid
            };

            ex.Data.Add($"{GetType().Name}::DeleteLink", parameters);

            throw;
        }
    }
}