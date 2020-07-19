using System.Linq;
using Core.DatabaseModel;
using Microsoft.EntityFrameworkCore;

namespace Core
{
    public static class IncludeExtensions
    {
        public static IQueryable<ApplicationUser> AddDefaultIncludes(this IQueryable<ApplicationUser> queryable)
        {
            return queryable
                .Include(u => u.Barcodes)
                .Include(u => u.Sales)
                .ThenInclude(s => s.UserPaymentBarcode)
                .Include(u => u.Sales)
                .ThenInclude(b => b.Product)
                .Include(u => u.Achievements)
                .ThenInclude(a => a.Achievement)
                .ThenInclude(a => a.AchievementGroup)
                .Include(u => u.UserVotings)
                .ThenInclude(v => v.ProductVoting)
                .ThenInclude(p => p.Product)
                .Include(u => u.TimeEntries);
        }

        public static IQueryable<Product> AddDefaultIncludes(this IQueryable<Product> queryable)
        {
            return AddDefaultIncludes(queryable, false);
        }

        public static IQueryable<Product> AddDefaultIncludes(this IQueryable<Product> queryable,
            bool includeNonPublicData)
        {
            if (includeNonPublicData)
                queryable = queryable
                    .Include(p => p.Prices)
                    .Include(p => p.ProductBarcodes)
                    .Include(p => p.StockChanges);
            return queryable;
        }

        public static IQueryable<Purchase> AddDefaultIncludes(this IQueryable<Purchase> queryable)
        {
            return queryable
                .Include(p => p.Products)
                .ThenInclude(p => p.Product);
        }

        public static IQueryable<ProductVoting> AddDefaultIncludes(this IQueryable<ProductVoting> queryable)
        {
            return queryable
                .Include(v => v.Product)
                .Include(v => v.ApplicationUser);
        }

        public static IQueryable<Achievement> AddDefaultIncludes(this IQueryable<Achievement> queryable)
        {
            return queryable
                .Include(a => a.UserAchievements)
                .ThenInclude(a => a.ApplicationUser)
                .Include(a => a.AchievementGroup);
        }
    }
}