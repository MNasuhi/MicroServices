using Contact.API.Data.Interfaces;
using Contact.API.Entities;
using Contact.API.Settings;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contact.API.Data
{
    public class ContactContext : IContactContext
    {
        public ContactContext(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            ContactInfo = database.GetCollection<ContactInfo>(settings.CollectionName);
        }
        public IMongoCollection<ContactInfo> ContactInfo { get; }
    }
}
