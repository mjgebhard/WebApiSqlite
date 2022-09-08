using Microsoft.EntityFrameworkCore;
using WebApiSqlite.Models;

namespace WebApiSqlite.Data
{
    public class WebApiSqliteContext : DbContext
    {
        public WebApiSqliteContext(DbContextOptions<WebApiSqliteContext> options) : base(options) { }

        public DbSet<Developer>? Developers { get; set; }
    }
}
