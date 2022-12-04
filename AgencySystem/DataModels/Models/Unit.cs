using System;
using System.Collections.Generic;

#nullable disable

namespace DataModels.Models
{
    public partial class Unit
    {
        public Unit()
        {
            Items = new HashSet<Item>();
        }

        public string Id { get; set; }
        public string Value { get; set; }

        public virtual ICollection<Item> Items { get; set; }
    }
}
