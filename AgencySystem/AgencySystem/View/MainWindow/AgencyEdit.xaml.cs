using AgencySystem.View.Components;
using AgencySystem.View.Pages;
using DataModels.Models;
using DataModels.Services;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace AgencySystem.View.MainWindow;

public partial class AgencyEdit : Window
{
    Firestore firestore = new Firestore();
    public AgencyEdit()
    {
        InitializeComponent();
    }

    private void TbPhone_PreviewTextInput(object sender, TextCompositionEventArgs e)
    {
        Regex regex = new Regex("[^0-9]+");
        e.Handled = regex.IsMatch(e.Text);
    }

    private void btnCancel_Click(object sender, RoutedEventArgs e)
    {
        this.Close();
    }

    private void btnConfirm_Click(object sender, RoutedEventArgs e)
    {
        Agency agency = new Agency()
        {
            AgencyId = TbName.Tag.ToString(),
            AgencyName = TbName.Text,
            PhoneNumber = TbPhone.Text,
            Address = TbAddress.Text,
            DayReception = TbTime.Text,
            TypeId = cbxType.Text,
            District = cbxDistrict.Text,
        };
        firestore.UpdateData(Utils.Collection.Agency.ToString(), agency.AgencyId, agency);
        MessageBox.Show("Cập nhật thành công!");
        this.Tag = agency;
        this.Close();
    }
}