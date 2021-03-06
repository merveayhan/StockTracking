﻿using StockTracking.Core.Entity;
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
        public DateTime? Date { get; set; }
        // public decimal? Discount { get; set; }


        public Guid AppUserID { get; set; }
        public virtual AppUser AppUser { get; set; }


        public Guid ProductID { get; set; }
        public virtual Product Product { get; set; }

        //public virtual List<AppUser> AppUsers { get; set; }
        //public virtual List<Product> Products { get; set; }
    }
}
