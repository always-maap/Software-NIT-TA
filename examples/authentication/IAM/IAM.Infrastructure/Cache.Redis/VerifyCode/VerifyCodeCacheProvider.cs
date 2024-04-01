using IAM.Application.Common;
using StackExchange.Redis;

namespace IAM.Infrastructure.Cache.Redis.VerifyCode;

public class VerifyCodeCacheProvider : IVerifyCodeCacheProvider
{
    private readonly IDatabase _database;
    
    public VerifyCodeCacheProvider(IDatabase database)
    {
        _database = database;
    }
    
    public async Task SetAsync(string phoneNumber, string verifyCode, TimeSpan expiration)
    {
        var key = VerifyCodeRedisKeys.GetKey(phoneNumber);
        
        await _database.StringSetAsync(key, verifyCode, expiration);
    }

    public async Task<string?> GetAsync(string phoneNumber)
    {
        var key = VerifyCodeRedisKeys.GetKey(phoneNumber);
        
        return await _database.StringGetAsync(key);
    }
}