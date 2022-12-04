using DataModels.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Services
{
    public class ReferenceManagement
    {
        private static ReferenceManagement instance = null;
        private static readonly object instanceLock = new object();
        private ReferenceManagement() { }
        public static ReferenceManagement Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ReferenceManagement();
                    }
                    return instance;
                }
            }
        }
        public IEnumerable<Reference> GetReferenceList()
        {
            List<Reference> References;
            try
            {
                var myStockDB = new AgencyManagemntContext();
                References = myStockDB.References.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return References;
        }
        public Reference GetReferenceByID(string ReferenceID)
        {
            Reference Reference = null;
            try
            {
                var myStockDB = new AgencyManagemntContext();
                Reference = myStockDB.References.SingleOrDefault(Reference => Reference.Name == ReferenceID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Reference;
        }
        public void AddNew(Reference Reference)
        {
            try
            {
                Reference _Reference = GetReferenceByID((string)Reference.Name);
                if (_Reference == null)
                {
                    var myStockDB = new AgencyManagemntContext();
                    myStockDB.References.Add(Reference);
                    myStockDB.SaveChanges();
                }
                else
                {
                    throw new Exception("The Reference is already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Update(Reference Reference)
        {
            try
            {
                Reference c = GetReferenceByID((string)Reference.Name);
                if (c != null)
                {
                    var myStockDB = new AgencyManagemntContext();
                    myStockDB.Entry<Reference>(Reference).State = EntityState.Modified;
                    myStockDB.SaveChanges();
                }
                else
                {
                    throw new Exception("The Reference does not already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Remove(Reference Reference)
        {
            try
            {
                Reference _Reference = GetReferenceByID((string)Reference.Name);
                if (_Reference != null)
                {
                    var myStockDB = new AgencyManagemntContext();
                    myStockDB.References.Remove(Reference);
                    myStockDB.SaveChanges();
                }
                else
                {
                    throw new Exception("The Reference does not already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
