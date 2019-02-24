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
    public class ResidenceController : ControllerBase
    {
        private readonly IResidence _residence;

        public ResidenceController(IResidence residence)
        {
            _residence = residence;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _residence.GetAll();

            if (!result.Any()) return NotFound();

            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetById(int Id)
        {
            var result = _residence.GetById(Id);

            if (result == null) return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody]Residence residence)
        {
            if (residence == null) return BadRequest();

            await _residence.Add(residence);

            return Ok(residence);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody]Residence residence)
        {
            if (residence == null) return BadRequest();

            await _residence.Update(residence);

            return Ok(residence);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int Id)
        {
            if (Id == 0) return BadRequest();

            await _residence.Delete(Id);

            return Ok("Deleted");
        }
    }
}