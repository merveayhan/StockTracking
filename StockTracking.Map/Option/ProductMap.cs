using StockTracking.Core.Map;
using StockTracking.Model.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTracking.Map.Option
{
    public class ProductMap:CoreMap<Product>
    {
        public ProductMap()
        {
            ToTable("dbo.Products");
            Property(x => x.ProductName).HasMaxLength(50).IsRequired();
            Property(x => x.Quantity).IsRequired();
            Property(x => x.Kdv).HasMaxLength(50).IsRequired();
            Property(x => x.FirstPrice).IsRequired();
            Property(x => x.SalePrice).IsRequired();
            Property(x => x.AddDate).IsRequired();
            Property(x => x.UserImage).IsRequired();
            Property(x => x.XSmallUserImage).IsRequired();
            Property(x => x.CruptedUserImage).IsRequired();

            HasRequired(x => x.Category)
               .WithMany(x => x.Products)
               .HasForeignKey(x => x.CategoryID)
               .WillCascadeOnDelete(true);//katerorisi silinirse ürün silinsin

            HasMany(x => x.Sales).WithRequired(x => x.Product).HasForeignKey(x => x.ProductID);

        }
    }
}
