using System;
using System.Collections.Generic;

#nullable disable

namespace DataModels.Models
{
    public partial class TurnoverReport
    {
        public string TurnoverId { get; set; }
        public int? Month { get; set; }
        public int? Year { get; set; }
    }
}
