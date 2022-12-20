using DataModels.Models;
using DataModels.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AgencySystem.View.Pages;

public partial class AddingExportSlip : Page
{
    private Firestore firestore = new Firestore();
    List<object> agences;
    List<object> products;
    List<object> units;
    List<ProductDetail> productDetails = new List<ProductDetail>();
    public AddingExportSlip()
    {
        InitializeComponent();
        setUp();
    }
    private async void setUp()
    {
        agences = new List<object>();
        agences = await firestore.GetAllDocument(Utils.Collection.Agency.ToString());
        foreach (Agency agency in agences)
        {
            if (agency.AgencyName != null)
            {
                cbxAgency.Items.Add(agency.AgencyName);
            }
        }
        products = new List<object>();
        products = await firestore.GetAllDocument(Utils.Collection.Items.ToString());
        foreach (Item item in products)
        {
            if (item.ItemsName != null)
            {
                CbProduct.Items.Add(item.ItemsName);
            }
        }
        units = new List<object>();
        units = await firestore.GetAllDocument(Utils.Collection.Units.ToString());
        foreach (Unit unit in units)
        {
            if (unit.Value != null)
            {
                CbUnit.Items.Add(unit.Value);
            }
        }
    }
    
    // Add data to database
    private async void BtAddData_Click(object sender, RoutedEventArgs e)
    {
        if (cbxAgency.Text == "" || TbDate.Text == "" || productDetails.Count == 0)
        {
            MessageBox.Show("Bạn chưa nhập thông tin");
            return;
        }
        Agency agency = (Agency)agences.Find((value) =>
        {
            Agency data = (Agency)value;
            return data.AgencyName == cbxAgency.Text;
        });

        ExportSlip exportSlip = new ExportSlip()
        {
            AgencyId = agency.AgencyId,
            Date = TbDate.Text,
            AmountPaid = double.Parse(TbPaid.Text),
            ExportSlipId = await firestore.GetIdForObject(Utils.Collection.ExportSlip.ToString()),
        };
        firestore.AddData(Utils.Collection.ExportSlip.ToString(), exportSlip.ExportSlipId, exportSlip);
        foreach (var item in productDetails)
        {
            Item product = (Item)products.Find((value) =>
            {
                Item data = value as Item;
                return data.ItemsName == CbProduct.Text;
            });
            ExportSlipDetail detail = new ExportSlipDetail()
            {
                Amount = item.Quantity,
                ExportSlipId = exportSlip.ExportSlipId,
                ItemsId = product?.ItemsId,
            };
            firestore.AddData(Utils.Collection.ExportSlipDetail.ToString(), exportSlip.ExportSlipId + "-" + item.Id, detail);
        }
        MessageBox.Show("Thêm dữ liệu thành công");
    }

    //Add product into table
    private void BtAddProduct_Click(object sender, RoutedEventArgs e)
    {
        if (CbProduct.Text == "" || CbUnit.Text == "" || TbQuantity.Text == "")
        {
            MessageBox.Show("Vui lòng điền đầy đủ thông tin");
            return;
        }
        Item item = (Item)products.Find((value) =>
        {
            Item data = value as Item;
            return data?.ItemsName == CbProduct.Text;
        });
        ProductDetail productDetail = new ProductDetail()
        {
            Id = item.ItemsId,
            Product = item.ItemsName,
            Quantity = int.Parse(TbQuantity.Text),
            Unit = CbUnit.Text,
            UnitPrice = item.Price,
            LastPrice = item.Price * int.Parse(TbQuantity.Text),
        };
        CbUnit.Text = "";
        CbProduct.Text = "";
        TbQuantity.Text = "";
        LbTotal.Content = double.Parse(LbTotal.Content.ToString()) + productDetail.LastPrice;
        productDetails.Add(productDetail);
        lvProduct.Items.Add(productDetail);
    }

    //Check condition
    private void TbQuantity_PreviewTextInput(object sender, TextCompositionEventArgs e)
    {
        Regex regex = new Regex("[^0-9]+");
        e.Handled = regex.IsMatch(e.Text);
    }

    //Caculate money
    private void TbPaid_TextChanged(object sender, TextChangedEventArgs e)
    {
        TextBox textBox = sender as TextBox;
        if (textBox.Text != "")
        {
            LbRemaining.Content = double.Parse(LbTotal.Content.ToString()) - double.Parse(textBox.Text);
        } else
        {
            LbRemaining.Content = double.Parse(LbTotal.Content.ToString());
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