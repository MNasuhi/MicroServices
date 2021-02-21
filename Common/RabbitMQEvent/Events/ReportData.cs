using RabbitMQEvent.Events.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitMQEvent.Events
{
    public class ReportData
    {
        public string Konum { get; set; }     
        public int KonumdakiToplamKayit { get; set; }
        public int KonumdakiToplamTelefonNo { get; set; }
    }
}
