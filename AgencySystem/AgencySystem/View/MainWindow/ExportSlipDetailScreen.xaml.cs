using DataModels.Models;
using DataModels.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AgencySystem.View.MainWindow
{
    /// <summary>
    /// Interaction logic for ExportSlipDetail.xaml
    /// </summary>
    public partial class ExportSlipDetailScreen : Window
    {
        private List<object> listDetail;
        private List<object> listDataProduct;
        string exportSlipId;
        Firestore firestore = new Firestore();
        public ExportSlipDetailScreen(string exportSlipId)
        {

            InitializeComponent();
            this.exportSlipId = exportSlipId;
            setUp();
        }

        private async void setUp()
        {
            listDetail = await firestore.GetAllDocument(Utils.Collection.ExportSlipDetail.ToString());
            listDataProduct = await firestore.GetAllDocument(Utils.Collection.Items.ToString());
            foreach (var value in listDetail)
            {
                ExportSlipDetail exportSlipDetail = value as ExportSlipDetail;
                if (exportSlipDetail != null && exportSlipDetail.ExportSlipId == exportSlipId)
                {
                    Item product = (Item)listDataProduct.Find((value) =>
                    {
                        Item item = value as Item;
                        return item.ItemsId == exportSlipDetail.ItemsId;
                    });
                    if (product == null) continue;
                    ProductDetail detail = new ProductDetail()
                    {
                        Id = exportSlipDetail.ItemsId,
                        Quantity = int.Parse(exportSlipDetail.Amount.ToString()),
                        Product = product.ItemsName,
                        Unit = product.UnitId,
                        UnitPrice = product.Price * 1.02,
                        LastPrice = product.Price * 1.02 * int.Parse(exportSlipDetail.Amount.ToString()),
                    };
                    lvProduct.Items.Add(detail);
                } else
                {
                    continue;
                }
            }
        }

        private class ProductDetail
        {
            public string Id { get; set; }

            public string Product { get; set; }

            public int Quantity { get; set; }

            public string Unit { get; set; }

            public double UnitPrice { get; set; }

            public double LastPrice { get; set; }

        }
    }

}
