using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reports.API.Entities
{
    public class Report
    {

        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }

        public DateTime Tarih { get { return DateTime.UtcNow; }  }

        public string Durum { get; set; }
    }
}
