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
    public class KindServiceController : ControllerBase
    {
        private readonly KindServiceRepository _kindServiceRepository;

        public KindServiceController(KindServiceRepository kindServiceRepository)
        {
            _kindServiceRepository = kindServiceRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _kindServiceRepository.GetAll();

            if (!result.Any()) return NotFound();

            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetById(int Id)
        {
            var result = _kindServiceRepository.GetById(Id);

            if (result == null) return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody]KindService kindService)
        {
            if (kindService == null) return BadRequest();

            await _kindServiceRepository.Add(kindService);

            return Ok(kindService);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody]KindService kindService)
        {
            if (kindService == null) return BadRequest();

            await _kindServiceRepository.Update(kindService);

            return Ok(kindService);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int Id)
        {
            if (Id == 0) return BadRequest();

            await _kindServiceRepository.Delete(Id);

            return Ok("Deleted");
        }
    }
}