using System.Windows.Controls;
using AgencySystem.View.Components;

namespace AgencySystem.View.Pages;

public partial class ViewReceipt : Page
{
    public ViewReceipt()
    {
        InitializeComponent();
        setUpSc();
    }
    
    private void setUpSc()
    {
        ListView listView = new ListView();
        listView.Items.Add(new UcViewReceipt());
        listView.Items.Add(new UcViewReceipt());
        listView.Items.Add(new UcViewReceipt());
        listView.Items.Add(new UcViewReceipt());
        listView.Items.Add(new UcViewReceipt());
        SvViewReicept.Content = listView;
    }
}