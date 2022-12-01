using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLDSVFPOLY.BUS.Services.Interfaces;
using QLDSVFPOLY.BUS.ViewModels.SinhVien;

namespace QLDSVFPOLY.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SinhViensController : ControllerBase
    {
        //
        private readonly ISinhVienServices _sinhVienServices;

        //
        public SinhViensController(ISinhVienServices sinhVienServices)
        {
            _sinhVienServices = sinhVienServices;
        }

        //
        [HttpGet]
        public async Task<IActionResult> GetListSinhVienList([FromQuery] SinhVienSearchVM search)
        {
            var objCollection = await _sinhVienServices.GetAllActiveAsync(search);

            var result = objCollection.Select(c => new SinhVienVM
            {
                Id = c.Id,
                Ma = c.Ma,
                Ho = c.Ho,
                TenDem = c.TenDem,
                Ten = c.Ten,
                GioiTinh = c.GioiTinh,
                NgaySinh = c.NgaySinh,
                DiaChi = c.DiaChi,
                SoDienThoai = c.SoDienThoai,
                Email = c.Email,
                TenDangNhap = c.TenDangNhap,
                MatKhau = c.MatKhau,
                DuongDanAnh = c.DuongDanAnh,
                NgayTao = c.NgayTao,
                TrangThai = c.TrangThai,
                IdChuyenNganh = c.IdChuyenNganh,
            }).ToList();
            return Ok(result);
        }

        //
        [HttpGet("all")]
        public async Task<IActionResult> GetAllSinhVien()
        {
            var objCollection = await _sinhVienServices.GetAllAsync(null);

            return Ok(objCollection);
        }

        //
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetSinhVienistById(Guid IdSinhVien)
        {
            var lecturerModel = await _sinhVienServices.GetByIdAsync(IdSinhVien);
            return Ok(lecturerModel);
        }

        //
        [HttpPost]
        public async Task<IActionResult> CreateSinhVien([FromBody] SinhVienCreateVM request)
        {
            if (request == null)
                return BadRequest();

            var newRole = await _sinhVienServices.CreateAsync(request);

            return Ok(newRole);
        }

        //
        [HttpPut]
        [Route("{IdSinhVien}")]
        public async Task<IActionResult> UpdateSinhVien(Guid IdSinhVien, [FromBody] SinhVienUpdateVM request)
        {
            var result = await _sinhVienServices.UpdateAsync(IdSinhVien, request);
            return Ok(result);
        }
    }
}
