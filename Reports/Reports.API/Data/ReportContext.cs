using MongoDB.Driver;
using Reports.API.Data.Interfaces;
using Reports.API.Entities;
using Reports.API.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reports.API.Data
{
    public class ReportContext : IReportContext
    {
        public ReportContext(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            Report = database.GetCollection<Report>(settings.CollectionName);
        }
        public IMongoCollection<Report> Report { get; }
    }
}
