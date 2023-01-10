using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonLogin.Business.Abstract;
using PersonLogin.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAll()
        {
            var allPersons = await _personService.GetAllPersons();
            return Ok(allPersons);
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var getidPerson = await _personService.GetByIdPerson(id);
            if (getidPerson!=null)
            {
                return Ok(getidPerson);
            }
            return NotFound();
        }


        [HttpGet]
        [Route("[action]/{name}")]
        public async  Task<IActionResult> GetByName(string name)
        {
            var getname = await _personService.GetByNamePerson(name);
            if (getname != null)
            {
                return Ok(getname);
            }
            return NotFound();
        }

        [HttpPost]
        [Route("[action]")]
        public async Task< IActionResult> Create([FromBody]Person person)
        {
             var createdPerson=await _personService.PersonCreate(person);
            if (ModelState.IsValid)
            {
                if (person.Name!="null".ToLower())
                {
                    return CreatedAtAction("GetById", new { ID = createdPerson.ID }, createdPerson);
                }
              
            }
            
            return BadRequest();
        }

        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> Update([FromBody]Person person)
        {
            var updatePerson= await _personService.PersonUpdate(person);
            if (ModelState.IsValid)
            {
                return Ok(updatePerson); 
            }
            return BadRequest();
        }

        [HttpDelete]
        [Route("[action]")]
        public async Task<IActionResult> Delete(int id)
        {
          
            if ( await _personService.GetByIdPerson(id)!=null)
            {
                await _personService.PersonDelete(id);

                return Ok();
            }

            return NotFound();

        }

    }
}
