using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyOnlineShop.Models
{
    public class ComputerViewModel
    {
         public Computer ComputerM { get; set; }
         public List<Computer> UserComputers { get; set; }
         public List<PartsModel> MyComputerParts { get; internal set; }
         public PagedList.IPagedList<MyOnlineShop.Models.PartsModel> ShopParts { get; set; }
         public string Token { get; set; }
         public IDictionary <string, (string, string)> TextAndIconToCustomer { get; set; }
    }
}