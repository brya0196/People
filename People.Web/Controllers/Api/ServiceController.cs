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
    public class ServiceController : ControllerBase
    {
        private readonly ServiceRepository _serviceRepository;

        public ServiceController(ServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _serviceRepository.GetAll();

            if (!result.Any()) return NotFound();

            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetById(int Id)
        {
            var result = _serviceRepository.GetById(Id);

            if (result == null) return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody]Service service)
        {
            if (service == null) return BadRequest();

            await _serviceRepository.Add(service);

            return Ok(service);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody]Service service)
        {
            if (service == null) return BadRequest();

            await _serviceRepository.Update(service);

            return Ok(service);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int Id)
        {
            if (Id == 0) return BadRequest();

            await _serviceRepository.Delete(Id);

            return Ok("Deleted");
        }
    }
}