using News.Application.Common.Models;

namespace News.Common.Interfaces
{
    public interface INewsQueries
    {
        Task<RssFeed?> Get(string feedUrl);
    }
}
