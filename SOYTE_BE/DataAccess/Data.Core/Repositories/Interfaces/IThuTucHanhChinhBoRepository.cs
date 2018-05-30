using Business.Entities;
using System.Collections.Generic;
using Data.Core.Repositories.Base;

namespace Data.Core.Repositories.Interfaces
{
    public interface IThuTucHanhChinhBoRepository : IRepository<ThuTucHanhChinhBo>
    {
        bool AddTTHCByPaging(List<ThuTucHanhChinhBo> items);
    }
}
