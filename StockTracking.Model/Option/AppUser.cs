﻿using StockTracking.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTracking.Model.Option
{
    public enum Role
    {
        None = 0,
        Admin = 1,
        Member = 2
    }
    public class AppUser:CoreEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public Role Role { get; set; }
        public string ImagePath { get; set; }

        public string UserImage { get; set; }
        public string XSmallUserImage { get; set; }
        public string CruptedUserImage { get; set; }

        public virtual List<Sale> Sales { get; set; }

        //public Guid SaleID { get; set; }
        //public virtual Sale Sale { get; set; }

    }
}
