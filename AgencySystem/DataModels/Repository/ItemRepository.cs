using DataModels.Models;
using DataModels.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Repository
{
    public class ItemRepository
    {
        public static IEnumerable<Item> GetItemList() => ItemManagement.Instance.GetItemList();
        public static Item GetItemById(string Id) => ItemManagement.Instance.GetItemByID(Id);
        public static void AddNew(Item Item) => ItemManagement.Instance.AddNew(Item);
        public static void Update(Item Item) => ItemManagement.Instance.Update(Item);
        public static void Remove(Item Item) => ItemManagement.Instance.Remove(Item);
    }
}
