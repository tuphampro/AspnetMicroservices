using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IdentityModel.Tokens.Jwt;

namespace WebHost.Customization
{
    public static class ServiceCollectionExtensions
    {
        public static void AddCustomCors(this IServiceProvider services)
        {
            //services.AddCors(options =>
            //{
            //    options.AddPolicy("CorsPolicy",
            //        builder => builder
            //        .SetIsOriginAllowed((host) => true)
            //        .AllowAnyMethod()
            //        .AllowAnyHeader()
            //        .AllowCredentials());
            //});
        }

        //public static IServiceCollection AddCustomAuthentication(this IServiceCollection services, IConfiguration configuration)
        //{
        //    JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Remove("sub");

        //    var identityUrl = configuration["IdentityUrl"];

        //    services.AddAuthentication(options =>
        //    {
        //        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        //        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

        //    })
        //    .AddJwtBearer(options =>
        //    {
        //        options.Authority = identityUrl;
        //        options.RequireHttpsMetadata = false;
        //        options.Audience = "apigateway";
        //    });

        //    return services;
        //}
    }
}
