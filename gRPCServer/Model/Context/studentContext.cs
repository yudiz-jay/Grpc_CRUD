
using Microsoft.EntityFrameworkCore;
using gRPCServer.Model.Entity;

namespace gRPCServer.Model.Context
{
    public class studentContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public studentContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"));
        }
        public DbSet<studentEntity> Students { get; set; }

    }

}

