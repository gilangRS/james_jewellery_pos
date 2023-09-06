using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connection.Interface
{
    public interface IStoneRepository
    {
        object GetStone1A(int Parcel01, int Parcel02, int Parcel03, int Parcel04);
        object GetStone1B(int Parcel01, int Parcel02, int Parcel03, int Parcel04, int Parcel05, int Parcel06, int Parcel07);
        object GetStone2(int Parcel01, int Parcel02, int Parcel03, int Parcel04);
        object GetStone3(int Parcel01, int Parcel02, int Parcel03, int Parcel04);
        object GetStone4(int Parcel01, int Parcel02, int Parcel03);
        object GetStone5(int Parcel01, int Parcel02, int Parcel03, int Parcel04, int Parcel05, int Parcel06, int Parcel07, int Parcel08);
        object GetHargaTotalBatu(int Item, int StoneDist, int IDStone, string Tipe, int TotalButir, decimal TotalCarat);
    }
}
