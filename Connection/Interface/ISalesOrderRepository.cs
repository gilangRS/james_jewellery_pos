using Connection.Models;
using Connection.RequestModels.PointOfSales;
using System;
using System.Collections.Generic;
using System.Text;

namespace Connection.Interface
{
    public interface ISalesOrderRepository
    {
        #region SO / TRADE IN
        object GetSalesOrder(int id, int tipelokasi, int idlokasi);
        object GetSalesOrderItemByStore(int tipelokasi, int idlokasi, string kw, string tipeproduct, int idcustomer);
        object AddSalesOrder(RequestSalesOrder rso);
        object UpdateSalesOrder(RequestSalesOrder rso, int idsolama);
        object DeleteSalesOrder(int id);

        object ValidateDiscountVoucher(string nomor, string loccode);
        object VoidSalesOrder(int id, string operatornama, string keterangan);
        object ReportSalesOrder(string kw, string start, string end, string location, int status, int page, int row, int excel);
        object ReportSalesDetail(string kw, string start, string end, string location, string producttype, int status, int page, int row, bool excel);
        object ReportTradeIn(string Keyword, string Start, string End, int Lokasi, int TipeLokasi, int Status);
        object ReportTradeInDetail(string kw, string start, string end, string location, string producttype, int item, int category, int status, int page, int row, bool excel);
        object ReportResellDetail(string kw, string start, string end, string location, string producttype, int reselltype, int item, int kategori, int status, int page, int row, bool excel);

        object PrintSalesOrder(int id);
        object PrintSalesOrderDJ(int id);
        object PrintSalesOrderPG(int id);
        object PrintSalesOrderGJ(int id);
        object PrintSalesOrderLD(int id);
        object PrintProductcCard(string Nomor);
        int GetIDInvoice(string Invoice, string tipe);

        object PostingSalesOrderToMyapps(int idso);
        object PostingVoidSalesOrderToMyapps(int idso);
        object SummarySalesOrder(string location, string start, string end, int selection);
        #endregion

        #region PK
        object AddPackaging(RequestSalesPackaging rpk);
        object VoidPackaging(int id, string operatornama, string keterangan);
        object ReportPackaging(string kw, string start, string end, string location, int status, int page, int row, int excel);
        object GetReferenceNumberPackaging(string kw, string tipe);
        #endregion

        #region SV
        object AddSouvenir(RequestSalesSouvenir rsv);
        object VoidSouvenir(int id, string operatornama, string keterangan);
        object ReportSouvenir(string kw, string start, string end, string location, int status, int page, int row, int excel);
        #endregion

        #region CT
        object AddCetakan(RequestSalesCetakan rsc);
        object VoidCetakan(int id, string operatornama, string keterangan);
        object ReportCetakan(string kw, string start, string end, string location, int status, int page, int row, int excel);
        #endregion
    }
}
