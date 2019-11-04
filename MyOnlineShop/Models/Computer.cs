using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyOnlineShop.Models
{
    public class Computer
    {
        public int Id { get; set; }
        public int IdClient { get; set; }
        public int IdCpu { get; set; }
        public int Comments { get; set; }
        public int Likes { get; set; }
    }
}