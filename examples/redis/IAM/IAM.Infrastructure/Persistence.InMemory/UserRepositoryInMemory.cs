using IAM.Application.Common;
using IAM.Domain;

namespace IAM.Infrastructure.Persistence.InMemory;

public class UserRepositoryInMemory : IUserRepository
{
    private static readonly List<User> _users = new();

    public void Add(User user)
    {
        _users.Add(user);
    }

    public void Update(User user)
    {
        var index = _users.FindIndex(x => x.Id == user.Id);
        if (index != -1)
        {
            _users[index] = user;
        }
    }

    public User? GetByPhone(string phone)
    {
        return _users.SingleOrDefault(x => x.Phone == phone);
    }
}