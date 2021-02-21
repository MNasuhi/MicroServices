using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contact.API.Entities.Enums
{
    public enum IletisimTipi: int
    {
        TelefonNumarasi = 1,
        Email = 2,
        Konum = 3
    }

    public class IletisimTipiConvert
    {
        public int IletisimTipiId { get; set; }
        public IletisimTipi IletisimTipi { get; set; }

        public static IletisimTipi iletisimEnum(int Id)
        {
            List<IletisimTipiConvert> iletisimTipleri = new List<IletisimTipiConvert>
            {
                new IletisimTipiConvert {IletisimTipi = IletisimTipi.Email,IletisimTipiId = 2},
                new IletisimTipiConvert {IletisimTipi = IletisimTipi.Konum,IletisimTipiId = 3},
                new IletisimTipiConvert {IletisimTipi = IletisimTipi.TelefonNumarasi,IletisimTipiId = 1},
            };
            return iletisimTipleri.Where(x => x.IletisimTipiId == Id).SingleOrDefault().IletisimTipi;
        }

        public static int iletisimId(IletisimTipi iletisim)
        {
            List<IletisimTipiConvert> iletisimTipleri = new List<IletisimTipiConvert>
            {
                new IletisimTipiConvert {IletisimTipi = IletisimTipi.Email,IletisimTipiId = 2},
                new IletisimTipiConvert {IletisimTipi = IletisimTipi.Konum,IletisimTipiId = 3},
                new IletisimTipiConvert {IletisimTipi = IletisimTipi.TelefonNumarasi,IletisimTipiId = 1},
            };
            return iletisimTipleri.Where(x => x.IletisimTipi == iletisim).SingleOrDefault().IletisimTipiId;
        }
    }
}
