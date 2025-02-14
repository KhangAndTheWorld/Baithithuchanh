using Microsoft.EntityFrameworkCore;
using BaiThiThucHanh2025.Models;

namespace BaiThiThucHanh2025.Data
{

    public class TestContext : DbContext
    {
        public TestContext(DbContextOptions<TestContext> options) : base(options)
        {
        }

        public DbSet<BaiThiThucHanh2025.Models.Player> Players { get; set; }

public DbSet<BaiThiThucHanh2025.Models.Asset> Assets { get; set; } = default!;
    }
}