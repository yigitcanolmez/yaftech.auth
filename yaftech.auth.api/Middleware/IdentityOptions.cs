using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using yaftech.auth.data.Database;
using yaftech.auth.model;

namespace yaftech.auth.api.Middleware
{
    public static class IdentityOptions
    {
        public static IServiceCollection AddIdentityOptions(this IServiceCollection services, IConfigurationSection configuration)
        {
            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<AuthDbContext>()
                .AddDefaultTokenProviders();
            // Adding Authentication  
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })

                        // Adding Jwt Bearer  
                        .AddJwtBearer(options =>
                        {
                            options.SaveToken = true;
                            options.RequireHttpsMetadata = false;
                            options.TokenValidationParameters = new TokenValidationParameters()
                            {
                                ValidateIssuer = true,
                                ValidateAudience = true,
                                ValidAudience = configuration["ValidAudience"],
                                ValidIssuer = configuration["ValidIssuer"],
                                ClockSkew = TimeSpan.Zero,
                                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Secret"]))
                            };
                        });

            return services;


        }
    }
}
