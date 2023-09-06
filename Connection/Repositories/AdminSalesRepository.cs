using Connection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Connection.Repositories
{
    public class AdminSalesRepository
    {
        private readonly JAWSDbContext _context;
        public AdminSalesRepository()
        {
            _context = new JAWSDbContext();
        }

        public List<DataAdminSale> GetDataAdminSales(int id = 0)
        {
            return _context.DataAdminSales.Where(p => p.Disable == false && p.Draft == false && ((p.Iduser == id) || (p.Iduser > 0 && id == 0) )).ToList();
        }
    }
}
