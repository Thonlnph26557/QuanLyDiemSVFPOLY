using QLDSVFPOLY.DAL.Repositories.Interfaces;
using QLDSVFPOLY.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using QLDSVFPOLY.DAL.Entities.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSVFPOLY.DAL.Repositories.Implements
{
    public class ChiTietDiemSoRepository : IChiTietDiemSoRepository
    {
        QLSVDbContext _qLSVDbContext;

        public ChiTietDiemSoRepository()
        {
            _qLSVDbContext = new QLSVDbContext();
        }

        public async Task<List<ChiTietDiemSo>> GetAllAsync()
        {
            return await _qLSVDbContext.ChiTietDiemSos.ToListAsync();
        }

        public async Task<ChiTietDiemSo> CreateAsync(ChiTietDiemSo obj)
        {
            return (await _qLSVDbContext.ChiTietDiemSos.AddAsync(obj)).Entity;
        }

        public async Task<ChiTietDiemSo> UpdateAsync(ChiTietDiemSo obj)
        {
            return await (Task.FromResult(_qLSVDbContext.ChiTietDiemSos.Update(obj).Entity));
        }

        public async Task<ChiTietDiemSo> RemoveAsync(Guid idDiemSo, Guid idLopHoc, Guid idSinhVien)
        {
            var tempobj = _qLSVDbContext.ChiTietDiemSos.FirstOrDefault(c => c.IdDiemSo == idDiemSo
                                                                 && c.IdChiTietLopHoc == idLopHoc
                                                                 && c.IdSinhVien == idSinhVien);
            return await (Task.FromResult(_qLSVDbContext.ChiTietDiemSos.Remove(tempobj).Entity));
        }

        public async Task SaveChangesAsync()
        {
            await _qLSVDbContext.SaveChangesAsync();
        }
    }
}
