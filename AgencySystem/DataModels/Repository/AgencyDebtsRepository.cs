using DataModels.Models;
using DataModels.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Repository
{
    public class AgencyDebtsRepository
    {
        public static IEnumerable<AgencyDebt> GetAgencyDebtList() => AgencyDebtManagement.Instance.GetAgencyDebtList();
        public static AgencyDebt GetAgencyById(string Id) => AgencyDebtManagement.Instance.GetAgencyDebtByID(Id);
        public static void AddNew(AgencyDebt agencyDebt) => AgencyDebtManagement.Instance.AddNew(agencyDebt);
        public static void Update(AgencyDebt agencyDebt) => AgencyDebtManagement.Instance.Update(agencyDebt);
        public static void Remove(AgencyDebt agencyDebt) => AgencyDebtManagement.Instance.Remove(agencyDebt);
    }
}
