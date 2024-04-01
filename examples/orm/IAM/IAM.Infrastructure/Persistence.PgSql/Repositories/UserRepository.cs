using IAM.Application.Common;
using IAM.Domain;

namespace IAM.Infrastructure.Persistence.PgSql.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _dbContext;

    public UserRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Add(User user)
    {
        _dbContext.Add(user);
        _dbContext.SaveChanges();
    }

    public void Update(User user)
    {
        _dbContext.Update(user);
        _dbContext.SaveChanges();
    }

    public User? GetByPhone(string phone)
    {
        return _dbContext.Users.FirstOrDefault(u => u.Phone == phone);
    }
}