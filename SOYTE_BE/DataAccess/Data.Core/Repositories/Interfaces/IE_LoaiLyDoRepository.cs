using Business.Entities;
using Business.Entities.ViewModels;
using Data.Core.Repositories.Base;
using System;
using System.Data;
using System.Collections.Generic;


namespace Data.Core.Repositories.Interfaces
{
    public interface IE_LoaiLyDoRepository : IRepository<E_LoaiLyDo>
    {
        IEnumerable<E_LoaiLyDo> DBMaster_E_LoaiLyDo_GetAll();
    }
}
