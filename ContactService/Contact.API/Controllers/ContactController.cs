using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contact.API.Entities;
using Contact.API.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Contact.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactRepository contactRepository;

        public ContactController(IContactRepository _contactRepository)
        {
            contactRepository = _contactRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContactInfo>>> GetAllContact()
        {
            var res = await contactRepository.GetAllComms();
            return Ok(res);
        }

        [HttpGet]
        [Route("GetPersonContacts/{id:length(24)}")]
        public async Task<ActionResult<IEnumerable<ContactInfo>>> GetPersonContacts(string Id)
        {
            var res = await contactRepository.GetAllContactsFromPerson(Id);
            return Ok(res);
        }

        [HttpGet("{id:length(24)}", Name = "GetContact")]
        public async Task<ActionResult<ContactInfo>> GetContact(string Id)
        {
            var res = await contactRepository.GetContact(Id);
            return Ok(res);
        }

        [HttpPost]
        public async Task<ActionResult<ContactInfo>> AddContact([FromBody] ContactInfo contact)
        {
            await contactRepository.AddContact(contact);
            return CreatedAtRoute("GetContact", new { id = contact.Id }, contact);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateContact([FromBody] ContactInfo contact)
        {
            return Ok(await contactRepository.UpdateContact(contact));
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<ActionResult> DeleteContact(string Id)
        {
            return Ok(await contactRepository.DeleteContact(Id));
        }

        [HttpGet]
        [Route("GetReport")]
        public async Task<ActionResult<IEnumerable<ContactInfo>>> GetReport()
        {
            var res = await contactRepository.GetReport();
            return Ok(res);
        }
    }
}
