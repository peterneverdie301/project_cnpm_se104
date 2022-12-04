using DataModels.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Services
{
    public class ExportSlipManagement
    {
        private static ExportSlipManagement instance = null;
        private static readonly object instanceLock = new object();
        private ExportSlipManagement() { }
        public static ExportSlipManagement Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ExportSlipManagement();
                    }
                    return instance;
                }
            }
        }
        public IEnumerable<ExportSlip> GetExportSlipList()
        {
            List<ExportSlip> ExportSlips;
            try
            {
                var myStockDB = new AgencyManagemntContext();
                ExportSlips = myStockDB.ExportSlips.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return ExportSlips;
        }
        public ExportSlip GetExportSlipByID(string ExportSlipID)
        {
            ExportSlip ExportSlip = null;
            try
            {
                var myStockDB = new AgencyManagemntContext();
                ExportSlip = myStockDB.ExportSlips.SingleOrDefault(ExportSlip => ExportSlip.ExportSlipId == ExportSlipID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return ExportSlip;
        }
        public void AddNew(ExportSlip ExportSlip)
        {
            try
            {
                ExportSlip _ExportSlip = GetExportSlipByID((string)ExportSlip.ExportSlipId);
                if (_ExportSlip == null)
                {
                    var myStockDB = new AgencyManagemntContext();
                    myStockDB.ExportSlips.Add(ExportSlip);
                    myStockDB.SaveChanges();
                }
                else
                {
                    throw new Exception("The ExportSlip is already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Update(ExportSlip ExportSlip)
        {
            try
            {
                ExportSlip c = GetExportSlipByID((string)ExportSlip.ExportSlipId);
                if (c != null)
                {
                    var myStockDB = new AgencyManagemntContext();
                    myStockDB.Entry<ExportSlip>(ExportSlip).State = EntityState.Modified;
                    myStockDB.SaveChanges();
                }
                else
                {
                    throw new Exception("The ExportSlip does not already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Remove(ExportSlip ExportSlip)
        {
            try
            {
                ExportSlip _ExportSlip = GetExportSlipByID((string)ExportSlip.ExportSlipId);
                if (_ExportSlip != null)
                {
                    var myStockDB = new AgencyManagemntContext();
                    myStockDB.ExportSlips.Remove(ExportSlip);
                    myStockDB.SaveChanges();
                }
                else
                {
                    throw new Exception("The ExportSlip does not already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
