using Business.Entities;
using Data.Core.Repositories.Base;
using System.Collections.Generic;

namespace Data.Core.Repositories.Interfaces
{
    public interface ILinhVucRepository : IRepository<DMLinhVuc>
    {
        bool AddLinhVucByPaging(List<DMLinhVuc> items);

        List<DMLinhVuc> GetDMLinhVucByPaging(string keySearch, int pageSize, int pageIndex, out int totalItems);
    }
}
