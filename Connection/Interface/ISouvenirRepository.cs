using Connection.RequestModels.PCS;
using System;
using System.Collections.Generic;
using System.Text;

namespace Connection.Interface
{
    public interface  ISouvenirRepository
    {
        List<object> GetStockSouvenirSummary(int Tipelokasi, int IDLokasi, int Souvenir, string From, string To, int Groupby, bool IsStore, string NIK);
        List<object> GetStockSouvenirActual(int Tipelokasi, int IDLokasi, int Souvenir);
        List<object> GetSouvenir();
        List<object> GetListSouvenir(string Keyword, int Status);
        void InsertSouvenir(PCS data);
        void UpdateSouvenir(PCS data, string UserName);
        object GetDetailSouvenir(int ID);
        object GetReceiveSouvenir(int IDLokasi, string From, string To, bool IsApproval);
        object GetDetailReceiveSouvenir(int ID, int IDLokasi, int IDProduct, string From, string To, int IsSummary, bool IsApproval);
        void InsertReceivingSouvenir(ReceivePCS Data, string UserName);
        void ApproveReceivingSouvenir(ReceivePCS Data, string UserName);
        void DeleteReceivingSouvenir(int ID);
        void DeleteReceivedSouvenir(int ID);
        object GetPemakaianSouvenir(int Tipelokasi, int IDLokasi, int Souvenir, string From, string To, string Keyword);
    }
}
