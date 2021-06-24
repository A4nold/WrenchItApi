using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WrenchItWebAPI.Models
{
    public class Service
    {
        public int ServiceId { get; set; }
        public long CustomerId { get; set; }
        public double PriceQuotation { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsCompleted { get; set; }
    }
}
