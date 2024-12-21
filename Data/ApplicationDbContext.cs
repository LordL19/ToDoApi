using Microsoft.EntityFrameworkCore;
using TaskEntity =ToDoApi.Models.Domain.Task;

namespace ToDoApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<TaskEntity> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TaskEntity>(entity =>
            {
                entity.HasKey(t => t.TaskId);

                entity.Property(t => t.TaskId)
                    .HasDefaultValueSql("NEWID()");
            });
        }
    }
}
