using System;
using System.Collections.Generic;

#nullable disable

namespace DataModels.Models
{
    public partial class Receipt
    {
        public string ReceiptId { get; set; }
        public string AgencyId { get; set; }
        public DateTime? Date { get; set; }
        public decimal? Proceeds { get; set; }

        public virtual Agency Agency { get; set; }
    }
}
