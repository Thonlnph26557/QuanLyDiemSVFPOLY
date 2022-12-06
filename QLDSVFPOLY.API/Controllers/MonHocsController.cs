using Microsoft.AspNetCore.Http;
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

        //lấy ra danh sách môn học còn hoạt động kết hợp tìm kiếm
        [HttpGet("active")]
        public async Task<IActionResult> GetAllMonHocActive([FromQuery] MonHocSearchVM search)
        {
            var listMonHocSearch = await _monHocServices.GetAllActiveAsync(search);

            if (search.Ma == null
                && search.Ten == null
                && search.TrangThai == 0
                )
            {
                listMonHocSearch = await _monHocServices.GetAllActiveAsync(null);
            }
            return Ok(listMonHocSearch);
        }

        //
        [HttpGet("all")]
        public async Task<IActionResult> GetAllMonHoc([FromQuery] MonHocSearchVM search)
        {
            var listMonHocSearch = await _monHocServices.GetAllAsync(search);

            if (search.Ma == null
                && search.Ten == null
                && search.TrangThai == 0
                )
            {
                listMonHocSearch = await _monHocServices.GetAllActiveAsync(null);
            }

            return Ok(listMonHocSearch);
        }

        // GetById ??? 
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetMonHocById(Guid IdMonHoc)
        {
            var monHoc = await _monHocServices.GetByIdAsync(IdMonHoc);
            return Ok(monHoc);
        }

        //Controller dc gọi khi thêm obj
        [HttpPost]
        public async Task<IActionResult> CreateMonHoc([FromBody] MonHocCreateVM monHoc)
        {
            if (monHoc == null)
                return BadRequest();

            var newMonHoc = await _monHocServices.CreateAsync(monHoc);

            return Ok(newMonHoc);
        }

        //Controller dc gọi khi update obj
        [HttpPut]
        [Route("{IdMonHoc}")]
        public async Task<IActionResult> UpdateMonHoc(Guid IdMonHoc, [FromBody] MonHocUpdateVM monHoc)
        {
            var result = await _monHocServices.UpdateAsync(IdMonHoc, monHoc);
            return Ok(result);
        }

        //
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveAsync(Guid id)
        {
            var temp = await _monHocServices.UpdateRemoveAsync(id);
            return Ok(temp);
        }

    }
}
