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
            try
            {
                var result = _kindService.GetAll();

                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }

        [HttpGet]
        [Route("api/KindService/GetById/{Id:int}")]
        public IActionResult GetById(int Id)
        {
            try
            {
                var result = _kindService.GetById(Id);

                if (result == null) return NotFound();

                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }

        [HttpPost]
        [Route("api/KindService/Add")]
        public async Task<IActionResult> Add([FromBody]KindService kindService)
        {
            try
            {
                if (kindService == null) return BadRequest();

                await _kindService.Add(kindService);

                return Ok(kindService);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }

        [HttpPut]
        [Route("api/KindService/Update")]
        public async Task<IActionResult> Update([FromBody]KindService kindService)
        {
            try
            {
                if (kindService == null) return BadRequest();

                await _kindService.Update(kindService);

                return Ok(kindService);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }

        [HttpDelete]
        [Route("api/KindService/Delete/{id:int}")]
        public async Task<IActionResult> Delete(int Id)
        {
            try
            {
                if (Id == 0) return BadRequest();

                await _kindService.Delete(Id);

                return Ok("Deleted");
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }
    }
}