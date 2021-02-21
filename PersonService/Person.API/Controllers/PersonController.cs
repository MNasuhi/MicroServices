using Microsoft.AspNetCore.Mvc;
using Person.API.Entities;
using Person.API.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Person.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonRepository personRepository;

        public PersonController(IPersonRepository _personRepository)
        {
            personRepository = _personRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Persons>>> GetAllPersons()
        {
            var res = await personRepository.GetAllPersons();
            return Ok(res);
        }

        [HttpGet("{id:length(24)}", Name = "GetPerson")]
        public async Task<ActionResult<Persons>> GetPerson(string Id)
        {
            var res = await personRepository.GetPerson(Id);
            return Ok(res);
        }

        [HttpPost]
        public async Task<ActionResult<Persons>> AddPerson([FromBody] Persons person)
        {
            await personRepository.AddPerson(person);
            return CreatedAtRoute("GetPerson", new { id = person.Id }, person);
        }

        [HttpPut]
        public async Task<ActionResult> UpdatePerson([FromBody] Persons person)
        {
            return Ok(await personRepository.UpdatePerson(person));
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<ActionResult> DeletePerson(string Id)
        {
            return Ok(await personRepository.DeletePerson(Id));
        }
    }
}
