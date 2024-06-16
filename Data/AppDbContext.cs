using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using WriteOffDebts.Models;

namespace WriteOffDebts.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<DebtorModel> Debtors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserModel>()
                .HasMany(u => u.Debtors)
                .WithOne(d => d.User)
                .HasForeignKey(d => d.UserId);
        }
    }
}
