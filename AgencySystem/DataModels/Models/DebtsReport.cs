using System;
using System.Collections.Generic;

#nullable disable

namespace DataModels.Models
{
    public partial class DebtsReport
    {
        public string DebtsId { get; set; }
        public int? Month { get; set; }
        public int? Year { get; set; }
    }
}
