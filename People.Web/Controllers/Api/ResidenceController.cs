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
    public class ResidenceController : ControllerBase
    {
        private readonly IResidence _residence;

        public ResidenceController(IResidence residence)
        {
            _residence = residence;
        }

        [HttpGet]
        [Route("api/Residence/GetAll")]
        public IActionResult GetAll()
        {
            var result = _residence.GetAll();

            return Ok(result);
        }

        [HttpGet]
        [Route("api/Residence/GetById/{Id:int}")]
        public IActionResult GetById(int Id)
        {
            var result = _residence.GetById(Id);

            if (result == null) return NotFound();

            return Ok(result);
        }

        [HttpPost]
        [Route("api/Residence/Add")]
        public async Task<IActionResult> Add([FromBody]Residence residence)
        {
            if (residence == null) return BadRequest();

            await _residence.Add(residence);

            return Ok(residence);
        }

        [HttpPut]
        [Route("api/Residence/Update")]
        public async Task<IActionResult> Update([FromBody]Residence residence)
        {
            if (residence == null) return BadRequest();

            await _residence.Update(residence);

            return Ok(residence);
        }

        [HttpDelete]
        [Route("api/Residence/Delete")]
        public async Task<IActionResult> Delete(int Id)
        {
            if (Id == 0) return BadRequest();

            await _residence.Delete(Id);

            return Ok("Deleted");
        }
    }
}