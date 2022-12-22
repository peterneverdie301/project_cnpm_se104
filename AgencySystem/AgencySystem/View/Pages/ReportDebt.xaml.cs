using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using AgencySystem.View.Components;
using DataModels.Models;
using DataModels.Services;

namespace AgencySystem.View.Pages;

public partial class ReportDebt : Page
{
    Firestore firestore = new Firestore();
    List<object> listAgencyDB;
    List<object> listExportSlipDB;
    List<Agency> agencies = new List<Agency>();
    List<ExportSlip> exportSlips = new List<ExportSlip>();
    double TotalTurnover = 0;
    public ReportDebt()
    {
        InitializeComponent();
        setUp();
    }

    async void setUp()
    {
        listAgencyDB = await firestore.GetAllDocument(Utils.Collection.Agency.ToString());
        listExportSlipDB = await firestore.GetAllDocument(Utils.Collection.ExportSlip.ToString());
        // get agency
        foreach (var item in listAgencyDB)
        {
            Agency agency = item as Agency;
            if (agency.AgencyId != null)
            {
                agencies.Add(agency);
            }
        }
        // get export slip
        foreach (var item in listExportSlipDB)
        {
            ExportSlip exportSlip = item as ExportSlip;
            if (exportSlip.AgencyId != null)
            {
                exportSlips.Add(exportSlip);
            }
            TotalTurnover += exportSlip.Total;
        }

        // Add data
        ListView listView = new ListView();
        foreach (var item in exportSlips)
        {
            UcDebt ucDebt = new UcDebt();
            ucDebt.lbName.Content = agencies.Find(value => value.AgencyId == item.AgencyId)?.AgencyName;
            ucDebt.lbSTT.Content = item.AgencyId;
            ucDebt.lbTotalPrice.Content = item.Total;
            var rate = item.Total / TotalTurnover * 100;
            ucDebt.lbRate.Content = MathF.Round((float)rate, 2);
            ucDebt.lbExportCount.Content = item.TotalItems;
            listView.Items.Add(ucDebt);
        }
        SvReportDebt.Content = listView;
    }
}