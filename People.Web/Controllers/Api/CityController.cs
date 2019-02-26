﻿using System;
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
    public class CityController : ControllerBase
    {
        private readonly ICity _city;

        public CityController(ICity city)
        {
            _city = city;
        }

        [HttpGet]
        [Route("api/Person/GetAll")]
        public IActionResult GetAll()
        {
            var result = _city.GetAll();

            return Ok(result);
        }

        [HttpGet]
        [Route("api/Person/GetById")]
        public IActionResult GetById(int Id)
        {
            var result = _city.GetById(Id);

            if (result == null) return NotFound();

            return Ok(result);
        }

        [HttpPost]
        [Route("api/Person/Add")]
        public async Task<IActionResult> Add([FromBody]City city)
        {
            if (city == null) return BadRequest();

            await _city.Add(city);

            return Ok(city);
        }

        [HttpPut]
        [Route("api/Person/Update")]
        public async Task<IActionResult> Update([FromBody]City city)
        {
            if (city == null) return BadRequest();

            await _city.Update(city);

            return Ok(city);
        }

        [HttpDelete]
        [Route("api/Person/Delete")]
        public async Task<IActionResult> Delete(int Id)
        {
            if (Id == 0) return BadRequest();

            await _city.Delete(Id);

            return Ok("Deleted");
        }
    }
}