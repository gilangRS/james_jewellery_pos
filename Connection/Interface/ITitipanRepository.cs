using Connection.RequestModels.PointOfSales;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Connection.Interface
{
    public interface ITitipanRepository
    {
        object GetTitipan(int id);
        object AddTitipan(RequestTitipan rr);
        object GetTitipanItemByCustomer(int idcustomer, string custlama);
        object ReportTitipan(string kw, string start, string end, string location, int status, int page, int row, int excel);
        object UploadImageTitipan(IFormFile files, int id, string brand);
        object AddNewProductTitipan(RequestStockProductDJCustomer sdjc);
        object GetProsesTitipan();
        object UpdateStatusTitipan(int id, int id_status_titipan);
    }
}
