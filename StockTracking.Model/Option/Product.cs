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
        public int Quantity { get; set; }
        public decimal Kdv { get; set; }
        public decimal FirstPrice { get; set; }
        public decimal SalePrice { get; set; }
        public DateTime? AddDate { get; set; }
        public string ImagePath { get; set; }

        

        public Guid CategoryID { get; set; }
        public virtual Category Category { get; set; }

        public virtual List<Sale> Sales { get; set; }

        //public Guid SaleID { get; set; }
        //public virtual Sale Sale { get; set; }


    }
}
