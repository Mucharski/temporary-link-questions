using Admin.Infra.Queries;
using Admin.Shared.Repositories;

namespace Admin.Infra.Repositories;

public class AdminRepository : IAdminRepository
{
    private readonly AdminQueries _queries;
}