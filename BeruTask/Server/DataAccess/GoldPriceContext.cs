using BeruTask.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace BeruTask.Server.DataAccess
{
    public class GoldPriceContext : DbContext
    {
        public GoldPriceContext(DbContextOptions options)
          : base(options)
        {
        }

        public DbSet<GoldPriceModel> GoldPrice { get; set; }
    }
}
