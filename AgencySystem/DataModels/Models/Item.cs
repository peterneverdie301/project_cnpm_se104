using System;
using System.Collections.Generic;

#nullable disable

namespace DataModels.Models
{
    public partial class Item
    {
        public string ItemsId { get; set; }
        public string ItemsName { get; set; }
        public string Unit { get; set; }
        public decimal? Price { get; set; }
    }
}
