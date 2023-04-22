using Microsoft.EntityFrameworkCore;

namespace L01P02_2020_HH_601_2020_BM_602.Models
{
    public class equiposDbContext : DbContext
    {
        public equiposDbContext(DbContextOptions options) : base(options) 
        {

        }
        public DbSet<platos> platos { get; set; }
        public DbSet<pedidos> pedidos { get; set; }

        public DbSet<motoristas> motoristas { get; set; }

        public DbSet<clientes> clientes{ get; set; }

    }
}
