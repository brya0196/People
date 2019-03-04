using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using People.Core.Repositories;
using People.Data.Entities;
using People.Data.Interface;

namespace People.Web.Controllers.Api
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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
            try
            {
                var result = _residence.GetAll();

                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }

        [HttpGet]
        [Route("api/Residence/GetById/{Id:int}")]
        public IActionResult GetById(int Id)
        {
            try
            {
                var result = _residence.GetById(Id);

                if (result == null) return NotFound();

                return Ok(result);
            }
            catch(Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }

        [HttpPost]
        [Route("api/Residence/Add")]
        public async Task<IActionResult> Add([FromBody]Residence residence)
        {
            try
            {
                if (residence == null) return BadRequest();

                await _residence.Add(residence);

                return Ok(residence);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }

        }

        [HttpPut]
        [Route("api/Residence/Update")]
        public async Task<IActionResult> Update([FromBody]Residence residence)
        {
            try
            {
                if (residence == null) return BadRequest();

                await _residence.Update(residence);

                return Ok(residence);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }

        [HttpDelete]
        [Route("api/Residence/Delete/{Id:int}")]
        public async Task<IActionResult> Delete(int Id)
        {
            try
            {
                if (Id == 0) return BadRequest();

                await _residence.Delete(Id);

                return Ok("Deleted");
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }
    }
}