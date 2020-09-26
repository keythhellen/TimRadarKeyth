using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimRadarKeyth.Models
{
    public class TimRadarContext : DbContext
    {
        public TimRadarContext(DbContextOptions<TimRadarContext> options)
            : base(options)
        {
        }

        public DbSet<ProductDelivery> ProductDeliveries { get; set; }
    }
}
