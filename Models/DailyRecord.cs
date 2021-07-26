using System;
using System.Collections.Generic;

#nullable disable

namespace bdo3.Models
{
    public partial class DailyRecord
    {
        public int MainKey { get; set; }
        public DateTime Date { get; set; }
        public long? TradingVolume { get; set; }
    }
}
