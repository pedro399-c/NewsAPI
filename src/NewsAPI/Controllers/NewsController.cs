using Microsoft.AspNetCore.Mvc;
using News.Application.Common.Models;
using News.Common.Interfaces;

namespace NewsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly INewsQueries newsQueries;

        public NewsController(INewsQueries newsQueries)
        {
            this.newsQueries = newsQueries;
        }

        [HttpGet]
        public async Task<ActionResult<RssFeed?>> Get([FromQuery] string feed)
        {
            return await this.newsQueries.Get(feed);
        }
    }
}
