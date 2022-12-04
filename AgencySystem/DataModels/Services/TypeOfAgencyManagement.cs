using DataModels.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Services
{
    public class TypeOfAgencyManagement
    {
        private static TypeOfAgencyManagement instance = null;
        private static readonly object instanceLock = new object();
        private TypeOfAgencyManagement() { }
        public static TypeOfAgencyManagement Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new TypeOfAgencyManagement();
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
        public TypeOfAgency GetTypeOfAgencyByID(string Id)
        {
            TypeOfAgency TypeOfAgency = null;
            try
            {
                var myStockDB = new AgencyManagemntContext();
                TypeOfAgency = myStockDB.TypeOfAgencies.SingleOrDefault(TypeOfAgency => TypeOfAgency.Id == Id);
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
                TypeOfAgency _TypeOfAgency = GetTypeOfAgencyByID((string)TypeOfAgency.Id);
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
                TypeOfAgency c = GetTypeOfAgencyByID((string)TypeOfAgency.Id);
                if (c != null)
                {
                    var myStockDB = new AgencyManagemntContext();
                    myStockDB.Entry<TypeOfAgency>(TypeOfAgency).State = EntityState.Modified;
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
        public void Remove(TypeOfAgency TypeOfAgency)
        {
            try
            {
                TypeOfAgency _TypeOfAgency = GetTypeOfAgencyByID((string)TypeOfAgency.Id);
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
