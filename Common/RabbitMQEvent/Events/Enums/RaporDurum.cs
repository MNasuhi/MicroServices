using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RabbitMQEvent.Events.Enums
{
    public enum RaporDurum : int
    {
        Hazırlanıyor = 1,
        Tamamlandı = 2
    }

    public class RaporDurumConvert
    {
        public int RaporDurumId { get; set; }
        public RaporDurum RaporDurum { get; set; }
        public string Aciklama { get; set; }

        public static RaporDurum RaporDurumEnum(int Id)
        {
            List<RaporDurumConvert> raporDurumları = new List<RaporDurumConvert>
            {
                new RaporDurumConvert {RaporDurum = RaporDurum.Hazırlanıyor,RaporDurumId = 1, Aciklama = "Rapor Hazırlanıyor"},
                new RaporDurumConvert {RaporDurum = RaporDurum.Tamamlandı,RaporDurumId = 2, Aciklama = "Rapor Tamamlandı"},
            };
            return raporDurumları.Where(x => x.RaporDurumId == Id).SingleOrDefault().RaporDurum;
        }

        public static int raporDurumId(RaporDurum raporDurum)
        {
            List<RaporDurumConvert> raporDurumları = new List<RaporDurumConvert>
            {
                new RaporDurumConvert {RaporDurum = RaporDurum.Hazırlanıyor,RaporDurumId = 1, Aciklama = "Rapor Hazırlanıyor"},
                new RaporDurumConvert {RaporDurum = RaporDurum.Tamamlandı,RaporDurumId = 2, Aciklama = "Rapor Tamamlandı"},
            };
            return raporDurumları.Where(x => x.RaporDurum == raporDurum).SingleOrDefault().RaporDurumId;
        }

        public static string raporDurumu(RaporDurum raporDurum)
        {
            List<RaporDurumConvert> raporDurumları = new List<RaporDurumConvert>
            {
                new RaporDurumConvert {RaporDurum = RaporDurum.Hazırlanıyor,RaporDurumId = 1, Aciklama = "Rapor Hazırlanıyor"},
                new RaporDurumConvert {RaporDurum = RaporDurum.Tamamlandı,RaporDurumId = 2, Aciklama = "Rapor Tamamlandı"},
            };
            return raporDurumları.Where(x => x.RaporDurum == raporDurum).SingleOrDefault().Aciklama;
        }
    }
}
