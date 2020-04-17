using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CollectionBookAPI.Application.Services;
using CollectionBookAPI.Core.Settings;
using CollectionBookAPI.Infrastructure.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace CollectionBookAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.Configure<BookmarkDatabaseSettings>(
                Configuration.GetSection(nameof(BookmarkDatabaseSettings)));

            services.AddSingleton<IBookmarkDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<BookmarkDatabaseSettings>>().Value);

            services.AddTransient<IBookmarkService, BookmarkService>();
            services.AddTransient<IBookmarkRepository, BookmarkRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
