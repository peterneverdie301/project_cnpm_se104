using System.Collections.Generic;
using System.Windows.Controls;
using AgencySystem.View.Components;
using DataModels.Models;
using DataModels.Services;

namespace AgencySystem.View.Pages;

public partial class ViewReceipt : Page
{
    Firestore firestore = new Firestore();
    private List<object> listReceitp;
    private List<object> listAgency;
    ListView listBoxReceptp;
    public ViewReceipt()
    {
        InitializeComponent();
        setUp();
    }
    
    private async void setUp()
    {
        listReceitp = await firestore.GetAllDocument(Utils.Collection.Receipt.ToString());
        listAgency = await firestore.GetAllDocument(Utils.Collection.Agency.ToString());
        listBoxReceptp = new ListView();
        foreach (Receipt receipt in listReceitp)
        {
            if (receipt.AgencyId == null) continue;
            Agency agency = (Agency)listAgency.Find((value) =>
            {
                Agency data = value as Agency;
                return data.AgencyId == receipt.AgencyId;
            });
            UcViewReceipt ucInfo = new UcViewReceipt();
            ucInfo.LbName.Content = agency.AgencyName;
            ucInfo.LbCustomerId.Content = "Id: " + receipt.AgencyId;
            ucInfo.LbProceeds.Content = receipt.Proceeds+ " VNĐ";
            ucInfo.LbTime.Content = receipt.Date;
            listBoxReceptp.Items.Add(ucInfo);
        }
        SvViewReicept.Content = listBoxReceptp;
    }
}