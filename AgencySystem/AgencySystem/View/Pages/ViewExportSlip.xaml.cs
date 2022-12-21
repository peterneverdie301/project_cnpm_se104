using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using AgencySystem.View.Components;
using AgencySystem.View.MainWindow;
using DataModels.Models;
using DataModels.Services;

namespace AgencySystem.View.Pages;

public partial class ViewExportSlip : Page
{
    Firestore firestore = new Firestore();
    private List<object> listSlip;
    ListView listBoxSlip;
    public ViewExportSlip()
    {
        InitializeComponent();
        setUp();
    }

    private async void setUp()
    {
        listSlip = await firestore.GetAllDocument(Utils.Collection.ExportSlip.ToString());
        listBoxSlip = new ListView();
        foreach (ExportSlip slip in listSlip)
        {
            if (slip.ExportSlipId == null) continue;
            UcViewExportSlip ucInfo = new UcViewExportSlip();
            //ucInfo.Lb.Content = item.ItemsName;
            ucInfo.LbId.Content = "Id: " + slip.AgencyId;
            ucInfo.LbPaid.Content = slip.AmountPaid+ " VNĐ";
            ucInfo.LbTime.Content = slip.Date;
            ucInfo.LbTotal.Content = slip.Total + "VNĐ";
            ucInfo.LbRemaining.Content = (slip.Total - slip.AmountPaid) + "VNĐ";
            ucInfo.BtDetail.Tag = slip;
            ucInfo.BtDetail.Click += BtnDetail_Click;
            listBoxSlip.Items.Add(ucInfo);
        }
        ScViewExportSlip.Content = listBoxSlip;
    }
    private void BtnDetail_Click(object sender, RoutedEventArgs e)
    {
        var btn = sender as Button;
        ExportSlip slip = btn?.Tag as ExportSlip;
        ExportSlipDetailScreen exportSlipDetail = new ExportSlipDetailScreen(slip.ExportSlipId);
        exportSlipDetail.Show();
    }
}