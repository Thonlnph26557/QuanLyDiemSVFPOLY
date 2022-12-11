using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLDSVFPOLY.BUS.Services.Implements;
using QLDSVFPOLY.BUS.Services.Interfaces;
using QLDSVFPOLY.BUS.ViewModels.SinhVien;
using QLDSVFPOLY.DAL.Entities.EF;

namespace QLDSVFPOLY.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SinhViensController : ControllerBase
    {
        //
        private readonly ISinhVienServices _sinhVienServices;
        private QLSVDbContext _qLSVDbContext;

        //
        public SinhViensController(ISinhVienServices sinhVienServices)
        {
            _sinhVienServices = sinhVienServices;
            _qLSVDbContext = new QLSVDbContext();
        }

        //lấy ra danh sách sinh viên còn hoạt động kết hợp tìm kiếm
        [HttpGet("allactive")]
        public async Task<IActionResult> GetAllSinhVienActive([FromQuery] SinhVienSearchVM search)
        {
            var listSinhVienSearch = await _sinhVienServices.GetAllActiveAsync(search);
            return Ok(listSinhVienSearch);
        }

        //
        [HttpGet("all")]
        public async Task<IActionResult> GetAllSinhVien([FromQuery] SinhVienSearchVM search)
        {
            var listSinhVienSearch = await _sinhVienServices.GetAllAsync(search);

            return Ok(listSinhVienSearch);
        }

        // GetById ??? 
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetSinhVienById(Guid id)
        {
            var sinhVien = await _sinhVienServices.GetByIdAsync(id);
            return Ok(sinhVien);
        }

        //Controller dc gọi khi thêm obj
        [HttpPost]
        public async Task<IActionResult> CreateSinhVien([FromBody] SinhVienCreateVM sinhVien)
        {
            if (sinhVien == null)
                return BadRequest();

            var newSinhVien = await _sinhVienServices.CreateAsync(sinhVien);

            return Ok(newSinhVien);
        }

        //Controller dc gọi khi update obj
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateSinhVien(Guid id, [FromBody] SinhVienUpdateVM sinhVien)
        {
            var result = await _sinhVienServices.UpdateAsync(id, sinhVien);
            return Ok(result);
        }

        //
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSinhVien(Guid id)
        {
            var temp = await _sinhVienServices.UpdateRemoveAsync(id);
            return Ok(temp);
        }

    }
}
