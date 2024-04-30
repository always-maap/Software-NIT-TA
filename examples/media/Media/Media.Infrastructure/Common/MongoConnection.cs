using MongoDB.Driver;
using MongoDB.Driver.GridFS;

namespace Media.Infrastructure.Common;

public class MongoConnection : IMongoConnection
{
    public MongoClient ReadPrefMongoClient { get; }
    public MongoClient WritePrefMongoClient { get; }

    private readonly IMongoDatabase _readPrefDatabase;
    private readonly IMongoDatabase _writePrefDatabase;

    public MongoConnection(MongoConnectionOptions mongoConnectionOptions)
    {
        ReadPrefMongoClient = CreateMongoClient(mongoConnectionOptions);
        _readPrefDatabase = ReadPrefMongoClient.GetDatabase(mongoConnectionOptions.DatabaseName,
            new MongoDatabaseSettings()
            {
                ReadConcern = ReadConcern.Majority,
                ReadPreference = ReadPreference.SecondaryPreferred
            });

        WritePrefMongoClient = CreateMongoClient(mongoConnectionOptions);
        _writePrefDatabase = WritePrefMongoClient.GetDatabase(mongoConnectionOptions.DatabaseName,
            new MongoDatabaseSettings()
            {
                WriteConcern = WriteConcern.WMajority,
                ReadConcern = ReadConcern.Majority,
                ReadPreference = ReadPreference.Primary
            });
    }

    public GridFSBucket CreateReadBucket(GridFSBucketOptions? options)
    {
        return new GridFSBucket(_readPrefDatabase);
    }

    public GridFSBucket CreateWriteBucket(GridFSBucketOptions? options)
    {
        return new GridFSBucket(_writePrefDatabase);
    }

    private static MongoClient CreateMongoClient(MongoConnectionOptions mongoConnectionOptions)
    {
        return new MongoClient(mongoConnectionOptions.ConnectionString);
    }
}