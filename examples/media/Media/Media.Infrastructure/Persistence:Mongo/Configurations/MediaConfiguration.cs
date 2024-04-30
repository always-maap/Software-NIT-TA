using Media.Domain.Image;
using MongoDB.Bson.Serialization;

namespace Media.Infrastructure.Persistence_Mongo.Configurations;

public class MediaConfiguration
{
    public void Configure()
    {
        BsonClassMap.RegisterClassMap<Domain.Media.MultiMedia>(cm =>
        {
            cm.SetIsRootClass(true);
            cm.AutoMap();
        });
            
        BsonClassMap.RegisterClassMap<Image>();
    }
}