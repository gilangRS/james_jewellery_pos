using Connection.Interface;
using Connection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Connection.Repositories
{
    public class ParcelRepository : IParcelRepository
    {
        private JAWSDbContext _context;

        public ParcelRepository()
        {
            _context = new JAWSDbContext();
        }

        public List<Parcel101> GetParcel101s()
        {
            return _context.Parcel101s.Where(p => p.Disable == false).ToList();
        }

        public List<Parcel102> GetParcel102s()
        {
            return _context.Parcel102s.Where(p => p.Disable == false).ToList();
        }

        public List<Parcel103> GetParcel103s()
        {
            return _context.Parcel103s.Where(p => p.Disable == false).ToList();
        }

        public List<Parcel104> GetParcel104s()
        {
            return _context.Parcel104s.Where(p => p.Disable == false).ToList();
        }

        public List<Parcel105> GetParcel105s()
        {
            return _context.Parcel105s.Where(p => p.Disable == false).ToList();
        }

        public List<Parcel106> GetParcel106s()
        {
            return _context.Parcel106s.Where(p => p.Disable == false).ToList();
        }

        public List<Parcel107> GetParcel107s()
        {
            return _context.Parcel107s.Where(p => p.Disable == false).ToList();
        }

        public List<Parcel201> GetParcel201s()
        {
            return _context.Parcel201s.Where(p => p.Disable == false).ToList();
        }

        public List<Parcel202> GetParcel202s()
        {
            return _context.Parcel202s.Where(p => p.Disable == false).ToList();
        }

        public List<Parcel203> GetParcel203s()
        {
            return _context.Parcel203s.Where(p => p.Disable == false).ToList();
        }

        public List<Parcel204> GetParcel204s()
        {
            return _context.Parcel204s.Where(p => p.Disable == false).ToList();
        }

        public List<Parcel205> GetParcel205s()
        {
            return _context.Parcel205s.Where(p => p.Disable == false).ToList();
        }

        public List<Parcel206> GetParcel206s()
        {
            return _context.Parcel206s.Where(p => p.Disable == false).ToList();
        }

        public List<Parcel207> GetParcel207s()
        {
            return _context.Parcel207s.Where(p => p.Disable == false).ToList();
        }

        public List<Parcel301> GetParcel301s()
        {
            return _context.Parcel301s.Where(p => p.Disable == false).ToList();
        }

        public List<Parcel302> GetParcel302s()
        {
            return _context.Parcel302s.Where(p => p.Disable == false).ToList();
        }

        public List<Parcel303> GetParcel303s()
        {
            return _context.Parcel303s.Where(p => p.Disable == false).ToList();
        }

        public List<Parcel304> GetParcel304s()
        {
            return _context.Parcel304s.Where(p => p.Disable == false).ToList();
        }

        public List<Parcel305> GetParcel305s()
        {
            return _context.Parcel305s.Where(p => p.Disable == false).ToList();
        }

        public List<Parcel306> GetParcel306s()
        {
            return _context.Parcel306s.Where(p => p.Disable == false).ToList();
        }

        public List<Parcel307> GetParcel307s()
        {
            return _context.Parcel307s.Where(p => p.Disable == false).ToList();
        }

        public List<Parcel308> GetParcel308s()
        {
            return _context.Parcel308s.Where(p => p.Disable == false).ToList();
        }

        public List<Parcel309> GetParcel309s()
        {
            return _context.Parcel309s.Where(p => p.Disable == false).ToList();
        }

        public List<Parcel310> GetParcel310s()
        {
            return _context.Parcel310s.Where(p => p.Disable == false).ToList();
        }

        public List<Parcel311> GetParcel311s()
        {
            return _context.Parcel311s.Where(p => p.Disable == false).ToList();
        }

        public List<Parcel312> GetParcel312s()
        {
            return _context.Parcel312s.Where(p => p.Disable == false).ToList();
        }

        public List<Parcel401> GetParcel401s()
        {
            return _context.Parcel401s.Where(p => p.Disable == false).ToList();
        }

        public List<Parcel402> GetParcel402s()
        {
            return _context.Parcel402s.Where(p => p.Disable == false).ToList();
        }

        public List<Parcel403> GetParcel403s()
        {
            return _context.Parcel403s.Where(p => p.Disable == false).ToList();
        }

        public List<Parcel501> GetParcel501s()
        {
            return _context.Parcel501s.Where(p => p.Disable == false).ToList();
        }

        public List<Parcel502> GetParcel502s()
        {
            return _context.Parcel502s.Where(p => p.Disable == false).ToList();
        }

        public List<Parcel503> GetParcel503s()
        {
            return _context.Parcel503s.Where(p => p.Disable == false).ToList();
        }

        public List<Parcel504> GetParcel504s()
        {
            return _context.Parcel504s.Where(p => p.Disable == false).ToList();
        }

        public List<Parcel505> GetParcel505s()
        {
            return _context.Parcel505s.Where(p => p.Disable == false).ToList();
        }

        public List<Parcel506> GetParcel506s()
        {
            return _context.Parcel506s.Where(p => p.Disable == false).ToList();
        }

        public List<Parcel507> GetParcel507s()
        {
            return _context.Parcel507s.Where(p => p.Disable == false).ToList();
        }

        public List<Parcel508> GetParcel508s()
        {
            return _context.Parcel508s.Where(p => p.Disable == false).ToList();
        }

        public List<Parcel509> GetParcel509s()
        {
            return _context.Parcel509s.Where(p => p.Disable == false).ToList();
        }
    }
}
