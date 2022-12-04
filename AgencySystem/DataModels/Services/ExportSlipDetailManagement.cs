using DataModels.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Services
{
    public class ExportSlipDetailManagement
    {
        private static ExportSlipDetailManagement instance = null;
        private static readonly object instanceLock = new object();
        private ExportSlipDetailManagement() { }
        public static ExportSlipDetailManagement Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ExportSlipDetailManagement();
                    }
                    return instance;
                }
            }
        }
        public IEnumerable<ExportSlipDetail> GetExportSlipDetailList()
        {
            List<ExportSlipDetail> ExportSlipDetails;
            try
            {
                var myStockDB = new AgencyManagemntContext();
                ExportSlipDetails = myStockDB.ExportSlipDetails.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return ExportSlipDetails;
        }
        public ExportSlipDetail GetExportSlipDetailByID(string ExportSlipDetailID)
        {
            ExportSlipDetail ExportSlipDetail = null;
            try
            {
                var myStockDB = new AgencyManagemntContext();
                ExportSlipDetail = myStockDB.ExportSlipDetails.SingleOrDefault(ExportSlipDetail => ExportSlipDetail.ExportSlipId == ExportSlipDetailID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return ExportSlipDetail;
        }
        public void AddNew(ExportSlipDetail ExportSlipDetail)
        {
            try
            {
                ExportSlipDetail _ExportSlipDetail = GetExportSlipDetailByID((string)ExportSlipDetail.ExportSlipId);
                if (_ExportSlipDetail == null)
                {
                    var myStockDB = new AgencyManagemntContext();
                    myStockDB.ExportSlipDetails.Add(ExportSlipDetail);
                    myStockDB.SaveChanges();
                }
                else
                {
                    throw new Exception("The ExportSlipDetail is already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Update(ExportSlipDetail ExportSlipDetail)
        {
            try
            {
                ExportSlipDetail c = GetExportSlipDetailByID((string)ExportSlipDetail.ExportSlipId);
                if (c != null)
                {
                    var myStockDB = new AgencyManagemntContext();
                    myStockDB.Entry<ExportSlipDetail>(ExportSlipDetail).State = EntityState.Modified;
                    myStockDB.SaveChanges();
                }
                else
                {
                    throw new Exception("The ExportSlipDetail does not already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Remove(ExportSlipDetail ExportSlipDetail)
        {
            try
            {
                ExportSlipDetail _ExportSlipDetail = GetExportSlipDetailByID((string)ExportSlipDetail.ExportSlipId);
                if (_ExportSlipDetail != null)
                {
                    var myStockDB = new AgencyManagemntContext();
                    myStockDB.ExportSlipDetails.Remove(ExportSlipDetail);
                    myStockDB.SaveChanges();
                }
                else
                {
                    throw new Exception("The ExportSlipDetail does not already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
