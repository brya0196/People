using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using People.Core.Repositories;
using People.Data.Entities;

namespace People.Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly PersonRepository _personRepository;

        public PersonController(PersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _personRepository.GetAll();

            if (!result.Any()) return NotFound();

            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetById(int Id)
        {
            var result = _personRepository.GetById(Id);

            if (result == null) return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody]Person person)
        {
            if (person == null) return BadRequest();

            await _personRepository.Add(person);

            return Ok(person);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody]Person person)
        {
            if (person == null) return BadRequest();

            await _personRepository.Update(person);

            return Ok(person);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int Id)
        {
            if (Id == 0) return BadRequest();

            await _personRepository.Delete(Id);

            return Ok("Deleted");
        }
    }
}