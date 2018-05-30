using System.Collections.Generic;
using Business.Entities;
using Business.Entities.BindingModels;
using Business.Entities.ViewModels;
using Data.Core.Repositories.Base;

namespace Data.Core.Repositories.Interfaces
{
    public interface IThuTucHanhChinhRepository: IRepository<ThuTucHanhChinh>
    {
        ThuTucHanhChinhEditViewModel GetThuTucHanhChinhById(string id);

        List<HoSoKemTheoViewModel> GetHoSoKemTheoByPaged(string tenHoSoKemTheo,string linhVucId, int pageSize, int pageIndex);

        IEnumerable<TTHC_BieuDoThongKe> GetBieuDoThongKe(string chartKey);

        IEnumerable<ThuTucHanhChinhDongBoViewModel> GetThuTucHanhChinhByDongBoPaged(string tenThuTuc, bool? conHieuLuc,
            bool? hetHieuLuc, bool? congKhai, bool? khongCongKhai, bool? tthcDacThu, string coQuanThucHien, string linhVucId, int pageIndex, int pageSize,
            out int totalItems);

        IEnumerable<DanhMuc> GetThuTucHanhChinhByLinhVucId(string id);

        IEnumerable<DanhMuc> GetThuTucHanhChinhByDonViId(string id);

        IEnumerable<DanhMuc> GetDonViByCapDonViId(string id);

        string InsThuTucHanhChinh(TTHCEditBindingModel model);

        IEnumerable<DanhMuc> GetLinhVucByDonViId(string id);

        IEnumerable<ThuTucHanhChinhDongBoViewModel> GetThuTucHanhChinhByUserDonViPaged(string tenThuTuc,
            bool? congKhai, bool? khongCongKhai, bool? buuChinhCongIch, int? dichVuCongCap, string linhVucId,
            int? userId, int pageIndex, int pageSize, out int totalItems);

        IEnumerable<ThuTucHanhChinhDongBoViewModel> GetThuTucHanhChinhMoiByDongBoPaged(string tenThuTuc, string capDonVi,
            string coQuanThucHien, string linhVucId, int pageIndex, int pageSize, out int totalItems);

        int UpdThuTucHanhChinhCongKhai(List<TTHC_DonVi> model);

        int UpdTTHCSoQuyetDinh(List<TTHCUpdSoQuyetDinhBindingModel>  model);

        int UpdThuTucHanhChinhBuuChinhCongIch(List<TTHC_DonVi> model);

        int CongKhaiThuTucHanhByLstId(string thuTucHCIds, int userId);

        ThuTucHanhChinhCongKhaiViewModel GetThuTucHanhChinhCongKhaiById(string id);
    }
}
