using Business.Entities;
using Business.Entities.ViewModels;
using Data.Core.Repositories.Base;
using System;
using System.Data;
using System.Collections.Generic;


namespace Data.Core.Repositories.Interfaces
{
    public interface IE_LoaiGoiYRepository : IRepository<E_LoaiGoiY>
    {
        IEnumerable<E_LoaiGoiY> DBMaster_E_LoaiGoiY_GetAll();
    }
}
