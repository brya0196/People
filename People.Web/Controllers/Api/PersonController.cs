using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using People.Core.Repositories;
using People.Data.Entities;
using People.Data.Interface;

namespace People.Web.Controllers.Api
{
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPerson _person;

        public PersonController(IPerson person)
        {
            _person = person;
        }

        [HttpGet]
        [Route("api/Person/GetAll")]
        public IActionResult GetAll()
        {
            var result = _person.GetAll();

            return Ok(result);
        }

        [HttpGet]
        [Route("api/Person/GetById/{Id:int}")]
        public IActionResult GetById(int Id)
        {
            var result = _person.GetById(Id);

            if (result == null) return NotFound();

            return Ok(result);
        }

        [HttpPost]
        [Route("api/Person/Add")]
        public async Task<IActionResult> Add([FromBody]Person person)
        {
            if (person == null) return BadRequest();

            await _person.Add(person);

            return Ok(person);
        }

        [HttpPost]
        [Route("api/Person/AddAll")]
        public async Task<IActionResult> AddAll([FromBody]List<Person> people)
        {
            if (!people.Any()) return BadRequest();

            foreach (var person in people)
            {
                await _person.Add(person);
            }

            return Ok(people);
        }

        [HttpPut]
        [Route("api/Person/Update")]
        public async Task<IActionResult> Update([FromBody]Person person)
        {
            if (person == null) return BadRequest();

            await _person.Update(person);

            return Ok(person);
        }

        [HttpDelete]
        [Route("api/Person/Delete")]
        public async Task<IActionResult> Delete(int Id)
        {
            if (Id == 0) return BadRequest();

            await _person.Delete(Id);

            return Ok("Deleted");
        }
    }
}