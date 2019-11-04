using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyOnlineShop.Models
{
    public class ComputerViewModel
    {
         public Computer ComputerM { get; set; }
         public PagedList.IPagedList<MyOnlineShop.Models.PartsModel> Parts { get; set; }
         public string Token { get; set; }
         public string MessageToCustomer { get; set; }
    }
}