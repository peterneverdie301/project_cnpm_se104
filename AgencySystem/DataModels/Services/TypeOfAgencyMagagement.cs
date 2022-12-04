using DataModels.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Services
{
    public class TypeOfAgencyMagagement
    {
        private static TypeOfAgencyMagagement instance = null;
        private static readonly object instanceLock = new object();
        private TypeOfAgencyMagagement() { }
        public static TypeOfAgencyMagagement Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new TypeOfAgencyMagagement();
                    }
                    return instance;
                }
            }
        }
        public IEnumerable<TypeOfAgency> GetTypeOfAgencyList()
        {
            List<TypeOfAgency> TypeOfAgencys;
            try
            {
                var myStockDB = new AgencyManagemntContext();
                TypeOfAgencys = myStockDB.TypeOfAgencies.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return TypeOfAgencys;
        }
        public TypeOfAgency GetTypeOfAgencyByID(int Type)
        {
            TypeOfAgency TypeOfAgency = null;
            try
            {
                var myStockDB = new AgencyManagemntContext();
                TypeOfAgency = myStockDB.TypeOfAgencies.SingleOrDefault(TypeOfAgency => TypeOfAgency.Type == Type);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return TypeOfAgency;
        }
        public void AddNew(TypeOfAgency TypeOfAgency)
        {
            try
            {
                TypeOfAgency _TypeOfAgency = GetTypeOfAgencyByID((int)TypeOfAgency.Type);
                if (_TypeOfAgency == null)
                {
                    var myStockDB = new AgencyManagemntContext();
                    myStockDB.TypeOfAgencies.Add(TypeOfAgency);
                    myStockDB.SaveChanges();
                }
                else
                {
                    throw new Exception("The TypeOfAgency is already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Update(TypeOfAgency TypeOfAgency)
        {
            try
            {
                TypeOfAgency c = GetTypeOfAgencyByID((int)TypeOfAgency.Type);
                if (c != null)
                {
                    var myStockDB = new AgencyManagemntContext();
                    myStockDB.Entry<TypeOfAgency>(TypeOfAgency).State = EntityState.Modified;

                }
                else
                {
                    throw new Exception("The TypeOfAgency does not already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Remove(TypeOfAgency TypeOfAgency)
        {
            try
            {
                TypeOfAgency _TypeOfAgency = GetTypeOfAgencyByID((int)TypeOfAgency.Type);
                if (_TypeOfAgency != null)
                {
                    var myStockDB = new AgencyManagemntContext();
                    myStockDB.TypeOfAgencies.Remove(TypeOfAgency);
                    myStockDB.SaveChanges();
                }
                else
                {
                    throw new Exception("The TypeOfAgency does not already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
