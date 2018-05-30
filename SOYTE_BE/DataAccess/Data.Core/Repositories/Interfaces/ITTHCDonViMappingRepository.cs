using System.Collections.Generic;
using Business.Entities;
using Data.Core.Repositories.Base;

namespace Data.Core.Repositories.Interfaces
{
    public interface ITTHCDonViMappingRepository : IRepository<TTHCDonViMapping>
    {
        List<DanhMuc> GetTTHCDonViByCapDonViPaged(string keySearch, string capDonViId, int pageSize, int pageIndex, out int totalItems);
    }
}
