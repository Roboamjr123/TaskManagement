using Microsoft.EntityFrameworkCore;
using TaskManagement.Models;

namespace TaskManagement.Database
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) :base(options) 
        {

        }
        
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<Project> Projects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the Project entity
            modelBuilder.Entity<Project>(entity =>
            {
                // Define the primary key
                entity.HasKey(p => p.Project_Id);

                // Configure Project_Name property as required
                entity.Property(p => p.Project_Name)
                    .IsRequired();

                // Configure the one-to-many relationship with Tasks
                entity.HasMany(p => p.Tasks)
                    .WithOne(t => t.Project)            // Each Task belongs to one Project
                    .HasForeignKey(t => t.Project_Id)  // Foreign key in Task entity
                    .IsRequired();                     // Required relationship
            });

            // Configure the Tasks entity
            modelBuilder.Entity<Tasks>(entity =>
            {
                // Define the primary key
                entity.HasKey(t => t.Tasks_Id);

                // Configure Task_Name property as required
                entity.Property(t => t.Task_Name)
                    .IsRequired();

                // Configure the many-to-one relationship with Project
                entity.HasOne(t => t.Project)
                    .WithMany(p => p.Tasks)            // Each Project has many Tasks
                    .HasForeignKey(t => t.Project_Id)  // Foreign key in Tasks entity
                    .IsRequired();                     // Required relationship

                // Configure the one-to-many relationship with Activities
                entity.HasMany(t => t.Activities)
                    .WithOne(a => a.Tasks)             // Each Activity belongs to one Task
                    .HasForeignKey(a => a.Tasks_Id)   // Foreign key in Activity entity
                    .IsRequired();                     // Required relationship
            });

            // Configure the Activity entity
            modelBuilder.Entity<Activity>(entity =>
            {
                // Define the primary key
                entity.HasKey(a => a.Act_Id);

                // Configure Act_Name property as required
                entity.Property(a => a.Act_Name)
                    .IsRequired();

                // Configure the many-to-one relationship with Tasks
                entity.HasOne(a => a.Tasks)
                    .WithMany(t => t.Activities)       // Each Task has many Activities
                    .HasForeignKey(a => a.Tasks_Id)   // Foreign key in Activity entity
                    .IsRequired(false);                     // Required relationship
            });

            base.OnModelCreating(modelBuilder);
        }

    }
}
