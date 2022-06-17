using LRRS.Data.Model.CoreModel;
using LRRS.Data.Model.Entity;
using LRRS.Data.Model.Entity.File;
using LRRS.Data.Model.Entity.Identity;
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
            builder.HasDefaultSchema("Lrr");

            builder.Entity<UserMark>(); 
            builder.Entity<Language>(entity =>
            {
                entity.HasMany(c => c.StringResources);
                entity.ToTable(name: "Languages");
            });
            builder.Entity<StringResource>();

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
                entity.HasMany(c => c.Students); 
                entity.ToTable(name: "Cources");
            });
            builder.Entity<Lesson>(entity =>
            {
                entity.HasMany(c => c.Files);
                entity.HasMany(c => c.Marks);
                entity.HasMany(c => c.Quizzes); 
                entity.HasOne(c=>c.Cource)
                .WithMany(ta => ta.Lessons)
                .HasForeignKey(u => u.CourceId)
                .OnDelete(DeleteBehavior.Restrict);

                entity.ToTable(name: "Lessons");
            });

            builder.Entity<Quiz>(entity =>
            {
                entity.HasMany(c => c.Questions); 
                entity.ToTable(name: "Quizzes");
            });
            builder.Entity<Question>(entity =>
            { 
                entity.HasMany(c => c.QuestionOptions);
                entity.HasKey(c => c.Id);
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
                entity.ToTable(name: "User");
            }); 
             
            builder.Entity<IdentityRole>(entity =>
            {
                entity.ToTable(name: "Role");
            });
            builder.Entity<ApplicationUserRole>(entity =>
            {
                entity.ToTable("UserRoles");
                entity.HasNoKey();
            });
            builder.Entity<ApplicationUserClaim>(entity =>
            {
                entity.ToTable("UserClaims");
            });
            builder.Entity<ApplicationUserLogin>(entity =>
            {
                entity.ToTable("UserLogins");
                entity.HasNoKey();
            });

            builder.Entity<ApplicationRoleClaim>(entity =>
            {
                entity.ToTable("RoleClaims");
            });
            builder.Entity<ApplicationUserToken>(entity =>
            {
                entity.ToTable("UserTokens");
                entity.HasNoKey();
            });


            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

        }

        public DbSet<Cource> Cources { get; set; }
        public DbSet<StudentCource> Students { get; set; }
        public DbSet<Lesson> Lessons { get; set; } 
        public DbSet<Grade> Grades { get; set; }
        public DbSet<FileOnDatabaseModel> FilesOnDB { get; set; }
        public DbSet<FileOnFileSystemModel> FilesOnServer { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<StringResource> StringResources { get; set; }
        public DbSet<ApplicationUserDevice> ApplicationUserDevices { get; set; }
    }
}
