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
        public string Date { get; set; }
        [FirestoreProperty]
        public double AmountPaid { get; set; }
        [FirestoreProperty]
        public double Total { get; set; }
        [FirestoreProperty]
        public double TotalItems { get; set; }
    }
}
