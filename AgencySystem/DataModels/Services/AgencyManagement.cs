using DataModels.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Services
{
    public class AgencyManagement
    {
        private static AgencyManagement instance = null;
        private static readonly object instanceLock = new object();
        private AgencyManagement() { }
        public static AgencyManagement Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new AgencyManagement();
                    }
                    return instance;
                }
            }
        }
        public IEnumerable<Agency> GetAgencyList()
        {
            List<Agency> Agencies;
            try
            {
                var myStockDB = new AgencyManagemntContext();
                Agencies = myStockDB.Agencies.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Agencies;
        }
        public Agency GetAgencyByID(string AgencyID)
        {
            Agency Agency = null;
            try
            {
                var myStockDB = new AgencyManagemntContext();
                Agency = myStockDB.Agencies.SingleOrDefault(Agency => Agency.AgencyId == AgencyID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Agency;
        }
        public void AddNew(Agency Agency)
        {
            try
            {
                Agency _Agency = GetAgencyByID((string)Agency.AgencyId);
                if (_Agency == null)
                {
                    var myStockDB = new AgencyManagemntContext();
                    myStockDB.Agencies.Add(Agency);
                    myStockDB.SaveChanges();
                }
                else
                {
                    throw new Exception("The Agency is already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Update(Agency Agency)
        {
            try
            {
                Agency c = GetAgencyByID((string)Agency.AgencyId);
                if (c != null)
                {
                    var myStockDB = new AgencyManagemntContext();
                    myStockDB.Entry<Agency>(Agency).State = EntityState.Modified;

                }
                else
                {
                    throw new Exception("The Agency does not already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Remove(Agency Agency)
        {
            try
            {
                Agency _Agency = GetAgencyByID((string)Agency.AgencyId);
                if (_Agency != null)
                {
                    var myStockDB = new AgencyManagemntContext();
                    myStockDB.Agencies.Remove(Agency);
                    myStockDB.SaveChanges();
                }
                else
                {
                    throw new Exception("The Agency does not already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
