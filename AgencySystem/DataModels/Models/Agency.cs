using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;

#nullable disable

namespace DataModels.Models
{
    [FirestoreData]
    public class Agency
    {
        [FirestoreProperty]
        public string AgencyId { get; set; }
        [FirestoreProperty]
        public string AgencyName { get; set; }
        [FirestoreProperty]
        public string TypeId { get; set; }
        [FirestoreProperty]
        public string PhoneNumber { get; set; }
        [FirestoreProperty]
        public string Address { get; set; }
        [FirestoreProperty]
        public string District { get; set; }
        [FirestoreProperty]
        public Timestamp DayReception { get; set; }
    }
}
