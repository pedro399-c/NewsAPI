namespace News.Application.Common.Models
{
    public class Image
    {
        public string? Url { get; }

        public Image(Uri? url)
        {
            this.Url = url?.AbsolutePath;
        }
    }
}
