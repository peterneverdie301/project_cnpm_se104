using DataModels.Models;
using DataModels.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Repository
{
    public class ExportSlipRepository
    {
        public static IEnumerable<ExportSlip> GetExportSlipList() => ExportSlipManagement.Instance.GetExportSlipList();
        public static ExportSlip GetExportSlipById(string Id) => ExportSlipManagement.Instance.GetExportSlipByID(Id);
        public static void AddNew(ExportSlip ExportSlip) => ExportSlipManagement.Instance.AddNew(ExportSlip);
        public static void Update(ExportSlip ExportSlip) => ExportSlipManagement.Instance.Update(ExportSlip);
        public static void Remove(ExportSlip ExportSlip) => ExportSlipManagement.Instance.Remove(ExportSlip);
    }
}
