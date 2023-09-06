using Connection.RequestModels.PointOfSales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connection.Interface
{
    public interface IAccountingRepository
    {
        object ReportSalesDetail(string kw, string start, string end, string location, string producttype, int item, int category, int segmen, int basic, int payment, int status, int page, int row, bool excel);
        object ReportSalesDetailLM();
        object ReportSalesDetailLEI(string kw, string start, string end, string location, int item, int level, int model, int basic, int payment, int status, int page, int row, bool excel);
        object ReportTradeInDetail(string kw, string start, string end, string location, string producttype, int item, int category, int payment, int status, int page, int row, bool excel);
        object ReportResellDetail(string kw, string start, string end, string location, string producttype, int item, int category, int payment, int status, int page, int row, bool excel);
    }
}
