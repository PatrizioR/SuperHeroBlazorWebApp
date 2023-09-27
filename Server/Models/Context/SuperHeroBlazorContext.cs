using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SuperHeroBlazorWebApp.Shared.Models;

namespace SuperHeroBlazorWebApp.Server.Models.Context
{
    public class SuperHeroBlazorContext : DbContext
    {
        public SuperHeroBlazorContext(IConfiguration configuration)
        {
            Configuration = configuration;
            Database.Migrate();
        }

        public SuperHeroBlazorContext(IConfiguration configuration, DbContextOptions<SuperHeroBlazorContext> options) : base(options)
        {
            Configuration = configuration;
            Database.Migrate();
        }

        public IConfiguration Configuration { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<SuperHero> SuperHeroes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite($"DataSource=../superhero.sqlite;");
            }
        }
    }
}
