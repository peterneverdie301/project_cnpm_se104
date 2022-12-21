using AgencySystem.View.Components;
using System.Windows.Controls;

namespace AgencySystem.View.Pages;

public partial class ReportTurnOver : Page
{
    public ReportTurnOver()
    {
        InitializeComponent();
        setUp();
    }

    private void setUp()
    {
        ListView listView = new ListView();
        listView.Items.Add(new UcTurnover());
        listView.Items.Add(new UcTurnover());
        listView.Items.Add(new UcTurnover());
        listView.Items.Add(new UcTurnover());
        listView.Items.Add(new UcTurnover());
        SvListOfAgency.Content = listView;
    }
}