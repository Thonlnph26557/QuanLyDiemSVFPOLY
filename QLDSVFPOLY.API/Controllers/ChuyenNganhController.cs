﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLDSVFPOLY.BUS.Services.Implements;
using QLDSVFPOLY.BUS.Services.Interfaces;
using QLDSVFPOLY.BUS.ViewModels.ChuyenNganh;
using QLDSVFPOLY.DTO.Extensions;

namespace QLDSVFPOLY.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChuyenNganhController : ControllerBase
    {
        IChuyenNganhServices _sv;
        public ChuyenNganhController()
        {
            _sv = new ChuyenNganhServices();
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllAsync([FromQuery] ChuyenNganhSearchVM obj)
        {
            var list = await _sv.GetAllAsync(obj);
            return Ok(list);
        }

        [HttpGet("allactive")]
        public async Task<IActionResult> GetAllActiveAsync([FromQuery] ChuyenNganhSearchVM obj)
        {
            var list = await _sv.GetAllActiveAsync(obj);
            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var temp = await _sv.GetByIdAsync(id);
            return Ok(temp);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] ChuyenNganhCreateVM obj)
        {
            if (obj == null) return BadRequest();
            var temp = await _sv.CreateAsync(obj);
            return Ok(temp);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] ChuyenNganhUpdateVM obj)
        {
            var temp = await _sv.UpdateAsync(id, obj);
            return Ok(temp);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveAsync(Guid id)
        {
            var temp = await _sv.RemoveAsync(id);
            return Ok(temp);
        }
    }
}
