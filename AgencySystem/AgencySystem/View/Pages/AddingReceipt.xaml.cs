using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
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

    private async void Handle_Add(object sender, RoutedEventArgs e)
    {
        if (cbxAgency.Text != "" && TbDate.Text != "" && TbMoney.Text != "")
        {
            Receipt receipt = new Receipt();
            try
            {
              receipt.Proceeds = double.Parse(TbMoney.Text);
            }
            catch
            {
                MessageBox.Show("Tiền nhập phải là số");
                return;
            }
            receipt.ReceiptId = await firestore.GetIdForObject(Utils.Collection.Receipt.ToString());
            receipt.Date = TbDate.Text;
            Agency agency = (Agency)agences.Find((a) => {
                Agency temp = (Agency)a;
                return temp.AgencyName == cbxAgency.Text;
            });
            receipt.AgencyId = agency?.AgencyId;
            firestore.AddData(Utils.Collection.Receipt.ToString(), receipt.ReceiptId, receipt);
            // Change debt agency
            string idAgencyDebt = TbDate.DisplayDate.Month + "-" + TbDate.DisplayDate.Year + "-" + agency?.AgencyId;
            AgencyDebt agencyDebt = (AgencyDebt)await firestore.GetData(Utils.Collection.AgencyDebt.ToString(), idAgencyDebt);
            if (agencyDebt != null)
            {
                double money = double.Parse(TbMoney.Text);
                if (money < agencyDebt.Incurred)
                {
                    agencyDebt.Incurred -= money;
                } else
                {
                    money -= (double)agencyDebt.Incurred;
                    agencyDebt.Incurred = 0;
                    agencyDebt.FirsDebt -= money;
                }

                firestore.UpdateData(Utils.Collection.AgencyDebt.ToString(), idAgencyDebt, agencyDebt);
            } else
            {
                AgencyDebt debt = new AgencyDebt();
                debt.Incurred = 0; 
                debt.AgencyId = agency?.AgencyId;
                debt.Year = TbDate.DisplayDate.Year;
                debt.Month = TbDate.DisplayDate.Month;
                debt.FirsDebt = 0;
                firestore.AddData(Utils.Collection.AgencyDebt.ToString(), idAgencyDebt, debt);
            }
            MessageBox.Show("Thêm phiếu thu tiền thành công");
        }
        MessageBox.Show("Bạn chưa nhập đầy đủ thông tin");

    }

    private void TbMoney_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
    {
        Regex regex = new Regex("[^0-9]+");
        e.Handled = regex.IsMatch(e.Text);
    }

    private void TbPhone_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
    {
        Regex regex = new Regex("[^0-9]+");
        e.Handled = regex.IsMatch(e.Text);
    }
}