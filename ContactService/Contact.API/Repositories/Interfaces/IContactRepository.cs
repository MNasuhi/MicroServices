using Contact.API.Entities;
using RabbitMQEvent.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contact.API.Repositories.Interfaces
{
    public interface IContactRepository
    {
        Task<IEnumerable<ContactInfo>> GetAllComms();
        Task<ContactInfo> GetContact(string contactId);
        Task<IEnumerable<ContactInfo>> GetAllContactsFromPerson(string personId);
        Task<bool> UpdateContact(ContactInfo contact);
        Task<bool> DeleteContact(string contactId);
        Task AddContact(ContactInfo contact);
        Task<ReportEvent> GetReport();
    }
}
