using GTR_WebApiTask.Model;
using Microsoft.EntityFrameworkCore;

namespace GTR_WebApiTask.DB
{
    public class taskContext: DbContext 
    {
        public taskContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
                .HasOne(e => e.Categories)
                .WithMany()
                .HasForeignKey(e => e.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);
        }


    }
}
