using Business.Entities;
using Business.Entities.ViewModels;
using Data.Core.Repositories.Base;
using System;
using System.Data;
using System.Collections.Generic;


namespace Data.Core.Repositories.Interfaces
{
    public interface IE_LoaiCapPhepRepository : IRepository<E_LoaiCapPhep>
    {
        IEnumerable<E_LoaiCapPhep> DBMaster_E_LoaiCapPhep_GetAll();
    }
}
