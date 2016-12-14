using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace TaskManager.Models
{
    public class TaskManagerContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Task> Tasks { get; set; }

        static TaskManagerContext()
        {
            Database.SetInitializer(new TasksManagerDbInitializer());
        }

        public TaskManagerContext()
            : base("name=TaskManagerDB")
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Task>()
            .HasMany(i => i.Authors)
            .WithMany(u => u.Tasks)
            .Map(m =>
            {
                 m.ToTable("TaskAuthor");
                 m.MapLeftKey("TaskId");
                 m.MapRightKey("AuthorId");
            });

        }
    }

    public class TasksManagerDbInitializer : DropCreateDatabaseIfModelChanges<TaskManagerContext>
    {
        protected override void Seed(TaskManagerContext db)
        {
            db.Authors.Add(new Author {Name = "Director"});
            db.Authors.Add(new Author {Name = "Head of Sales"});
            db.Authors.Add(new Author {Name = "Manager"});
            db.Authors.Add(new Author {Name = "The tea drinker"});
            db.Tasks.Add(new Task { Name = "Buy the pizza", Description = "asdfasdfadsf", CreateDate = DateTime.Now});
            db.Tasks.Add(new Task { Name = "Buy the phone", Description = "asdfasdfadsf", CreateDate = DateTime.Now });
            db.Tasks.Add(new Task { Name = "Buy the pistol", Description = "asdfasdfadsf", CreateDate = DateTime.Now });
            db.Tasks.Add(new Task { Name = "Buy the socks", Description = "asdfasdfadsf", CreateDate = DateTime.Now });
            db.SaveChanges();
        }
    }


}
