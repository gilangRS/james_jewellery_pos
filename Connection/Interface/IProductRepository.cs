using Connection.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Connection.Interface
{
    public interface IProductRepository
    {
        object GetProductCatalogDJ(string Keyword, int ProductItem, int ProductCategory, int ProductLevel, int StoneDist, int FrameMaterial, int FrameColor, decimal MinPrice, decimal MaxPrice, int Basic, int Stock, int StoneBrand, int Brand, int Page, int ItemPerPage, int isStore);
        object GetDetailProductDJ(int id);
        object GetDetailCatalogDJ(string Keyword, decimal HargaMin, decimal HargaMax, int isStore, int Stone);
        object GetProductCatalogPG(string Keyword, int ProductItem, int GoldLevel, int GoldModel, int FrameColor, decimal MinPrice, decimal MaxPrice, int Basic, int Stock, int Brand, int Page, int ItemPerPage, int FixRate, decimal MinWeight, decimal MaxWeight, decimal MinSize, decimal MaxSize, int UserID);
        object GetDetailCatalogPG(string Keyword, decimal MinSize, decimal MaxSize, decimal MinWeight, decimal MaxWeight, decimal MinPrice, decimal MaxPrice);
        object GetTrendingProduct();
    }
}
