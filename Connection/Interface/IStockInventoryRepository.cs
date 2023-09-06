using System.Collections.Generic;

namespace Connection.Interface
{
    public interface IStockInventoryRepository
    {
        List<object> GetStockDJRekapOutlet(string Nomor, int Tipelokasi, int IDLokasi, int ProductItem, int ProductCategory, int Substorage, int GroupBy);
        List<object> GetStockDJListOutlet(string Nomor, int Tipelokasi, int IDLokasi, int ProductItem, int ProductCategory, int Substorage);
        List<object> GetDJOutgoing(string Nomor, int Tipelokasi, int IDLokasi, int Substorage);
        List<object> GetStockPGListOutlet(string Nomor, int Tipelokasi, int IDLokasi, int ProductItem, int GoldLevel, int Model, int FrameColor, int Substorage);
        List<object> GetPGOutgoing(string Nomor, int Tipelokasi, int IDLokasi, int Substorage);
        List<object> GetStockLDListOutlet(string Nomor, int Tipelokasi, int IDLokasi, int Shape, int Size, int Color, int Clarity, int Cutting, int Brand, int Category, int Substorage);
        List<object> GetStockLDList(string Nomor, int Tipelokasi, int IDLokasi, int Shape, int Size, int Color, int Clarity, int Cutting, int Brand, int Category, int Substorage);
        List<object> GetLDOutgoing(string Nomor, int Tipelokasi, int IDLokasi, int Substorage);
        List<object> GetStockGJRekapOutlet(string Nomor, int Tipelokasi, int IDLokasi, int ProductItem, int ProductCategory, int Substorage, int GroupBy);
        List<object> GetStockGJListOutlet(string Nomor, int Tipelokasi, int IDLokasi, int ProductItem, int ProductCategory, int Substorage);
        List<object> GetGJOutgoing(string Nomor, int Tipelokasi, int IDLokasi, int Substorage);
        object GetStockSummary(int Tipelokasi, int IDLokasi, int ProductItem, int ProductCategory, int Substorage);
        List<object> GetStockLedger(string Nomor);
        object GetItemRekap(int Tipelokasi, int IDLokasi, int ProductItem, int Substorage);
        object GetItemDetail(int Tipelokasi, int IDLokasi, int ProductItem, int Substorage);
    }
}