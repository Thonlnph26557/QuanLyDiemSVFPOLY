using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLDSVFPOLY.BUS.Services.Interfaces;
using QLDSVFPOLY.BUS.ViewModels.ChuyenNganhMonHoc;

namespace QLDSVFPOLY.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChuyenNganhMonHocsController : ControllerBase
    {
        private readonly IChuyenNganhMonHocServices _iChuyenNganhMonHocServices;

        public ChuyenNganhMonHocsController(IChuyenNganhMonHocServices iChuyenNganhMonHocServices)
        {
            _iChuyenNganhMonHocServices = iChuyenNganhMonHocServices ?? throw new ArgumentNullException(nameof(iChuyenNganhMonHocServices));
        }

        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> GetAllAsync()
        {
            var listObjectVM = await _iChuyenNganhMonHocServices.GetAllAsync();

            return Ok(listObjectVM);
        }

        //lấy ra danh sách CNMH còn hoạt động kết hợp tìm kiếm
        [HttpGet("GetAllActiveAsync")]
        public async Task<IActionResult> GetAllActiveAsync()
        {
            var listObjectVM = await _iChuyenNganhMonHocServices.GetAllActiveAsync();

            return Ok(listObjectVM);
        }

        //GetById 
        [HttpGet("id")]
        public async Task<IActionResult> GetByIdAsync([FromQuery] Guid idChuyenNganh, [FromQuery] Guid idMonHoc)
        {
            var objVM = await _iChuyenNganhMonHocServices.GetByIdAsync(idChuyenNganh, idMonHoc);
            return Ok(objVM);
        }

        //Controller dc gọi khi thêm obj
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] ChuyenNganhMonHocCreateVM obj)
        {
            if (obj == null) return BadRequest();

            var newObjCreateVM = await _iChuyenNganhMonHocServices.CreateAsync(obj);

            return Ok(newObjCreateVM);
        }

        [HttpDelete]
        
        public async Task<IActionResult> RemoveAsync([FromQuery] Guid idChuyenNganh, [FromQuery] Guid idMonHoc)
        {
            var objRemoveVM = await _iChuyenNganhMonHocServices.RemoveAsync(idChuyenNganh, idMonHoc);
            return Ok(objRemoveVM);
        }
    }
}
