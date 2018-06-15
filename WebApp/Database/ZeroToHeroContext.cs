using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WebApp.Models;

namespace WebApp.Database
{
    public class ZeroToHeroContext : DbContext
    {
        public ZeroToHeroContext(DbContextOptions<ZeroToHeroContext> options) : base(options)
        {
        }
        public DbSet<Filme> Filmes { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Filme>().HasKey(m => m.Id);
            base.OnModelCreating(builder);
        }
    }
}