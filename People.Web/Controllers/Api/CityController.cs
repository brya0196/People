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
    public class CityController : ControllerBase
    {
        private readonly CityRepository _cityRepository;

        public CityController(CityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _cityRepository.GetAll();

            if (!result.Any()) return NotFound();

            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetById(int Id)
        {
            var result = _cityRepository.GetById(Id);

            if (result == null) return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody]City city)
        {
            if (city == null) return BadRequest();

            await _cityRepository.Add(city);

            return Ok(city);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody]City city)
        {
            if (city == null) return BadRequest();

            await _cityRepository.Update(city);

            return Ok(city);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int Id)
        {
            if (Id == 0) return BadRequest();

            await _cityRepository.Delete(Id);

            return Ok("Deleted");
        }
    }
}