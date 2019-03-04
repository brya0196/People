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
    public class ServiceController : ControllerBase
    {
        private readonly IService _service;

        public ServiceController(IService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("api/Service/GetAll")]
        public IActionResult GetAll()
        {
            try
            {
                var result = _service.GetAll();

                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }

        [HttpGet]
        [Route("api/Service/GetById/{Id:int}")]
        public IActionResult GetById(int Id)
        {
            try
            {
                var result = _service.GetById(Id);

                if (result == null) return NotFound();

                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }

        [HttpGet]
        [Route("api/Service/GetAllByIdResidence/{Id:int}")]
        public IActionResult GetAllByIdResidence(int Id)
        {
            try
            {
                var result = _service.GetAll().Where(s => s.IdResidence == Id);

                if (result == null) return NotFound();

                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }

        [HttpPost]
        [Route("api/Service/Add")]
        public async Task<IActionResult> Add([FromBody]Service service)
        {
            try
            {
                if (service == null) return BadRequest();

                await _service.Add(service);

                return Ok(service);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }

        [HttpPost]
        [Route("api/Service/AddAll")]
        public async Task<IActionResult> AddAll([FromBody]List<Service> services)
        {
            try
            {
                if (!services.Any()) return BadRequest();

                foreach (var service in services)
                {
                    await _service.Add(service);
                }

                return Ok(services);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }

        [HttpPut]
        [Route("api/Service/Update")]
        public async Task<IActionResult> Update([FromBody]Service service)
        {
            try
            {
                if (service == null) return BadRequest();

                await _service.Update(service);

                return Ok(service);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }

        [HttpDelete]
        [Route("api/Service/Delete/{Id:int}")]
        public async Task<IActionResult> Delete(int Id)
        {
            try
            {
                if (Id == 0) return BadRequest();

                await _service.Delete(Id);

                return Ok("Deleted");
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }
    }
}