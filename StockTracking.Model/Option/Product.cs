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
        public string Quantity { get; set; }
        public string Kdv { get; set; }
        public string FirstPrice { get; set; }
        public string SalePrice { get; set; }
        public DateTime? AddDate { get; set; }
        public string ImagePath { get; set; }

        

        public Guid CategoryID { get; set; }
        public virtual Category Category { get; set; }

      
        //public Guid SaleID { get; set; }
        //public virtual Sale Sale { get; set; }


    }
}
