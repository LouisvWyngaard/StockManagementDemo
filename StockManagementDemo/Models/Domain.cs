using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StockManagementDemo.Models
{
    public partial class StockItem
    {
        public int? ID { get; set; }

        public string RegNo { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public string ModelYear { get; set; }

        public decimal KMS { get; set; }

        public string Colour { get; set; }

        public string VIN { get; set; }

        public decimal RetailPrice { get; set; }

        public decimal CostPrice { get; set; }

        public int Accessories { get; set; }

        public int Images { get; set; }

        public DateTime DTCreated { get; set; }

        public DateTime DTUpdated { get; set; }

    }

    public partial class fullStockItem
    {
        public int? ID { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public List<Image> image { get; set; }
    }


    public partial class StockAccessory
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }

    public partial class Image
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string ImageBinary { get; set; }

        public int StockItemID { get; set; }
    }

    public class StockManagementDbContext : DbContext
    {
        public StockManagementDbContext(DbContextOptions<StockManagementDbContext> options)
            : base(options)
        {
        }

        public DbSet<StockItem> StockItem { get; set; }

        public DbSet<StockAccessory> StockAccessory { get; set; }

        public DbSet<Image> Image { get; set; }
        
    }
}
