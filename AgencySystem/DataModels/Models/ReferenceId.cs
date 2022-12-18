using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Models
{
    [FirestoreData]
    internal class ReferenceId
    {
        [FirestoreProperty]
        public int Value { get; set; }
    }
}
