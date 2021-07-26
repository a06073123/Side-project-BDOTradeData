using System;
using System.Collections.Generic;

#nullable disable

namespace bdo3.Models
{
    public partial class TradeRecord
    {
        //log time every 6hr
        public DateTime Time { get; set; }
        public int MainKey { get; set; }
        //sell order
        public long? SumCount { get; set; }
        //total sold
        public long? TotalSumCount { get; set; }
        //the min price of sell order
        public long? MinPrice { get; set; }
    }
}
