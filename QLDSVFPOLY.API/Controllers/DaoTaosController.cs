using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLDSVFPOLY.BUS.Services.Interfaces;
using QLDSVFPOLY.BUS.ViewModels.DaoTao;
using QLDSVFPOLY.DTO.Entities.EF;

namespace QLDSVFPOLY.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DaoTaosController : ControllerBase
    {
        //
        private readonly IDaoTaoServices _daoTaoServices;
        private QLSVDbContext _qLSVDbContext;

        //
        public DaoTaosController(IDaoTaoServices daoTaoServices)
        {
            _daoTaoServices = daoTaoServices;
            _qLSVDbContext = new QLSVDbContext();
        }

        //
        [HttpGet]
        public async Task<IActionResult> GetListDaoTaoList([FromQuery] DaoTaoSearchVM search)
        {
            var objCollection = await _daoTaoServices.GetAllActiveAsync(search);

            var result = objCollection.Select(c => new DaoTaoVM
            {
                Id = c.Id,
                Ma = c.Ma,
                DiaChi = c.DiaChi,
                SoDienThoai = c.SoDienThoai,
                Email = c.Email,
                TenDangNhap = c.TenDangNhap,
                MatKhau = c.MatKhau,
                NgayTao = c.NgayTao,
                TrangThai = c.TrangThai,
            }).ToList();
            return Ok(result);
        }

        //
        [HttpGet("all")]
        public async Task<IActionResult> GetAllDaoTao()
        {
            var objCollection = await _daoTaoServices.GetAllAsync(null);

            return Ok(objCollection);
        }

        //
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetDaoTaoListById(Guid IdDaoTao)
        {
            var lecturerModel = await _daoTaoServices.GetByIdAsync(IdDaoTao);
            return Ok(lecturerModel);
        }

        //
        [HttpPost]
        public async Task<IActionResult> CreateDaoTao([FromBody] DaoTaoCreateVM request)
        {
            if (request == null)
                return BadRequest();

            var newRole = await _daoTaoServices.CreateAsync(request);

            return Ok(newRole);
        }

        //
        [HttpPut]
        [Route("{IdDaoTao}")]
        public async Task<IActionResult> UpdateDaoTao(Guid IdDaoTao, [FromBody] DaoTaoUpdateVM request)
        {
            var result = await _daoTaoServices.UpdateAsync(IdDaoTao, request);
            return Ok(result);
        }
    }
}
