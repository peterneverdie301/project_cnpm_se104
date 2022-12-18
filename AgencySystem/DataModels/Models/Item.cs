using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;

#nullable disable

namespace DataModels.Models
{
    [FirestoreData]
    public partial class Item
    {
        [FirestoreProperty]
        public string ItemsId { get; set; }
        [FirestoreProperty]
        public string ItemsName { get; set; }
        [FirestoreProperty]
        public string UnitId { get; set; }
        [FirestoreProperty]
        public double Price { get; set; }
    }
}
