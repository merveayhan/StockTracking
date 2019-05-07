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
            Property(x => x.Quantity).IsOptional();
            Property(x => x.Date).IsOptional();
            // Property(x => x.Discount).IsOptional();          

            HasRequired(x => x.Product)
              .WithMany(x => x.Sales)
              .HasForeignKey(x => x.ProductID)
              .WillCascadeOnDelete(false);

            HasRequired(x => x.AppUser)
              .WithMany(x => x.Sales)
              .HasForeignKey(x => x.AppUserID)
              .WillCascadeOnDelete(false); 


            //HasMany(x => x.AppUsers).WithRequired(x => x.Sale).HasForeignKey(x => x.SaleID).WillCascadeOnDelete(false); ;
            //HasMany(x => x.Products).WithRequired(x => x.Sale).HasForeignKey(x => x.SaleID).WillCascadeOnDelete(false); ;
        }
    }
}
