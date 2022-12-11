using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;

#nullable disable

namespace DataModels.Models
{
    [FirestoreData]
    public partial class Receipt
    {
        [FirestoreProperty]
        public string ReceiptId { get; set; }
        [FirestoreProperty]
        public string AgencyId { get; set; }
        [FirestoreProperty]
        public DateTime? Date { get; set; }
        [FirestoreProperty]
        public decimal? Proceeds { get; set; }
    }
}
