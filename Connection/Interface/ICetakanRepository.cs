using Connection.RequestModels.PCS;
using System.Collections.Generic;

namespace Connection.Interface
{
    public interface ICetakanRepository
    {
        List<object> GetCetakan();
        List<object> GetStockCetakanActual(int Tipelokasi, int IDLokasi, int Packaging);
        List<object> GetStockCetakanSummary(int Tipelokasi, int IDLokasi, int Packaging, string From, string To, int Groupby, bool IsStore, string NIK);
        List<object> GetListCetakan(string Keyword, int Status);
        void InsertCetakan(PCS data);
        void UpdateCetakan(PCS data, string UserName);
        object GetDetailCetakan(int ID);
        object GetReceiveCetakan(int IDLokasi, string From, string To, bool IsApproval);
        object GetDetailReceiveCetakan(int ID, int IDLokasi, int IDProduct, string From, string To, int IsSummary, bool IsApproval);
        void InsertReceivingCetakan(ReceivePCS Data, string UserName);
        void ApproveReceivingCetakan(ReceivePCS Data, string UserName);
        void DeleteReceivingCetakan(int ID);
        void DeleteReceivedCetakan(int ID);
        object GetPemakaianCetakan(int Tipelokasi, int IDLokasi, int Souvenir, string From, string To, string Keyword);
    }
}