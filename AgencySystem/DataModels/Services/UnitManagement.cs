using DataModels.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Services
{
    public class UnitManagement
    {
        private static UnitManagement instance = null;
        private static readonly object instanceLock = new object();
        private UnitManagement() { }
        public static UnitManagement Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new UnitManagement();
                    }
                    return instance;
                }
            }
        }
        public IEnumerable<Unit> GetUnitList()
        {
            List<Unit> Units;
            try
            {
                var myStockDB = new AgencyManagemntContext();
                Units = myStockDB.Units.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Units;
        }
        public Unit GetUnitByID(string UnitID)
        {
            Unit Unit = null;
            try
            {
                var myStockDB = new AgencyManagemntContext();
                Unit = myStockDB.Units.SingleOrDefault(Unit => Unit.Id == UnitID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Unit;
        }
        public void AddNew(Unit Unit)
        {
            try
            {
                Unit _Unit = GetUnitByID((string)Unit.Id);
                if (_Unit == null)
                {
                    var myStockDB = new AgencyManagemntContext();
                    myStockDB.Units.Add(Unit);
                    myStockDB.SaveChanges();
                }
                else
                {
                    throw new Exception("The Unit is already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Update(Unit Unit)
        {
            try
            {
                Unit c = GetUnitByID((string)Unit.Id);
                if (c != null)
                {
                    var myStockDB = new AgencyManagemntContext();
                    myStockDB.Entry<Unit>(Unit).State = EntityState.Modified;
                    myStockDB.SaveChanges();
                }
                else
                {
                    throw new Exception("The Unit does not already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Remove(Unit Unit)
        {
            try
            {
                Unit _Unit = GetUnitByID((string)Unit.Id);
                if (_Unit != null)
                {
                    var myStockDB = new AgencyManagemntContext();
                    myStockDB.Units.Remove(Unit);
                    myStockDB.SaveChanges();
                }
                else
                {
                    throw new Exception("The Unit does not already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
