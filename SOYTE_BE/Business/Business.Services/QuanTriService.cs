using Business.Entities;
using Business.Entities.ViewModels;
using Business.Services.Contracts;
using Core.Common.Utilities;
using Data.Core.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;

namespace Business.Services
{
    public class QuanTriService : IQuanTriService
    {
        #region Private Repository & contractor

        private readonly IParameterRepository _parameterRepository;
        private readonly ILinhVucRepository _linhVucRepository;
        private readonly IDMCapDonViRepository _dmCapDonViRepository;
        private readonly IDMDonViRepository _dmDonViRepository;
        private readonly ITTHCDonViMappingRepository _tthcDonViMapRepository;
        private readonly IDMHoSoKemTheoRepository _hoSoKemTheoMapRepository;
		public QuanTriService(
           ILinhVucRepository linhVucRepository,
           IParameterRepository parameterRepository,
           IDMCapDonViRepository dmCapDonViRepository,
           IDMDonViRepository dmDonViRepository,
           ITTHCDonViMappingRepository tthcDonViMapRepository,
		   IDMHoSoKemTheoRepository hoSoKemTheoMapRepository)
        {
            _parameterRepository = parameterRepository;
            _linhVucRepository = linhVucRepository;
            _dmCapDonViRepository = dmCapDonViRepository;
            _tthcDonViMapRepository = tthcDonViMapRepository;
            _dmDonViRepository = dmDonViRepository;
			_hoSoKemTheoMapRepository = hoSoKemTheoMapRepository;
        }

        #endregion

        public DMParameter GetParameterByKey(string key)
        {
            return _parameterRepository.GetParameterByKey(key);
        }

        public int InsParameter(DMParameter item)
        {
            return _parameterRepository.InsParameter(item);
        }

        public PagedData<DMLinhVuc> GetDanhMucLinhVucPaging(string keySearch, int pageSize, int pageIndex)
        {
            int totalItems;
            var datas = _linhVucRepository.GetDMLinhVucByPaging(keySearch, pageSize, pageIndex, out totalItems);
            return new PagedData<DMLinhVuc>
            {
                Data = datas,
                PageIndex = pageIndex,
                PageSize = pageSize,
                TotalItems = totalItems
            };
        }

		#region < DANH MUC HO SO KEM THEO >
		public PagedData<HoSoKemTheoViewModel> GetDMHoSoKemTheoditionByPaged(bool hoSoMoi, string linhVucId, string hoSoKemTheo,
			int pageSize, int pageIndex)
		{
			var datas = _hoSoKemTheoMapRepository.GetDMHoSoKemTheoditionByPaged(hoSoMoi, linhVucId, hoSoKemTheo, pageSize,
				pageIndex);
			return new PagedData<HoSoKemTheoViewModel>
			{
				Data = datas,
				PageIndex = pageIndex,
				PageSize = pageSize,
				TotalItems = datas.FirstOrDefault() != null ? datas.First().TotalItems : 0
			};
		}

	    public string AddDMHoSoKemTheo(DM_HoSoKemTheo item)
	    {
		    return _hoSoKemTheoMapRepository.AddDMHoSoKemTheo(item);
	    }
		#endregion

		#region DANH MỤC CHUNG
		public IEnumerable<DMCapDonVi> GetDanhMucCapDonVi(int? pageSize, int? pageIndex)
        {
            return _dmCapDonViRepository.GetDanhMucCapDonVi(pageSize, pageIndex);
        }

        public PagedData<DanhMuc> GetDMCapDonViConditionByPaged(string ten, string isActive, int pageSize, int pageIndex)
        {
            var datas = _dmCapDonViRepository.GetDMCapDonViConditionByPaged(ten, isActive.ToBoolNullable(), pageSize, pageIndex);

            return new PagedData<DanhMuc>
            {
                Data = (from model in datas select new DanhMuc { Id = model.Id, Name = model.Ten }).ToList(),
                PageIndex = pageIndex,
                PageSize = pageSize,
                TotalItems = datas.FirstOrDefault() != null ? datas.First().TotalItems : 0
            };
        }

        public PagedData<DanhMuc> GetDMLinhVucByPaging(string keySearch, int pageSize, int pageIndex)
        {
            int totalItems;
            var datas =
                _linhVucRepository.GetDMLinhVucByPaging(keySearch, pageSize, pageIndex, out totalItems)
                    .Select(m => new DanhMuc {Id = m.Id, Name = m.TenLinhVuc}).ToList();
            return new PagedData<DanhMuc>
            {
                Data = datas,
                PageIndex = pageIndex,
                PageSize = pageSize,
                TotalItems = totalItems
            };
        }

        public PagedData<DanhMuc> GetTTHCDonViByPaged(string keySearch, string capDonViId, int pageSize, int pageIndex)
        {
            int totalItems;
            var datas = _tthcDonViMapRepository.GetTTHCDonViByCapDonViPaged(keySearch, capDonViId, pageSize, pageIndex, out totalItems);
            return new PagedData<DanhMuc>
            {
                Data = datas,
                PageIndex = pageIndex,
                PageSize = pageSize,
                TotalItems = totalItems
            };
        }

        public PagedData<DanhMuc> GetDMDonViConditionByPaged(string ten, string capDonViId, string isActive, int pageSize, int pageIndex)
        {
            var datas = _dmDonViRepository.GetDMDonViConditionByPaged(ten, capDonViId, isActive.ToBoolNullable(), pageSize, pageIndex);

            return new PagedData<DanhMuc>
            {
                Data = (from model in datas select new DanhMuc {Id = model.Id, Name = model.Ten}).ToList(),
                PageIndex = pageIndex,
                PageSize = pageSize,
                TotalItems = datas.FirstOrDefault() != null ? datas.First().TotalItems : 0
            };
        }
	    
		#endregion
	}
}
