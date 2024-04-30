using Media.Domain.Media.Options;

namespace Media.Domain.Media;

public class MultiMedia
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string MimeType { get; set; }

    protected MultiMedia(MultiMediaOptions options)
    {
        Id = Guid.NewGuid();
        Name = options.Name;
        MimeType = options.MimeType;
    }
    
    public static MultiMedia Create(MultiMediaOptions options)
    {
        return new MultiMedia(options);
    }
}