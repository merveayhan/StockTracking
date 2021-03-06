﻿using StockTracking.Core.Map;
using StockTracking.Model.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTracking.Map.Option
{
    public class CategoryMap:CoreMap<Category>
    {
        public CategoryMap()
        {
            ToTable("dbo.Categories");
            Property(x => x.CategoryName).IsOptional();
            Property(x => x.Description).IsOptional();

            HasMany(x => x.Products).WithRequired(x => x.Category).HasForeignKey(x => x.CategoryID).WillCascadeOnDelete(false);
        }
    }
}
