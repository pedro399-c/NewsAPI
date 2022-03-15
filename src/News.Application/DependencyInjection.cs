using Microsoft.Extensions.DependencyInjection;
using News.Application.News.Queries;
using News.Common.Interfaces;

namespace News.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddSingleton<INewsQueries, NewsQueries>();
            return services;
        }
    }
}
