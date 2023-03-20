
using Microsoft.EntityFrameworkCore;
using Watermarker.Models;

namespace Watermarker.Data
{
    public class WatermarkerDbContext : DbContext
    {
        public WatermarkerDbContext(DbContextOptions options) : base(options)
        { }
        public DbSet<User> Users { get; set; }
    }

}

