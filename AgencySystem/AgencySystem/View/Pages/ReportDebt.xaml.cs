using System.Windows.Controls;
using AgencySystem.View.Components;

namespace AgencySystem.View.Pages;

public partial class ReportDebt : Page
{
    public ReportDebt()
    {
        InitializeComponent();
        setUp();
    }

    void setUp()
    {
        ListView listView = new ListView();
        listView.Items.Add(new UcDebt());
        listView.Items.Add(new UcDebt());
        listView.Items.Add(new UcDebt());
        listView.Items.Add(new UcDebt());
        listView.Items.Add(new UcDebt());
        listView.Items.Add(new UcDebt());
        listView.Items.Add(new UcDebt());
        LvReportDebt.Content = listView;
    }
}