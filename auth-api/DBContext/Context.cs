using Microsoft.EntityFrameworkCore;
using auth_api.Entities;

namespace auth_api.Data
{
    public class DataContext : DbContext
    {
        public DbSet<UserEntity> users { get; set; }

        public DataContext(DbContextOptions<DataContext> options)
            :base(options)
            {

            }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
            => builder.UseNpgsql("Host=postgres;Port=5432;Database=auth;Username=joemama;Password=password123");
    }
}