using RabbitMQEvent.Events.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitMQEvent.Events
{
    public class ReportEvent
    {
        public Guid ReportId { get; set; }
        public string Tarih { get { return DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"); } }
        public RaporDurum Durum { get; set; }
        public List<ReportData> RaporIcerigi { get; set; }


    }
}
