using DataModels.Models;
using DataModels.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Repository
{
    public class ReferenceRepository
    {
        public static IEnumerable<Reference> GetReferenceList() => ReferenceManagement.Instance.GetReferenceList();
        public static Reference GetReferenceById(string Id) => ReferenceManagement.Instance.GetReferenceByID(Id);
        public static void AddNew(Reference Reference) => ReferenceManagement.Instance.AddNew(Reference);
        public static void Update(Reference Reference) => ReferenceManagement.Instance.Update(Reference);
        public static void Remove(Reference Reference) => ReferenceManagement.Instance.Remove(Reference);
    }
}
