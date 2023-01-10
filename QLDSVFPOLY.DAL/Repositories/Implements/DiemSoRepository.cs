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
        QLSVDbContext _dbContext;

        public DiemSoRepository()
        {
            _dbContext = new QLSVDbContext();
        }

        public async Task<List<DiemSo>> GetAllAsync()
        {
            return await Task.FromResult(_dbContext.DiemSos.ToList());
        }

        public async Task<DiemSo> CreateAsync(DiemSo obj)
        {
            return (await _dbContext.DiemSos.AddAsync(obj)).Entity;
        }

        public async Task<DiemSo> UpdateAsync(DiemSo obj)
        {
            return await (Task.FromResult(_dbContext.DiemSos.Update(obj).Entity));
        }

        public async Task<DiemSo> RemoveAsync(Guid id)
        {
            var obj = _dbContext.DiemSos.FirstOrDefault(x => x.Id == id);
            return await (Task.FromResult(_dbContext.DiemSos.Remove(obj).Entity));
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
