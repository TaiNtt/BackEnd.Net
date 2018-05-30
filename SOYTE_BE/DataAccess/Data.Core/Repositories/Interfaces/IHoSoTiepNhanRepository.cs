using Business.Entities;
using Business.Entities.ViewModels;
using Data.Core.Repositories.Base;
using System;
using System.Data;
using System.Collections.Generic;


namespace Data.Core.Repositories.Interfaces
{
    public interface IHoSoTiepNhanRepository : IRepository<HoSoTiepNhan>
    {
        HoSoTiepNhan MotCua_HoSoTiepNhan_GetByHoSoId(long hoSoId);
        string MotCua_GenSoBienNhanByThuTucID(long ThuTucID);
        bool MotCua_KiemTraSoBienNhan(string SoBienNhan);
        long  MotCua_HoSoTiepNhan_Ins(HoSoTiepNhan model, IDbConnection conns, IDbTransaction trans);
        IEnumerable<HoSoTiepNhanViewModel> MotCua_HoSoTiepNhan_GetByCondition(int? linhVucID, int? thuTucID, string soBienNhan,
            DateTime? tuNgay, DateTime? denNgay, string hoTenNguoiNop, string soGiayTo, int? userDangNhapID, int? trangThaiHoSoID,
            int pageIndex, int pageSize, out int totalItems);
        DataTableViewModel MotCua_HoSoTiepNhan_XuatDanhSach(int? linhVucID, int? thuTucID, string soBienNhan,
           DateTime? tuNgay, DateTime? denNgay, string hoTenNguoiNop, string soGiayTo, int? userDangNhapID, int? trangThaiHoSoID, string listHoSoID);
        DataTableViewModel MotCua_HoSoTiepNhan_InBienNhan(long hoSoId);
        DataTableViewModel MotCua_HoSoTiepNhan_XuatThongTinChiTietHoSo(long hoSoId);
        IEnumerable<HoSoTiepNhanViewModel> MotCua_HoSoTiepNhan_Search(int? linhVucID, int? thuTucID, string soBienNhan,
            DateTime? tuNgay, DateTime? denNgay, string hoTenNguoiNop, string soGiayTo, int? trangThaiHoSoID,
            int pageIndex, int pageSize, out int totalItems);
        IEnumerable<HoSoTiepNhanViewModel> MotCua_HoSoTiepNhan_SearchFromHomePage(string traCuu, int pageIndex, int pageSize, out int totalItems);
        bool MotCua_HoSoTiepNhan_UpdByHoSoID(HoSoTiepNhan model, IDbConnection conns, IDbTransaction trans);
        bool MotCua_HoSoTiepNhan_UpdQuaTrinhXuLyHienTaiByHoSoID(long HoSoID, long QuaTrinhXuLyHienTaiID, IDbConnection conns, IDbTransaction trans);
        bool MotCua_HoSoTiepNhan_UpdTrangThaiHoSoByHoSoID(long HoSoID, int TrangThaiHoSoID, string TenTrangThaiHoSo, IDbConnection conns, IDbTransaction trans);
        bool MotCua_HoSoTiepNhan_UpdDaCapByHoSoID(long HoSoID, int TrangThaiHoSoID, IDbConnection conns, IDbTransaction trans);
        bool MotCua_HoSoTiepNhan_DelByHoSoID(long HoSoID,int? UserID, IDbConnection conns, IDbTransaction trans);
    }
}
