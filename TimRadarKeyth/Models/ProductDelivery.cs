using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimRadarKeyth.Models
{
    public class ProductDelivery
    {
        public int Id { get; set; }
        public DateTime DeliveryDate { get; set; }
        public String Description { get; set; }
        public int Amount { get; set; }
        public Decimal UnitaryValue { get; set; }
    }
}
