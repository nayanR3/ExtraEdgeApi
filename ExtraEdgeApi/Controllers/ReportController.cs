using ExtraEdgeApi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExtraEdgeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ReportController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("api/sales/monthlyReport")]
        public IActionResult GetMonthlySalesReport(DateTime from, DateTime to)
        {
            var monthlySales = _context.sells
                .Where(p => p.SellDate >= from && p.SellDate <= to)
                .GroupBy(p => new { p.SellDate.Year, p.SellDate.Month })
                .Select(g => new
                {
                    Year = g.Key.Year,
                    Month = g.Key.Month,
                    TotalSales = g.Sum(p => p.FinalPrice)
                });

            return Ok(monthlySales);
        }



        [HttpGet]
        [Route("api/sales/monthlyBrandReport")]
        public async Task<IActionResult> GetMonthlyBrandWiseSalesReport(DateTime fromDate, DateTime toDate, int brandId)
        {
            var brandSales = await _context.sells
            .Include(s => s.Mobile)
            .ThenInclude(m => m.Brand)
            .Where(s => s.SellDate >= fromDate && s.SellDate <= toDate && s.Mobile.Brand.BrandId == brandId)
            .GroupBy(s => s.Mobile.Brand)
            .Select(g => new BrandSalesReport
            {
                BrandId = g.Key.BrandId,
                BrandName = g.Key.Name,
                TotalSales = g.Sum(s => s.FinalPrice),
                TotalDiscounts = g.Sum(s => s.Discount),
                TotalQuantitySold = g.Count()
            })
            .ToListAsync();

            return Ok(brandSales);
        }

        [HttpGet]
        [Route("api/profitLossReport")]
        public async Task<IActionResult> GetProfitLossReport(DateTime fromDate, DateTime toDate)
        {
            // Calculate profit/loss for the current timeline
            var currentSales = await _context.sells
                .Include(s => s.Mobile)
                    .ThenInclude(m => m.Brand)
                .Where(s => s.SellDate >= fromDate && s.SellDate <= toDate)
                .ToListAsync();

            var currentProfit = currentSales.Sum(s => s.FinalPrice - s.Mobile.Price - s.Discount);

            // Calculate profit/loss for the previous timeline
            var previousFromDate = fromDate.AddYears(-1);
            var previousToDate = toDate.AddYears(-1);

            var previousSales = await _context.sells
                .Include(s => s.Mobile)
                    .ThenInclude(m => m.Brand)
                .Where(s => s.SellDate >= previousFromDate && s.SellDate <= previousToDate)
                .ToListAsync();

            var previousProfit = previousSales.Sum(s => s.FinalPrice - s.Mobile.Price - s.Discount);

            // Return the profit/loss report
            var report = new ProfitLossReport
            {
                CurrentFromDate = fromDate,
                CurrentToDate = toDate,
                CurrentProfit = currentProfit,
                PreviousFromDate = previousFromDate,
                PreviousToDate = previousToDate,
                PreviousProfit = previousProfit
            };

            return Ok(report);
        }


    }

}
