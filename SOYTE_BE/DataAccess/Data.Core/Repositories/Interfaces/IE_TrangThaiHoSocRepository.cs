using Business.Entities;
using Business.Entities.ViewModels;
using Data.Core.Repositories.Base;
using System;
using System.Data;
using System.Collections.Generic;


namespace Data.Core.Repositories.Interfaces
{
    public interface IE_TrangThaiHoSoRepository : IRepository<E_TrangThaiHoSo>
    {
        IEnumerable<E_TrangThaiHoSo> MotCua_E_TrangThaiHoSo_GetAll();
    }
}
