using System;
using System.Collections.Generic;
using System.Linq;
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
            ucInfo.LbTypeOfAgency.Content = agency.TypeId;
            ucInfo.LbPhone.Content = agency.PhoneNumber;
            ucInfo.btnDelete.Tag = ucInfo;
            ucInfo.btnDelete.Click += BtnDelete_Click;
            ucInfo.btnEdit.Tag = agency;
            ucInfo.btnEdit.Click += BtnEdit_Click;
            listBoxAgency.Items.Add(ucInfo);
        }
        viewAgency.Content = listBoxAgency;
    }

    private void BtnEdit_Click(object sender, RoutedEventArgs e)
    {
        var btn = sender as Button;
        Agency agency = btn?.Tag as Agency;
        AgencyEdit agencyEdit = new AgencyEdit();
        agencyEdit.TbName.Tag = agency?.AgencyId;
        agencyEdit.TbName.Text = agency?.AgencyName;
        agencyEdit.TbPhone.Text = agency?.PhoneNumber;
        agencyEdit.TbAddress.Text = agency?.Address;
        agencyEdit.TbTime.Text = agency?.DayReception;
        agencyEdit.cbxType.Text = agency?.TypeId;
        agencyEdit.cbxDistrict.Text = agency?.District;
        agencyEdit.Closed += AgencyEdit_Closed;
        agencyEdit.Show();
    }

    private void AgencyEdit_Closed(object? sender, EventArgs e)
    {
        // Do later
    }

    private async void BtnDelete_Click(object sender, RoutedEventArgs e)
    {
        Button btnDelete = sender as Button;
        UcInfoAgency ucInfo = btnDelete?.Tag as UcInfoAgency;
        listBoxAgency.Items.Remove(ucInfo);
        viewAgency.Content = listBoxAgency;
        firestore.DeleteData(Utils.Collection.Agency.ToString(), ucInfo?.LbCustomerId.Tag.ToString());
        string districtId = String.Concat(ucInfo.LbDistrictOfAgency.Content.ToString().Where(c => !Char.IsWhiteSpace(c)));
        Reference reference = await firestore.GetData(Utils.Collection.Reference.ToString(), districtId) as Reference;
        reference.Current -= 1;
        firestore.UpdateData(Utils.Collection.Reference.ToString(), districtId, reference);
        MessageBox.Show("Xóa thành công");
    }
}