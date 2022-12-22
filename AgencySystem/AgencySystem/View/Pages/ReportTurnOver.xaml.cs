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
        listBoxDebt = new ListView();
        foreach (AgencyDebt debts in listDebt)
        {
            if (debts.AgencyId == null) continue;
            UcTurnover ucInfo = new UcTurnover();
            ucInfo.LbFisrtDebt.Content = debts.FirsDebt + " VNĐ";
            ucInfo.LbIncurred.Content = debts.Incurred + " VNĐ";
            ucInfo.LbLastDebt.Content = Convert.ToDouble(debts.FirsDebt + debts.Incurred) + " VNĐ";
            Agency agency = (Agency)listAgency.Find(data =>
            {
                Agency temp = data as Agency;
                return temp.AgencyId == debts.AgencyId;
            });
            ucInfo.LbAgencyName.Content = agency.AgencyName;
            listBoxDebt.Items.Add(ucInfo);
        }
        SvListOfAgency.Content = listBoxDebt;
    }
}