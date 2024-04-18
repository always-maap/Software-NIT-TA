using IAM.Application.Common;
using IAM.Domain;

namespace IAM.Infrastructure.Persistence_InMemory;

public class UserRepositoryInMemory : IUserRepository
{
    private static readonly List<User> _users = new();

    public async Task Add(User user)
    {
        await Task.CompletedTask;
        _users.Add(user);
    }

    public async Task Update(User user)
    {
        await Task.CompletedTask;
        var index = _users.FindIndex(x => x.Id == user.Id);
        if (index != -1)
        {
            _users[index] = user;
        }
    }

    public async Task<User?> GetByPhone(string phone)
    {
        await Task.CompletedTask;
        return _users.SingleOrDefault(x => x.Phone == phone);
    }
}