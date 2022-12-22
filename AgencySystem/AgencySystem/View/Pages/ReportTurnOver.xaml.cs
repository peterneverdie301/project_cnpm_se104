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
            listBoxDebt.Items.Add(ucInfo);
        }
        SvListOfAgency.Content = listBoxDebt;
    }
}