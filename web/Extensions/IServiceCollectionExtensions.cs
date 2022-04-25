using System;
using Curate.Data;
using Curate.Data.Models;
using Curate.Data.Repositories;
using Curate.Data.Repositories.Interfaces;
using Curate.Data.Services;
using Curate.Data.Services.Interfaces;
using Curate.Data.ViewModels.Identity;
using Curate.Web.Identity;
using Curate.Web.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Curate.Web.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            // Configure DbContext with Scoped lifetime
            services.AddDbContext<curatedbContext>(options =>
                {
                    options.UseSqlServer(configuration.GetConnectionString("CurateDbConnection"));
                }
            );
            services.AddScoped<Func<curatedbContext>>((provider) => () => provider.GetService<curatedbContext>());
            services.AddScoped<DbFactory>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services
                .AddScoped(typeof(IRepository<>), typeof(Repository<>))
                .AddScoped<IRssFeedRepository, RssFeedRepository>()
                .AddScoped<IRssFeedArticleRepository, RssFeedArticleRepository>()
                .AddScoped<IRssFeedErrorRepository, RssFeedErrorRepository>()
                .AddScoped< IRssFeedCategoryRepository, RssFeedCategoryRepository>()
                .AddScoped<IPostRepository, PostRepository>()
                .AddScoped<IVideoRepository, VideoRepository>()
                .AddScoped<IVideoChannelRepository, VideoChannelRepository>()
                .AddScoped<ITagRepository, TagRepository>()
                .AddScoped<IVideoPlaylistRepository,VideoPlaylistRepository>();
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            return services
            .AddScoped<ISearchService, SearchService>()
            .AddScoped<INyamboService, NyamboService>()
            .AddScoped<ITagService, TagService>()
            .AddScoped<IVideoService, VideoService>()
            .AddScoped<IYoutubeApiService, YoutubeApiService>()
            .AddScoped<IRssFeedAdminService, RssFeedAdminService>()
            .AddScoped<IUserClaimsPrincipalFactory<ApplicationUser>, AppClaimsPrincipalFactory>()
            .AddScoped<SignInManager<ApplicationUser>, AuditableSignInManager<ApplicationUser>>()
            .AddTransient<IEmailSender, AuthMessageSender>()
            .AddTransient<ISmsSender, AuthMessageSender>();
        }
    }
}
