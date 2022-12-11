using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;

#nullable disable

namespace DataModels.Models
{
    [FirestoreData]
    public partial class Unit
    {
        [FirestoreProperty]
        public string Id { get; set; }
        [FirestoreProperty]
        public string Value { get; set; }
    }
}
