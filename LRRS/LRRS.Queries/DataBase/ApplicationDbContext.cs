using LRRS.Data.Model.CoreModel;
using LRRS.Data.Model.Entity;
using LRRS.Data.Model.Entity.File;
using LRRS.Data.Model.Entity.Quiz;
using LRRS.Data.Model.Entity.Quiz;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore; 

namespace LRRS.Queries.DataBase
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {


        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.HasDefaultSchema("Identity");

            builder.Entity<UserMark>(entity =>
            {
                entity.ToTable(name: "TestMarks");
            });

            builder.Entity<Language>(entity =>
            {
                entity.ToTable(name: "Languages");
                entity.OwnsMany(c=>c.StringResources);
            });

            builder.Entity<StringResource>(entity =>
            {
                entity.ToTable(name: "StringResources");
            });

            builder.Entity<FileOnFileSystemModel>(entity =>
            {
                entity.HasOne(c => c.Owner);
                entity.ToTable(name: "FileOnFileSystem");
            });
            builder.Entity<FileOnDatabaseModel>(entity =>
            {
                entity.HasOne(c => c.Owner);
                entity.ToTable(name: "FileOnDatabase");
            });
            builder.Entity<Cource>(entity =>
            {
                entity.HasMany(c => c.Lessons);
                entity.HasMany(c => c.Students);
                entity.ToTable(name: "Cources");
            });
            builder.Entity<Lesson>(entity =>
            {
                entity.HasMany(c => c.Files);
                entity.HasMany(c => c.Marks);
                entity.HasMany(c => c.Quizzes);
                entity.ToTable(name: "Lessons");
            });

            builder.Entity<Quiz>(entity =>
            {
                entity.HasMany(c => c.Questions); 
                entity.ToTable(name: "Questions");
            });
            builder.Entity<Question>(entity =>
            {
                entity.HasMany(c => c.QuestionOptions);
                entity.ToTable(name: "Questions");
            });

            builder.Entity<StudentCource>(entity =>
            {
                entity.HasOne(c => c.Cource);
                entity.HasOne(c => c.Student);
            });

            builder.Entity<Grade>(entity =>
            {
                entity.ToTable(name: "Grades");
            });

            builder.Entity<ApplicationUser>(entity =>
            {
                entity.HasMany(c => c.Grades);
                entity.HasMany(c => c.Files);
                entity.HasMany(c => c.Cources);
            }); 

            builder.Entity<IdentityUser>(entity =>
            {
                entity.ToTable(name: "User");
            });
            builder.Entity<IdentityRole>(entity =>
            {
                entity.ToTable(name: "Role");
            });
            builder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.ToTable("UserRoles");
            });
            builder.Entity<IdentityUserClaim<string>>(entity =>
            {
                entity.ToTable("UserClaims");
            });
            builder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.ToTable("UserLogins");
            });

            builder.Entity<IdentityRoleClaim<string>>(entity =>
            {
                entity.ToTable("RoleClaims");
            });
            builder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.ToTable("UserTokens");
            });

        }

        public DbSet<Cource> Cource { get; set; }
        public DbSet<StudentCource> Students { get; set; }
        public DbSet<Lesson> Lessons { get; set; } 
        public DbSet<Grade> Grades { get; set; }
        public DbSet<FileOnDatabaseModel> FilesOnDB { get; set; }
        public DbSet<FileOnFileSystemModel> FilesOnServer { get; set; }
        public DbSet<Quiz> Quizs { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<StringResource> StringResources { get; set; }
    }
}
