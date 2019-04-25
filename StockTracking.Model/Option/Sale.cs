using StockTracking.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTracking.Model.Option
{
    public class Sale:CoreEntity
    {
        public short? Quantity { get; set; }
        public DateTime Date { get; set; }
        public int Discount { get; set; }

        public Guid ProductID { get; set; }
        public virtual Product Product { get; set; }

        public Guid AppUserID { get; set; }
        public virtual AppUser AppUser { get; set; }

    }
}
