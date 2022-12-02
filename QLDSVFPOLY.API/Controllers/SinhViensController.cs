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

        //
        [HttpGet("active")]
        public async Task<IActionResult> GetListSinhVienList([FromQuery] SinhVienSearchVM search)
        {
            var objCollection = await _sinhVienServices.GetAllActiveAsync(search);

            if (search.Ma == null
                && search.Ho == null
                && search.TenDem == null
                && search.Ten == null
                && search.GioiTinh == 0
                && search.DiaChi == null
                && search.SoDienThoai == null
                && search.Email == null
                && search.TrangThai == 0
                && search.IdChuyenNganh == null)
            {
                objCollection = await _sinhVienServices.GetAllActiveAsync(null);
            }

            return Ok(objCollection);
        }

        //
        [HttpGet("all")]
        public async Task<IActionResult> GetAllSinhVien([FromQuery] SinhVienSearchVM search)
        {
            var objCollection = await _sinhVienServices.GetAllAsync(search);

            if (search.Ma == null
                && search.Ho == null
                && search.TenDem == null
                && search.Ten == null
                && search.GioiTinh == 0
                && search.DiaChi == null
                && search.SoDienThoai == null
                && search.Email == null
                && search.TrangThai == 0
                && search.IdChuyenNganh == null)
            {
                objCollection = await _sinhVienServices.GetAllActiveAsync(null);
            }

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

        //
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveAsync(Guid id)
        {
            var temp = await _sinhVienServices.RemoveAsync(id);
            return Ok(temp);
        }

    }
}
