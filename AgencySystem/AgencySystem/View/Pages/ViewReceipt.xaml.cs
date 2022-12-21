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
    ListView listBoxReceptp;
    public ViewReceipt()
    {
        InitializeComponent();
        setUp();
    }
    
    private async void setUp()
    {
        listReceitp = await firestore.GetAllDocument(Utils.Collection.Receipt.ToString());
        listBoxReceptp = new ListView();
        foreach (Receipt receipt in listReceitp)
        {
            if (receipt.AgencyId == null) continue;
            UcViewReceipt ucInfo = new UcViewReceipt();
            ucInfo.LbName.Content = await firestore.GetData(Utils.Collection.Agency.ToString(), receipt.AgencyId);
            ucInfo.LbCustomerId.Content = "Id: " + receipt.AgencyId;
            ucInfo.LbProceeds.Content = receipt.Proceeds+ " VNĐ";
            ucInfo.LbTime.Content = receipt.Date;
            listBoxReceptp.Items.Add(ucInfo);
        }
        SvViewReicept.Content = listBoxReceptp;
    }
}