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

    private void TbQuantity_PreviewTextInput(object sender, TextCompositionEventArgs e)
    {
        Regex regex = new Regex("[^0-9]+");
        e.Handled = regex.IsMatch(e.Text);
    }
}