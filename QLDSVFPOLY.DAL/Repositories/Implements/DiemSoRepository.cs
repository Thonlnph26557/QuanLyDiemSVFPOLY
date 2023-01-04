using Microsoft.EntityFrameworkCore;
using QLDSVFPOLY.DAL.Repositories.Interfaces;
using QLDSVFPOLY.DAL.Entities;
using QLDSVFPOLY.DAL.Entities.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSVFPOLY.DAL.Repositories.Implements
{
    public class DiemSoRepository : IDiemSoRepository
    {
        QLSVDbContext _qLSVDbContext;

        public DiemSoRepository()
        {
            _qLSVDbContext = new QLSVDbContext();
        }

        public async Task<DiemSo> CreateAsync(DiemSo obj)
        {
            await _qLSVDbContext.DiemSos.AddAsync(obj);
            await _qLSVDbContext.SaveChangesAsync();
            return obj;
        }

        public async Task<DiemSo> DeleteAsync(Guid id)
        {
            var tempobj = _qLSVDbContext.DiemSos.FirstOrDefault(x => x.Id == id);

            _qLSVDbContext.Remove(tempobj);
            await _qLSVDbContext.SaveChangesAsync();
            return tempobj;
        }

        public async Task<DiemSo> UpdateAsync(DiemSo obj)
        {
            var tempobj = _qLSVDbContext.DiemSos.FirstOrDefault(x => x.Id == obj.Id);

            _qLSVDbContext.Update(tempobj);
            await _qLSVDbContext.SaveChangesAsync();
            return tempobj;
        }

        public async Task<List<DiemSo>> GetAllDiemSoAsync()
        {
            return await _qLSVDbContext.DiemSos.ToListAsync();
        }

        public async Task<DiemSo> GetById(Guid id)
        {
            return await _qLSVDbContext.DiemSos.FindAsync(id);
        }

        public async Task SaveChangesAsync()
        {
            await _qLSVDbContext.SaveChangesAsync();
        }
    }
}
