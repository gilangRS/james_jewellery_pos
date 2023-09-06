using Connection.Models;
using System.Collections.Generic;

namespace Connection.Interface
{
    public interface ICharacterRepository
    {
        List<CharDesignCategory> GetDesignCategories();
        List<CharDesignConcept> GetDesignConcepts();
        List<CharDesignProcess> GetDesignProcesses();
        List<CharFrameColor> GetFrameColors();
        List<CharFrameFinishing> GetFrameFinishings();
        List<CharFrameMaterial> GetFrameMaterials();
        List<CharGoldLevel> GetGoldLevels();
        List<CharGoldModel> GetGoldModels();
        List<CharProcessCon> GetProcessCons();
        List<CharProductCategory> GetProductCategories();
        List<CharProductCategory2> GetProductCategory2s();
        List<CharProductItem> GetProductItems();
        List<CharProductLevel> GetProductLevels();
        List<CharStoneDist> GetStoneDists();
        List<CharStoneDist> GetStoneDists(int Category, int Level);
        List<Parcel106> GetStoneBrand();
        List<CharTargetAge> GetTargetAges();
        List<CharTargetGender> GetTargetGenders();
        List<DataSupplier> GetSupplier();
        List<CharProcessFinishing> GetCharProcessFinishings();
    }
}