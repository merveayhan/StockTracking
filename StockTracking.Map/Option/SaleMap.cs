using StockTracking.Core.Map;
using StockTracking.Model.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTracking.Map.Option
{
    public class SaleMap:CoreMap<Sale>
    {
        public SaleMap()
        {
            ToTable("dbo.Sales");
            Property(x => x.Quantity).IsRequired();
            Property(x => x.Date).IsRequired();
            Property(x => x.Discount).IsRequired();


            HasRequired(x => x.Product)
              .WithMany(x => x.Sales)
              .HasForeignKey(x => x.ProductID)
              .WillCascadeOnDelete(true);//katerorisi silinirse ürün silinsin

            HasRequired(x => x.AppUser)
              .WithMany(x => x.Sales)
              .HasForeignKey(x => x.AppUserID)
              .WillCascadeOnDelete(true);//katerorisi silinirse ürün silinsin
        }
    }
}
