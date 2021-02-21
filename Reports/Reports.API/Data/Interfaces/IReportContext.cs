using MongoDB.Driver;
using Reports.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reports.API.Data.Interfaces
{
    public interface IReportContext
    {
        IMongoCollection<Report> Report { get; }
    }
}
