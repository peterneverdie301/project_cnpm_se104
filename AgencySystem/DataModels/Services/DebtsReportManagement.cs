using DataModels.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Services
{
    public class DebtsReportManagement
    {
        private static DebtsReportManagement instance = null;
        private static readonly object instanceLock = new object();
        private DebtsReportManagement() { }
        public static DebtsReportManagement Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new DebtsReportManagement();
                    }
                    return instance;
                }
            }
        }
        public IEnumerable<DebtsReport> GetDebtsReportList()
        {
            List<DebtsReport> DebtsReports;
            try
            {
                var myStockDB = new AgencyManagemntContext();
                DebtsReports = myStockDB.DebtsReports.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return DebtsReports;
        }
        public DebtsReport GetDebtsReportByID(string DebtsReportID)
        {
            DebtsReport DebtsReport = null;
            try
            {
                var myStockDB = new AgencyManagemntContext();
                DebtsReport = myStockDB.DebtsReports.SingleOrDefault(DebtsReport => DebtsReport.DebtsId == DebtsReportID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return DebtsReport;
        }
        public void AddNew(DebtsReport DebtsReport)
        {
            try
            {
                DebtsReport _DebtsReport = GetDebtsReportByID((string)DebtsReport.DebtsId);
                if (_DebtsReport == null)
                {
                    var myStockDB = new AgencyManagemntContext();
                    myStockDB.DebtsReports.Add(DebtsReport);
                    myStockDB.SaveChanges();
                }
                else
                {
                    throw new Exception("The DebtsReport is already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Update(DebtsReport DebtsReport)
        {
            try
            {
                DebtsReport c = GetDebtsReportByID((string)DebtsReport.DebtsId);
                if (c != null)
                {
                    var myStockDB = new AgencyManagemntContext();
                    myStockDB.Entry<DebtsReport>(DebtsReport).State = EntityState.Modified;
                    myStockDB.SaveChanges();
                }
                else
                {
                    throw new Exception("The DebtsReport does not already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Remove(DebtsReport DebtsReport)
        {
            try
            {
                DebtsReport _DebtsReport = GetDebtsReportByID((string)DebtsReport.DebtsId);
                if (_DebtsReport != null)
                {
                    var myStockDB = new AgencyManagemntContext();
                    myStockDB.DebtsReports.Remove(DebtsReport);
                    myStockDB.SaveChanges();
                }
                else
                {
                    throw new Exception("The DebtsReport does not already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
