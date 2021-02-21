using Contact.API.Data.Interfaces;
using Contact.API.Entities;
using Contact.API.Entities.Enums;
using Contact.API.Repositories.Interfaces;
using MongoDB.Driver;
using RabbitMQEvent.Constants;
using RabbitMQEvent.Events;
using RabbitMQEvent.Events.Enums;
using RabbitMQEvent.Producer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contact.API.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly IContactContext contactContext;
        private readonly ReportRabbitMQProducer reportProducer;

        public ContactRepository(IContactContext _contactContext, ReportRabbitMQProducer _reportProducer)
        {
            contactContext = _contactContext;
            reportProducer = _reportProducer;
        }
        public async Task AddContact(ContactInfo contact)
        {
            await contactContext.ContactInfo.InsertOneAsync(contact);
        }

        public async Task<bool> DeleteContact(string contactId)
        {
            DeleteResult deleteResult = await contactContext.ContactInfo.DeleteOneAsync(x => x.Id == contactId);
            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }

        public async Task<IEnumerable<ContactInfo>> GetAllComms()
        {
            return await contactContext.ContactInfo.Find(c => true).ToListAsync();
        }

        public async Task<IEnumerable<ContactInfo>> GetAllContactsFromPerson(string personId)
        {
            return await contactContext.ContactInfo.Find(c => c.PersonId == personId).ToListAsync();
        }

        public async Task<ContactInfo> GetContact(string contactId)
        {
            return await contactContext.ContactInfo.Find(c => c.Id == contactId).FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateContact(ContactInfo contact)
        {
            var result = await contactContext.ContactInfo.ReplaceOneAsync(filter: x => x.Id == contact.Id, replacement: contact);
            return result.IsAcknowledged && result.ModifiedCount > 0;
        }

        public async Task<ReportEvent> GetReport()
        {


            var allContact = await contactContext.ContactInfo.Find(x => true).ToListAsync();
            var filteredData = allContact.Where(b=>b.IletisimTipi == Entities.Enums.IletisimTipi.Konum).Select(c => new ReportData { Konum = c.Aciklama, KonumdakiToplamTelefonNo = allContact.Where(x => x.IletisimTipi == Entities.Enums.IletisimTipi.TelefonNumarasi && x.PersonId == c.PersonId).Count() });
            var res = filteredData.GroupBy(x => x.Konum).Select(y => new ReportData { Konum = y.Key, KonumdakiToplamKayit = y.Count(),KonumdakiToplamTelefonNo = y.Sum(v=>v.KonumdakiToplamTelefonNo) }).ToList();
            var model = new ReportEvent()
            {
                Durum = RaporDurumConvert.RaporDurumEnum(2),
                ReportId = Guid.NewGuid(),
                RaporIcerigi = res
            };

            try
            {
                reportProducer.PubishReport(EventConstants.ReportQueue,model);
            }
            catch (Exception)
            {

                throw;
            }
            return model;

        }
    }
}
