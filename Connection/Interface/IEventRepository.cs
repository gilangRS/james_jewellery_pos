using Connection.RequestModels.PointOfSales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connection.Interface
{
    public interface IEventRepository
    {
        object AddPromoEvent(RequestPromoEvent rpe);
        object GetPromoEvent(int id);
        object GetActivePromoEvent();
        object ReportPromoEvent(string kw, string startdate, string enddate, int status, int page, int row, int excel);
        object ApprovalPromoEvent(int id, string operatornama);
        object DisablePromoEvent(int id, string operatornama, string keterangan);

        object AddPromoBank(RequestPromoBank rpb);
        object GetPromoBank(int id);
        object GetActivePromoBank(int id, string producttype);
        object ReportPromoBank(string kw, string startdate, string enddate, int status, int page, int row, int excel);
        object ApprovalPromoBank(int id, string operatornama);
        object DisablePromoBank(int id, string operatornama, string keterangan);
        object GetRoleApproval(int iduser);

        object ReportPemakaianPromo(string kw, string startdate, string enddate, string location, int tipe, int status, int page, int rows, int excel);
    }
}
