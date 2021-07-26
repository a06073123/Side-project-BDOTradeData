using System;
using System.Collections.Generic;

#nullable disable

namespace bdo3.ViewModels
{
    public partial class DailyRank
    {
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public int MainKey { get; set; }
        public long TradingVolume { get; set; }
    }
}