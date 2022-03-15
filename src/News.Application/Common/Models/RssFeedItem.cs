using Newtonsoft.Json;
using System.Globalization;

namespace News.Application.Common.Models
{
    public class RssFeedItem
    {
        public string Title { get; set; } = null!;

        public string? Desc { get; set; }

        public string? PubDate => this.PublishDate == default ? null : this.PublishDate.ToString("dd-MM-yyyy HH:mm:ss", CultureInfo.InvariantCulture);

        public string[] Authors { get; set; } = Array.Empty<string>();

        [JsonIgnore]
        public DateTime PublishDate { get; set; }
    }
}
