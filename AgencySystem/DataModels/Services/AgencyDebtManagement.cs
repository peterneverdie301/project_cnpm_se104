using DataModels.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Services
{
    public class AgencyDebtManagement
    {
        private static AgencyDebtManagement instance = null;
        private static readonly object instanceLock = new object();
        private AgencyDebtManagement() { }
        public static AgencyDebtManagement Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new AgencyDebtManagement();
                    }
                    return instance;
                }
            }
        }
        public IEnumerable<AgencyDebt> GetAgencyDebtList()
        {
            List<AgencyDebt> AgencyDebts;
            try
            {
                var myStockDB = new AgencyManagemntContext();
                AgencyDebts = myStockDB.AgencyDebts.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return AgencyDebts;
        }
        public AgencyDebt GetAgencyDebtByID(string AgencyDebtID)
        {
            AgencyDebt AgencyDebt = null;
            try
            {
                var myStockDB = new AgencyManagemntContext();
                AgencyDebt = myStockDB.AgencyDebts.SingleOrDefault(AgencyDebt => AgencyDebt.AgencyId == AgencyDebtID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return AgencyDebt;
        }
        public void AddNew(AgencyDebt AgencyDebt)
        {
            try
            {
                AgencyDebt _AgencyDebt = GetAgencyDebtByID((string)AgencyDebt.AgencyId);
                if (_AgencyDebt == null)
                {
                    var myStockDB = new AgencyManagemntContext();
                    myStockDB.AgencyDebts.Add(AgencyDebt);
                    myStockDB.SaveChanges();
                }
                else
                {
                    throw new Exception("The AgencyDebt is already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Update(AgencyDebt AgencyDebt)
        {
            try
            {
                AgencyDebt c = GetAgencyDebtByID((string)AgencyDebt.AgencyId);
                if (c != null)
                {
                    var myStockDB = new AgencyManagemntContext();
                    myStockDB.Entry<AgencyDebt>(AgencyDebt).State = EntityState.Modified;

                }
                else
                {
                    throw new Exception("The AgencyDebt does not already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Remove(AgencyDebt AgencyDebt)
        {
            try
            {
                AgencyDebt _AgencyDebt = GetAgencyDebtByID((string)AgencyDebt.AgencyId);
                if (_AgencyDebt != null)
                {
                    var myStockDB = new AgencyManagemntContext();
                    myStockDB.AgencyDebts.Remove(AgencyDebt);
                    myStockDB.SaveChanges();
                }
                else
                {
                    throw new Exception("The AgencyDebt does not already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
