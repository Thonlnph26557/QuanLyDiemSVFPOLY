using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLDSVFPOLY.BUS.Services.Interfaces;
using QLDSVFPOLY.BUS.ViewModels.MonHoc;

namespace QLDSVFPOLY.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonHocsController : ControllerBase
    {
        //
        private readonly IMonHocServices _monHocServices;

        //
        public MonHocsController(IMonHocServices monHocServices)
        {
            _monHocServices = monHocServices;
        }

        //
        [HttpGet("all")]
        public async Task<IActionResult> GetAllMonHoc([FromQuery] MonHocSearchVM search)
        {
            var listMonHocSearch = await _monHocServices.GetAllAsync(search);
            return Ok(listMonHocSearch);
        }

        //lấy ra danh sách môn học còn hoạt động kết hợp tìm kiếm
        [HttpGet("allactive")]
        public async Task<IActionResult> GetAllMonHocActive([FromQuery] MonHocSearchVM search)
        {
            var listMonHocSearch = await _monHocServices.GetAllActiveAsync(search);
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
        [Route("{Id}")]
        public async Task<IActionResult> UpdateMonHoc(Guid Id, [FromBody] MonHocUpdateVM monHoc)
        {
            var result = await _monHocServices.UpdateAsync(Id, monHoc);
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
