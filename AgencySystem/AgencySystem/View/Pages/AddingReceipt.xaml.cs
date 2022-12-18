using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using DataModels.Models;
using DataModels.Services;

namespace AgencySystem.View.Pages;

public partial class AddingReceipt : Page
{
    private Firestore firestore = new Firestore();
    List<object> agences;
    public AddingReceipt()
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

    }

    private void Handle_Add(object sender, RoutedEventArgs e)
    {

    }
}