using AgencySystem.View.Components;
using AgencySystem.View.Pages;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace AgencySystem.View.Pages;

public partial class Adding : Page
{
    public Adding()
    {
        InitializeComponent();
        if (LbAddingAgency != null) LbAddingAgency.Style = Resources["NavItemClickedStyle"] as Style;
        FrContainer.Content = new AddingAgency();
    }
    
    private void LbAddingAgency_OnMouseDown(object sender, MouseButtonEventArgs e)
    {
        ResetNavItemsToDefault();
        LbAddingAgency.Style = Resources["NavItemClickedStyle"] as Style;
        FrContainer.Content = new AddingAgency();
    }
    
    private void LbAddingReceipt_OnMouseDown(object sender, MouseButtonEventArgs e)
    {
        ResetNavItemsToDefault();
        LbAddingReceipt.Style = Resources["NavItemClickedStyle"] as Style;
        FrContainer.Content = new AddingReceipt();
    }
    
    private void LbAddingProduct_OnMouseDown(object sender, MouseButtonEventArgs e)
    {
        ResetNavItemsToDefault();
        LbAddingProduct.Style = Resources["NavItemClickedStyle"] as Style;
        FrContainer.Content = new AddingProduct();
    }
    private void ResetNavItemsToDefault()
    {
        LbAddingAgency.Style = Resources["NavItemStyle"] as Style;
        LbAddingReceipt.Style = Resources["NavItemStyle"] as Style;
        LbAddingProduct.Style = Resources["NavItemStyle"] as Style;
    }
}