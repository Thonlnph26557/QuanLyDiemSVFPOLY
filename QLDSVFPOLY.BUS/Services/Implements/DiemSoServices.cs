using QLDSVFPOLY.BUS.Services.Interfaces;
using QLDSVFPOLY.BUS.ViewModels.DiemSo;
using QLDSVFPOLY.DAL.Repositories.Implements;
using QLDSVFPOLY.DAL.Repositories.Interfaces;
using QLDSVFPOLY.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSVFPOLY.BUS.Services.Implements
{
    public class DiemSoServices : IDiemSoServices
    {
        IDiemSoRepository _iDiemSoRepository;
        List<DiemSo> _listDiemSo;


        public DiemSoServices()
        {
            _iDiemSoRepository = new DiemSoRepository();
        }

        public Task<bool> CreateAsync(DiemSoCreateVM obj)
        {
            throw new NotImplementedException();
        }

        public Task<List<DiemSoVM>> GetAllActiveAsync(DiemSoSearchVM obj)
        {
            throw new NotImplementedException();
        }

        public Task<List<DiemSoVM>> GetAllAsync(DiemSoSearchVM obj)
        {
            throw new NotImplementedException();
        }

        public Task<DiemSoVM> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Guid id, DiemSoUpdateVM obj)
        {
            throw new NotImplementedException();
        }
    }
}
