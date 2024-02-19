using Microsoft.EntityFrameworkCore;
using AmuraTest.Models;

namespace AmuraTest.Data
{
    public class BackContext: DbContext
    {
        public BackContext(DbContextOptions<BackContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
    }
}
