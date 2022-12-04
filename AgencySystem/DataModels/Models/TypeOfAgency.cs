using System;
using System.Collections.Generic;

#nullable disable

namespace DataModels.Models
{
    public partial class TypeOfAgency
    {
        public TypeOfAgency()
        {
            Agencies = new HashSet<Agency>();
        }

        public string Id { get; set; }
        public int? Type { get; set; }

        public virtual ICollection<Agency> Agencies { get; set; }
    }
}
