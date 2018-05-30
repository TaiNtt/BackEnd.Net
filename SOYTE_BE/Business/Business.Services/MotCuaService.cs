using Business.Entities;
using Business.Services.Contracts;
using Data.Core.Repositories.Interfaces;
using Business.Entities.ViewModels;
using System.Data;
using System.Data.Sql;
using System;
using System.Collections.Generic;
using Core.Common.Utilities;
using System.Linq;
using System.Configuration;
using System.Data.SqlClient;
using log4net;
using log4net.Config;

namespace Business.Services
{
    public class MotCuaService : IMotCuaService
    {
        protected static readonly ILog log = LogManager.GetLogger(typeof(MotCuaService));
        #region Private Repository & contractor
        IDbConnection cons;
        IDbTransaction trans;
        private static readonly string MotCuaConn = ConfigurationManager.ConnectionStrings["MotCua.ConnString"].ConnectionString;
        private readonly IHoSoTiepNhanRepository _hoSoTiepNhanRepository;
        private readonly IHoSoTheoDoiRepository _hoSoTheoDoiRepository;
        private readonly IQuaTrinhXuLyRepository _quaTrinhXuLyRepository;
        private readonly IWorkListRepository _workListRepository;
        private readonly IYeuCauBoSungRepository _yeuCauBoSungRepository;
        private readonly ITamNgungThamDinhRepository _tamNgungThamDinhRepository;
        private readonly IKhongPheDuyetRepository _khongPheDuyetRepository;
        private readonly IKhongGiaiQuyetRepository _khongGiaiQuyetRepository;
        private readonly IQuyTrinhRepository _quyTrinhRepository;
        private readonly IDM_LinhVucRepository _dM_LinhVucRepository;
        private readonly IDM_ThuTucRepository _dM_ThuTucRepository;
        private readonly IDM_QuyTrinh_BuocRepository _dM_QuyTrinh_BuocRepository;
        private readonly IDM_QuyTrinh_Buoc_NguoiNhanRepository _dM_QuyTrinh_Buoc_NguoiNhanRepository;
        private readonly IDM_ChungTuKemTheoRepository _dM_ChungTuKemTheoRepository;
        private readonly IChungTuKemTheoRepository _chungTuKemTheoRepository;
        private readonly IE_TrangThaiHoSoRepository _e_TrangThaiHoSoRepository;
        private readonly IE_NoiNhanKetQuaRepository _e_NoiNhanKetQuaRepository;
        public MotCuaService(IHoSoTiepNhanRepository hoSoTiepNhanRepository
                            , IHoSoTheoDoiRepository hoSoTheoDoiRepository
                            , IWorkListRepository workListRepository
                            , IQuaTrinhXuLyRepository quaTrinhXuLyRepository
                            , IYeuCauBoSungRepository yeuCauBoSungRepository
                            , ITamNgungThamDinhRepository tamNgungThamDinhRepository
                            , IKhongPheDuyetRepository khongPheDuyetRepository
                            , IKhongGiaiQuyetRepository khongGiaiQuyetRepository
                            , IQuyTrinhRepository quyTrinhRepository

                            , IDM_LinhVucRepository dM_LinhVucRepository
                            , IDM_ThuTucRepository dM_ThuTucRepository
                            , IDM_QuyTrinh_BuocRepository dM_QuyTrinh_BuocRepository
                            , IDM_QuyTrinh_Buoc_NguoiNhanRepository dM_QuyTrinh_Buoc_NguoiNhanRepository
                            , IDM_ChungTuKemTheoRepository dM_ChungTuKemTheoRepository
                            , IChungTuKemTheoRepository chungTuKemTheoRepository
                            , IE_TrangThaiHoSoRepository e_TrangThaiHoSoRepository
                            , IE_NoiNhanKetQuaRepository e_NoiNhanKetQuaRepository
                            )
        {
            _hoSoTiepNhanRepository = hoSoTiepNhanRepository;
            _quaTrinhXuLyRepository = quaTrinhXuLyRepository;
            _workListRepository = workListRepository;
            _yeuCauBoSungRepository = yeuCauBoSungRepository;
            _tamNgungThamDinhRepository = tamNgungThamDinhRepository;
            _khongPheDuyetRepository = khongPheDuyetRepository;
            _khongGiaiQuyetRepository = khongGiaiQuyetRepository;
            _quyTrinhRepository = quyTrinhRepository;
            _dM_LinhVucRepository = dM_LinhVucRepository;
            _dM_ThuTucRepository = dM_ThuTucRepository;
            _dM_QuyTrinh_BuocRepository = dM_QuyTrinh_BuocRepository;
            _dM_QuyTrinh_Buoc_NguoiNhanRepository = dM_QuyTrinh_Buoc_NguoiNhanRepository;
            _hoSoTheoDoiRepository = hoSoTheoDoiRepository;
            _dM_ChungTuKemTheoRepository = dM_ChungTuKemTheoRepository;
            _chungTuKemTheoRepository = chungTuKemTheoRepository;
            _e_TrangThaiHoSoRepository = e_TrangThaiHoSoRepository;
            _e_NoiNhanKetQuaRepository = e_NoiNhanKetQuaRepository;
        }
        #endregion

        public HoSoTiepNhan MotCua_HoSoTiepNhan_GetByHoSoId(long hoSoId)
        {
            return _hoSoTiepNhanRepository.MotCua_HoSoTiepNhan_GetByHoSoId(hoSoId);
        }
        public bool MotCua_HoSoTiepNhan_DelByHoSoID(long hoSoId, int UserID)
        {
            try
            {
                cons = new SqlConnection(MotCuaConn);
                cons.Open();
                trans = cons.BeginTransaction();
                var delHoSoTiepNhanbyHoSoId = _hoSoTiepNhanRepository.MotCua_HoSoTiepNhan_DelByHoSoID(hoSoId, UserID, cons, trans);
                if (!delHoSoTiepNhanbyHoSoId)
                {
                    XmlConfigurator.Configure();
                    log.Error("result = MotCua_HoSoTiepNhan_DelByHoSoID(EdXml);");
                    trans.Rollback();
                    return delHoSoTiepNhanbyHoSoId;
                }
                trans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                XmlConfigurator.Configure();
                log.Error(ex.Message, ex);
                return false;
            }
        }
        public string MotCua_GenSoBienNhanByThuTucID(long ThuTucID)
        {
            try
            {
                return _hoSoTiepNhanRepository.MotCua_GenSoBienNhanByThuTucID(ThuTucID);
            }
            catch (Exception ex)
            {
                XmlConfigurator.Configure();
                log.Error(ex.Message, ex);
                return "";
            }
        }

        public bool MotCua_KiemTraSoBienNhan(string SoBienNhan)
        {
            try
            {
                return _hoSoTiepNhanRepository.MotCua_KiemTraSoBienNhan(SoBienNhan);
            }
            catch (Exception ex)
            {
                XmlConfigurator.Configure();
                log.Error(ex.Message, ex);
                return false;
            }
        }
        public long MotCua_HoSoTiepNhan_SaveFullProcess(HoSoTiepNhanFullProcessSave hoSoTiepNhanFullProcessSave)
        {
            long hosoid = 0;
            try
            {
                bool flagupd = true; //1: insert - 0: update
                cons = new SqlConnection(MotCuaConn);
                cons.Open();
                trans = cons.BeginTransaction();
                if (hoSoTiepNhanFullProcessSave.hosotiepnhan.HoSoID != 0)
                {
                    flagupd = false;
                    hosoid = hoSoTiepNhanFullProcessSave.hosotiepnhan.HoSoID;
                }
                else { flagupd = true; }
                if (flagupd)
                {
                    hosoid = _hoSoTiepNhanRepository.MotCua_HoSoTiepNhan_Ins(hoSoTiepNhanFullProcessSave.hosotiepnhan, cons, trans);
                    if (hosoid == -1)
                    {
                        trans.Rollback();
                        XmlConfigurator.Configure();
                        log.Error("result = MotCua_HoSoTiepNhan_Ins(EdXml);");
                        return -1;
                    }
                    else
                    {
                        hoSoTiepNhanFullProcessSave.quatrinhxuly.HoSoID = hosoid;
                        long kqQuaTrinhXuLyIns = _quaTrinhXuLyRepository.MotCua_QuaTrinhXuLy_Ins(hoSoTiepNhanFullProcessSave.quatrinhxuly, cons, trans);
                        var kqupdQuaTrinhHienTai = _hoSoTiepNhanRepository.MotCua_HoSoTiepNhan_UpdQuaTrinhXuLyHienTaiByHoSoID(hosoid, kqQuaTrinhXuLyIns, cons, trans);
                        // ins/upd WorkList
                        var kqWorkListInsUpd = _workListRepository.MotCua_WorkList_InsUpdByUserIDandTrangThaiHoSoID(
                            hoSoTiepNhanFullProcessSave.UserId ?? null,
                            hoSoTiepNhanFullProcessSave.TrangThaiHoSoId ?? null,
                            hoSoTiepNhanFullProcessSave.TrangThaiCapNhat ?? null,
                            cons, trans);
                    }
                }
                else
                {
                    var updHoSoTiepNhanbyHoSoId = _hoSoTiepNhanRepository.MotCua_HoSoTiepNhan_UpdByHoSoID(hoSoTiepNhanFullProcessSave.hosotiepnhan, cons, trans);
                }
                trans.Commit();
                return hosoid;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                XmlConfigurator.Configure();
                log.Error(ex.Message, ex);
                return -1;
            }
        }
        public long MotCua_HoSoTiepNhan_Save(HoSoTiepNhanSave hoSoTiepNhanSave)
        {
            long hosoid = 0;
            try
            {
                bool flagupd = true; //1: insert - 0: update
                cons = new SqlConnection(MotCuaConn);
                cons.Open();
                trans = cons.BeginTransaction();
                if (hoSoTiepNhanSave.HoSoTiepNhan.HoSoID != 0)
                {
                    flagupd = false;
                    hosoid = hoSoTiepNhanSave.HoSoTiepNhan.HoSoID;
                }
                else { flagupd = true; }
                if (flagupd)
                {
                    hosoid = _hoSoTiepNhanRepository.MotCua_HoSoTiepNhan_Ins(hoSoTiepNhanSave.HoSoTiepNhan, cons, trans);
                    if (hosoid == -1)
                    {
                        trans.Rollback();
                        XmlConfigurator.Configure();
                        log.Error("result = MotCua_HoSoTiepNhan_Ins(EdXml);");
                        return -1;
                    }
                    else
                    {
                        //Ho So Kem Theo
                        foreach (var item in hoSoTiepNhanSave.lstChungTuKemTheo)
                        {
                            item.HoSoID = (int)hosoid;
                            var kqHSKemTheo = _chungTuKemTheoRepository.MotCua_ChungTuKemTheo_Ins(item, cons, trans);

                        }
                        //Qua Trinh Xu Ly
                        QuaTrinhXuLy quatrinhxuly = new QuaTrinhXuLy
                        {
                            IsQuaTrinhHienTai = true,
                            HoSoID = hosoid,
                            NgayNhan = DateTime.Today,
                            NguoiXuLyHienTaiID = hoSoTiepNhanSave.HoSoTiepNhan.LastUpdUserID,
                            TrangThaiHienTaiID = 1,
                            CreatedUserID = hoSoTiepNhanSave.HoSoTiepNhan.LastUpdUserID,
                            LastUpdUserID = hoSoTiepNhanSave.HoSoTiepNhan.LastUpdUserID,
                        };
                        long kqQuaTrinhXuLyIns = _quaTrinhXuLyRepository.MotCua_QuaTrinhXuLy_Ins(quatrinhxuly, cons, trans);
                        var kqupdQuaTrinhHienTai = _hoSoTiepNhanRepository.MotCua_HoSoTiepNhan_UpdQuaTrinhXuLyHienTaiByHoSoID(hosoid, kqQuaTrinhXuLyIns, cons, trans);
                        // ins/upd WorkList
                        var kqWorkListInsUpd = _workListRepository.MotCua_WorkList_InsUpdByUserIDandTrangThaiHoSoID(
                            hoSoTiepNhanSave.HoSoTiepNhan.LastUpdUserID ?? null,
                            quatrinhxuly.TrangThaiHienTaiID ?? null,
                            1,
                            cons, trans);
                    }
                }
                else
                {
                    var updHoSoTiepNhanbyHoSoId = _hoSoTiepNhanRepository.MotCua_HoSoTiepNhan_UpdByHoSoID(hoSoTiepNhanSave.HoSoTiepNhan, cons, trans);
                    if (!updHoSoTiepNhanbyHoSoId)
                    {
                        XmlConfigurator.Configure();
                        log.Error("result = MotCua_HoSoTiepNhan_UpdByHoSoID(EdXml);");
                        trans.Rollback();
                        return -1;
                    }
                    else
                    {
                        //Ho So Kem Theo
                        var kqHSKemTheoDel = _chungTuKemTheoRepository.MotCua_ChungTuKemTheo_DelAllByHoSoID(hoSoTiepNhanSave.HoSoTiepNhan.HoSoID, cons, trans);
                        foreach (var item in hoSoTiepNhanSave.lstChungTuKemTheo)
                        {
                            item.HoSoID = (int)hosoid;
                            var kqHSKemTheo = _chungTuKemTheoRepository.MotCua_ChungTuKemTheo_Ins(item, cons, trans);

                        }
                    }
                }
                trans.Commit();
                return hosoid;
            }
            catch (Exception ex)
            {
                XmlConfigurator.Configure();
                log.Error(ex.Message, ex);
                trans.Rollback();
                return -1;
            }
        }
        public PagedData<HoSoTiepNhanViewModel> MotCua_HoSoTiepNhan_GetByCondition(string linhVucID, string thuTucID, string soBienNhan,
            string tuNgay, string denNgay, string hoTenNguoiNop, string soGiayTo, string userDangNhapID, string trangThaiHoSoID, int pageIndex, int pageSize)
        {
            try
            {
                int totalItems;
                var datas = _hoSoTiepNhanRepository.MotCua_HoSoTiepNhan_GetByCondition(linhVucID.ToIntNullable(), thuTucID.ToIntNullable(), soBienNhan,
                    tuNgay.ToDateTimeNullable(), denNgay.ToDateTimeNullable(), hoTenNguoiNop, soGiayTo, userDangNhapID.ToIntNullable(), trangThaiHoSoID.ToIntNullable(), pageIndex, pageSize, out totalItems).ToList();

                return new PagedData<HoSoTiepNhanViewModel>
                {
                    Data = datas,
                    PageIndex = pageIndex,
                    PageSize = pageSize,
                    TotalItems = totalItems
                };
            }
            catch (Exception ex)
            {
                XmlConfigurator.Configure();
                log.Error(ex.Message, ex);
                return null;
            }
        }
        public DataTableViewModel MotCua_HoSoTiepNhan_XuatDanhSach(string linhVucID, string thuTucID, string soBienNhan,
         string tuNgay, string denNgay, string hoTenNguoiNop, string soGiayTo, string userDangNhapID, string trangThaiHoSoID, string listHoSoID)
        {
            try
            {
                var datas = _hoSoTiepNhanRepository.MotCua_HoSoTiepNhan_XuatDanhSach(linhVucID.ToIntNullable(), thuTucID.ToIntNullable(), soBienNhan,
                    tuNgay.ToDateTimeNullable(), denNgay.ToDateTimeNullable(), hoTenNguoiNop, soGiayTo, userDangNhapID.ToIntNullable(), trangThaiHoSoID.ToIntNullable(), listHoSoID);
                return datas;

            }
            catch (Exception ex)
            {
                XmlConfigurator.Configure();
                log.Error(ex.Message, ex);
                return null;
            }
        }
        public DataTableViewModel MotCua_HoSoTiepNhan_InBienNhan(long hoSoID)
        {
            try
            {
                var datas = _hoSoTiepNhanRepository.MotCua_HoSoTiepNhan_InBienNhan(hoSoID);
                return datas;

            }
            catch (Exception ex)
            {
                XmlConfigurator.Configure();
                log.Error(ex.Message, ex);
                return null;
            }
        }
        public DataTableViewModel MotCua_HoSoTiepNhan_XuatThongTinChiTietHoSo(long hoSoID)
        {
            try
            {
                var datas = _hoSoTiepNhanRepository.MotCua_HoSoTiepNhan_XuatThongTinChiTietHoSo(hoSoID);
                return datas;

            }
            catch (Exception ex)
            {
                XmlConfigurator.Configure();
                log.Error(ex.Message, ex);
                return null;
            }
        }
        public IEnumerable<WorkListViewModel> MotCua_WorkList_CountByTrangThaiHoSoIDId_UserID(int UserID)
        {
            return _workListRepository.MotCua_WorkList_CountByTrangThaiHoSoIDId_UserID(UserID);
        }
        public IEnumerable<WorkListViewModel> MotCua_WorkList_CountByFilter(string linhVucID, string thuTucID, string soBienNhan,
            string tuNgay, string denNgay, string hoTenNguoiNop, string soGiayTo, int UserID)
        {
            return _workListRepository.MotCua_WorkList_CountByFilter(linhVucID.ToIntNullable(), thuTucID.ToIntNullable(), soBienNhan,
                    tuNgay.ToDateTimeNullable(), denNgay.ToDateTimeNullable(), hoTenNguoiNop, soGiayTo, UserID);
        }
        public PagedData<HoSoTiepNhanViewModel> MotCua_HoSoTiepNhan_Search(string linhVucID, string thuTucID, string soBienNhan,
            string tuNgay, string denNgay, string hoTenNguoiNop, string soGiayTo, string trangThaiHoSoID, int pageIndex, int pageSize)
        {
            try
            {
                int totalItems;
                var datas = _hoSoTiepNhanRepository.MotCua_HoSoTiepNhan_Search(linhVucID.ToIntNullable(), thuTucID.ToIntNullable(), soBienNhan,
                    tuNgay.ToDateTimeNullable(), denNgay.ToDateTimeNullable(), hoTenNguoiNop, soGiayTo, trangThaiHoSoID.ToIntNullable(), pageIndex, pageSize, out totalItems).ToList();

                return new PagedData<HoSoTiepNhanViewModel>
                {
                    Data = datas,
                    PageIndex = pageIndex,
                    PageSize = pageSize,
                    TotalItems = totalItems
                };
            }
            catch (Exception ex)
            {
                XmlConfigurator.Configure();
                log.Error(ex.Message, ex);
                return null;
            }
        }
        public PagedData<HoSoTiepNhanViewModel> MotCua_HoSoTiepNhan_SearchFromHomePage(string traCuu, int pageIndex, int pageSize)
        {
            try
            {
                int totalItems;
                var datas = _hoSoTiepNhanRepository.MotCua_HoSoTiepNhan_SearchFromHomePage(traCuu, pageIndex, pageSize, out totalItems).ToList();
                return new PagedData<HoSoTiepNhanViewModel>
                {
                    Data = datas,
                    PageIndex = pageIndex,
                    PageSize = pageSize,
                    TotalItems = totalItems
                };
            }
            catch (Exception ex)
            {
                XmlConfigurator.Configure();
                log.Error(ex.Message, ex);
                return null;
            }
        }
        //Luan chuyen ho so 
        public bool MotCua_HoSoTiepNhan_TransFullProcess(HoSoTiepNhanFullProcessTrans hoSoTiepNhanFullProcessTrans)
        {
            try
            {
                cons = new SqlConnection(MotCuaConn);
                cons.Open();
                trans = cons.BeginTransaction();

                //Xu ly table QuaTrinhXuLy
                long quatrinhxulyId = _quaTrinhXuLyRepository.MotCua_QuaTrinhXuLy_InsUpd(hoSoTiepNhanFullProcessTrans.HoSoID
                                                                                        , hoSoTiepNhanFullProcessTrans.NguoiXuLyHienTaiID ?? null
                                                                                        , hoSoTiepNhanFullProcessTrans.NguoiXuLyTiepTheoID ?? null
                                                                                        , hoSoTiepNhanFullProcessTrans.TrangThaiHienTaiID ?? null
                                                                                        , hoSoTiepNhanFullProcessTrans.TrangThaiTiepTheoID ?? null
                                                                                        , cons, trans);

                //HoSoTiepNhan
                var updQuaTrinhXuLyHienTai = _hoSoTiepNhanRepository.MotCua_HoSoTiepNhan_UpdQuaTrinhXuLyHienTaiByHoSoID(hoSoTiepNhanFullProcessTrans.HoSoID
                                                                                        , quatrinhxulyId, cons, trans);

                var updTrangThaiHoSoTiepNhan = _hoSoTiepNhanRepository.MotCua_HoSoTiepNhan_UpdTrangThaiHoSoByHoSoID(hoSoTiepNhanFullProcessTrans.HoSoID
                                                                                        , hoSoTiepNhanFullProcessTrans.TrangThaiTiepTheoID ?? 0
                                                                                        , hoSoTiepNhanFullProcessTrans.TenTrangThaiTiepTheo
                                                                                        , cons, trans);
            

                //WorkList: SoLuong - 1
                var kqWorkListInsUpdOld = _workListRepository.MotCua_WorkList_InsUpdByUserIDandTrangThaiHoSoID(
                            hoSoTiepNhanFullProcessTrans.NguoiXuLyHienTaiID ?? null,
                            hoSoTiepNhanFullProcessTrans.TrangThaiHienTaiID ?? null,
                            0, cons, trans);
                //WorkList: SoLuong + 1
                var kqWorkListInsUpdNew = _workListRepository.MotCua_WorkList_InsUpdByUserIDandTrangThaiHoSoID(
                            hoSoTiepNhanFullProcessTrans.NguoiXuLyTiepTheoID ?? null,
                            hoSoTiepNhanFullProcessTrans.TrangThaiTiepTheoID ?? null,
                            1, cons, trans);

                //Cac nghiep vu lien quan
                switch (hoSoTiepNhanFullProcessTrans.hosotiepnhan.TrangThaiHoSoID.Value)
                {
                    case 9://Tam ngung
                        hoSoTiepNhanFullProcessTrans.tamngungthamdinh.QuaTrinhXuLyID = quatrinhxulyId;
                        var insTamNgungThamDinh = _tamNgungThamDinhRepository.MotCua_TamNgungThamDinh_Ins(hoSoTiepNhanFullProcessTrans.tamngungthamdinh, cons, trans);
                        break;
                    case 4: //Yeu cau bo sung
                        hoSoTiepNhanFullProcessTrans.yeucaubosung.QuaTrinhXuLyID = quatrinhxulyId;
                        var insYeuCauBoSung = _yeuCauBoSungRepository.MotCua_YeuCauBoSung_Ins(hoSoTiepNhanFullProcessTrans.yeucaubosung, cons, trans);
                        break;
                    case 10: //Khong giai quyet
                        hoSoTiepNhanFullProcessTrans.khonggiaiquyet.QuaTrinhXuLyID = quatrinhxulyId;
                        var insKhongGiaiQuyet = _khongGiaiQuyetRepository.MotCua_KhongGiaiQuyet_Ins(hoSoTiepNhanFullProcessTrans.khonggiaiquyet, cons, trans);
                        break;
                    case 12: //Khong Phe Duyet
                        hoSoTiepNhanFullProcessTrans.khongpheduyet.QuaTrinhXuLyID = quatrinhxulyId;
                        var insKhongPheDuyet = _khongPheDuyetRepository.MotCua_KhongPheDuyet_Ins(hoSoTiepNhanFullProcessTrans.khongpheduyet, cons, trans);
                        break;
                }

                trans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                XmlConfigurator.Configure();
                log.Error(ex.Message, ex);
                trans.Rollback();
                return false;
            }
        }
        public int MotCua_HoSoTiepNhan_TransFullProcess_List(List<HoSoTiepNhanFullProcessTrans> lstHoSoTiepNhanFullProcessTrans)
        {
            try
            {
                int trangThaiHienTaiID = 0;
                cons = new SqlConnection(MotCuaConn);
                cons.Open();
                trans = cons.BeginTransaction();

                foreach (var hoSoTiepNhanFullProcessTrans in lstHoSoTiepNhanFullProcessTrans)
                {
                    long quatrinhxulyId = _quaTrinhXuLyRepository.MotCua_QuaTrinhXuLy_InsUpd(hoSoTiepNhanFullProcessTrans.hosotiepnhan.HoSoID
                                                                                        , hoSoTiepNhanFullProcessTrans.NguoiXuLyHienTaiID ?? null
                                                                                        , hoSoTiepNhanFullProcessTrans.NguoiXuLyTiepTheoID ?? null
                                                                                        , hoSoTiepNhanFullProcessTrans.TrangThaiHienTaiID ?? null
                                                                                        , hoSoTiepNhanFullProcessTrans.TrangThaiTiepTheoID ?? null
                                                                                        , cons, trans);

                    //HoSoTiepNhan
                    var updQuaTrinhXuLyHienTai = _hoSoTiepNhanRepository.MotCua_HoSoTiepNhan_UpdQuaTrinhXuLyHienTaiByHoSoID(hoSoTiepNhanFullProcessTrans.hosotiepnhan.HoSoID
                                                                                            , quatrinhxulyId, cons, trans);

                    var updTrangThaiHoSoTiepNhan = _hoSoTiepNhanRepository.MotCua_HoSoTiepNhan_UpdTrangThaiHoSoByHoSoID(hoSoTiepNhanFullProcessTrans.hosotiepnhan.HoSoID
                                                                                            , hoSoTiepNhanFullProcessTrans.hosotiepnhan.TrangThaiHoSoID.Value
                                                                                            , hoSoTiepNhanFullProcessTrans.hosotiepnhan.TenTrangThaiHoSo
                                                                                            , cons, trans);

                    trangThaiHienTaiID = hoSoTiepNhanFullProcessTrans.hosotiepnhan.TrangThaiHoSoID.Value;

                    //WorkList: SoLuong - 1
                    var kqWorkListInsUpdOld = _workListRepository.MotCua_WorkList_InsUpdByUserIDandTrangThaiHoSoID(
                                hoSoTiepNhanFullProcessTrans.userIdOld ?? null,
                                hoSoTiepNhanFullProcessTrans.TrangThaiHoSoIdOld ?? null,
                                0, cons, trans);
                    //WorkList: SoLuong + 1
                    var kqWorkListInsUpdNew = _workListRepository.MotCua_WorkList_InsUpdByUserIDandTrangThaiHoSoID(
                                hoSoTiepNhanFullProcessTrans.userIdNew ?? null,
                                hoSoTiepNhanFullProcessTrans.TrangThaiHoSoIdNew ?? null,
                                1, cons, trans);

                    //Cac nghiep vu lien quan
                    switch (hoSoTiepNhanFullProcessTrans.hosotiepnhan.TrangThaiHoSoID.Value)
                    {
                        case 9://Tam ngung
                            hoSoTiepNhanFullProcessTrans.tamngungthamdinh.QuaTrinhXuLyID = quatrinhxulyId;
                            var insTamNgungThamDinh = _tamNgungThamDinhRepository.MotCua_TamNgungThamDinh_Ins(hoSoTiepNhanFullProcessTrans.tamngungthamdinh, cons, trans);
                            break;
                        case 4: //Yeu cau bo sung
                            hoSoTiepNhanFullProcessTrans.yeucaubosung.QuaTrinhXuLyID = quatrinhxulyId;
                            var insYeuCauBoSung = _yeuCauBoSungRepository.MotCua_YeuCauBoSung_Ins(hoSoTiepNhanFullProcessTrans.yeucaubosung, cons, trans);
                            break;
                        case 10: //Khong giai quyet
                            hoSoTiepNhanFullProcessTrans.khonggiaiquyet.QuaTrinhXuLyID = quatrinhxulyId;
                            var insKhongGiaiQuyet = _khongGiaiQuyetRepository.MotCua_KhongGiaiQuyet_Ins(hoSoTiepNhanFullProcessTrans.khonggiaiquyet, cons, trans);
                            break;
                        case 12: //Khong Phe Duyet
                            hoSoTiepNhanFullProcessTrans.khongpheduyet.QuaTrinhXuLyID = quatrinhxulyId;
                            var insKhongPheDuyet = _khongPheDuyetRepository.MotCua_KhongPheDuyet_Ins(hoSoTiepNhanFullProcessTrans.khongpheduyet, cons, trans);
                            break;
                    }
                    trans.Commit();
                }
                return trangThaiHienTaiID;
            }
            catch (Exception ex)
            {
                XmlConfigurator.Configure();
                log.Error(ex.Message, ex);
                trans.Rollback();
                return 0;
            }
        }
        public bool MotCua_HoSoTiepNhan_DelFullProcess(HoSoTiepNhanFullProcessDel hoSoTiepNhanFullProcessDel)
        {
            try
            {
                cons = new SqlConnection(MotCuaConn);
                cons.Open();
                trans = cons.BeginTransaction();

                var delHoSoTiepNhan = _hoSoTiepNhanRepository.MotCua_HoSoTiepNhan_DelByHoSoID(hoSoTiepNhanFullProcessDel.HoSoID, hoSoTiepNhanFullProcessDel.UserId, cons, trans);
                if (!delHoSoTiepNhan)
                {
                    XmlConfigurator.Configure();
                    log.Error("result = MotCua_HoSoTiepNhan_DelByHoSoID(EdXml);");
                    trans.Rollback();
                    return false;
                }
                //var delQuaTrinhXuLy = _quaTrinhXuLyRepository.MotCua_QuaTrinhXuLy_DelByHoSoID(HoSoID, cons, trans);
                //if (!delQuaTrinhXuLy)
                //{
                //    XmlConfigurator.Configure();
                //    log.Error("result = MotCua_QuaTrinhXuLy_DelByHoSoID(EdXml);");
                //    trans.Rollback();
                //    return false;
                //}
                var updSoLuongWorkList = _workListRepository.MotCua_WorkList_InsUpdByUserIDandTrangThaiHoSoID(hoSoTiepNhanFullProcessDel.UserId, hoSoTiepNhanFullProcessDel.TrangThaiHoSoId, 0, cons, trans);
                if (!updSoLuongWorkList)
                {
                    XmlConfigurator.Configure();
                    log.Error("result = MotCua_WorkList_InsUpdByUserIDandTrangThaiHoSoID(EdXml);");
                    trans.Rollback();
                    return false;
                }

                trans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                XmlConfigurator.Configure();
                log.Error(ex.Message, ex);
                trans.Rollback();
                return false;
            }
        }
        public IEnumerable<QuaTrinhXuLyViewModel> MotCua_QuaTrinhXuLys_GetByHoSoID(long hoSoId)
        {
            try
            {
                cons = new SqlConnection(MotCuaConn);
                cons.Open();
                return _quaTrinhXuLyRepository.MotCua_QuaTrinhXuLys_GetByHoSoID(hoSoId, cons);
            }
            catch (Exception ex)
            {
                XmlConfigurator.Configure();
                log.Error(ex.Message, ex);
                return null;
            }
        }
        public DataTableViewModel MotCua_QuaTrinhXuLys_XuatThongTinChiTietHoSo(long hoSoID)
        {
            try
            {
                var datas = _quaTrinhXuLyRepository.MotCua_QuaTrinhXuLys_XuatThongTinChiTietHoSo(hoSoID);
                return datas;

            }
            catch (Exception ex)
            {
                XmlConfigurator.Configure();
                log.Error(ex.Message, ex);
                return null;
            }
        }
        public IEnumerable<QuyTrinhViewModel> MotCua_QuyTrinhs_GetByThuTucIDandTrangThaiHienTaiID(int ThuTucID, int TrangThaiHienTaiID)
        {
            try
            {
                cons = new SqlConnection(MotCuaConn);
                cons.Open();
                return _quyTrinhRepository.MotCua_QuyTrinhs_GetByThuTucIDandTrangThaiHienTaiID(ThuTucID, TrangThaiHienTaiID, cons);
            }
            catch (Exception ex)
            {
                XmlConfigurator.Configure();
                log.Error(ex.Message, ex);
                return null;
            }
        }
        public bool MotCua_QuyTrinhs_CheckByHoSoIDandTrangThaiTiepTheoID(int HoSoID, int TrangThaiTiepTheoID, int NguoiNhanID)
        {
            try
            {
                cons = new SqlConnection(MotCuaConn);
                cons.Open();
                return _quyTrinhRepository.MotCua_QuyTrinhs_CheckByHoSoIDandTrangThaiTiepTheoID(HoSoID, TrangThaiTiepTheoID, NguoiNhanID, cons);
            }
            catch (Exception ex)
            {
                XmlConfigurator.Configure();
                log.Error(ex.Message, ex);
                return false;
            }
        }
        //Ho so theo doi
        public long MotCua_HoSoTheoDoi_Save(HoSoTheoDoi hosotheodoi)
        {
            long theodoihosoid = 0;
            try
            {
                cons = new SqlConnection(MotCuaConn);
                cons.Open();
                trans = cons.BeginTransaction();

                theodoihosoid = _hoSoTheoDoiRepository.MotCua_HoSoTheoDoi_Ins(hosotheodoi, cons, trans);
                if (theodoihosoid == -1) { trans.Rollback(); return -1; }

                trans.Commit();
                return theodoihosoid;
            }
            catch (Exception ex)
            {
                XmlConfigurator.Configure();
                log.Error(ex.Message, ex);
                trans.Rollback();
                return -1;
            }
        }
        public bool MotCua_HoSoTheoDoi_Del(long HoSoID, long UserID)
        {
            try
            {
                cons = new SqlConnection(MotCuaConn);
                cons.Open();
                trans = cons.BeginTransaction();

                var delHoSoTheoDoi = _hoSoTheoDoiRepository.MotCua_HoSoTheoDoi_Del(HoSoID, UserID, cons, trans);
                if (!delHoSoTheoDoi) { trans.Rollback(); return false; }

                trans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                XmlConfigurator.Configure();
                log.Error(ex.Message, ex);
                trans.Rollback();
                return false;
            }
        }
        //DM_LinhVuc
        public IEnumerable<DM_LinhVuc> MotCua_DM_LinhVuc_GetAll()
        {
            try
            {
                return _dM_LinhVucRepository.MotCua_DM_LinhVuc_GetAll();
            }
            catch (Exception ex)
            {
                XmlConfigurator.Configure();
                log.Error(ex.Message, ex);
                return null;
            }
        }
        public DM_LinhVuc MotCua_DM_LinhVuc_GetByLinhVucID(int LinhVucID)
        {
            try
            {
                return _dM_LinhVucRepository.MotCua_DM_LinhVuc_GetByLinhVucID(LinhVucID);
            }
            catch (Exception ex)
            {
                XmlConfigurator.Configure();
                log.Error(ex.Message, ex);
                return null;
            }
        }
        public PagedData<DM_LinhVucList> MotCua_DM_LinhVuc_List(string tuKhoa, int pageIndex, int pageSize)
        {
            try
            {
                int totalItems;
                var datas = _dM_LinhVucRepository.MotCua_DM_LinhVuc_List(tuKhoa, pageIndex, pageSize, out totalItems).ToList();

                return new PagedData<DM_LinhVucList>
                {
                    Data = datas,
                    PageIndex = pageIndex,
                    PageSize = pageSize,
                    TotalItems = totalItems
                };
            }
            catch (Exception ex)
            {
                XmlConfigurator.Configure();
                log.Error(ex.Message, ex);
                return null;
            }
        }
        public bool MotCua_DM_LinhVuc_Save(DM_LinhVuc dm_linhvuc)
        {
            int linhVucID = 0;
            try
            {
                bool flagupd = true; //1: insert - 0: update
                cons = new SqlConnection(MotCuaConn);
                cons.Open();
                trans = cons.BeginTransaction();

                if (dm_linhvuc.LinhVucID != 0)
                {
                    flagupd = false;
                    linhVucID = dm_linhvuc.LinhVucID;
                }
                else { flagupd = true; }
                if (flagupd)
                {
                    var insDM_LinhVuc = _dM_LinhVucRepository.MotCua_DM_LinhVuc_Ins(dm_linhvuc, cons, trans);
                    if (!insDM_LinhVuc)
                    {
                        XmlConfigurator.Configure();
                        log.Error("result = MotCua_DM_LinhVuc_Ins(EdXml);");
                        trans.Rollback();
                        return false;
                    }
                }
                else
                {
                    var updDM_LinhVuc = _dM_LinhVucRepository.MotCua_DM_LinhVuc_UpdID(dm_linhvuc, cons, trans);
                    if (!updDM_LinhVuc)
                    {
                        XmlConfigurator.Configure();
                        log.Error("result = MotCua_DM_LinhVuc_UpdID(EdXml);");
                        trans.Rollback();
                        return false;
                    }
                }
                trans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                XmlConfigurator.Configure();
                log.Error(ex.Message, ex);
                trans.Rollback();
                return false;
            }
        }
        //DM_ThuTuc
        public List<DM_ThuTuc> MotCua_DM_ThuTuc_GetByLinhVucID(int LinhVucID)
        {
            try
            {
                return _dM_ThuTucRepository.MotCua_DM_ThuTuc_GetByLinhVucID(LinhVucID).ToList();
            }
            catch (Exception ex)
            {
                XmlConfigurator.Configure();
                log.Error(ex.Message, ex);
                return null;
            }

        }
        public DM_ThuTuc MotCua_DM_ThuTuc_GetByThuTucID(int ThuTucID)
        {
            try
            {
                return _dM_ThuTucRepository.MotCua_DM_ThuTuc_GetByThuTucID(ThuTucID);
            }
            catch (Exception ex)
            {
                XmlConfigurator.Configure();
                log.Error(ex.Message, ex);
                return null;
            }
        }
        public PagedData<DM_ThuTucList> MotCua_DM_ThuTuc_List(string tuKhoa, int pageIndex, int pageSize)
        {
            try
            {
                int totalItems;
                var datas = _dM_ThuTucRepository.MotCua_DM_ThuTuc_List(tuKhoa, pageIndex, pageSize, out totalItems).ToList();

                return new PagedData<DM_ThuTucList>
                {
                    Data = datas,
                    PageIndex = pageIndex,
                    PageSize = pageSize,
                    TotalItems = totalItems
                };
            }
            catch (Exception ex)
            {
                XmlConfigurator.Configure();
                log.Error(ex.Message, ex);
                return null;
            }
        }
        public bool MotCua_DM_ThuTuc_Save(DM_ThuTucSave model)
        {
            int thuTucID = 0;
            try
            {
                bool flagupd = true; //1: insert - 0: update
                cons = new SqlConnection(MotCuaConn);
                cons.Open();
                trans = cons.BeginTransaction();

                if (model.dm_ThuTuc.ThuTucID != 0)
                {
                    flagupd = false;
                    thuTucID = model.dm_ThuTuc.ThuTucID;
                }
                else { flagupd = true; }
                if (flagupd)
                {
                    thuTucID = _dM_ThuTucRepository.MotCua_DM_ThuTuc_Ins(model.dm_ThuTuc, cons, trans);
                    if (thuTucID == -1)
                    {
                        XmlConfigurator.Configure();
                        log.Error("result = MotCua_DM_ThuTuc_Ins(EdXml);");
                        trans.Rollback();
                        return false;
                    }
                    else
                    {
                        if (model.lstDM_ChungTuKemTheo != null)
                        {
                            foreach (var item in model.lstDM_ChungTuKemTheo)
                            {
                                item.ThuTucID = thuTucID;
                                var insDM_ChungTuKemTheo = _dM_ChungTuKemTheoRepository.MotCua_DM_ChungTuKemTheo_Ins(item, cons, trans);
                                if (!insDM_ChungTuKemTheo)
                                {
                                    XmlConfigurator.Configure();
                                    log.Error("result = MotCua_DM_ChungTuKemTheo_Ins(EdXml);");
                                    trans.Rollback();
                                    return false;
                                }
                            }
                        }
                    }
                }
                else
                {
                    var updDM_ThuTuc = _dM_ThuTucRepository.MotCua_DM_ThuTuc_UpdID(model.dm_ThuTuc, cons, trans);
                    if (!updDM_ThuTuc)
                    {
                        XmlConfigurator.Configure();
                        log.Error("result = MotCua_DM_ThuTuc_UpdID(EdXml);");
                        trans.Rollback();
                        return false;
                    }
                    var delDM_ChungTuKemTheo = _dM_ChungTuKemTheoRepository.MotCua_DM_ChungTuKemTheo_DelByThuTucID(thuTucID, cons, trans);
                    if (!delDM_ChungTuKemTheo)
                    {
                        XmlConfigurator.Configure();
                        log.Error("result = MotCua_DM_ChungTuKemTheo_DelByThuTucID(EdXml);");
                        trans.Rollback();
                        return false;
                    }
                    foreach (var item in model.lstDM_ChungTuKemTheo)
                    {
                        var insDM_ChungTuKemTheo = _dM_ChungTuKemTheoRepository.MotCua_DM_ChungTuKemTheo_Ins(item, cons, trans);
                        if (!insDM_ChungTuKemTheo)
                        {
                            XmlConfigurator.Configure();
                            log.Error("result = MotCua_DM_ChungTuKemTheo_Ins(EdXml);");
                            trans.Rollback();
                            return false;
                        }
                    }
                }
                trans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                XmlConfigurator.Configure();
                log.Error(ex.Message, ex);
                trans.Rollback();
                return false;
            }
        }
        //DM_QuyTrinh_Buoc + DM_QuyTrinh_Buoc_NguoiNhan
        public PagedData<DM_QuyTrinh_Buoc_NguoiNhanList> MotCua_DM_QuyTrinh_Buoc_NguoiNhan_List(int thuTucID, int pageIndex, int pageSize)
        {
            try
            {
                int totalItems;
                var datas = _dM_QuyTrinh_BuocRepository.MotCua_DM_QuyTrinh_Buoc_NguoiNhan_List(thuTucID, pageIndex, pageSize, out totalItems).ToList();

                return new PagedData<DM_QuyTrinh_Buoc_NguoiNhanList>
                {
                    Data = datas,
                    PageIndex = pageIndex,
                    PageSize = pageSize,
                    TotalItems = totalItems
                };
            }
            catch (Exception ex)
            {
                XmlConfigurator.Configure();
                log.Error(ex.Message, ex);
                return null;
            }
        }
        public DM_QuyTrinh_Buoc MotCua_DM_QuyTrinh_Buoc_GetByBuocID(int BuocID)
        {
            try
            {
                return _dM_QuyTrinh_BuocRepository.MotCua_DM_QuyTrinh_Buoc_GetByBuocID(BuocID);
            }
            catch (Exception ex)
            {
                XmlConfigurator.Configure();
                log.Error(ex.Message, ex);
                return null;
            }
        }
        public DM_QuyTrinh_Buoc_NguoiNhan MotCua_DM_QuyTrinh_Buoc_NguoiNhan_GetByBuocID(int BuocID)
        {
            try
            {
                return _dM_QuyTrinh_Buoc_NguoiNhanRepository.MotCua_DM_QuyTrinh_Buoc_NguoiNhan_GetByBuocID(BuocID);
            }
            catch (Exception ex)
            {
                XmlConfigurator.Configure();
                log.Error(ex.Message, ex);
                return null;
            }
        }
        public IEnumerable<DM_QuyTrinh_Buoc_NguoiNhan> MotCua_DM_QuyTrinh_Buoc_NguoiNhan_ListByBuocID(int BuocID)
        {
            try
            {
                return _dM_QuyTrinh_Buoc_NguoiNhanRepository.MotCua_DM_QuyTrinh_Buoc_NguoiNhan_ListByBuocID(BuocID);
            }
            catch (Exception ex)
            {
                XmlConfigurator.Configure();
                log.Error(ex.Message, ex);
                return null;
            }
        }
        public bool MotCua_DM_QuyTrinh_Buoc_NguoiNhan_Save(DM_QuyTrinh_Buoc_NguoiNhanSave model)
        {
            int buocID = 0;
            try
            {
                bool flagupd = true; //1: insert - 0: update
                cons = new SqlConnection(MotCuaConn);
                cons.Open();
                trans = cons.BeginTransaction();

                if (model.dm_QuyTrinh_Buoc.BuocID != 0)
                {
                    flagupd = false;
                    buocID = model.dm_QuyTrinh_Buoc.BuocID;
                }
                else { flagupd = true; }
                if (flagupd)
                {
                    buocID = _dM_QuyTrinh_BuocRepository.MotCua_DM_QuyTrinh_Buoc_Ins(model.dm_QuyTrinh_Buoc, cons, trans);
                    if (buocID == -1)
                    {
                        XmlConfigurator.Configure();
                        log.Error("result = MotCua_DM_QuyTrinh_Buoc_Ins(EdXml);");
                        trans.Rollback();
                        return false;
                    }
                    else
                    {
                        if (model.lstDM_QuyTrinh_Buoc_NguoiNhan != null)
                        {
                            foreach (var item in model.lstDM_QuyTrinh_Buoc_NguoiNhan)
                            {
                                item.BuocID = buocID;
                                var insDM_QuyTrinhBuocNguoiNhan = _dM_QuyTrinh_Buoc_NguoiNhanRepository.MotCua_DM_QuyTrinh_Buoc_NguoiNhan_Ins(item, cons, trans);
                                if (!insDM_QuyTrinhBuocNguoiNhan)
                                {
                                    XmlConfigurator.Configure();
                                    log.Error("result = MotCua_DM_QuyTrinh_Buoc_NguoiNhan_Ins(EdXml);");
                                    trans.Rollback();
                                    return false;
                                }
                            }
                        }
                    }
                }
                else
                {
                    var updDM_QuyTrinhBuoc = _dM_QuyTrinh_BuocRepository.MotCua_DM_QuyTrinh_Buoc_UpdByBuocID(model.dm_QuyTrinh_Buoc, cons, trans);
                    if (!updDM_QuyTrinhBuoc)
                    {
                        XmlConfigurator.Configure();
                        log.Error("result = MotCua_DM_QuyTrinh_Buoc_UpdByBuocID(EdXml);");
                        trans.Rollback();
                        return false;
                    }
                    var delDM_QuyTrinhBuocNguoiNhan = _dM_QuyTrinh_Buoc_NguoiNhanRepository.MotCua_DM_QuyTrinh_Buoc_NguoiNhan_Del(buocID, cons, trans);
                    if (!delDM_QuyTrinhBuocNguoiNhan)
                    {
                        XmlConfigurator.Configure();
                        log.Error("result = MotCua_DM_QuyTrinh_Buoc_NguoiNhan_Del(EdXml);");
                        trans.Rollback();
                        return false;
                    }
                    foreach (var item in model.lstDM_QuyTrinh_Buoc_NguoiNhan)
                    {
                        //item.BuocID = buocID;
                        var insDM_QuyTrinhBuocNguoiNhan = _dM_QuyTrinh_Buoc_NguoiNhanRepository.MotCua_DM_QuyTrinh_Buoc_NguoiNhan_Ins(item, cons, trans);
                        if (!insDM_QuyTrinhBuocNguoiNhan)
                        {
                            XmlConfigurator.Configure();
                            log.Error("result = MotCua_DM_QuyTrinh_Buoc_NguoiNhan_Ins(EdXml);");
                            trans.Rollback();
                            return false;
                        }
                    }
                }
                trans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                XmlConfigurator.Configure();
                log.Error(ex.Message, ex);
                trans.Rollback();
                return false;
            }
        }

        //DM_ChungTuKemTheo
        public List<DM_ChungTuKemTheo> MotCua_DM_ChungTuKemTheo_GetByThuTucID(int ThuTucID)
        {
            try
            {
                return _dM_ChungTuKemTheoRepository.MotCua_DM_ChungTuKemTheo_GetByThuTucID(ThuTucID).ToList();
            }
            catch (Exception ex)
            {
                XmlConfigurator.Configure();
                log.Error(ex.Message, ex);
                return null;
            }
        }

        //ChungTuKemTheo
        public List<ChungTuKemTheo> MotCua_ChungTuKemTheo_GetByHoSoID(int HoSoID)
        {
            try
            {
                return _chungTuKemTheoRepository.MotCua_ChungTuKemTheo_GetByHoSoID(HoSoID).ToList();
            }
            catch (Exception ex)
            {
                XmlConfigurator.Configure();
                log.Error(ex.Message, ex);
                return null;
            }
        }
        public bool MotCua_ChungTuKemTheo_Ins(ChungTuKemTheo chungtukemtheo)
        {
            try
            {
                cons = new SqlConnection(MotCuaConn);
                cons.Open();
                trans = cons.BeginTransaction();
                var result = _chungTuKemTheoRepository.MotCua_ChungTuKemTheo_Ins(chungtukemtheo, cons, trans);
                if (!result)
                {
                    XmlConfigurator.Configure();
                    log.Error("result = MotCua_ChungTuKemTheo_Ins(EdXml);");
                    trans.Rollback();
                    return false;
                }
                trans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                XmlConfigurator.Configure();
                log.Error(ex.Message, ex);
                return false;
            }
        }
        public bool MotCua_ChungTuKemTheo_UpdID(ChungTuKemTheo chungtukemtheo)
        {
            try
            {
                cons = new SqlConnection(MotCuaConn);
                cons.Open();
                trans = cons.BeginTransaction();
                var result = _chungTuKemTheoRepository.MotCua_ChungTuKemTheo_UpdID(chungtukemtheo, cons, trans);
                if (!result)
                {
                    XmlConfigurator.Configure();
                    log.Error("result = MotCua_ChungTuKemTheo_UpdID(EdXml);");
                    trans.Rollback();
                    return false;
                }
                trans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                XmlConfigurator.Configure();
                log.Error(ex.Message, ex);
                return false;
            }
        }

        //E_TrangThaiHoSo
        public List<E_TrangThaiHoSo> MotCua_E_TrangThaiHoSo_GetAll()
        {
            try
            {
                return _e_TrangThaiHoSoRepository.MotCua_E_TrangThaiHoSo_GetAll().ToList();
            }
            catch (Exception ex)
            {
                XmlConfigurator.Configure();
                log.Error(ex.Message, ex);
                return null;
            }
        }
        //E_TrangThaiHoSo
        public List<E_NoiNhanKetQua> MotCua_E_NoiNhanKetQua_GetAll()
        {
            try
            {
                return _e_NoiNhanKetQuaRepository.MotCua_E_NoiNhanKetQua_GetAll().ToList();
            }
            catch (Exception ex)
            {
                XmlConfigurator.Configure();
                log.Error(ex.Message, ex);
                return null;
            }
        }

        //MotCua_ListUsersRoles
        public IEnumerable<MotCua_ListUsersRoles> MotCua_ListUsersRoles()
        {
            try
            {
                return _dM_QuyTrinh_Buoc_NguoiNhanRepository.MotCua_ListUsersRoles();
            }
            catch (Exception ex)
            {
                XmlConfigurator.Configure();
                log.Error(ex.Message, ex);
                return null;
            }
        }
    }
}
