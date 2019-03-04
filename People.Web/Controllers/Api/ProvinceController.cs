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
    public class ProvinceController : ControllerBase
    {
        private readonly IProvince _province;

        public ProvinceController(IProvince province)
        {
            _province = province;
        }

        [HttpGet("GetAll")]
        [Route("api/Province/GetAll")]
        public IActionResult GetAll()
        {
            try
            {
                var result = _province.GetAll();

                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }

        [HttpGet("GetById")]
        [Route("api/Province/GetById/{Id:int}")]
        public IActionResult GetById(int Id)
        {
            try
            {
                var result = _province.GetById(Id);

                if (result == null) return NotFound();

                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }

        [HttpPost]
        [Route("api/Province/Add")]
        public async Task<IActionResult> Add([FromBody]Province province)
        {
            try
            {
                if (province == null) return BadRequest();

                await _province.Add(province);

                return Ok(province);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }

        [HttpPut]
        [Route("api/Province/Update")]
        public async Task<IActionResult> Update([FromBody]Province province)
        {
            try
            {
                if (province == null) return BadRequest();

                await _province.Update(province);

                return Ok(province);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }

        [HttpDelete]
        [Route("api/Province/Delete")]
        public async Task<IActionResult> Delete(int Id)
        {
            try
            {
                if (Id == 0) return BadRequest();

                await _province.Delete(Id);

                return Ok("Deleted");
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }
    }
}