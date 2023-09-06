using Connection.RequestModels.StockTransfer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Connection.Interface
{
    public interface IStockIncomingRepository
    {
        List<object> GetStockOutgoingDJ(string From, string To, int BrandAsal, int BrandTujuan, int TipeAsal, int TipeTujuan, int IDAsal, int IDTujuan, string Nomor);
        List<object> GetStockOutgoingPG(string From, string To, int BrandAsal, int BrandTujuan, int TipeAsal, int TipeTujuan, int IDAsal, int IDTujuan, string Nomor);
        List<object> GetStockOutgoingLD(string From, string To, int BrandAsal, int BrandTujuan, int TipeAsal, int TipeTujuan, int IDAsal, int IDTujuan, string Nomor);
        List<object> GetStockOutgoingGJ(string From, string To, int BrandAsal, int TipeAsal, int TipeTujuan, int IDAsal, int IDTujuan, string Nomor);
        List<object> GetStockOutgoingPackaging(string From, string To, int BrandAsal, int TipeAsal, int TipeTujuan, int IDAsal, int IDTujuan, string Nomor);
        List<object> GetStockOutgoingSouvenir(string From, string To, int BrandAsal, int TipeAsal, int TipeTujuan, int IDAsal, int IDTujuan, string Nomor);
        List<object> GetStockOutgoingCetakan(string From, string To, int BrandAsal, int TipeAsal, int TipeTujuan, int IDAsal, int IDTujuan, string Nomor);
        List<object> GetStockIncomingDJ(string From, string To, int BrandAsal, int BrandTujuan, int TipeAsal, int TipeTujuan, int IDAsal, int IDTujuan, int Status, string Nomor, bool IsApproval);
        List<object> GetStockIncomingPG(string From, string To, int BrandAsal, int BrandTujuan, int TipeAsal, int TipeTujuan, int IDAsal, int IDTujuan, int Status, string Nomor, bool IsApproval);
        List<object> GetStockIncomingLD(string From, string To, int BrandAsal, int BrandTujuan, int TipeAsal, int TipeTujuan, int IDAsal, int IDTujuan, int Status, string Nomor, bool IsApproval);
        List<object> GetStockIncomingGJ(string From, string To, int BrandAsal, int TipeAsal, int TipeTujuan, int IDAsal, int IDTujuan, int Status, string Nomor, bool IsApproval);
        List<object> GetStockIncomingPackaging(string From, string To, int BrandAsal, int TipeAsal, int TipeTujuan, int IDAsal, int IDTujuan, int Status, string Nomor, bool IsApproval);
        List<object> GetStockIncomingPackagingDetailList(string From, string To, int BrandAsal, int TipeAsal, int TipeTujuan, int IDAsal, int IDTujuan, int Status, string Nomor, int IDProduct);
        List<object> GetStockIncomingSouvenir(string From, string To, int BrandAsal, int TipeAsal, int TipeTujuan, int IDAsal, int IDTujuan, int Status, string Nomor, bool IsApproval); 
        List<object> GetStockIncomingSouvenirDetailList(string From, string To, int BrandAsal, int TipeAsal, int TipeTujuan, int IDAsal, int IDTujuan, int Status, string Nomor, int IDProduct);
        List<object> GetStockIncomingCetakan(string From, string To, int BrandAsal, int TipeAsal, int TipeTujuan, int IDAsal, int IDTujuan, int Status, string Nomor, bool IsApproval);
        List<object> GetStockIncomingCetakanDetailList(string From, string To, int BrandAsal, int TipeAsal, int TipeTujuan, int IDAsal, int IDTujuan, int Status, string Nomor, int IDProduct);
        object GetStockIncomingDJDetail(int ID, int isCrossBrand);
        object GetStockIncomingPGDetail(int ID, int isCrossBrand);
        object GetStockIncomingLDDetail(int ID, int isCrossBrand);
        object GetStockIncomingGJDetail(int ID);
        object GetStockIncomingPackagingDetail(int ID);
        object GetStockIncomingSouvenirDetail(int ID);
        object GetStockIncomingCetakanDetail(int ID);
        void InsertStockIncomingDJ(RequestStockOutgoingBRJ datas, string Username);
        void InsertStockIncomingPG(RequestStockOutgoingBRJ datas, string Username);
        void InsertStockIncomingLD(RequestStockOutgoingBRJ datas, string Username);
        void InsertStockIncomingGJ(RequestStockOutgoingBRJ datas, string Username);
        void InsertStockIncomingPackaging(RequestStockOutgoingPS datas, string Username);
        void InsertStockIncomingSouvenir(RequestStockOutgoingPS datas, string Username);
        void InsertStockIncomingCetakan(RequestStockOutgoingPS datas, string Username);
        void ApprovalIncomingDJ(int ID, string Username);
        void ApprovalIncomingPG(int ID, string Username);
        void ApprovalIncomingLD(int ID, string Username);
        void ApprovalIncomingGJ(int ID, string Username);
        void ApprovalIncomingPackaging(int ID, string Username);
        void ApprovalIncomingSouvenir(int ID, string Username);
        void ApprovalIncomingCetakan(int ID, string Username);
        void DeleteStockIncomingDJ(int ID);
        void DeleteStockIncomingPG(int ID);
        void DeleteStockIncomingLD(int ID);
        void DeleteStockIncomingGJ(int ID);
        void DeleteStockIncomingPackaging(int ID);
        void DeleteStockIncomingSouvenir(int ID);
        void DeleteStockIncomingCetakan(int ID);
        int GetIDOutgoing(int ID, bool isCrossBrand);
    }
}
