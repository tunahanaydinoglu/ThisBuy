using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ThisBuy.Dal.Entities;

namespace ThisBuy.Web.Models
{
    public class RegisterViewModel
    {
        public User User { get; set; }
    }
}