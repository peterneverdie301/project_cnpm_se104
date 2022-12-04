using DataModels.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Services
{
    public class ItemManagement
    {
        private static ItemManagement instance = null;
        private static readonly object instanceLock = new object();
        private ItemManagement() { }
        public static ItemManagement Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ItemManagement();
                    }
                    return instance;
                }
            }
        }
        public IEnumerable<Item> GetItemList()
        {
            List<Item> Items;
            try
            {
                var myStockDB = new AgencyManagemntContext();
                Items = myStockDB.Items.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Items;
        }
        public Item GetItemByID(string ItemID)
        {
            Item Item = null;
            try
            {
                var myStockDB = new AgencyManagemntContext();
                Item = myStockDB.Items.SingleOrDefault(Item => Item.ItemsId == ItemID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Item;
        }
        public void AddNew(Item Item)
        {
            try
            {
                Item _Item = GetItemByID((string)Item.ItemsId);
                if (_Item == null)
                {
                    var myStockDB = new AgencyManagemntContext();
                    myStockDB.Items.Add(Item);
                    myStockDB.SaveChanges();
                }
                else
                {
                    throw new Exception("The Item is already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Update(Item Item)
        {
            try
            {
                Item c = GetItemByID((string)Item.ItemsId);
                if (c != null)
                {
                    var myStockDB = new AgencyManagemntContext();
                    myStockDB.Entry<Item>(Item).State = EntityState.Modified;

                }
                else
                {
                    throw new Exception("The Item does not already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Remove(Item Item)
        {
            try
            {
                Item _Item = GetItemByID((string)Item.ItemsId);
                if (_Item != null)
                {
                    var myStockDB = new AgencyManagemntContext();
                    myStockDB.Items.Remove(Item);
                    myStockDB.SaveChanges();
                }
                else
                {
                    throw new Exception("The Item does not already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
