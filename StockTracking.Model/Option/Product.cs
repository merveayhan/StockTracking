using StockTracking.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTracking.Model.Option
{ 
    public class Product:CoreEntity
    {
        public string ProductName { get; set; }
        public short? Quantity { get; set; }
        public string Kdv { get; set; }
        public decimal? FirstPrice { get; set; }
        public decimal? SalePrice { get; set; }
        public DateTime AddDate { get; set; }

        public string UserImage { get; set; }
        public string XSmallUserImage { get; set; }
        public string CruptedUserImage { get; set; }

        public Guid CategoryID { get; set; }
        public virtual Category Category { get; set; }

        public virtual List<Sale> Sales { get; set; }


    }
}
