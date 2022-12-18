using DataModels.Models;
using DataModels.Services;
using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace AgencySystem.View.Pages;

public partial class AddingAgency : Page
{
    private Firestore firestore = new Firestore();
    public AddingAgency()
    {
        InitializeComponent();
    }

    private async void HandleAddAgency(object sender, RoutedEventArgs e)
    {
        Agency agency = new Agency();
        if(TbName.Text != "" && TbPhone.Text != "" && TbAddress.Text != "" && cbxType.Text != "" 
            && cbxDistrict.Text != "" && TbTime.Text != "")
        {
            agency.AgencyId = await firestore.GetIdForObject(Utils.Collection.Agency.ToString());
            agency.AgencyName = TbName.Text;
            agency.PhoneNumber = TbPhone.Text;
            agency.Address = TbAddress.Text;
            agency.TypeId = cbxType.Text;
            agency.DayReception = TbTime.Text.ToString();
            agency.District = cbxDistrict.Text;
            firestore.AddData(Utils.Collection.Agency.ToString(), agency.AgencyId, agency);
            MessageBox.Show("Thêm đại lý thành công", "Agency Management");
        }
        else
        {
            MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Agency Management");
        }
    }

    private void TbPhone_PreviewTextInput(object sender, TextCompositionEventArgs e)
    {
        Regex regex = new Regex("[^0-9]+");
        e.Handled = regex.IsMatch(e.Text);
    }
}