using DataModels.Models;
using DataModels.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Repository
{
    public class ExportSlipDetailRepository
    {
        public static IEnumerable<ExportSlipDetail> GetExportSlipDetailList() => ExportSlipDetailManagement.Instance.GetExportSlipDetailList();
        public static ExportSlipDetail GetExportSlipDetailById(string Id) => ExportSlipDetailManagement.Instance.GetExportSlipDetailByID(Id);
        public static void AddNew(ExportSlipDetail ExportSlipDetail) => ExportSlipDetailManagement.Instance.AddNew(ExportSlipDetail);
        public static void Update(ExportSlipDetail ExportSlipDetail) => ExportSlipDetailManagement.Instance.Update(ExportSlipDetail);
        public static void Remove(ExportSlipDetail ExportSlipDetail) => ExportSlipDetailManagement.Instance.Remove(ExportSlipDetail);
    }
}
