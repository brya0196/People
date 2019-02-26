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
    public class KindServiceController : ControllerBase
    {
        private readonly IKindService _kindService;

        public KindServiceController(IKindService kindService)
        {
            _kindService = kindService;
        }

        [HttpGet]
        [Route("api/KindService/GetAll")]
        public IActionResult GetAll()
        {
            var result = _kindService.GetAll();

            return Ok(result);
        }

        [HttpGet]
        [Route("api/KindService/GetById")]
        public IActionResult GetById(int Id)
        {
            var result = _kindService.GetById(Id);

            if (result == null) return NotFound();

            return Ok(result);
        }

        [HttpPost]
        [Route("api/KindService/GetAdd")]
        public async Task<IActionResult> Add([FromBody]KindService kindService)
        {
            if (kindService == null) return BadRequest();

            await _kindService.Add(kindService);

            return Ok(kindService);
        }

        [HttpPut]
        [Route("api/KindService/Update")]
        public async Task<IActionResult> Update([FromBody]KindService kindService)
        {
            if (kindService == null) return BadRequest();

            await _kindService.Update(kindService);

            return Ok(kindService);
        }

        [HttpDelete]
        [Route("api/KindService/Delete/{id:int}")]
        public async Task<IActionResult> Delete(int Id)
        {
            if (Id == 0) return BadRequest();

            await _kindService.Delete(Id);

            return Ok("Deleted");
        }
    }
}