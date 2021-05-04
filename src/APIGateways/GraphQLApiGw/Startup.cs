using GraphQL;
using GraphQL.Samples.Schemas.Chat;
using GraphQL.Samples.Server;
using GraphQL.Server;
using GraphQL.Server.Transports.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLApiGw
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public IConfiguration Configuration { get; }

        public IWebHostEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services
             .AddSingleton<IChat, Chat>()
             .AddSingleton<IDocumentExecuter, SubscriptionDocumentExecuter>()

             .AddSingleton<ChatSchema>()
             .AddGraphQL((options, provider) =>
             {
                 options.EnableMetrics = Environment.IsDevelopment();
                 var logger = provider.GetRequiredService<ILogger<Startup>>();
                 options.UnhandledExceptionDelegate = ctx => logger.LogError("{Error} occurred", ctx.OriginalException.Message);
             })
             .AddSystemTextJson(deserializerSettings => { }, serializerSettings => { })
             //.AddErrorInfoProvider<CustomErrorInfoProvider>(opt => opt.ExposeExceptionStackTrace = Environment.IsDevelopment())
             .AddWebSockets()
             .AddDataLoader()
             .AddGraphTypes(typeof(ChatSchema));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (Environment.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseWebSockets();

            app.UseGraphQLWebSockets<ChatSchema>();
            app.UseGraphQL<ChatSchema>();
            app.UseGraphQLAltair();

        }
    }
}
