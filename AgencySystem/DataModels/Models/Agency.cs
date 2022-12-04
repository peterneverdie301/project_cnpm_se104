using System;
using System.Collections.Generic;

#nullable disable

namespace DataModels.Models
{
    public partial class Agency
    {
        public Agency()
        {
            ExportSlips = new HashSet<ExportSlip>();
            Receipts = new HashSet<Receipt>();
        }

        public string AgencyId { get; set; }
        public string AgencyName { get; set; }
        public string TypeId { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string District { get; set; }
        public DateTime? DayReception { get; set; }

        public virtual TypeOfAgency Type { get; set; }
        public virtual ICollection<ExportSlip> ExportSlips { get; set; }
        public virtual ICollection<Receipt> Receipts { get; set; }
    }
}
