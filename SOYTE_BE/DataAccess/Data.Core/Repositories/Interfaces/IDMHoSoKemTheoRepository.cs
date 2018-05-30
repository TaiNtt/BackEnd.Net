using Business.Entities;
using Business.Entities.ViewModels;
using Data.Core.Repositories.Base;
using System.Collections.Generic;

namespace Data.Core.Repositories.Interfaces
{
	public interface IDMHoSoKemTheoRepository : IRepository<DM_HoSoKemTheo>
	{
		string AddDMHoSoKemTheo(DM_HoSoKemTheo item);

		List<HoSoKemTheoViewModel> GetDMHoSoKemTheoditionByPaged(bool hoSoMoi, string linhVucId, string hoSoKemTheo,
			int pageSize, int pageIndex);
	}
}
