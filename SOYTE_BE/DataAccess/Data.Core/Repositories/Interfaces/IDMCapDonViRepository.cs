using Business.Entities;
using Data.Core.Repositories.Base;
using System.Collections.Generic;

namespace Data.Core.Repositories.Interfaces
{
    public interface IDMCapDonViRepository : IRepository<DMCapDonVi>
    {
        IEnumerable<DMCapDonVi> GetDanhMucCapDonVi(int? pageSize, int? pageIndex);

        List<DMCapDonVi> GetDMCapDonViConditionByPaged(string ten, bool? isActive, int pageSize, int pageIndex);
    }
}
