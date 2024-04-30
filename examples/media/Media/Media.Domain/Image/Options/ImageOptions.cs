using Media.Domain.Media.Options;

namespace Media.Domain.Image.Options;

public class ImageOptions : MultiMediaOptions
{
    public int Width { get; set; }
    public int Height { get; set; }
    public string Alt { get; set; }
}