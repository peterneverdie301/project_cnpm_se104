using System;
using System.Collections.Generic;

#nullable disable

namespace DataModels.Models
{
    public partial class ExportSlip
    {
        public string ExportSlipId { get; set; }
        public string AgencyId { get; set; }
        public DateTime? Date { get; set; }
        public decimal? AmountPaid { get; set; }

        public virtual Agency Agency { get; set; }
    }
}
