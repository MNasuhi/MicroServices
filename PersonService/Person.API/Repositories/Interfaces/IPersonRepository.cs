using Person.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Person.API.Repositories.Interfaces
{
    public interface IPersonRepository
    {
        Task<IEnumerable<Persons>> GetAllPersons();
        Task<Persons> GetPerson(string personId);
        Task AddPerson(Persons person);
        Task<bool> UpdatePerson(Persons person);
        Task<bool> DeletePerson(string personId);
    }
}
