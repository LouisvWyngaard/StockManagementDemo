using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace StockManagementDemo.Models
{
    public static class StockManagementDbContextExtensions
    {
        public static IQueryable<StockItem> getAllStock(this StockManagementDbContext dbContext)
        {
            var query = dbContext.StockItem.AsQueryable();

            return query;
        }

        public static async Task<StockItem> getStockByID(this StockManagementDbContext dbContext, int ID)
            => await dbContext.StockItem.FirstOrDefaultAsync(item => item.ID == ID);

        public static IQueryable<Image> getImageByStockID(this StockManagementDbContext dbContext, int stockID)
            => dbContext.Image.Where(item => item.StockItemID == stockID);

        
    }
}
