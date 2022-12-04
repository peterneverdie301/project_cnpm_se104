using DataModels.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Services
{
    public class ReceiptManagement
    {
        private static ReceiptManagement instance = null;
        private static readonly object instanceLock = new object();
        private ReceiptManagement() { }
        public static ReceiptManagement Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ReceiptManagement();
                    }
                    return instance;
                }
            }
        }
        public IEnumerable<Receipt> GetReceiptList()
        {
            List<Receipt> Receipts;
            try
            {
                var myStockDB = new AgencyManagemntContext();
                Receipts = myStockDB.Receipts.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Receipts;
        }
        public Receipt GetReceiptByID(string ReceiptID)
        {
            Receipt Receipt = null;
            try
            {
                var myStockDB = new AgencyManagemntContext();
                Receipt = myStockDB.Receipts.SingleOrDefault(Receipt => Receipt.ReceiptId == ReceiptID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Receipt;
        }
        public void AddNew(Receipt Receipt)
        {
            try
            {
                Receipt _Receipt = GetReceiptByID((string)Receipt.ReceiptId);
                if (_Receipt == null)
                {
                    var myStockDB = new AgencyManagemntContext();
                    myStockDB.Receipts.Add(Receipt);
                    myStockDB.SaveChanges();
                }
                else
                {
                    throw new Exception("The Receipt is already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Update(Receipt Receipt)
        {
            try
            {
                Receipt c = GetReceiptByID((string)Receipt.ReceiptId);
                if (c != null)
                {
                    var myStockDB = new AgencyManagemntContext();
                    myStockDB.Entry<Receipt>(Receipt).State = EntityState.Modified;

                }
                else
                {
                    throw new Exception("The Receipt does not already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Remove(Receipt Receipt)
        {
            try
            {
                Receipt _Receipt = GetReceiptByID((string)Receipt.ReceiptId);
                if (_Receipt != null)
                {
                    var myStockDB = new AgencyManagemntContext();
                    myStockDB.Receipts.Remove(Receipt);
                    myStockDB.SaveChanges();
                }
                else
                {
                    throw new Exception("The Receipt does not already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
