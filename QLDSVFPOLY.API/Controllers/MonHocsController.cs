﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLDSVFPOLY.BUS.Services.Implements;
using QLDSVFPOLY.BUS.Services.Interfaces;
using QLDSVFPOLY.BUS.ViewModels.DaoTao;
using QLDSVFPOLY.BUS.ViewModels.MonHoc;
using QLDSVFPOLY.DAL.Entities.EF;

namespace QLDSVFPOLY.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonHocsController : ControllerBase
    {
        //
        private readonly IMonHocServices _monHocServices;
        private QLSVDbContext _qLSVDbContext;

        //
        public MonHocsController(IMonHocServices monHocServices)
        {
            _monHocServices = monHocServices;
            _qLSVDbContext = new QLSVDbContext();
        }

        //
        [HttpGet("active")]
        public async Task<IActionResult> GetListMonHocList([FromQuery] MonHocSearchVM search)
        {
            var objCollection = await _monHocServices.GetAllActiveAsync(search);

            if (search.Ma == null
                && search.Ten == null
                && search.TrangThai == 0
                && search.IdChuyenNganh == null
                )
            {
                objCollection = await _monHocServices.GetAllActiveAsync(null);
            }
            return Ok(objCollection);
        }

        //
        [HttpGet("all")]
        public async Task<IActionResult> GetAllMonHoc([FromQuery] MonHocSearchVM search)
        {
            var objCollection = await _monHocServices.GetAllAsync(search);

            if (search.Ma == null
                && search.Ten == null
                && search.TrangThai == 0
                && search.IdChuyenNganh == null
                )
            {
                objCollection = await _monHocServices.GetAllActiveAsync(null);
            }

            return Ok(objCollection);
        }

        //
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetMonHocListById(Guid IdMonHoc)
        {
            var lecturerModel = await _monHocServices.GetByIdAsync(IdMonHoc);
            return Ok(lecturerModel);
        }

        //
        [HttpPost]
        public async Task<IActionResult> CreateMonHoc([FromBody] MonHocCreateVM request)
        {
            if (request == null)
                return BadRequest();

            var newRole = await _monHocServices.CreateAsync(request);

            return Ok(newRole);
        }

        //
        [HttpPut]
        [Route("{IdMonHoc}")]
        public async Task<IActionResult> UpdateMonHoc(Guid IdMonHoc, [FromBody] MonHocUpdateVM request)
        {
            var result = await _monHocServices.UpdateAsync(IdMonHoc, request);
            return Ok(result);
        }

        //
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveAsync(Guid id)
        {
            var temp = await _monHocServices.RemoveAsync(id);
            return Ok(temp);
        }

    }
}