using Microsoft.EntityFrameworkCore;
using AdvanceCSharp.database.Model;

namespace AdvanceCSharp.database
{
    public class AppDbContext: DbContext
    {
        public DbSet<Users> Users { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Carts> Carts { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            _ = optionsBuilder.UseSqlServer("Data Source=sql.bsite.net\\MSSQL2016;Initial Catalog=tuanph108_;User ID=tuanph108_;Password=Tuan01082002;Trust Server Certificate=True");
        }
    }
}
