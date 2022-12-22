using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using AgencySystem.View.Components;
using DataModels.Models;
using DataModels.Services;
using Google.Protobuf;
using Google.Type;

namespace AgencySystem.View.Pages;

public partial class ReportDebt : Page
{
    Firestore firestore = new Firestore();
    List<object> listAgencyDB;
    List<object> listExportSlipDB;
    List<Agency> agencies = new List<Agency>();
    List<ExportSlip> exportSlips = new List<ExportSlip>();
    ListView listView;
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
        listView = new ListView();
        foreach (var item in exportSlips)
        {
            UcDebt ucDebt = new UcDebt();
            ucDebt.lbName.Content = agencies.Find(value => value.AgencyId == item.AgencyId)?.AgencyName;
            ucDebt.lbSTT.Content = item.ExportSlipId;
            ucDebt.lbTotalPrice.Content = item.Total;
            var rate = item.Total / TotalTurnover * 100;
            ucDebt.lbRate.Content = MathF.Round((float)rate, 2);
            ucDebt.lbExportCount.Content = item.TotalItems;
            listView.Items.Add(ucDebt);
        }
        SvReportDebt.Content = listView;
        LbTotal.Content = TotalTurnover;
    }

    private void CbYear_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        TotalTurnover = 0;
        ComboBoxItem data = e.AddedItems[0] as ComboBoxItem;
        int year = int.Parse(data.Content.ToString());
        int month;
        if (CbMonth.Text == "")
        {
            month = 12;
            CbMonth.Text = "12";
        }
        else
        {
            month = int.Parse(CbMonth.Text);
        }
        listView = new ListView();
        foreach (var item in exportSlips)
        {
            UcDebt ucDebt = new UcDebt();
            int monthTurnover = int.Parse(item.Date.Substring(0, 2));
            int yearTurnover = int.Parse(item.Date.Substring(item.Date.Length - 4));
            if (monthTurnover == month && yearTurnover == year)
            {
                ucDebt.lbName.Content = agencies.Find(value => value.AgencyId == item.AgencyId)?.AgencyName;
                ucDebt.lbSTT.Content = item.ExportSlipId;
                ucDebt.lbTotalPrice.Content = item.Total;
                var rate = item.Total / TotalTurnover * 100;
                ucDebt.lbRate.Content = MathF.Round((float)rate, 2);
                ucDebt.lbExportCount.Content = item.TotalItems;
                TotalTurnover += item.Total;
                listView.Items.Add(ucDebt);
            }
        }
        SvReportDebt.Content = listView;
        LbTotal.Content = TotalTurnover;
    }

    private void CbMonth_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        TotalTurnover = 0;
        ComboBoxItem data = e.AddedItems[0] as ComboBoxItem;
        int month = int.Parse(data.Content.ToString());
        int year;
        if (CbYear.Text == "")
        {
            year = 2022;
            CbYear.Text = "2022";
        }
        else
        {
            year = int.Parse(CbYear.Text);
        }
        listView = new ListView();
        foreach (var item in exportSlips)
        {
            UcDebt ucDebt = new UcDebt();
            int monthTurnover = int.Parse(item.Date.Substring(0, 2));
            int yearTurnover = int.Parse(item.Date.Substring(item.Date.Length - 4));

            if (monthTurnover == month && yearTurnover == year)
            {
                ucDebt.lbName.Content = agencies.Find(value => value.AgencyId == item.AgencyId)?.AgencyName;
                ucDebt.lbSTT.Content = item.ExportSlipId;
                ucDebt.lbTotalPrice.Content = item.Total;
                var rate = item.Total / TotalTurnover * 100;
                ucDebt.lbRate.Content = MathF.Round((float)rate, 2);
                ucDebt.lbExportCount.Content = item.TotalItems;
                TotalTurnover += item.Total;
                listView.Items.Add(ucDebt);
            }
        }
        SvReportDebt.Content = listView;
        LbTotal.Content = TotalTurnover;
    }
}