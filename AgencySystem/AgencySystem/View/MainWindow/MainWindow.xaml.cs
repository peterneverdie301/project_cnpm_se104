using AgencySystem.View.Components;
using AgencySystem.View.Pages;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace AgencySystem.View.MainWindow;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void handleClose(object sender, MouseButtonEventArgs e)
    {
        this.Close();
    }

    private void handleChangePage(object sender, MouseButtonEventArgs e)
    {
        Label data = (Label)sender;
        switch (data.Content)
        {
            case "Home Page":
                break;
            case "Adding Agency":
                FrContainer.Content = new AddingAgency();
                break;
            case "Adding Receipts":
                FrContainer.Content = new AddingReceipt();
                break;
            default:
                break;
        }
    }
}