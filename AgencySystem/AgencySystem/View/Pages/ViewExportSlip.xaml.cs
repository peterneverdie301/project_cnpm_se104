using System.Windows.Controls;
using AgencySystem.View.Components;

namespace AgencySystem.View.Pages;

public partial class ViewExportSlip : Page
{
    public ViewExportSlip()
    {
        InitializeComponent();
        setUpSc();
    }

    private void setUpSc()
    {
        ListView listView = new ListView();
        listView.Items.Add(new UcViewExportSlip());
        listView.Items.Add(new UcViewExportSlip());
        listView.Items.Add(new UcViewExportSlip());
        listView.Items.Add(new UcViewExportSlip());
        ScViewExportSlip.Content = listView;
    }
}