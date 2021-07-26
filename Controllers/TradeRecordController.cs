using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Immutable;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Collections.Generic;

using bdo3.Models;
using bdo3.ViewModels;

namespace bdo3.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TradeRecordController : Controller
    {
        private readonly ILogger<TradeRecordController> _logger;
        private readonly BDOContext _context;

        public TradeRecordController(ILogger<TradeRecordController> logger, BDOContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public async Task<JsonResult> GetAsync()
        {
            DateTime yesterday = DateTime.Now.Date.AddDays(-1);
            DailyRank[] drs = _context.DailyRecords.Where(dr => dr.Date == yesterday)
                                        .OrderByDescending(dr => dr.TradingVolume)
                                        .Take(100)
                                        .Join(_context.TradeItems,
                                        dr => dr.MainKey,
                                        ti => ti.MainKey,
                                        (dr, ti) => new
                                        DailyRank
                                        {
                                            Name = ti.Name,
                                            MainKey = dr.MainKey,
                                            Date = dr.Date,
                                            TradingVolume = dr.TradingVolume.GetValueOrDefault()
                                        })
                                        .ToArray();
            return Json(new ReduceDailyRecordsBody(drs));
        }

        [HttpGet("{MainKey}")]
        public async Task<JsonResult> GetAsync(int mainKey)
        {
            DateTime oneMonthAgo = DateTime.Now.AddMonths(-1);
            TradeRecord[] trs = _context.TradeRecords.Where(tr => tr.MainKey == mainKey && tr.Time >= oneMonthAgo)
                                                .OrderBy(tr => tr.Time)
                                                .ToArray();
            return Json(new ReduceTradeRecordsBody(trs));
        }
    }

    public class ReduceDailyRecordsBody
    {
        public DateTime times { get; set; }
        public IList<string> names { get; set; }
        public IList<int> mainKeys { get; set; }
        public IList<long> tradingVolumes { get; set; }

        public ReduceDailyRecordsBody(DailyRank[] drs)
        {
            this.times = drs[0].Date;
            this.names = new List<string>();
            this.mainKeys = new List<int>();
            this.tradingVolumes = new List<long>();

            foreach (DailyRank dr in drs)
            {
                this.names.Add(dr.Name);
                this.mainKeys.Add(dr.MainKey);
                this.tradingVolumes.Add(dr.TradingVolume);
            }
        }

    }

    public class ReduceTradeRecordsBody
    {
        public int mainKey { get; set; }
        public IList<DateTime> times { get; set; }
        public IList<long> sumCounts { get; set; }
        public IList<long> totalSumCounts { get; set; }
        public IList<long> minPrices { get; set; }

        public ReduceTradeRecordsBody(TradeRecord[] trs)
        {
            this.mainKey = trs[0].MainKey;
            this.times = new List<DateTime>();
            this.sumCounts = new List<long>();
            this.totalSumCounts = new List<long>();
            this.minPrices = new List<long>();

            foreach (TradeRecord tr in trs)
            {
                this.times.Add(tr.Time);
                this.sumCounts.Add(tr.SumCount.GetValueOrDefault());
                this.totalSumCounts.Add(tr.TotalSumCount.GetValueOrDefault());
                this.minPrices.Add(tr.MinPrice.GetValueOrDefault());
            }
        }
    }
}
