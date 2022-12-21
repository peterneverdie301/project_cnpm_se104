using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using AgencySystem.View.Components;
using AgencySystem.View.MainWindow;
using DataModels.Models;
using DataModels.Services;

namespace AgencySystem.View.Pages;

public partial class ViewProduct : Page
{
    Firestore firestore = new Firestore();
    private List<object> listProduct;
    ListView listBoxProduct;
    public ViewProduct()
    {
        InitializeComponent();
        setUp();
    }

    private async void setUp()
    {
        listProduct = await firestore.GetAllDocument(Utils.Collection.Items.ToString());
        listBoxProduct = new ListView();
        foreach (Item item in listProduct)
        {
            if (item.ItemsName == null) continue;
            UcViewProduct ucInfo = new UcViewProduct();
            ucInfo.LbProduct.Content = item.ItemsName;
            ucInfo.LbId.Content = "Id: " + item.ItemsId;
            ucInfo.LbId.Tag= item.ItemsId;
            ucInfo.LbRequestId.Tag = item.ItemsId;
            ucInfo.LbPrice.Content = item.Price + " VNĐ";
            ucInfo.LbUnit.Content = item.UnitId;
            ucInfo.BtnDelete.Tag = ucInfo;
            ucInfo.BtnDelete.Click += BtnDelete_Click;
            ucInfo.BtnEdit.Tag = item;
            ucInfo.BtnEdit.Click += BtnEdit_Click;
            listBoxProduct.Items.Add(ucInfo);
        }
        ScViewProduct.Content = listBoxProduct;
    }
    private void BtnDelete_Click(object sender, RoutedEventArgs e)
    {
        Button btnDelete = sender as Button;
        UcViewProduct ucInfo = btnDelete?.Tag as UcViewProduct;
        listBoxProduct.Items.Remove(ucInfo);
        ScViewProduct.Content = listBoxProduct;
        firestore.DeleteData(Utils.Collection.Items.ToString(), ucInfo?.LbId.Tag.ToString());
        MessageBox.Show("Xóa thành công");
    }
    private void BtnEdit_Click(object sender, RoutedEventArgs e)
    {
        var btn = sender as Button;
        Item item = btn?.Tag as Item;
        ProductEdit productEdit = new ProductEdit();
        productEdit.TbProduct.Tag = item?.ItemsId;
        productEdit.TbProduct.Text = item?.ItemsName;
        productEdit.cbxUnit.SelectedItem = item?.UnitId;
        productEdit.TbPrice.Text = item?.Price.ToString();
        productEdit.Show();
    }
}