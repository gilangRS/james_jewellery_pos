using Connection.Models;
using System.Collections.Generic;

namespace Connection.Interface
{
    public interface IDataSalesRepository
    {
        object GetDataSalesByStore(int idlokasi, int tipelokasi);
        object GetDataSalesByID(int id);
        object GetDataSalesByKeyword(string keyword, string kode);
        object GetDataSalesCrossBrandByStore(string brand, string locationcode, string keyword);
    }
}
