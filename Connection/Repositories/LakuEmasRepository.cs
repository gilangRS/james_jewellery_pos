using Connection.Interface;
using Connection.Settings;
using System;
using System.Collections.Generic;
using System.Text;

namespace Connection.Repositories
{
    public class LakuEmasRepository : ILakuEmasRepository
    {
        private readonly LakuEmasConfiguration _lec;
        public LakuEmasRepository() 
        {
            _lec = new LakuEmasConfiguration();
        }
        public string AddTransactionLE(string customername, string customeremail, string customeradress, string customerKTP, string customerhandphone, int bankid, string bankaccountnumber, string bankaccountname, string store, string keterangan, string cashboxcode, List<LakuEmasConfiguration.ItemPLU> items)
        {
            return _lec.AddTransactionLE(customername, customeremail, customeradress, customerKTP, customerhandphone, bankid, bankaccountnumber,bankaccountname, store, keterangan, cashboxcode, items);
        }
        public string GetCashBox(string store) 
        {
            return _lec.GetCashBox(store);
        }

        public object GetRateLEI()
        {
            return _lec.GetRateLEI();
        }


    }
}
