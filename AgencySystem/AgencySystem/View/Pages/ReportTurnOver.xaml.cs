using AgencySystem.View.Components;
using DataModels.Models;
using DataModels.Services;
using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace AgencySystem.View.Pages;

public partial class ReportTurnOver : Page
{
    Firestore firestore = new Firestore();
    private List<object> listDebt;
    private List<object> listAgency;
    List<Agency> agencies = new List<Agency>();
    List<AgencyDebt> agencyDebts = new List<AgencyDebt>();
    ListView listBoxDebt;
    public ReportTurnOver()
    {
        InitializeComponent();
        setUp();
    }

    private async void setUp()
    {
        listDebt = await firestore.GetAllDocument(Utils.Collection.AgencyDebt.ToString());
        listAgency = await firestore.GetAllDocument(Utils.Collection.Agency.ToString());
        foreach (var item in listAgency)
        {
            Agency agency = item as Agency;
            if (agency.AgencyId != null)
            {
                agencies.Add(agency);
            }
        }
        listBoxDebt = new ListView();
        foreach (AgencyDebt debts in listDebt)
        {
            if (debts.AgencyId == null) continue;
            UcTurnover ucInfo = new UcTurnover();
            ucInfo.LbFisrtDebt.Content = debts.FirsDebt + " VNĐ";
            ucInfo.LbIncurred.Content = debts.Incurred + " VNĐ";
            ucInfo.LbLastDebt.Content = Convert.ToDouble(debts.FirsDebt + debts.Incurred) + " VNĐ";
            Agency agency = agencies.Find((value) => value.AgencyId == debts.AgencyId);
            ucInfo.LbAgencyName.Content = agency.AgencyName;
            ucInfo.LbId.Content = agency.AgencyId;
            listBoxDebt.Items.Add(ucInfo);
        }
        SvListOfAgency.Content = listBoxDebt;
    }

    private void CbYear_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        ComboBoxItem item = e.AddedItems[0] as ComboBoxItem;
        int year = int.Parse(item.Content.ToString());
        int month;
        if (CbMonth.Text == "")
        {
            month = 12;
            CbMonth.Text = "12";
        }else
        {
            month = int.Parse(CbMonth.Text);
        }
        listBoxDebt = new ListView();
        foreach (AgencyDebt debts in listDebt)
        {
            if (debts.AgencyId == null) continue;
            if (debts.Month == month && debts.Year == year)
            {
                UcTurnover ucInfo = new UcTurnover();
                ucInfo.LbFisrtDebt.Content = debts.FirsDebt + " VNĐ";
                ucInfo.LbIncurred.Content = debts.Incurred + " VNĐ";
                ucInfo.LbLastDebt.Content = Convert.ToDouble(debts.FirsDebt + debts.Incurred) + " VNĐ";
                var agency = agencies.Find((value) => value.AgencyId == debts.AgencyId);
                ucInfo.LbAgencyName.Content = agency.AgencyName;
                ucInfo.LbId.Content = agency.AgencyId;
                listBoxDebt.Items.Add(ucInfo);
            }
        }
        SvListOfAgency.Content = listBoxDebt;
    }

    private void CbMonth_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        ComboBoxItem item = e.AddedItems[0] as ComboBoxItem;
        int month = int.Parse(item.Content.ToString());
        int year;
        if (CbYear.Text == "")
        {
            year = 2022;
            CbYear.Text = "2022";
        } else
        {
            year = int.Parse(CbYear.Text);
        }
        listBoxDebt = new ListView();
        foreach (AgencyDebt debts in listDebt)
        {
            if (debts.AgencyId == null) continue;
            if (debts.Month == month && debts.Year == year)
            {
                UcTurnover ucInfo = new UcTurnover();
                ucInfo.LbFisrtDebt.Content = debts.FirsDebt + " VNĐ";
                ucInfo.LbIncurred.Content = debts.Incurred + " VNĐ";
                ucInfo.LbLastDebt.Content = Convert.ToDouble(debts.FirsDebt + debts.Incurred) + " VNĐ";
                var agency = agencies.Find((value) => value.AgencyId == debts.AgencyId);
                ucInfo.LbAgencyName.Content = agency.AgencyName;
                ucInfo.LbId.Content = agency.AgencyId;
                listBoxDebt.Items.Add(ucInfo);
            }
        }
        SvListOfAgency.Content = listBoxDebt;
    }
}