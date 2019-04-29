using StockTracking.Model.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockTracking.UI.Areas.Admin.Models.DTO
{
    public class ProductDTO
    {
        public Guid ID { get; set; }
        public string ProductName { get; set; }
        public short? Quantity { get; set; }
        public string Kdv { get; set; }
        public decimal? FirstPrice { get; set; }
        public decimal? SalePrice { get; set; }
        public DateTime AddDate { get; set; }
        public string ImagePath { get; set; }
        public string UserImage { get; set; }
        public string XSmallUserImage { get; set; }
        public string CruptedUserImage { get; set; }

        public List<Category> Categories { get; set; }
    }
}