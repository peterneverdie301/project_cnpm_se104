using DataModels.Models;
using DataModels.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Repository
{
    public class DebtsReportRepository
    {
        public static IEnumerable<DebtsReport> GetDebtsReportList() => DebtsReportManagement.Instance.GetDebtsReportList();
        public static DebtsReport GetDebtsReportById(string Id) => DebtsReportManagement.Instance.GetDebtsReportByID(Id);
        public static void AddNew(DebtsReport DebtsReport) => DebtsReportManagement.Instance.AddNew(DebtsReport);
        public static void Update(DebtsReport DebtsReport) => DebtsReportManagement.Instance.Update(DebtsReport);
        public static void Remove(DebtsReport DebtsReport) => DebtsReportManagement.Instance.Remove(DebtsReport);
    }
}
