using DataModels.Models;
using DataModels.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Repository
{
    public class UnitRepository
    {
        public static IEnumerable<Unit> GetUnitList() => UnitManagement.Instance.GetUnitList();
        public static Unit GetUnitById(string Id) => UnitManagement.Instance.GetUnitByID(Id);
        public static void AddNew(Unit Unit) => UnitManagement.Instance.AddNew(Unit);
        public static void Update(Unit Unit) => UnitManagement.Instance.Update(Unit);
        public static void Remove(Unit Unit) => UnitManagement.Instance.Remove(Unit);
    }
}
