using DataModels.Models;
using DataModels.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Repository
{
    public class TypeOfTypeOfAgencyRepository
    {
        public static IEnumerable<TypeOfAgency> GetTypeOfAgencyList() => TypeOfAgencyManagement.Instance.GetTypeOfAgencyList();
        public static TypeOfAgency GetTypeOfAgencyById(string Id) => TypeOfAgencyManagement.Instance.GetTypeOfAgencyByID(Id);
        public static void AddNew(TypeOfAgency TypeOfAgency) => TypeOfAgencyManagement.Instance.AddNew(TypeOfAgency);
        public static void Update(TypeOfAgency TypeOfAgency) => TypeOfAgencyManagement.Instance.Update(TypeOfAgency);
        public static void Remove(TypeOfAgency TypeOfAgency) => TypeOfAgencyManagement.Instance.Remove(TypeOfAgency);
    }
}
