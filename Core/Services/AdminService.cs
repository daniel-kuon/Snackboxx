using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DatabaseModel;
using Microsoft.EntityFrameworkCore;

namespace Core.Services
{
    public class AdminService
    {
        private DataContext _context;

        public AdminService(DataContext context)
        {
            _context = context;
        }

        public async Task<decimal> GetOpenAmount()
        {
            return await _context.Sales.SumAsync(s => s.Amount) - await _context.Payments.SumAsync(p => p.Amount);
        }

//        public async Task<List<SaleOverview>> GetMonthlySalesOverview()
//        {
//            var saleOverview = await _context.Sales
//                .GroupBy(s => new {s.CreatedAt.Year, s.CreatedAt.Month})
//                .Select(g => new
//                {
//                    g.Key, 
//                    Sum = g.Sum(s =>(double) s.Amount),
//                    Count = g.Count()
//                })
//                .ToListAsync();
//            var paymentOverview = await _context.Sales
//                .GroupBy(s =>  new {s.CreatedAt.Year, s.CreatedAt.Month})
//                .Select(g => new
//                {
//                    g.Key, 
//                    Sum = g.Sum(s => (double)s.Amount),
//                    Count = g.Count()
//                })
//                .ToListAsync();
//            return saleOverview
//                .Union(paymentOverview)
//                .Select(i => i.Key)
//                .Distinct()
//                .
//                .Select(k => new SaleOverview()
//                {
//                    Date = DateTime.ParseExact(k, "MM-yyyy", null),
//                    SalesAmount = (decimal) (saleOverview.FirstOrDefault(s => s.Key == k)?.Sum ?? 0),
//                    Sales = saleOverview.FirstOrDefault(s => s.Key == k)?.Count ?? 0,
//                    PaymentsAmount = (decimal) (paymentOverview.FirstOrDefault(s => s.Key == k)?.Sum ?? 0),
//                    Period = TimePeriod.Month
//                })
//                .ToList();
//        }

//        public async Task<List<SaleOverview>> GetWeeklySalesOverview()
//        {
//            var saleOverview = await _context.Sales
//                .GroupBy(s => new {s.CreatedAt.Year, s.CreatedAt.Day})
//                .Select(g => new
//                {
//                    Key = g.Key.Month + "-" + g.Key.Year, 
//                    Sum = g.Sum(s => s.Amount),
//                    Count = g.Count()
//                })
//                .ToListAsync();
//            var paymentOverview = await _context.Sales
//                .GroupBy(s => new {s.CreatedAt.Year, s.CreatedAt.Month})
//                .Select(g => new
//                {
//                    Key = g.Key.Month + "-" + g.Key.Year, 
//                    Sum = g.Sum(s => s.Amount),
//                    Count = g.Count()
//                })
//                .ToListAsync();
//            return saleOverview
//                .Union(paymentOverview)
//                .Select(i => i.Key)
//                .Distinct()
//                .Select(k => new SaleOverview()
//                {
//                    Date = DateTime.ParseExact(k, "MM-yyyy", null),
//                    SalesAmount = saleOverview.FirstOrDefault(s => s.Key == k)?.Sum ?? 0,
//                    Sales = saleOverview.FirstOrDefault(s => s.Key == k)?.Count ?? 0,
//                    PaymentsAmount = paymentOverview.FirstOrDefault(s => s.Key == k)?.Sum ?? 0,
//                    Period = TimePeriod.Month
//                })
//                .ToList();
//        }
        
//        public async Task<List<MonthlyOverview>>()
//        {
//            
//        }
    }

    public class SaleOverview
    {
        public DateTime Date { get; set; }
        public decimal SalesAmount { get; set; }
        public decimal Sales { get; set; }
        public decimal PaymentsAmount { get; set; }
        public TimePeriod Period { get; set; }
    }

    public enum TimePeriod
    {
        Week,
        Month
    }

    public class ProductSaleOverView
    {
        public DateTime Month { get; set; }
        public decimal SalesAmount { get; set; }
        public decimal Sales { get; set; }
        public TimePeriod Period { get; set; }
    }
}