using Admin.Shared.Commands.Input;

namespace Admin.Shared.Entities.Parameters;

public class GenerateLinkParams
{
    public GenerateLinkParams(GenerateLinkCommand command)
    {
        Guid = Guid.NewGuid();
        Cpf = command.Cpf;
        Name = command.Name;
        Email = command.Email;
        BirthDate = command.BirthDate;
        Phone = command.Phone;
        Operator = command.Operator;
        CreatedAt = DateTime.Now;
        ExpiresAt = DateTime.Now.AddHours(3);
    }
    
    public Guid Guid { get; }
    public string Cpf { get; }
    public string Name { get; }
    public string Email { get; }
    public DateTime BirthDate { get; }
    public string Phone { get; }
    public string Operator { get; }
    public DateTime CreatedAt { get; }
    public DateTime ExpiresAt { get; }
}