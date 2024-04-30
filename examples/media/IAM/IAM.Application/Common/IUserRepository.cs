using IAM.Domain;

namespace IAM.Application.Common;

public interface IUserRepository
{
    Task Add(User user);
    Task Update(User user);
    Task<User?> GetByPhone(string phone);
}