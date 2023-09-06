using Connection.Models;
using Connection.RequestModels.PointOfSales;
using System.Collections.Generic;

namespace Connection.Interface
{
    public interface ILocationRepository
    {
        List<LocExhibition> GetLocExhibitions();
        List<LocOutlet> GetLocOutlets();
        List<LocWarehouse> GetLocWarehouses();
        List<LocOutlet> GetLocOutlets(string code);
        List<LocExhibition> GetLocExhibitions(string code); 
        List<LocOutlet> GetLocOutlets(int ID);
        List<LocExhibition> GetLocExhibitions(int ID);
        List<LocWarehouse> GetLocWarehouses(int ID);
        List<object> SalesLocationByLogin(int UserID, int isSO);
        List<object> GetLocationAllBrand(int Brand, int Tipe, int Location);
        public RequestLocation GetDataLocation(int Brand, int Tipe, int Location);
    }
}