using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using People.Core.Repositories;
using People.Data.Entities;
using People.Data.Interface;

namespace People.Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPerson _person;

        public PersonController(IPerson person)
        {
            _person = person;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _person.GetAll();

            if (!result.Any()) return NotFound();

            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetById(int Id)
        {
            var result = _person.GetById(Id);

            if (result == null) return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody]Person person)
        {
            if (person == null) return BadRequest();

            await _person.Add(person);

            return Ok(person);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody]Person person)
        {
            if (person == null) return BadRequest();

            await _person.Update(person);

            return Ok(person);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int Id)
        {
            if (Id == 0) return BadRequest();

            await _person.Delete(Id);

            return Ok("Deleted");
        }
    }
}