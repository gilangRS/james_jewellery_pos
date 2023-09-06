using Connection.RequestModels.PointOfSales;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Connection.Interface
{
    public interface IRepairRepository
    {
        List<object> GetCharProcessRepair();
        object GetRepair(int id);
        object GetRepairResult(int id_repair_result);
        object AddRepair(RequestRepair rr);
        object GetRepairItemByCustomer(int idcustomer, string custlama);
        object ReportRepair(string kw, string start, string end, string location, int status, int page, int row, int excel);
        object ReportRepairResult(string kw, string start, string end, string location, int status, int page, int row, int excel);
        object UploadImageRepair(IFormFile files, int id, string brand);
        object GetListInvoiceRepair(string kw, string location, int page, int row, int excel);
        object AddRepairInvoice(RequestRepairResult rr);
        object AddPaymentRepair(RequestSalesOrderRepair ror, string operator_nama);
        object PostingRepairToMyapps(string nomor);
    }
}
