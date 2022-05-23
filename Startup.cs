using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using JsonApiDotNetCore.Extensions;
using JsonApiDotNetCore.Data;
using GettingStarted.Models;

namespace GettingStarted
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<SampleDbContext>(options =>
            {
                options.UseSqlite("Data Source=sample.db");
            });

            var mvcCoreBuilder = services.AddMvcCore();
            services.AddJsonApi(
                options => options.Namespace = "api", 
                mvcCoreBuilder, 
                discover => discover.AddCurrentAssembly());
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, SampleDbContext context)
        {
            context.Database.EnsureDeleted(); // indicies need to be reset
            context.Database.EnsureCreated();
            CreateSampleData(context);

            app.UseJsonApi();
        }
        private static void CreateSampleData(SampleDbContext context)
        {
            // Note: The generate-examples.ps1 script (to create example requests in documentation) depends on these.

            context.Articles.AddRange(new Article
            {
                Title = "Frankenstein",
                Author = new Person
                {
                    Name = "Mary Shelley"
                }
            }, new Article
            {
                Title = "Robinson Crusoe",
                Author = new Person
                {
                    Name = "Daniel Defoe"
                }
            }, new Article
            {
                Title = "Gulliver's Travels",
                Author = new Person
                {
                    Name = "Jonathan Swift"
                }
            });

            context.SaveChanges();
        }
    }
}
