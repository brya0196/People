using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
            try
            {
                var result = _person.GetAll();

                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }

        [HttpGet]
        [Route("api/Person/GetById/{Id:int}")]
        public IActionResult GetById(int Id)
        {
            try
            {
                var result = _person.GetById(Id);

                if (result == null) return NotFound();

                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }

        [HttpPost]
        [Route("api/Person/Add")]
        public async Task<IActionResult> Add([FromBody]Person person)
        {
            try
            {
                if (person == null) return BadRequest();

                await _person.Add(person);

                return Ok(person);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }

        [HttpPost]
        [Route("api/Person/AddAll")]
        public async Task<IActionResult> AddAll([FromBody]List<Person> people)
        {
            try
            {
                if (!people.Any()) return BadRequest();

                foreach (var person in people)
                {
                    await _person.Add(person);
                }

                return Ok(people);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }

        [HttpPut]
        [Route("api/Person/Update")]
        public async Task<IActionResult> Update([FromBody]Person person)
        {
            try
            {
                if (person == null) return BadRequest();

                await _person.Update(person);

                return Ok(person);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }

        [HttpDelete]
        [Route("api/Person/Delete/{Id:int}")]
        public async Task<IActionResult> Delete(int Id)
        {
            try
            {
                if (Id == 0) return BadRequest();

                await _person.Delete(Id);

                return Ok("Deleted");
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }
    }
}