using Microsoft.EntityFrameworkCore;
using QLDSVFPOLY.DAL.Entities;
using QLDSVFPOLY.DAL.Entities.EF;
using QLDSVFPOLY.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSVFPOLY.DAL.Repositories.Implements
{
    public class ChuyenNganhMonHocRepository : IChuyenNganhMonHocRepository
    {
        QLSVDbContext _qLSVDbContext;

        public ChuyenNganhMonHocRepository()
        {
            _qLSVDbContext = new QLSVDbContext();
        }

        public async Task<ChuyenNganhMonHoc> CreateAsync(ChuyenNganhMonHoc obj)
        {
            await _qLSVDbContext.AddAsync(obj);
            await _qLSVDbContext.SaveChangesAsync();
            return obj;
        }

        public async Task<ChuyenNganhMonHoc> DeleteAsync(Guid idChuyenNganh, Guid idMonHoc)
        {
            var tempobj = _qLSVDbContext.ChuyenNganhMonHocs.FirstOrDefault(c => c.IdChuyenNganh == idChuyenNganh
                                                                 && c.IdMonHoc == idMonHoc);
            _qLSVDbContext.Remove(tempobj);
            await _qLSVDbContext.SaveChangesAsync();
            return tempobj;
        }

        public async Task<ChuyenNganhMonHoc> UpdateAsync(ChuyenNganhMonHoc obj)
        {
            var tempobj = _qLSVDbContext.ChuyenNganhMonHocs.FirstOrDefault(x => x.IdChuyenNganh == obj.IdChuyenNganh && x.IdMonHoc == obj.IdMonHoc);

            _qLSVDbContext.Update(tempobj);
            await _qLSVDbContext.SaveChangesAsync();
            return tempobj;
        }

        public async Task<List<ChuyenNganhMonHoc>> GetAllAsync()
        {
            return await _qLSVDbContext.ChuyenNganhMonHocs.ToListAsync();
        }

        public async Task<ChuyenNganhMonHoc> GetByIdAsync(Guid idChuyenNganh, Guid idMonHoc)
        {
            var tempobj = await _qLSVDbContext.ChuyenNganhMonHocs.FirstOrDefaultAsync(c => c.IdChuyenNganh == idChuyenNganh
                                                     && c.IdMonHoc == idMonHoc);
            return tempobj;
        }

        public async Task SaveChangesAsync()
        {
            await _qLSVDbContext.SaveChangesAsync();
        }
    }
}
