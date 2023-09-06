using Connection.Settings;
using System;
using System.Collections.Generic;
using System.Text;

namespace Connection.Interface
{
    public interface ILakuEmasRepository
    {
        string AddTransactionLE(string customername, string customeremail, string customeradress, string customerKTP, string customerhandphone, int bankid, string bankaccountnumber, string bankaccountname, string store, string keterangan, string cashboxcode, List<LakuEmasConfiguration.ItemPLU> items);
        string GetCashBox(string store);
        object GetRateLEI();
    }
}
