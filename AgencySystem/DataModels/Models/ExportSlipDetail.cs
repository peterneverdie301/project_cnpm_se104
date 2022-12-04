using System;
using System.Collections.Generic;

#nullable disable

namespace DataModels.Models
{
    public partial class ExportSlipDetail
    {
        public string ExportSlipId { get; set; }
        public string ItemsId { get; set; }
        public int? Amount { get; set; }

        public virtual ExportSlip ExportSlip { get; set; }
        public virtual Item Items { get; set; }
    }
}
