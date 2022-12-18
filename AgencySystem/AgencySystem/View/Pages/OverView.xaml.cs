using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using AgencySystem.View.Components;
using AgencySystem.View.MainWindow;
using DataModels.Models;
using DataModels.Services;

namespace AgencySystem.View.Pages;

public partial class OverView : Page
{
    Firestore firestore = new Firestore();
    private List<object> listAgency;
    ListView listBoxAgency;
    public OverView()
    {
        InitializeComponent();
        setUp();

    }

    private async void setUp()
    {
        listAgency = await firestore.GetAllDocument(Utils.Collection.Agency.ToString());
        listBoxAgency = new ListView();
        foreach (Agency agency in listAgency)
        {
            if (agency.AgencyName == null) continue;
            UcInfoAgency ucInfo = new UcInfoAgency();
            ucInfo.LbName.Content = agency.AgencyName;
            ucInfo.LbCustomerId.Content = "Id: "  + agency.AgencyId;
            ucInfo.LbCustomerId.Tag = agency.AgencyId;
            ucInfo.LbDistrictOfAgency.Content = agency.District;
            //ucInfo.LbTypeOfAgency.Content = agency.TypeId;
            ucInfo.LbDebt.Content = "10000$";
            ucInfo.btnDelete.Tag = ucInfo;
            ucInfo.btnDelete.Click += BtnDelete_Click;
            ucInfo.btnEdit.Click += BtnEdit_Click;
            listBoxAgency.Items.Add(ucInfo);
        }
        viewAgency.Content = listBoxAgency;
    }

    private void BtnEdit_Click(object sender, RoutedEventArgs e)
    {
        AgencyEdit agencyEdit = new AgencyEdit();
        agencyEdit.Show();
    }

    private void BtnDelete_Click(object sender, RoutedEventArgs e)
    {
        Button btnDelete = sender as Button;
        UcInfoAgency ucInfo = btnDelete?.Tag as UcInfoAgency;
        listBoxAgency.Items.Remove(ucInfo);
        viewAgency.Content = listBoxAgency;
        firestore.DeleteData(Utils.Collection.Agency.ToString(), ucInfo?.LbCustomerId.Tag.ToString());
        MessageBox.Show("Xóa thành công");
    }
}