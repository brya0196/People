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
            var result = _service.GetAll();

            return Ok(result);
        }

        [HttpGet]
        [Route("api/Service/GetById")]
        public IActionResult GetById(int Id)
        {
            var result = _service.GetById(Id);

            if (result == null) return NotFound();

            return Ok(result);
        }

        [HttpPost]
        [Route("api/Service/Add")]
        public async Task<IActionResult> Add([FromBody]Service service)
        {
            if (service == null) return BadRequest();

            await _service.Add(service);

            return Ok(service);
        }

        [HttpPost]
        [Route("api/Service/AddAll")]
        public async Task<IActionResult> AddAll([FromBody]List<Service> services)
        {
            if (!services.Any()) return BadRequest();

            foreach (var service in services)
            {
                await _service.Add(service);
            }

            return Ok(services);
        }

        [HttpPut]
        [Route("api/Service/Update")]
        public async Task<IActionResult> Update([FromBody]Service service)
        {
            if (service == null) return BadRequest();

            await _service.Update(service);

            return Ok(service);
        }

        [HttpDelete]
        [Route("api/Service/Delete")]
        public async Task<IActionResult> Delete(int Id)
        {
            if (Id == 0) return BadRequest();

            await _service.Delete(Id);

            return Ok("Deleted");
        }
    }
}