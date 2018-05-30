using System;
using System.Collections.Generic;
using System.Linq;
using Business.Entities;
using Business.Entities.BindingModels;
using Business.Entities.ViewModels;
using Business.Services.Contracts;
using Core.Common.Utilities;
using Data.Core.Repositories.Interfaces;

namespace Business.Services
{
    public class ThuTucHanhChinhService : IThuTucHanhChinhService
    {
        #region Private Repository & contractor

        private readonly IDuongDiQuyTrinhRepository _duongDiQuyTrinhRepository;
        private readonly IThuTucHanhChinhBoRepository _thuTucHanhChinhRepository;
        private readonly IThuTucHanhChinhRepository _thuTucHanhChinhRepositories;
        private readonly ILinhVucRepository _linhVucRepository;
        

        public ThuTucHanhChinhService(
            IDuongDiQuyTrinhRepository duongDiQuyTrinhRepository,
            IThuTucHanhChinhBoRepository thuTucHanhChinhRepository,
            ILinhVucRepository linhVucRepository,
            IThuTucHanhChinhRepository thuTucHanhChinhRepositories,
            IParameterRepository parameterRepository)
        {
            _duongDiQuyTrinhRepository = duongDiQuyTrinhRepository;
            _thuTucHanhChinhRepository = thuTucHanhChinhRepository;
            _linhVucRepository = linhVucRepository;
            _thuTucHanhChinhRepositories = thuTucHanhChinhRepositories;
        }

        #endregion

        public bool AddTTHCByPaging(List<ThuTucHanhChinhBo> items)
        {            
            return _thuTucHanhChinhRepository.AddTTHCByPaging(items);
        }

        public bool AddLinhVucByPaging(List<DMLinhVuc> items)
        {
            return _linhVucRepository.AddLinhVucByPaging(items);
        }
      
        public ThuTucHanhChinhEditViewModel GetThuTucHanhChinhById(string id)
        {
            return _thuTucHanhChinhRepositories.GetThuTucHanhChinhById(id);
        }

        public IEnumerable<TTHC_BieuDoThongKe> GetBieuDoThongKe(string chartKey)
        {
            return _thuTucHanhChinhRepositories.GetBieuDoThongKe(chartKey);
        }

        public PagedData<ThuTucHanhChinhDongBoViewModel> GetThuTucHanhChinhByDongBoPaged(string tenThuTuc, string conHieuLuc,
            string hetHieuLuc, string congKhai, string khongCongKhai, string tthcDacThu, string coQuanThucHien, string linhVucId, int pageIndex, int pageSize)
        {
            int totalItems;
            var datas = _thuTucHanhChinhRepositories.GetThuTucHanhChinhByDongBoPaged(tenThuTuc, conHieuLuc.ToBoolNullable(), hetHieuLuc.ToBoolNullable(),
                congKhai.ToBoolNullable(), khongCongKhai.ToBoolNullable(), tthcDacThu.ToBoolNullable(), coQuanThucHien, linhVucId, pageIndex, pageSize, out totalItems).ToList();

            return new PagedData<ThuTucHanhChinhDongBoViewModel>
            {
                Data = datas,
                PageIndex = pageIndex,
                PageSize = pageSize,
                TotalItems = totalItems
            };
        }

        public PagedData<HoSoKemTheoViewModel> GetHoSoKemTheoByPaged(string tenHoSoKemTheo, string linhVucId, int pageSize, int pageIndex)
        {
            var datas = _thuTucHanhChinhRepositories.GetHoSoKemTheoByPaged(tenHoSoKemTheo, linhVucId, pageSize, pageIndex);
            var dmHoSoKemTheo = datas.FirstOrDefault();
            int totalItems = 0;
            if (dmHoSoKemTheo != null)
                totalItems = dmHoSoKemTheo.TotalItems;
            return new PagedData<HoSoKemTheoViewModel>
            {
                Data = datas,
                PageIndex = pageIndex,
                PageSize = pageSize,
                TotalItems = totalItems
            };
        }

        public EnumerableData<DanhMuc> GetThuTucHanhChinhByLinhVucId(string id)
        {
            var datas= _thuTucHanhChinhRepositories.GetThuTucHanhChinhByLinhVucId(id);
            return new EnumerableData<DanhMuc> { Data = datas };
        }

        public EnumerableData<DanhMuc> GetThuTucHanhChinhByDonViId(string id)
        {
            var datas= _thuTucHanhChinhRepositories.GetThuTucHanhChinhByDonViId(id);
            return new EnumerableData<DanhMuc> { Data = datas };
        }

        public EnumerableData<DanhMuc> GetDonViByCapDonViId(string id)
        {            
            var datas = _thuTucHanhChinhRepositories.GetDonViByCapDonViId(id);
            return new EnumerableData<DanhMuc> {Data = datas };
        }

        public string InsThuTucHanhChinh(TTHCEditBindingModel model)
        {
            return _thuTucHanhChinhRepositories.InsThuTucHanhChinh(model);
        }

        public EnumerableData<DanhMuc> GetLinhVucByDonViId(string id)
        {
            var datas= _thuTucHanhChinhRepositories.GetLinhVucByDonViId(id);
            return new EnumerableData<DanhMuc> { Data = datas };
        }

        public PagedData<ThuTucHanhChinhDongBoViewModel> GetThuTucHanhChinhByUserDonViPaged(string tenThuTuc, string congKhai, string khongCongKhai, string buuChinhCongIch, string dichVuCongCap, string linhVucId, string userId, int pageIndex, int pageSize)
        {
            int totalItems;
            var datas = _thuTucHanhChinhRepositories.GetThuTucHanhChinhByUserDonViPaged(tenThuTuc, congKhai.ToBoolNullable(), khongCongKhai.ToBoolNullable(),
                buuChinhCongIch.ToBoolNullable(), Converter.ToInt(dichVuCongCap), linhVucId,Converter.ToInt(userId), pageIndex, pageSize, out totalItems).ToList();

            return new PagedData<ThuTucHanhChinhDongBoViewModel>
            {
                Data = datas,
                PageIndex = pageIndex,
                PageSize = pageSize,
                TotalItems = totalItems
            };
        }

        public int UpdThuTucHanhChinhCongKhai(List<TTHC_DonVi> model)
        {
            return _thuTucHanhChinhRepositories.UpdThuTucHanhChinhCongKhai(model);
        }

        public PagedData<ThuTucHanhChinhDongBoViewModel> GetThuTucHanhChinhMoiByDongBoPaged(string tenThuTuc, string capDonVi, string coQuanThucHien, string linhVucId, int pageIndex, int pageSize)
        {
            int totalItems;
            var datas = _thuTucHanhChinhRepositories.GetThuTucHanhChinhMoiByDongBoPaged(tenThuTuc, capDonVi,
                coQuanThucHien, linhVucId, pageIndex, pageSize, out totalItems).ToList();

            return new PagedData<ThuTucHanhChinhDongBoViewModel>
            {
                Data = datas,
                PageIndex = pageIndex,
                PageSize = pageSize,
                TotalItems = totalItems
            };
        }

        public int UpdTTHCSoQuyetDinh(List<TTHCUpdSoQuyetDinhBindingModel> model)
        {
            return _thuTucHanhChinhRepositories.UpdTTHCSoQuyetDinh(model);
        }

        public int CongKhaiThuTucHanhByLstId(string thuTucHCIds, int userId)
        {
            return _thuTucHanhChinhRepositories.CongKhaiThuTucHanhByLstId(thuTucHCIds, userId);
        }

        public int UpdThuTucHanhChinhBuuChinhCongIch(List<TTHC_DonVi> model)
        {
            return _thuTucHanhChinhRepositories.UpdThuTucHanhChinhBuuChinhCongIch(model);
        }

        public ThuTucHanhChinhCongKhaiViewModel GetThuTucHanhChinhCongKhaiById(string id)
        {
            return _thuTucHanhChinhRepositories.GetThuTucHanhChinhCongKhaiById(id);
        }
    }
}
