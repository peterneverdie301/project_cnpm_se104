using DataModels.Models;
using DataModels.Services;
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
        item.ItemsId = "mh-1";
        item.ItemsName = TbItem.Text;
        item.UnitId = TbPhone.Text;
        item.Price = TbAddress.Text;
        firestore.AddData(Utils.Collection.Items.ToString(), item.ItemsId, item);
        MessageBox.Show("Thêm công ty thành công", "item Management");

    }
}