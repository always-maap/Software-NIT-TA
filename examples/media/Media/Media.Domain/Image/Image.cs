using Media.Domain.Image.Options;
using Media.Domain.Media;

namespace Media.Domain.Image;

public class Image : MultiMedia
{
    public int Width { get; private set; }
    public int Height { get; private set; }
    public string Alt { get; private set; }
    
    private Image(ImageOptions options) : base(options)
    {
        Width = options.Width;
        Height = options.Height;
        Alt = options.Alt;
    }
    
    public static Image Create(ImageOptions options)
    {
        return new Image(options);
    }
}