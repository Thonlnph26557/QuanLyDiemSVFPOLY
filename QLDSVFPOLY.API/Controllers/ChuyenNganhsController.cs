using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLDSVFPOLY.BUS.Services.Implements;
using QLDSVFPOLY.BUS.Services.Interfaces;
using QLDSVFPOLY.BUS.ViewModels.ChuyenNganh;

namespace QLDSVFPOLY.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChuyenNganhsController : ControllerBase
    {
        IChuyenNganhServices _iChuyenNganhServices;
        public ChuyenNganhsController(IChuyenNganhServices iChuyenNganhServices)
        {
            _iChuyenNganhServices = iChuyenNganhServices;
        }

        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> GetAllAsync()
        {
            var list = await _iChuyenNganhServices.GetAllAsync();
            return Ok(list);
        }

        [HttpGet("GetAllActiveAsync")]
        public async Task<IActionResult> GetAllActiveAsync()
        {
            var list = await _iChuyenNganhServices.GetAllActiveAsync();
            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var temp = await _iChuyenNganhServices.GetByIdAsync(id);
            return Ok(temp);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] ChuyenNganhCreateVM obj)
        {
            if (obj == null) return BadRequest();
            var temp = await _iChuyenNganhServices.CreateAsync(obj);
            return Ok(temp);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] ChuyenNganhUpdateVM obj)
        {
            var temp = await _iChuyenNganhServices.UpdateAsync(id, obj);
            return Ok(temp);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveAsync(Guid id)
        {
            var temp = await _iChuyenNganhServices.UpdateTrangThaiAsync(id);
            return Ok(temp);
        }

        //lấy ra chuyên ngành hẹp theo idChuyenNganh 
        [HttpGet]
        [Route("GetChuyenNganhhepById/{id}")]
        public async Task<IActionResult> GetChuyenNganhhepById(Guid id)
        {
            var listCNHep = await _iChuyenNganhServices.GetChuyenNganhHepById(id);
            return Ok(listCNHep);
        }

    }
}
