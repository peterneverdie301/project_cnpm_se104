using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;

#nullable disable

namespace DataModels.Models
{
    [FirestoreData]
    public partial class ExportSlipDetail
    {
        [FirestoreProperty]
        public string ExportSlipId { get; set; }
        [FirestoreProperty]
        public string ItemsId { get; set; }
        [FirestoreProperty]
        public int? Amount { get; set; }
    }
}