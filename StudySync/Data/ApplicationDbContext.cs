using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StudySync.Models;

namespace StudySync.Data
{

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<TaskItem> Tasks { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Subtask> Subtasks { get; set; }
        public DbSet<Reminder> Reminders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 1) Seed Users
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Name = "Alice", Email = "alice@example.com" },
                new User { Id = 2, Name = "Bob", Email = "bob@example.com" }
            );

            // 2) Seed Categories
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Homework" },
                new Category { Id = 2, Name = "Exams" }
            );

            // 3) Seed Tasks (reference seeded Users, Categories)
            modelBuilder.Entity<TaskItem>().HasData(
                new TaskItem { Id = 1, Title = "Math Assignment", UserId = 1, CategoryId = 1, Description = "Test", Priority= "low" },
                new TaskItem { Id = 2, Title = "Study for Physics", UserId = 2, CategoryId = 2, Description = "Test New", Priority = "high" }
            );

        }

    }

}

