using DataModels.Models;
using DataModels.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Repository
{
    public class AgencyRepository
    {
        public static IEnumerable<Agency> GetAgencyList() => AgencyManagement.Instance.GetAgencyList();
        public static Agency GetAgencyById(string Id) => AgencyManagement.Instance.GetAgencyByID(Id);
        public static void AddNew(Agency Agency) => AgencyManagement.Instance.AddNew(Agency);
        public static void Update(Agency Agency) => AgencyManagement.Instance.Update(Agency);
        public static void Remove(Agency Agency) => AgencyManagement.Instance.Remove(Agency);
    }
}
