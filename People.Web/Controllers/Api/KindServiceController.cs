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
    public class KindServiceController : ControllerBase
    {
        private readonly IKindService _kindService;

        public KindServiceController(IKindService kindService)
        {
            _kindService = kindService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _kindService.GetAll();

            if (!result.Any()) return NotFound();

            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetById(int Id)
        {
            var result = _kindService.GetById(Id);

            if (result == null) return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody]KindService kindService)
        {
            if (kindService == null) return BadRequest();

            await _kindService.Add(kindService);

            return Ok(kindService);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody]KindService kindService)
        {
            if (kindService == null) return BadRequest();

            await _kindService.Update(kindService);

            return Ok(kindService);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int Id)
        {
            if (Id == 0) return BadRequest();

            await _kindService.Delete(Id);

            return Ok("Deleted");
        }
    }
}