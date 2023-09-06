using System;
using System.Collections.Generic;
using System.Text;

namespace Connection.Interface
{
    public interface IPromoRepository
    {
        object GetPromoDJList(string Nomor, int TipeLokasi, int IDLokasi, int Status);
        object GetPromoPGList(string Nomor, int TipeLokasi, int IDLokasi, int Status);
    }
}
