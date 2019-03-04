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
    public class CityController : ControllerBase
    {
        private readonly ICity _city;

        public CityController(ICity city)
        {
            _city = city;
        }

        [HttpGet]
        [Route("api/City/GetAll")]
        public IActionResult GetAll()
        {
            try
            {
                var result = _city.GetAll();

                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }
        
        [HttpGet]
        [Route("api/City/GetById/{Id:int}")]
        public IActionResult GetById(int Id)
        {
            try
            {
                var result = _city.GetById(Id);

                if (result == null) return NotFound();

                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }

        [HttpGet]
        [Route("api/City/GetByIdProvince/{Id:int}")]
        public IActionResult GetByIdProvince(int Id)
        {
            try
            {
                var result = _city.GetByIdProvince(Id);

                if (result == null) return NotFound();

                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }

        [HttpPost]
        [Route("api/City/Add")]
        public async Task<IActionResult> Add([FromBody]City city)
        {
            try
            {
                if (city == null) return BadRequest();

                await _city.Add(city);

                return Ok(city);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }

        [HttpPut]
        [Route("api/City/Update")]
        public async Task<IActionResult> Update([FromBody]City city)
        {
            try
            {
                if (city == null) return BadRequest();

                await _city.Update(city);

                return Ok(city);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }

        [HttpDelete]
        [Route("api/City/Delete")]
        public async Task<IActionResult> Delete(int Id)
        {
            try
            {
                if (Id == 0) return BadRequest();

                await _city.Delete(Id);

                return Ok("Deleted");
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
            
        }
    }
}