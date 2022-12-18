using DataModels.Models;
using DataModels.Services;
using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Xml.Linq;

namespace AgencySystem.View.Pages;

public partial class AddingProduct : Page
{
    private Firestore firestore = new Firestore();
    public AddingProduct()
    {
        InitializeComponent();
    }
    private async void HandleAddItem(object sender, RoutedEventArgs e)
    {
        Item item  = new Item();
        item.ItemsId = await firestore.GetIdForObject(Utils.Collection.Items.ToString());
        item.ItemsName = TbItem.Text;
        item.UnitId = CbUnit.Text;
        item.Price = Convert.ToDouble(TbPrice.Text);
        firestore.AddData(Utils.Collection.Items.ToString(), item.ItemsId, item);
        MessageBox.Show("Thêm sản phẩm thành công", "Item Management");

    }
}