using DataModels.Models;
using Google.Cloud.Firestore;
using Google.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Services
{
    public class Utils
    {
        public enum Collection
        {
            Agency,
            AgencyDebt,
            DebtsReport,
            ExportSlip,
            ExportSlipDetail,
            Items,
            Receipt,
            TurnoverReport,
            Units,
            Reference,
            TypeOfAngency,
        }

        public static object ConvertData(string collection, DocumentSnapshot data)
        {
            switch (collection)
            {
                case "Agency":
                    return data.ConvertTo<Agency>();
                case "AgencyDebt":
                    return data.ConvertTo<AgencyDebt>();
                case "DebtsReport":
                    return data.ConvertTo<DebtsReport>();
                case "ExportSlip":
                    return data.ConvertTo<ExportSlip>();
                case "ExportSlipDetail":
                    return data.ConvertTo<ExportSlipDetail>();
                case "Items":
                    return data.ConvertTo<Item>();
                case "Receipt":
                    return data.ConvertTo<Receipt>();
                case "TurnoverReport":
                    return data.ConvertTo<TurnoverReport>();
                case "Units":
                    return data.ConvertTo<Unit>();
                case "Reference":
                    return data.ConvertTo<Reference>();
                case "TypeOfAngency":
                    return data.ConvertTo<TypeOfAgency>();
                default:
                    return null;
            }
        }

        public static string GetIdForObject (string collection, int lenght)
        {
            switch (collection)
            {
                case "Agency":
                    return "dl-" + lenght;
                case "AgencyDebt":
                    return "dl-" + lenght;
                //case "DebtsReport":
                //    return data.ConvertTo<DebtsReport>();
                //case "ExportSlip":
                //    return data.ConvertTo<ExportSlip>();
                //case "ExportSlipDetail":
                //    return data.ConvertTo<ExportSlipDetail>();
                //case "Items":
                //    return data.ConvertTo<Item>();
                //case "Receipt":
                //    return data.ConvertTo<Receipt>();
                //case "TurnoverReport":
                //    return data.ConvertTo<TurnoverReport>();
                //case "Units":
                //    return data.ConvertTo<Unit>();
                //case "Reference":
                //    return data.ConvertTo<Reference>();
                //case "TypeOfAngency":
                //    return data.ConvertTo<TypeOfAgency>();
                default:
                    return null;
            }
        }
        
    }
}
