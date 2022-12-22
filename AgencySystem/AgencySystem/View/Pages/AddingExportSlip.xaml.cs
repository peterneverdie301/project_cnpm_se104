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
                Label lbl = new Label();
                lbl.Content = agency.AgencyName;
                lbl.Tag = agency;
                cbxAgency.Items.Add(lbl);
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
        //units = new List<object>();
        //units = await firestore.GetAllDocument(Utils.Collection.Units.ToString());
        //foreach (Unit unit in units)
        //{
        //    if (unit.Value != null)
        //    {
        //        CbUnit.Items.Add(unit.Value);
        //    }
        //}
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
            return data.AgencyId == lbAgencyId.Content.ToString();
        });

        // Adding export slip
        ExportSlip exportSlip = new ExportSlip()
        {
            AgencyId = agency.AgencyId,
            Date = TbDate.Text,
            AmountPaid = double.Parse(TbPaid.Text),
            ExportSlipId = await firestore.GetIdForObject(Utils.Collection.ExportSlip.ToString()),
            Total = double.Parse(LbTotal.Content.ToString()),
            TotalItems = productDetails.Count,
        };
        firestore.AddData(Utils.Collection.ExportSlip.ToString(), exportSlip.ExportSlipId, exportSlip);

        //Adding export slip detail
        foreach (var item in productDetails)
        {
            ExportSlipDetail detail = new ExportSlipDetail()
            {
                Amount = item.Quantity,
                ExportSlipId = exportSlip.ExportSlipId,
                ItemsId = item.Id,
            };
            firestore.AddData(Utils.Collection.ExportSlipDetail.ToString(), exportSlip.ExportSlipId + "-" + item.Id, detail);
        }

        //Chang debt agency if has
        var docId = TbDate.DisplayDate.Month + "-" + TbDate.DisplayDate.Year + "-" + agency.AgencyId;

        var dataDebt = await firestore.GetData(Utils.Collection.AgencyDebt.ToString(), docId) as AgencyDebt;
        if (dataDebt != null)
        {
            dataDebt.Incurred += double.Parse(LbRemaining.Content.ToString());
            firestore.UpdateData(Utils.Collection.AgencyDebt.ToString(), docId, dataDebt);
        } else
        {
            dataDebt = new AgencyDebt();
            dataDebt.Month = TbDate.DisplayDate.Month;
            dataDebt.Year = TbDate.DisplayDate.Year;
            dataDebt.AgencyId = agency.AgencyId;
            dataDebt.FirsDebt = double.Parse(LbRemaining.Content.ToString());
            dataDebt.Incurred = 0;
            firestore.AddData(Utils.Collection.AgencyDebt.ToString(), docId, dataDebt);
        }

        MessageBox.Show("Thêm dữ liệu thành công");
    }

    //Add product into table
    private void BtAddProduct_Click(object sender, RoutedEventArgs e)
    {
        if (CbProduct.Text == "" || TbQuantity.Text == "")
        {
            MessageBox.Show("Vui lòng điền đầy đủ thông tin");
            return;
        }
        Item item = (Item)products.Find((value) =>
        {
            Item data = value as Item;
            return data?.ItemsName == CbProduct.SelectedItem;
        });
        ProductDetail productDetail = new ProductDetail()
        {
            Id = item.ItemsId,
            Product = item.ItemsName,
            Quantity = int.Parse(TbQuantity.Text),
            Unit = CbUnit.Content?.ToString(),
            UnitPrice = item.Price * 1.02,
            LastPrice = item.Price * 1.02  * int.Parse(TbQuantity.Text),
        };
        CbUnit.Content = "";
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
            if(double.Parse(textBox.Text) <= double.Parse(LbTotal.Content.ToString()))
            {
                LbRemaining.Content = double.Parse(LbTotal.Content.ToString()) - double.Parse(textBox.Text);
            } else
            {
                MessageBox.Show("Tiền trả không được vượt quá tổng tiền");
            }
        } else
        {
            LbRemaining.Content = double.Parse(LbTotal.Content.ToString());
        }  
    }

    private void CbProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        ComboBox comboBox = sender as ComboBox;
        Item sp = (Item)products.Find((value) =>
        {
            Item temp = value as Item;
            return temp.ItemsName == comboBox.SelectedItem;
        });
        CbUnit.Content = sp?.UnitId;
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

    private void cbxAgency_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        Label label = e.AddedItems[0] as Label;
        Agency agency = label.Tag as Agency;
        lbAgencyId.Content = agency.AgencyId;
    }
}