using Connection.RequestModels.StockTransfer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Connection.Interface
{
    public interface IStockOutgoingRepository
    {
        List<object> GetStockOutgoingDJ(string From, string To, int BrandAsal, int BrandTujuan, int TipeAsal, int TipeTujuan, int IDAsal, int IDTujuan, int Status, string Nomor, bool IsApproval);
        List<object> GetStockOutgoingPG(string From, string To, int BrandAsal, int BrandTujuan, int TipeAsal, int TipeTujuan, int IDAsal, int IDTujuan, int Status, string Nomor, bool IsApproval);
        List<object> GetStockOutgoingLD(string From, string To, int BrandAsal, int BrandTujuan, int TipeAsal, int TipeTujuan, int IDAsal, int IDTujuan, int Status, string Nomor, bool IsApproval);
        List<object> GetStockOutgoingGJ(string From, string To, int BrandAsal, int TipeAsal, int TipeTujuan, int IDAsal, int IDTujuan, int Status, string Nomor, bool IsApproval);
        List<object> GetStockOutgoingPackaging(string From, string To, int BrandAsal, int TipeAsal, int TipeTujuan, int IDAsal, int IDTujuan, int Status, string Nomor, bool IsApproval);
        List<object> GetStockOutgoingSouvenir(string From, string To, int BrandAsal, int TipeAsal, int TipeTujuan, int IDAsal, int IDTujuan, int Status, string Nomor, bool IsApproval);
        List<object> GetStockOutgoingCetakan(string From, string To, int BrandAsal, int TipeAsal, int TipeTujuan, int IDAsal, int IDTujuan, int Status, string Nomor, bool IsApproval);
        object GetStockOutgoingDJDetail(int ID, int isCrossBrand);
        object GetStockOutgoingPGDetail(int ID, int isCrossBrand);
        object GetStockOutgoingLDDetail(int ID, int isCrossBrand);
        object GetStockOutgoingGJDetail(int ID);
        object GetStockOutgoingPackagingDetail(int ID);
        object GetStockOutgoingSouvenirDetail(int ID);
        object GetStockOutgoingCetakanDetail(int ID);
        object GetStockOutgoingPackagingDetailList(string From, string To, int BrandAsal, int TipeAsal, int TipeTujuan, int IDAsal, int IDTujuan, string Nomor, int IDProduct, int Status);
        object GetStockOutgoingSouvenirDetailList(string From, string To, int BrandAsal, int TipeAsal, int TipeTujuan, int IDAsal, int IDTujuan, string Nomor, int IDProduct, int Sttaus);
        object GetStockOutgoingCetakanDetailList(string From, string To, int BrandAsal, int TipeAsal, int TipeTujuan, int IDAsal, int IDTujuan, string Nomor, int IDProduct, int Status);
        void InsertStockOutgoingDJ(RequestStockOutgoingBRJ datas, string UserName);
        void InsertStockOutgoingPG(RequestStockOutgoingBRJ datas, string Username);
        void InsertStockOutgoingLD(RequestStockOutgoingBRJ datas, string Username);
        void InsertStockOutgoingGJ(RequestStockOutgoingBRJ datas, string Username);
        void InsertStockOutgoingPackaging(RequestStockOutgoingPS datas, string Username);
        void InsertStockOutgoingSouvenir(RequestStockOutgoingPS datas, string Username);
        void InsertStockOutgoingCetakan(RequestStockOutgoingPS datas, string Username);
        void UpdateStockOutgoingDJ(RequestStockOutgoingBRJ datas, string Username);
        void UpdateStockOutgoingPG(RequestStockOutgoingBRJ datas, string Username);
        void UpdateStockOutgoingLD(RequestStockOutgoingBRJ datas, string Username);
        void UpdateStockOutgoingGJ(RequestStockOutgoingBRJ datas, string Username);
        void UpdateStockOutgoingPackaging(RequestStockOutgoingPS datas, string Username);
        void UpdateStockOutgoingSouvenir(RequestStockOutgoingPS datas, string Username);
        void UpdateStockOutgoingCetakan(RequestStockOutgoingPS datas, string Username);
        void ApprovalOutgoingDJ(int ID, string Username);
        void ApprovalOutgoingPG(int ID, string Username);
        void ApprovalOutgoingLD(int ID, string Username);
        void ApprovalOutgoingGJ(int ID, string Username);
        void ApprovalOutgoingSouvenir(int ID, string Username);
        void ApprovalOutgoingPackaging(int ID, string Username);
        void ApprovalOutgoingCetakan(int ID, string Username);
        void DeleteStockOutgoingDJ(int ID);
        void DeleteStockOutgoingPG(int ID);
        void DeleteStockOutgoingLD(int ID);
        void DeleteStockOutgoingGJ(int ID);
        void DeleteStockOutgoingSouvenir(int ID);
        void DeleteStockOutgoingPackaging(int ID);
        void DeleteStockOutgoingCetakan(int ID);
        object GetCertificate(int ID, bool isCrossBrand);
    }
}
