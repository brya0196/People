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
    [Route("api/[controller]")]
    [ApiController]
    public class ProvinceController : ControllerBase
    {
        private readonly IProvince _province;

        public ProvinceController(IProvince province)
        {
            _province = province;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _province.GetAll();

            return Ok(result);
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int Id)
        {
            var result = _province.GetById(Id);

            if (result == null) return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody]Province province)
        {
            if (province == null) return BadRequest();

            await _province.Add(province);

            return Ok(province);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody]Province province)
        {
            if (province == null) return BadRequest();

            await _province.Update(province);

            return Ok(province);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int Id)
        {
            if (Id == 0) return BadRequest();

            await _province.Delete(Id);

            return Ok("Deleted");
        }
    }
}