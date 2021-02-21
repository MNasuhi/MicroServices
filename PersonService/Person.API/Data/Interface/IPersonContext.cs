using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Person.API.Entities;

namespace Person.API.Data.Interface
{
    public interface IPersonContext
    {
        IMongoCollection<Persons> Persons { get; }
    }
}
