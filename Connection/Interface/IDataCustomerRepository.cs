using System;
using System.Collections.Generic;
using System.Text;
using Connection.Models;

namespace Connection.Interface
{
    public interface IDataCustomerRepository
    {
        object GetDataCustomerByID(int id);
        object GetDataCustomerByKeyword(string kw, int searchby);
        //object CreateOrUpdateCustomerByStampsID(int idcustomerstamps, string kodecustomer);
    }
}
