using News.Application.Common.Models;
using News.Common.Interfaces;
using System.ServiceModel.Syndication;
using System.Xml.Linq;

namespace News.Application.News.Queries
{
    internal class NewsQueries : INewsQueries
    {
        private readonly IHttpClientFactory clientFactory;

        public NewsQueries(IHttpClientFactory clientFactory)
        {
            this.clientFactory = clientFactory;
        }

        public async Task<RssFeed?> Get(string feedUrl)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, feedUrl);
            var client = clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var data = await response.Content.ReadAsStringAsync();

                var newsFeed = SyndicationFeed.Load(XDocument.Parse(data).CreateReader());

                return new RssFeed
                {
                    Title = newsFeed.Title.Text,
                    Description = newsFeed.Description.Text,
                    Image = new Image(newsFeed.ImageUrl),
                    Entries = newsFeed.Items
                        .Select(item => new RssFeedItem
                        {
                            Title = item.Title.Text,
                            Desc = item.Summary?.Text,
                            PublishDate = item.PublishDate.DateTime,
                            Authors = item.Authors
                                .Select(author => author.Name)
                                .ToArray()
                        })
                        .ToArray()
                };
            }

            return null;
        }
    }
}
