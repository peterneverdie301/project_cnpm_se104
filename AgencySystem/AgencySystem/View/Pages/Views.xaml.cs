using AgencySystem.View.Components;
using AgencySystem.View.Pages;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace AgencySystem.View.Pages;

public partial class Views : Page
{
    public Views()
    {
        InitializeComponent();
        if (LbOverView != null) LbOverView.Style = Resources["NavItemClickedStyle"] as Style;
        FrContainer.Content = new OverView();
    }
    
    private void LbOverView_OnMouseDown(object sender, MouseButtonEventArgs e)
    {
        ResetNavItemsToDefault();
        LbOverView.Style = Resources["NavItemClickedStyle"] as Style;
        FrContainer.Content = new OverView();
    }
    
    private void LbViewReceipt_OnMouseDown(object sender, MouseButtonEventArgs e)
    {
        ResetNavItemsToDefault();
        LbViewReceipt.Style = Resources["NavItemClickedStyle"] as Style;
        FrContainer.Content = new ViewReceipt();
    }
    
    private void LbViewProduct_OnMouseDown(object sender, MouseButtonEventArgs e)
    {
        ResetNavItemsToDefault();
        LbViewProduct.Style = Resources["NavItemClickedStyle"] as Style;
        FrContainer.Content = new ViewProduct();
    }
    
    private void LbViewExportSlip_OnMouseDown(object sender, MouseButtonEventArgs e)
    {
        ResetNavItemsToDefault();
        LbViewExportSlip.Style = Resources["NavItemClickedStyle"] as Style;
        FrContainer.Content = new ViewExportSlip();
    }
    private void ResetNavItemsToDefault()
    {
        LbOverView.Style = Resources["NavItemStyle"] as Style;
        LbViewReceipt.Style = Resources["NavItemStyle"] as Style;
        LbViewProduct.Style = Resources["NavItemStyle"] as Style;
        LbViewExportSlip.Style = Resources["NavItemStyle"] as Style;
    }


    
}