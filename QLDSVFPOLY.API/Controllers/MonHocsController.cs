using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLDSVFPOLY.BUS.Services.Implements;
using QLDSVFPOLY.BUS.Services.Interfaces;
using QLDSVFPOLY.BUS.ViewModels.MonHoc;

namespace QLDSVFPOLY.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonHocsController : ControllerBase
    {
        //
        private readonly IMonHocServices _iMonHocRepository;

        //
        public MonHocsController(IMonHocServices imonHocServices)
        {
            _iMonHocRepository = imonHocServices ?? throw new ArgumentNullException(nameof(imonHocServices));
        }

        //
        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> GetAllAsync()
        {
            var listObjectVM = await _iMonHocRepository.GetAllAsync();
            return Ok(listObjectVM);
        }

        //lấy ra danh sách môn học còn hoạt động kết hợp tìm kiếm
        [HttpGet("GetAllActiveAsync")]
        public async Task<IActionResult> GetAllActiveAsync()
        {
            var listObjectVM = await _iMonHocRepository.GetAllActiveAsync();
            return Ok(listObjectVM);
        }



        // GetById 
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var objVM = await _iMonHocRepository.GetByIdAsync(id);
            return Ok(objVM);
        }

        //Controller dc gọi khi thêm obj
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] MonHocCreateVM obj)
        {
            if (obj == null)
                return BadRequest();

            var newObjCreateVM = await _iMonHocRepository.CreateAsync(obj);

            return Ok(newObjCreateVM);
        }

        //Controller dc gọi khi update obj
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] MonHocUpdateVM obj)
        {
            var objVM = await _iMonHocRepository.UpdateAsync(id, obj);
            return Ok(objVM);
        }

        //
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveAsync(Guid id)
        {
            var objRemoveVM = await _iMonHocRepository.UpdateRemoveAsync(id);
            return Ok(objRemoveVM);
        }

    }
}
