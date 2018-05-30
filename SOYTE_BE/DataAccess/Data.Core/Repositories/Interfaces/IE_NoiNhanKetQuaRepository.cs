using Business.Entities;
using Business.Entities.ViewModels;
using Data.Core.Repositories.Base;
using System;
using System.Data;
using System.Collections.Generic;


namespace Data.Core.Repositories.Interfaces
{
    public interface IE_NoiNhanKetQuaRepository : IRepository<E_NoiNhanKetQua>
    {
        IEnumerable<E_NoiNhanKetQua> MotCua_E_NoiNhanKetQua_GetAll();
    }
}
