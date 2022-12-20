using DataModels.Models;
using DataModels.Services;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Xml.Linq;

namespace AgencySystem.View.Pages;

public partial class AddingProduct : Page
{
    private Firestore firestore = new Firestore();
    List<object> units;
    public AddingProduct()
    {
        InitializeComponent();
        setUp();
    }
    private async void setUp()
    {
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
    private async void HandleAddItem(object sender, RoutedEventArgs e)
    {
        Item item  = new Item();
        if(TbItem.Text != "" && CbUnit.Text != "" && TbPrice.Text != "")
        {
            item.ItemsId = await firestore.GetIdForObject(Utils.Collection.Items.ToString());
            item.ItemsName = TbItem.Text;
            item.UnitId = CbUnit.Text;
            item.Price = Convert.ToDouble(TbPrice.Text);
            firestore.AddData(Utils.Collection.Items.ToString(), item.ItemsId, item);
            MessageBox.Show("Thêm sản phẩm thành công", "Item Management");
        }
        else{
            MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Item Management");
        }
    }

    private void TbQuantity_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
    {
        Regex regex = new Regex("[^0-9]+");
        e.Handled = regex.IsMatch(e.Text);
    }

    private void TbPrice_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
    {
        Regex regex = new Regex("[^0-9]+");
        e.Handled = regex.IsMatch(e.Text);
    }
}