namespace News.Application.Common.Models
{
    public class RssFeed
    {
        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public int AuthorsToday => this.Entries.Count(item => item.PublishDate.ToUniversalTime().Date == DateTime.UtcNow.Date);

        public Image Image { get; set; } = null!;

        public RssFeedItem[] Entries { get; set; } = Array.Empty<RssFeedItem>();
    }
}
