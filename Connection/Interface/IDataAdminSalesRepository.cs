using Connection.Models;
using System.Collections.Generic;


namespace Connection.Interface
{
    public interface IDataAdminSalesRepository
    {
        object GetDataAdminSalesByID(int id);
        List<object> GetDataAdminSalesByUserID(int UserID);
        object GetDataAdminSalesByKeyword(string keyword);
        object GetDataAdminSalesByStore(int idlokasi, int tipelokasi);
    }
}
