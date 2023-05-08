using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Prueba1.Models.DataModels;

namespace Prueba1
{
    public static class AddJwtTokenServicesExtension
    {

        public static void AddJwtTokenServices(this IServiceCollection service, IConfiguration configuration)
        {

            var bindJwtSettings = new JwtSettings();
            configuration.Bind("JsonWebTokenKeys", bindJwtSettings);

            service.AddSingleton(bindJwtSettings);

            service.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = bindJwtSettings.ValidateIssuerSignigKey,
                    IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(bindJwtSettings.IssuerSigningKey)),
                    ValidateIssuer = bindJwtSettings.ValidateIusser,
                    ValidIssuer = bindJwtSettings.ValidIuuser,
                    ValidateAudience = bindJwtSettings.ValidateAudience,
                    ValidAudience = bindJwtSettings.ValidAudience,
                    RequireExpirationTime = bindJwtSettings.ValidateLifeTime,
                    ClockSkew = TimeSpan.FromDays(1)

                };
            });


        }

    }
}
