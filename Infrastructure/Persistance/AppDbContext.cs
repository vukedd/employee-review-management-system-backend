using Domain.Models.Evaluations;
using Domain.Models.Evaluations.EvaluationComponents;
using Domain.Models.Feedbacks;
using Domain.Models.Memberships;
using Domain.Models.Users;
using Infrastructure.Configurations.Users;
using Infrastructure.Configurations.Evaluations;
using Infrastructure.Configurations.Evaluations.EvaluationComponents;
using Infrastructure.Configurations.Feedbacks;
using Infrastructure.Configurations.Memberships;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<ConcreteEvaluation> ConcreteEvaluations { get; set; }
        public DbSet<Evaluation> Evaluations { get; set; }
        public DbSet<EvaluationPeriod> EvaluationsPeriods { get; set; }
        public DbSet<Domain.Models.Feedbacks.Feedback> Feedbacks { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Response> Responses { get; set; }
        public DbSet<Domain.Models.Users.User> Users { get; set; }
        public DbSet<Domain.Models.Memberships.Team> Teams { get; set; }
        public DbSet<Domain.Models.Memberships.Membership> Memberships { get; set; }
        public DbSet<EvaluationPeriodEvaluation> EvaluationPeriodEvaluations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new TeamConfiguration());
            modelBuilder.ApplyConfiguration(new MembershipConfiguration());
            modelBuilder.ApplyConfiguration(new EvaluationConfiguration());
            modelBuilder.ApplyConfiguration(new EvaluationPeriodConfiguration());
            modelBuilder.ApplyConfiguration(new EvaluationPeriodEvaluationConfiguration());
            modelBuilder.ApplyConfiguration(new ConcreteEvaluationConfiguration());
            modelBuilder.ApplyConfiguration(new QuestionConfiguration());
            modelBuilder.ApplyConfiguration(new ResponseConfiguration());
            modelBuilder.ApplyConfiguration(new FeedbackConfiguration());
        }
    }
}