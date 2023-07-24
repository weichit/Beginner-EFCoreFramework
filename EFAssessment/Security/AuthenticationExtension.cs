using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace EFAssessment.Security;
public static class AunthenticationExtension
{
    public static IServiceCollection AddAppointmentAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        // Add authentication service in program.cs
        JwtOptions jwtConfig = configuration.GetSection(JwtOptions.SectionName).Get<JwtOptions>()!;
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtConfig.Issuer,
                    ValidAudience = jwtConfig.Issuer,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig.Secret)),
                    ClockSkew = TimeSpan.Zero
                };
            }
            );
        return services;
    }

}