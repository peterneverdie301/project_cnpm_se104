using AgencySystem.View.Components;
using AgencySystem.View.Pages;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace AgencySystem.View.MainWindow;

public partial class AgencyEdit : Window
{
    public AgencyEdit()
    {
        InitializeComponent();
    }

    private void TbPhone_PreviewTextInput(object sender, TextCompositionEventArgs e)
    {
        Regex regex = new Regex("[^0-9]+");
        e.Handled = regex.IsMatch(e.Text);
    }
}