using Connection.RequestModels.PointOfSales;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Connection.Interface
{
    public interface IPaymentRepository
    {
        List<object> GetPaymentTypes();
        List<object> GetCards();
        List<object> GetProgramCicilans();
        List<object> GetEDCs(bool islei, bool isqris);
        List<object> GetBankIssuers();
        List<object> GetJenisKartuKredits();

        object ValidationAddPayment(int id);
        object AddPaymentToSalesOrder(RequestSalesReceipt sr);
        object PostingSalesOrderToStamps(int id, bool isrequireemail);
        object CancelSalesOrderToStamps(int id, bool isrequireemail);
        object VoidPaymentSalesOrder(int idsalesreceiptdetail, string operatorname);
        object ValidateDownPayment(string nomor, int idcustomer, string kodecustomerlama);
        object ValidatePaymentVoucher(string nomor, string loccode, string customercode);

        object AddDownPayment(RequestSalesReceiptDPPO po);
        object GetDownPaymentByCustomer(string kw, int idcustomer, string kodecustomerlama);
        object GetDownPaymentByID(int id);
        object VoidDownPayment(int id, string operatornama, string keterangan);
        object ReportDownPayment(string kw, string start, string end, string location, int status, int excel, int page, int row);
        object UploadImageDownPayment(IFormFile files, int id, string brand);

        object ReportSummaryPaymentSalesOrder(string kw, string start, string end, string location, int status, int excel, int page, int row);
    }
}
