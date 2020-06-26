using System.Collections.Generic;
using MyOnlineShop.Models.Entities;
using MyOnlineShop.ProgramLogic;

namespace MyOnlineShop.Models.ViewModels
{
    public class ComputerViewModel
    {
         public ComputerEntity ComputerM { get; set; }
         public List<ComputerEntity> UserComputers { get; set; }
         public IDictionary <string, PartsBaseEntity> MyComputerParts { get; set; }
         public PagedList.IPagedList<PartsBaseEntity> ShopPartsPagedList { get; set; }
         public string ShopPartsFilteredByPartName { get; set; }
         public Feedback TextAndIconToCustomer { get; set; }
    }
}