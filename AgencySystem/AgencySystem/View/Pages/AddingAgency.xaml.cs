using DataModels.Models;
using DataModels.Services;
using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace AgencySystem.View.Pages;

public partial class AddingAgency : Page
{
    private Firestore firestore = new Firestore();
    List<object> types;
    public AddingAgency()
    {
        InitializeComponent();
        setUp();
    }
    private async void setUp()
    {
        types = new List<object>();
        types = await firestore.GetAllDocument(Utils.Collection.TypeOfAngency.ToString());
        foreach (TypeOfAgency type in types)
        {
            if (type.Type != null)
            {
                cbxType.Items.Add(type.Type);
            }
        }

    }

    private async void addAgency(Reference reference, string districtId)
    {
        Agency agency = new Agency();
        if (TbName.Text != "" && TbPhone.Text != "" && TbAddress.Text != "" && cbxType.Text != ""
            && cbxDistrict.Text != "" && TbTime.Text != "")
        {
            agency.AgencyId = await firestore.GetIdForObject(Utils.Collection.Agency.ToString());
            agency.AgencyName = TbName.Text;
            agency.PhoneNumber = TbPhone.Text;
            agency.Address = TbAddress.Text;
            agency.TypeId = cbxType.Text;
            agency.DayReception = TbTime.Text.ToString();
            agency.District = cbxDistrict.Text;
            reference.Current += 1;
            firestore.UpdateData(Utils.Collection.Reference.ToString(), districtId, reference);
            firestore.AddData(Utils.Collection.Agency.ToString(), agency.AgencyId, agency);
            MessageBox.Show("Thêm đại lý thành công", "Agency Management");
        }
        else
        {
            MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Agency Management");
        }
    }

    private async void HandleAddAgency(object sender, RoutedEventArgs e)
    {
        string districtId = String.Concat(cbxDistrict.Text.Where(c => !Char.IsWhiteSpace(c)));
        Reference reference = await firestore.GetData(Utils.Collection.Reference.ToString(), districtId) as Reference;
        if (reference != null)
        {
            if (reference.Current < reference.Max)
            {
                addAgency(reference, districtId);

            } else
            {
                MessageBox.Show("Số lượng đại lý tối đa trong quận " + reference.Name + "không được vượt quá " + reference.Max);
            }
        } else
        {
            reference = new Reference();
            reference.Current = 0;
            reference.Name = cbxDistrict.Text;
            reference.Max = 4;
            reference.Id = districtId;
            addAgency(reference, districtId);
        }

        
    }

    private void TbPhone_PreviewTextInput(object sender, TextCompositionEventArgs e)
    {
        Regex regex = new Regex("[^0-9]+");
        e.Handled = regex.IsMatch(e.Text);
    }
}