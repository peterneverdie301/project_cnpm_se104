using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;

#nullable disable

namespace DataModels.Models
{
    [FirestoreData]
    public partial class DebtsReport
    {
        [FirestoreProperty]
        public string DebtsId { get; set; }
        [FirestoreProperty]
        public int? Month { get; set; }
        [FirestoreProperty]
        public int? Year { get; set; }
    }
}
