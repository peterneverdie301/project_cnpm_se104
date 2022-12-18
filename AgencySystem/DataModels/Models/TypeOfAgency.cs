using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;

#nullable disable

namespace DataModels.Models
{
    [FirestoreData]
    public partial class TypeOfAgency
    {
        [FirestoreProperty]
        public string Id { get; set; }
        [FirestoreProperty]
        public int? Type { get; set; }
        [FirestoreProperty]
        public double? MaxDebt { get; set; }
    }
}
