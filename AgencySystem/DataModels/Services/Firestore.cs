using Google.Cloud.Firestore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Services
{
    public class Firestore
    {
        private FirestoreDb db = null;
        //public FirestoreDb Db { get => db; set => db = value; }

        public Firestore()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + @"config_server.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);
            this.db = FirestoreDb.Create("agencymanagement-ce1e9");
        }

        public async Task<object> GetData(string collection, string id)
        {
            DocumentReference document = db.Collection(collection).Document(id);
            DocumentSnapshot snapshot = await document.GetSnapshotAsync();
            if (snapshot.Exists)
            {
                return Utils.ConvertData(collection, snapshot);
            }
            return null;
        }
        public async Task<List<object>> GetAllDocument(string collection)
        {
            List<object> documents = new List<object>();
            Query allQuery = db.Collection(collection);
            QuerySnapshot allQuerySnapshot = await allQuery.GetSnapshotAsync();
            foreach (DocumentSnapshot documentSnapshot in allQuerySnapshot.Documents)
            {
                documents.Add(Utils.ConvertData(collection, documentSnapshot));
            }
            return documents;
        }
        public async void AddData(string collection, string id, object data)
        {
            await db.Collection(collection).Document(id).SetAsync(data);
        }
        public async void UpdateData(string collection, string id, object data)
        {
            DocumentReference document = db.Collection(collection).Document(id);
            await document.SetAsync(data);
        }
        public async void DeleteData(string collection, string id)
        {
            DocumentReference document = db.Collection(collection).Document(id);
            await document.DeleteAsync();
        }

        public async Task<string> GetIdForProject (string collection)
        {
            Query allQuery = db.Collection(collection);
            QuerySnapshot allQuerySnapshot = await allQuery.GetSnapshotAsync();
            return Utils.GetIdForObject(collection, allQuerySnapshot.Count);

        }
    }
}
