using Application.Common.Repositories;
using Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Client.Extensions.Msal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    // This class represents a configuration module for the infrastructure layer which has to
    // be executed to make the infrastructure layer build succesfully, we get the connection string
    // and use it to establish the connection between EF and the database, and inject components into
    // their interfaces,
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(connectionString, b =>
                    b.MigrationsAssembly(typeof(DependencyInjection).Assembly.FullName));
            });

            services.AddScoped<Application.Common.Repositories.IEvaluationPeriodRepository, Persistance.Evaluations.EvaluationPeriodRepository>();
            services.AddScoped<Application.Common.Repositories.IEvaluationRepository, Persistance.Evaluations.EvaluationRepository>();
            services.AddScoped<Application.Common.Repositories.IUserRepository, Persistance.User.UserRepository>();
            services.AddScoped<Application.Common.Repositories.ITeamRepository, Persistance.Team.TeamRepository>();
            services.AddScoped<Application.Common.Repositories.IConcreteEvaluationRepository, Persistance.Evaluations.ConcreteEvaluationRepository>();
            services.AddScoped<Application.Common.Repositories.IFeedbackRepository, Persistance.Feedback.FeedbackRepository>();
            services.AddScoped<Application.Common.Repositories.IMembershipRepository, Persistance.Membership.MembershipRepository>();
            services.AddScoped<Application.Common.Services.IPasswordHasher, Auth.PasswordHasher>();
            services.AddScoped<Application.Common.Services.IJwtService, Auth.JWTService>();
            services.AddScoped<Application.Common.Repositories.IRefreshTokenRepository, Persistance.Auth.RefreshTokenRepository>();

            return services;
        }
    }
}
