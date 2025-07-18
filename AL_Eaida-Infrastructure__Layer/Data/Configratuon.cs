using Al_Eaida_Domin.Modules;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore; // Add this if missing
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using AL_Eaida_Infrastructure__Layer.Repositery.TokenRepositery;
using Microsoft.Extensions.Configuration;
using Al_Eaida_Domin.Interface;
using AL_Eaida_Infrastructure__Layer.Repositery;

namespace AL_Eaida_Infrastructure__Layer.Data
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
          
            services.AddScoped<ITokenRepository,TokenRepositery>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}