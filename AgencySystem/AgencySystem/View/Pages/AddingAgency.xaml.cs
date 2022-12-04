using DataModels.Models;
using DataModels.Services;
using System.Windows.Controls;
using System.Windows.Input;

namespace AgencySystem.View.Pages;

public partial class AddingAgency : Page
{
    public AddingAgency()
    {
        InitializeComponent();
    }

    private void handleAddAgency(object sender, MouseButtonEventArgs e)
    {
        Agency agency = new Agency();
        agency.AgencyName = TbName.Text;
        agency.AgencyId = "1";
        AgencyManagement.Instance.AddNew(agency);

    }
}