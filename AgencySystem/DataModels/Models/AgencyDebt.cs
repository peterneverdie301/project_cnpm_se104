using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;

#nullable disable

namespace DataModels.Models
{
    [FirestoreData]
    public class AgencyDebt
    {
        [FirestoreProperty]
        public string AgencyId { get; set; }
        [FirestoreProperty]
        public int? Month { get; set; }
        [FirestoreProperty]
        public int? Year { get; set; }
        [FirestoreProperty]
        public double? FirsDebt { get; set; }
        [FirestoreProperty]
        public double? Incurred { get; set; }
    }
}
