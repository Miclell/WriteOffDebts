using Microsoft.EntityFrameworkCore;
using WriteOffDebts.Models;

namespace WriteOffDebts.Data
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<DebtorModel> Debtors { get; set; }
    }
}
