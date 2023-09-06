using Connection.RequestModels.PointOfSales;
using System;
using System.Collections.Generic;
using System.Text;

namespace Connection.Interface
{
    public interface IDocQCRepository
    {
        object AddQCDJ(RequestDocQCDJ dj, string operatornama);
        object AddQCPG(RequestDocQCPG pg, string operatornama);
        object AddQCGJ(RequestDocQCGJ gj, string operatornama);
        object AddQCLD(RequestDocQCLD ld, string operatornama);
        object AddQCDJTitipan(RequestDocQCDJCustomer dj, string operatornama);
        object ReportQC(string kw, string start, string end, string location, string tipe, int excel, int page, int row);
        object GetQC(int id, string tipe);
        object GetQCByProduct(int idproduct, string tipe);
        object GetProductList(string kw, string tipe);
        object GetProductDetail(int id, string tipe);
        object ApprovalQCLD(int id, decimal harga, string keterangan, string approvalname, int iduser);
        object GetRoleApprovalQCLD(int iduser);
        object GetListQCLDNotApproved(string kw, string start, string end, int iduser, int excel, int page, int row);
        List<object> GetListPositionLD();
        List<object> GetListClarityCharLD();
        List<object> GetListSizeLD();
    }
}
