using MongoDB.Driver;
using MongoDB.Driver.GridFS;

namespace Media.Infrastructure.Common;

public interface IMongoConnection
{
    MongoClient ReadPrefMongoClient { get; }
    MongoClient WritePrefMongoClient { get; }
    
    GridFSBucket CreateReadBucket(GridFSBucketOptions? options);
    GridFSBucket CreateWriteBucket(GridFSBucketOptions? options);
}