using Connection.RequestModels.PCS;
using System;
using System.Collections.Generic;
using System.Text;

namespace Connection.Interface
{
    public interface  IPackagingRepository
    {
        List<object> GetStockPackagingSummary(int Tipelokasi, int IDLokasi, int Packaging, string From, string To, int Groupby, bool IsStore, string NIK);
        List<object> GetStockPackagingActual(int Tipelokasi, int IDLokasi, int Packaging);
        List<object> GetPackaging();
        List<object> GetListPackaging(string Keyword, int Status);
        void InsertPackaging(PCS data);
        void UpdatePackaging(PCS data, string UserName);
        object GetDetailPackaging(int ID);
        object GetReceivePackaging(int IDLokasi, string From, string To, bool IsApproval);
        object GetDetailReceivePackaging(int ID, int IDLokasi, int IDProduct, string From, string To, int IsSummary, bool IsApproval);
        void InsertReceivingPackaging(ReceivePCS Data, string UserName);
        void ApproveReceivingPackaging(ReceivePCS Data, string UserName);
        void DeleteReceivingPackaging(int ID);
        void DeleteReceivedPackaging(int ID);
        object GetPemakaianPackaging(int Tipelokasi, int IDLokasi, int Souvenir, string From, string To, string Keyword);
    }
}
