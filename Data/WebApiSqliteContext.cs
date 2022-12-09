using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using WebApiSqlite.Models;

namespace WebApiSqlite.Data
{
    public class WebApiSqliteContext : DbContext
    {
        public WebApiSqliteContext(DbContextOptions<WebApiSqliteContext> options) : base(options) { }

        public DbSet<Developer>? Developers { get; set; }
        public DbSet<ActionItem>? ActionItems { get; set; }
        public DbSet<Employee>? Employees { get; set; }
        public DbSet<Department>? Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActionItem>()
                .HasOne(d => d.Developer)
                .WithMany(d => d.ActionItems);
        }
    }
}
