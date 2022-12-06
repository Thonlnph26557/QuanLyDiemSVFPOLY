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
            _iChuyenNganhMonHocServices = iChuyenNganhMonHocServices;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllChuyenNganhMonHoc([FromQuery] ChuyenNganhMonHocSearchVM searchVm)
        {
            var listCNMHSearch = await _iChuyenNganhMonHocServices.GetAllAsync(searchVm);

            return Ok(listCNMHSearch);
        }

        //lấy ra danh sách giảng viên còn hoạt động kết hợp tìm kiếm
        [HttpGet("active")]
        public async Task<IActionResult> GetAllChuyenNganhMonHocActive([FromQuery] ChuyenNganhMonHocSearchVM searchVm)
        {
            var listCNMHSearchActive = await _iChuyenNganhMonHocServices.GetAllActiveAsync(searchVm);

            return Ok(listCNMHSearchActive);
        }

        //GetById ??? 
        [HttpGet("getbyid")]
        // [Route("{id}")]
        public async Task<IActionResult> GetChuyenNganhMonHocById([FromQuery] Guid idChuyenNganh, [FromQuery] Guid idMonHoc)
        {
            var chuyenNganhMH = await _iChuyenNganhMonHocServices.GetByIdAsync(idChuyenNganh, idMonHoc);
            return Ok(chuyenNganhMH);
        }

        //Controller dc gọi khi thêm obj
        [HttpPost]
        public async Task<IActionResult> CreateChuyenNganhMonHoc([FromBody] ChuyenNganhMonHocCreateVM chuyenNganhMH, Guid idChuyenNganh, Guid idMonHoc)
        {
            if (chuyenNganhMH == null)
                return BadRequest();

            var newChuyenNganhMH = await _iChuyenNganhMonHocServices.CreateAsync(chuyenNganhMH, idChuyenNganh, idMonHoc);

            return Ok(newChuyenNganhMH);
        }

        [HttpDelete]
        //[Route("{id}")]
        public async Task<IActionResult> DeleteChuyenNganhMH([FromQuery] Guid idChuyenNganh, [FromQuery] Guid idMonHoc)
        {
            var result = await _iChuyenNganhMonHocServices.RemoveAsync(idChuyenNganh, idMonHoc);
            return Ok(result);
        }
    }
}
