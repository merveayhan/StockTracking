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
            Property(x => x.ProductName).HasMaxLength(50).IsOptional();
            Property(x => x.Quantity).HasMaxLength(50).IsOptional();
            Property(x => x.Kdv).HasMaxLength(50).IsOptional();
            Property(x => x.FirstPrice).IsOptional();
            Property(x => x.SalePrice).IsOptional();
            Property(x => x.AddDate).HasColumnType("datetime2").IsOptional();
            Property(x => x.ImagePath).IsOptional();
            //Property(x => x.UserImage).IsOptional();
            //Property(x => x.XSmallUserImage).IsOptional();
            //Property(x => x.CruptedUserImage).IsOptional();

            HasRequired(x => x.Category)
               .WithMany(x => x.Products)
               .HasForeignKey(x => x.CategoryID)
               .WillCascadeOnDelete(false); //katerorisi silinirse ürün silinsin


            //HasRequired(x => x.Sale)
            //   .WithMany(x => x.Products)
            //   .HasForeignKey(x => x.SaleID)
            //   .WillCascadeOnDelete(true); //katerorisi silinirse ürün silinsin



        }
    }
}
