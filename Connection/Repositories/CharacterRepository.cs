using System;
using System.Collections.Generic;
using System.Text;
using Connection.Models;
using Connection.Interface;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Connection.Repositories
{
    public class CharacterRepository : ICharacterRepository
    {
        private readonly JAWSDbContext _context;

        public CharacterRepository()
        {
            _context = new JAWSDbContext();
        }

        public List<CharProductItem> GetProductItems()
        {
            return _context.CharProductItems.Where(p => p.Disable == false).ToList();
        }

        public List<CharProductLevel> GetProductLevels()
        {
            return _context.CharProductLevels.Where(p => p.Disable == false).ToList();
        }
        public List<CharProductCategory> GetProductCategories()
        {
            return _context.CharProductCategories.Where(p => p.Disable == false).ToList();
        }

        public List<CharProductCategory2> GetProductCategory2s()
        {
            return _context.CharProductCategory2s.Where(p => p.Disable == false).ToList();
        }

        public List<CharStoneDist> GetStoneDists()
        {
            return _context.CharStoneDists.Where(p => p.Disable == false).ToList();
        }
        public List<Parcel106> GetStoneBrand()
        {
            return _context.Parcel106s.Where(p => p.Disable == false).ToList();
        }

        public List<CharFrameColor> GetFrameColors()
        {
            return _context.CharFrameColors.Where(p => p.Disable == false).ToList();
        }

        public List<CharFrameMaterial> GetFrameMaterials()
        {
            return _context.CharFrameMaterials.Where(p => p.Disable == false).ToList();
        }

        public List<CharFrameFinishing> GetFrameFinishings()
        {
            return _context.CharFrameFinishings.Where(p => p.Disable == false).ToList();
        }
        public List<CharGoldLevel> GetGoldLevels()
        {
            return _context.CharGoldLevels.Where(p => p.Disable == false).ToList();
        }

        public List<CharGoldModel> GetGoldModels()
        {
            return _context.CharGoldModels.Where(p => p.Disable == false).ToList();
        }

        public List<CharProcessCon> GetProcessCons()
        {
            return _context.CharProcessCons.Where(p => p.Disable == false).ToList();
        }

        public List<CharDesignCategory> GetDesignCategories()
        {
            return _context.CharDesignCategories.Where(p => p.Disable == false).ToList();
        }

        public List<CharDesignConcept> GetDesignConcepts()
        {
            return _context.CharDesignConcepts.Where(p => p.Disable == false).ToList();
        }

        public List<CharDesignProcess> GetDesignProcesses()
        {
            return _context.CharDesignProcesses.Where(p => p.Disable == false).ToList();
        }

        public List<CharTargetAge> GetTargetAges()
        {
            return _context.CharTargetAges.Where(p => p.Disable == false).ToList();
        }

        public List<CharTargetGender> GetTargetGenders()
        {
            return _context.CharTargetGenders.Where(p => p.Disable == false).ToList();
        }

        public List<DataSupplier> GetSupplier()
        {
            return _context.DataSuppliers.Where(p => p.Disable == false && p.Draft == false).ToList();
        }

        public List<CharProcessFinishing> GetCharProcessFinishings()
        {
            return _context.CharProcessFinishings.Where(p => p.Disable == false).ToList();
        }

        public List<CharStoneDist> GetStoneDists(int Category, int Level)
        {
            return _context.CharStoneDists.Include(p => p.SettingsStoneDists).Where(p => p.Disable == false && p.SettingsStoneDists.Any(q => q.Idcategory == Category && q.Idlevel == Level)).ToList();
        }
    }
}
