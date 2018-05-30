using System.Collections.Generic;
using Business.Entities;
using Data.Core.Repositories.Base;

namespace Data.Core.Repositories.Interfaces
{
    public interface IDMDonViRepository : IRepository<DM_DonVi>
    {
        List<DM_DonVi> GetDMDonViConditionByPaged(string ten, string capDonViId, bool? isActive, int pageSize, int pageIndex);
    }
}
