using DataModels.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Services
{
    public class TurnoverReportManagement
    {
        private static TurnoverReportManagement instance = null;
        private static readonly object instanceLock = new object();
        private TurnoverReportManagement() { }
        public static TurnoverReportManagement Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new TurnoverReportManagement();
                    }
                    return instance;
                }
            }
        }
        public IEnumerable<TurnoverReport> GetTurnoverReportList()
        {
            List<TurnoverReport> TurnoverReports;
            try
            {
                var myStockDB = new AgencyManagemntContext();
                TurnoverReports = myStockDB.TurnoverReports.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return TurnoverReports;
        }
        public TurnoverReport GetTurnoverReportByID(string TurnoverReportID)
        {
            TurnoverReport TurnoverReport = null;
            try
            {
                var myStockDB = new AgencyManagemntContext();
                TurnoverReport = myStockDB.TurnoverReports.SingleOrDefault(TurnoverReport => TurnoverReport.TurnoverId == TurnoverReportID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return TurnoverReport;
        }
        public void AddNew(TurnoverReport TurnoverReport)
        {
            try
            {
                TurnoverReport _TurnoverReport = GetTurnoverReportByID((string)TurnoverReport.TurnoverId);
                if (_TurnoverReport == null)
                {
                    var myStockDB = new AgencyManagemntContext();
                    myStockDB.TurnoverReports.Add(TurnoverReport);
                    myStockDB.SaveChanges();
                }
                else
                {
                    throw new Exception("The TurnoverReport is already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Update(TurnoverReport TurnoverReport)
        {
            try
            {
                TurnoverReport c = GetTurnoverReportByID((string)TurnoverReport.TurnoverId);
                if (c != null)
                {
                    var myStockDB = new AgencyManagemntContext();
                    myStockDB.Entry<TurnoverReport>(TurnoverReport).State = EntityState.Modified;
                    myStockDB.SaveChanges();
                }
                else
                {
                    throw new Exception("The TurnoverReport does not already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Remove(TurnoverReport TurnoverReport)
        {
            try
            {
                TurnoverReport _TurnoverReport = GetTurnoverReportByID((string)TurnoverReport.TurnoverId);
                if (_TurnoverReport != null)
                {
                    var myStockDB = new AgencyManagemntContext();
                    myStockDB.TurnoverReports.Remove(TurnoverReport);
                    myStockDB.SaveChanges();
                }
                else
                {
                    throw new Exception("The TurnoverReport does not already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
