using Contact.API.Entities.Enums;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contact.API.Entities
{
    public class ContactInfo
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string PersonId { get; set; }
        public IletisimTipi IletisimTipi { get; set; }
        public string Aciklama { get; set; }

    }
}
