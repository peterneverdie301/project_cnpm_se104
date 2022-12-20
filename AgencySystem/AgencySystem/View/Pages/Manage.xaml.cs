using System;
using System.Collections.Generic;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Xml.Linq;
using DataModels.Models;
using DataModels.Services;

namespace AgencySystem.View.Pages;

public partial class Manage : Page
{
    private Firestore firestore = new Firestore();
    List<object> types;
    List<object> units;
    public Manage()
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
                CbTypeList.Items.Add(type.Type);
            }
        }

        units = new List<object>();
        units = await firestore.GetAllDocument(Utils.Collection.Units.ToString());
        foreach (Unit unit in units)
        {
            if (unit.Value != null)
            {
                CbUnitList.Items.Add(unit.Value);
            }
        }
    }
    private async void HandleAddType(object sender, RoutedEventArgs e)
    {
        TypeOfAgency typeOfAgency = new TypeOfAgency();
        if (TbType.Text != "" && TbDebt.Text != "")
        {
            typeOfAgency.Id = TbType.Text;
            typeOfAgency.Type = Convert.ToInt16(TbType.Text);
            typeOfAgency.MaxDebt = Convert.ToDouble(TbDebt.Text);
            firestore.AddData(Utils.Collection.TypeOfAngency.ToString(), typeOfAgency.Id, typeOfAgency);
            MessageBox.Show("Thêm loại đại lý thành công", "Agency Management");
        }
        else
        {
            MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Agency Management");
        }
    }
    private async void HandleAddUnit(object sender, RoutedEventArgs e)
    {
        Unit unit = new Unit();
        if (TbUnit.Text != "")
        {
            unit.Id = TbUnit.Text;
            unit.Value = TbUnit.Text;
            firestore.AddData(Utils.Collection.Units.ToString(), unit.Id, unit);
            MessageBox.Show("Thêm đơn vị tính thành công", "Agency Management");
        }
        else
        {
            MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Agency Management");
        }
    }
    private async void HandleRemoveType(object sender, RoutedEventArgs e)
    {
            TypeOfAgency typeOfAgency = new TypeOfAgency();
            typeOfAgency.Id = TbType.Text;
            firestore.DeleteData(Utils.Collection.TypeOfAngency.ToString(), typeOfAgency.Id);
            MessageBox.Show("Xóa loại đại lý thành công", "Agency Management");
    }
    private async void HandleRemoveUnit(object sender, RoutedEventArgs e)
    {
        Unit unit = new Unit();
        unit.Id = TbUnit.Text;
        firestore.DeleteData(Utils.Collection.Units.ToString(), unit.Id);
        MessageBox.Show("Xóa đơn vị tính thành công", "Agency Management");
    }
    private void TbType_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
    {
        Regex regex = new Regex("[^0-9]+");
        e.Handled = regex.IsMatch(e.Text);
    }

    private void TbDebt_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
    {
        Regex regex = new Regex("[^0-9]+");
        e.Handled = regex.IsMatch(e.Text);
    }

}