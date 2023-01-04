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


        public async Task<ChiTietDiemSo> DeleteAsync(Guid idDiemSo, Guid idLopHoc, Guid idSinhVien)
        {
            var tempobj = _qLSVDbContext.ChiTietDiemSos.FirstOrDefault(c => c.IdDiemSo == idDiemSo
                                                                 && c.IdChiTietLopHoc == idLopHoc
                                                                 && c.IdSinhVien == idSinhVien);
            _qLSVDbContext.Remove(tempobj);
            await _qLSVDbContext.SaveChangesAsync();
            return tempobj;
        }

        public async Task<List<ChiTietDiemSo>> GetAllChiTietDiemSoAsync()
        {
            return await _qLSVDbContext.ChiTietDiemSos.ToListAsync();
        }

        public async Task<ChiTietDiemSo> UpdateAsync(ChiTietDiemSo obj)
        {
            var tempobj = _qLSVDbContext.ChiTietDiemSos.Where(x => x.IdDiemSo == obj.IdDiemSo && x.IdSinhVien == obj.IdSinhVien && x.IdChiTietLopHoc == obj.IdChiTietLopHoc).FirstOrDefault();

            _qLSVDbContext.Update(tempobj);
            await _qLSVDbContext.SaveChangesAsync();
            return tempobj;
        }

        public async Task<ChiTietDiemSo> CreateAsync(ChiTietDiemSo obj)
        {
            await _qLSVDbContext.AddAsync(obj);
            await _qLSVDbContext.SaveChangesAsync();
            return obj;
        }

        public async Task<ChiTietDiemSo> GetByIdAsync(Guid idDiemSo, Guid idLopHoc, Guid idSinhVien)
        {
            var tempobj = await _qLSVDbContext.ChiTietDiemSos.FirstOrDefaultAsync(c => c.IdDiemSo == idDiemSo
                                                                && c.IdChiTietLopHoc == idLopHoc
                                                                && c.IdSinhVien == idSinhVien);
            return tempobj;
        }

        public async Task SaveChangesAsync()
        {
            await _qLSVDbContext.SaveChangesAsync();
        }
    }
}
