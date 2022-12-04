using DataModels.Models;
using DataModels.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Repository
{
    public class TurnoverReportRepository
    {
        public static IEnumerable<TurnoverReport> GetTurnoverReportList() => TurnoverReportManagement.Instance.GetTurnoverReportList();
        public static TurnoverReport GetTurnoverReportById(string Id) => TurnoverReportManagement.Instance.GetTurnoverReportByID(Id);
        public static void AddNew(TurnoverReport TurnoverReport) => TurnoverReportManagement.Instance.AddNew(TurnoverReport);
        public static void Update(TurnoverReport TurnoverReport) => TurnoverReportManagement.Instance.Update(TurnoverReport);
        public static void Remove(TurnoverReport TurnoverReport) => TurnoverReportManagement.Instance.Remove(TurnoverReport);
    }
}
