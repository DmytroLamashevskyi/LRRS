﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebApp.Models;

namespace WebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {


        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<FileOnFileSystemModel>(entity =>
            {
                entity.ToTable(name: "FileOnFileSystem");
            });
            builder.Entity<FileOnDatabaseModel>(entity =>
            {
                entity.ToTable(name: "FileOnDatabase");
            });
            builder.Entity<Cource>(entity =>
            { 
                entity.HasMany(c => c.Lessons);
                entity.HasMany(c => c.Students);
                entity.HasMany(c => c.Marks);
            });
            builder.Entity<Lesson>();

            builder.Entity<StudentCource>(entity =>
            {
                entity.HasOne(c => c.Cource);
                entity.HasOne(c => c.Student);
            });

            builder.Entity<Grade>(entity =>
            {
                entity.ToTable(name: "Grades");
                entity.HasMany(e => e.Files);
            });

            builder.Entity<ApplicationUser>(entity =>
            {
                entity.HasMany(c => c.Cources); 
            });

            base.OnModelCreating(builder);
            builder.HasDefaultSchema("Identity");
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

        public DbSet<WebApp.Models.Cource> Cource { get; set; }

        public DbSet<WebApp.Models.StudentCource> Students { get; set; }
        public DbSet<WebApp.Models.Lesson> Lessons { get; set; } 
        public DbSet<WebApp.Models.Grade> Grades { get; set; }
        public DbSet<WebApp.Models.FileOnDatabaseModel> FilesOnDb { get; set; }
    }
}
