using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;

#nullable disable

namespace DataModels.Models
{
    [FirestoreData]
    public class ExportSlip
    {
        [FirestoreProperty]
        public string ExportSlipId { get; set; }
        [FirestoreProperty]
        public string AgencyId { get; set; }
        [FirestoreProperty]
        public DateTime? Date { get; set; }
        [FirestoreProperty]
        public decimal? AmountPaid { get; set; }

    }
}
