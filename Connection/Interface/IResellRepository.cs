using Connection.RequestModels.PointOfSales;
using System;
using System.Collections.Generic;
using System.Text;

namespace Connection.Interface
{
    public interface IResellRepository
    {
        object GetResell(int id);
        object ValidationAddResell(int id);
        object AddResell(RequestResell rr);
        object VoidResell(int id, string operatornama, string keterangan);
        object GetResellItemByCustomer(int idcustomer, string custlama, string tipetransaksi);
        object CheckPLUResell(string Nomor, string Brand, string Tipe);
        object ReportResell(string kw, string start, string end, string location, int reselltype, int status, int page, int row, int excel);
        object ReportResellDetail(string kw, string start, string end, string location, string producttype, int reselltype, int item, int kategori, int status, int page, int row, int excel);
        object AddResellCrossBrand(RequestResell rr);
        object GetResellItemCrossBrandByCustomer(int idcustomer, string custlama);

        object AddPLUDJ(RequestAddPLUDJ product, string Username, int IDBrand);
        object AddPLUPG(RequestAddPLUPG product, string Username, int IDBrand);
        object AddPLULD(RequestAddPLULD product, string Username, int IDBrand);

        object DeletePLUDJ(string nomor);
        object DeletePLUPG(string nomor);
        object DeletePLULD(string nomor);
    }
}
