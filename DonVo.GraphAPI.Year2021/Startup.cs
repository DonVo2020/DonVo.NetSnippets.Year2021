using DonVo.GraphAPI.Year2021.GraphqlCore;
using DonVo.GraphAPI.Year2021.Repositories;
using DonVo.GraphAPI.Year2021.Repositories.Interfaces;
using EfLinqQuerySnippets._03.AdvancedQuerying.Data;
using GraphQL;
using GraphQL.NewtonsoftJson;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace DonVo.GraphAPI.Year2021
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

            services.AddDbContext<BookShopContext>
                 (options => options.UseSqlServer(Configuration.GetConnectionString("GraphQLDBConnection")));
            services.AddTransient<IAuthorRepository, AuthorRepository>();

            //GraphQL
            services
              .AddScoped<AuthorSchema>()
              .AddSingleton<IDocumentExecuter, DocumentExecuter>()
              .AddSingleton<IDocumentWriter, DocumentWriter>();
            // Add all GraphQL types (ObjectGraphType, InputObjectGraphType, ObjectGraphType<X>).
            services
              .AddGraphQL(options =>
              {
                  options.EnableMetrics = false; // True: Metrics appears in the response
              })
              .AddNewtonsoftJson()
              .AddGraphTypes(ServiceLifetime.Scoped);


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DonVo.GraphAPI.Year2021", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            // --> GraphQL
            app.UseGraphQL<AuthorSchema>(); // Default path: /graphql
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions()); // http://localhost:5000/ui/playground


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DonVo.GraphAPI.Year2021 v1"));
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
