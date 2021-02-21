using MongoDB.Driver;
using Person.API.Data.Interface;
using Person.API.Entities;
using Person.API.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Person.API.Data
{
    public class PersonContext : IPersonContext
    {
        public PersonContext(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            Persons = database.GetCollection<Persons>(settings.CollectionName);
        }
        public IMongoCollection<Persons> Persons { get; } 
    }
}
