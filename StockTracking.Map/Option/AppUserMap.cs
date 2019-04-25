using StockTracking.Core.Map;
using StockTracking.Model.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTracking.Map.Option
{
    public class AppUserMap:CoreMap<AppUser>
    {
        public AppUserMap()
        {
            ToTable("dbo.Users");
            Property(x => x.FirstName).HasMaxLength(50).IsRequired();
            Property(x => x.LastName).HasMaxLength(50).IsRequired();
            Property(x => x.UserName).HasMaxLength(50).IsRequired();
            Property(x => x.Password).HasMaxLength(50).IsRequired();
            Property(x => x.Address).HasMaxLength(150).IsRequired();
            Property(x => x.PhoneNumber).HasMaxLength(50).IsRequired();
            Property(x => x.Role).IsOptional();
            Property(x => x.UserImage).IsRequired();
            Property(x => x.XSmallUserImage).IsRequired();
            Property(x => x.CruptedUserImage).IsRequired();

            HasMany(x => x.Sales).WithRequired(x => x.AppUser).HasForeignKey(x => x.AppUserID);

        }
    }
}
