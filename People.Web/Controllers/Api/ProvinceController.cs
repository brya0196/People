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
    public class ProvinceController : ControllerBase
    {
        private readonly ProvinceRepository _provinceRepository;

        public ProvinceController(ProvinceRepository provinceRepository)
        {
            _provinceRepository = provinceRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _provinceRepository.GetAll();

            if (!result.Any()) return NotFound();

            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetById(int Id)
        {
            var result = _provinceRepository.GetById(Id);

            if (result == null) return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody]Province province)
        {
            if (province == null) return BadRequest();

            await _provinceRepository.Add(province);

            return Ok(province);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody]Province province)
        {
            if (province == null) return BadRequest();

            await _provinceRepository.Update(province);

            return Ok(province);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int Id)
        {
            if (Id == 0) return BadRequest();

            await _provinceRepository.Delete(Id);

            return Ok("Deleted");
        }
    }
}