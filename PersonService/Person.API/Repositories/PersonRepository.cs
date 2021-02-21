using MongoDB.Driver;
using Person.API.Data.Interface;
using Person.API.Entities;
using Person.API.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Person.API.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly IPersonContext context;

        public PersonRepository(IPersonContext _context)
        {
            context = _context;
        }



        public async Task AddPerson(Persons person)
        {
            await context.Persons.InsertOneAsync(person);
            
        }

        public async Task<bool> DeletePerson(string personId)
        {
            DeleteResult deleteResult = await context.Persons.DeleteOneAsync(x=> x.Id == personId);
            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }

        public async Task<IEnumerable<Persons>> GetAllPersons()
        {
            return await context.Persons.Find(ss=>true).ToListAsync();
        }

        public async Task<Persons> GetPerson(string personId)
        {
            return await context.Persons.Find(ss => ss.Id == personId).FirstOrDefaultAsync();
        }

        public async Task<bool> UpdatePerson(Persons person)
        {
            var result = await context.Persons.ReplaceOneAsync(filter: x => x.Id == person.Id, replacement: person);
            return result.IsAcknowledged && result.ModifiedCount > 0;
        }
    }
}
