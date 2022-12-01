using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLDSVFPOLY.BUS.Services.Implements;
using QLDSVFPOLY.BUS.Services.Interfaces;
using QLDSVFPOLY.BUS.ViewModels.GiangVien;

namespace QLDSVFPOLY.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GiangVienController : ControllerBase
    {
        private readonly IGiangVienServices _iGiangVienServices;

        public GiangVienController(IGiangVienServices iGiangVienServices)
        {
            _iGiangVienServices = iGiangVienServices;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllGiangVien([FromQuery] GiangVienSearchVM searchVm)
        {
            var listGiangVienSearch = await _iGiangVienServices.GetAllAsync(searchVm);

            if (searchVm.Ma == null
                && searchVm.SoDienThoai == null
                && searchVm.Ten == null
                )
            {
                listGiangVienSearch = await _iGiangVienServices.GetAllAsync(null);
            }

            return Ok(listGiangVienSearch);
        }

        //lấy ra danh sách giảng viên còn hoạt động kết hợp tìm kiếm
        [HttpGet("active")]
        public async Task<IActionResult> GetAllGiangVienActive([FromQuery] GiangVienSearchVM searchVm)
        {
            var listGiangVienSearch = await _iGiangVienServices.GetAllActiveAsync(searchVm);

            if (searchVm.Ma == null
                && searchVm.SoDienThoai == null
                && searchVm.Ten == null
                )
            {
                await _iGiangVienServices.GetAllActiveAsync(null);
            }

            return Ok(listGiangVienSearch);
        }


        //GetById ??? 
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetGiangVienById(Guid id)
        {
            var giangVien = await _iGiangVienServices.GetByIdAsync(id);
            return Ok(giangVien);
        }

        //Controller dc gọi khi thêm obj
        [HttpPost]
        public async Task<IActionResult> CreateGiangVien([FromBody] GiangVienCreateVM giangVien)
        {
            if (giangVien == null)
                return BadRequest();

            var newGiangVien = await _iGiangVienServices.CreateAsync(giangVien);

            return Ok(newGiangVien);
        }

        //Controller dc gọi khi update obj
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateGiangVien(Guid id, [FromBody] GiangVienUpdateVM giangVien)
        {
            var result = await _iGiangVienServices.UpdateAsync(id, giangVien);
            return Ok(result);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteGiangVien(Guid id)
        {
            var result = await _iGiangVienServices.RemoveAsync(id);
            return Ok(result);
        }

    }
}
