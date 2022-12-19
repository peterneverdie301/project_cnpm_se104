using System.Windows.Controls;
using AgencySystem.View.Components;

namespace AgencySystem.View.Pages;

public partial class ViewProduct : Page
{
    public ViewProduct()
    {
        InitializeComponent();
        setUpSc();
    }

    private void setUpSc()
    {
        ListView listView = new ListView();

        listView.Items.Add(new UcViewProduct());
        listView.Items.Add(new UcViewProduct());
        listView.Items.Add(new UcViewProduct());
        listView.Items.Add(new UcViewProduct());

        ScViewProduct.Content = listView;
    }
}