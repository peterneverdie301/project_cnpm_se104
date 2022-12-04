using DataModels.Models;
using DataModels.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Repository
{
    public class ReceiptRepository
    {
        public static IEnumerable<Receipt> GetReceiptList() => ReceiptManagement.Instance.GetReceiptList();
        public static Receipt GetReceiptById(string Id) => ReceiptManagement.Instance.GetReceiptByID(Id);
        public static void AddNew(Receipt Receipt) => ReceiptManagement.Instance.AddNew(Receipt);
        public static void Update(Receipt Receipt) => ReceiptManagement.Instance.Update(Receipt);
        public static void Remove(Receipt Receipt) => ReceiptManagement.Instance.Remove(Receipt);
    }
}
