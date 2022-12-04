using System;
using System.Collections.Generic;

#nullable disable

namespace DataModels.Models
{
    public partial class AgencyDebt
    {
        public string AgencyId { get; set; }
        public int? Month { get; set; }
        public int? Year { get; set; }
        public decimal? FirsDebt { get; set; }
        public decimal? Incurred { get; set; }

        public virtual Agency Agency { get; set; }
    }
}
