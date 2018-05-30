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
using System.Xml.Serialization;
using System.IO;
using System.Xml.Linq;
using System.Xml;
using System.Configuration;
using System.Data.SqlClient;
using log4net;
using log4net.Config;

namespace Business.Services
{
    public class DBMasterService : IDBMasterService
    {
        protected static readonly ILog log = LogManager.GetLogger(typeof(DBMasterService));
        #region Private Repository & contractor
        IDbConnection cons;
        IDbTransaction trans;
        private static readonly string MotCuaConn = ConfigurationManager.ConnectionStrings["MotCua.ConnString"].ConnectionString;
        private static readonly string DBMasterConn = ConfigurationManager.ConnectionStrings["DBMaster.ConnString"].ConnectionString;


        private readonly IDM_NoiCapChungChiRepository _dM_NoiCapChungChiRepository;
        private readonly IDM_PhamViHoatDongChuyenMonRepository _dM_PhamViHoatDongChuyenMonRepository;
        private readonly IDM_LinhVucRepository _dM_LinhVucRepository;
        private readonly IDM_DuDieuKienHanhNgheRepository _dM_DuDieuKienHanhNgheRepository;
        private readonly IDM_PhuongXaRepository _dM_PhuongXaRepository;
        private readonly IDM_QuanHuyenRepository _dM_QuanHuyenRepository;
        private readonly IDM_TinhThanhRepository _dM_TinhThanhRepository;
        private readonly IDM_TrinhDoChuyenMonRepository _dM_TrinhDoChuyenMonRepository;
        private readonly IDM_HinhThucToChucRepository _dM_HinhThucToChucRepository;
        private readonly IDM_PhongBanRepository _dM_PhongBanRepository;
        private readonly IDM_PhamViKinhDoanhRepository _dM_PhamViKinhDoanhRepository;
        private readonly IE_LoaiCapPhepRepository _e_LoaiCapPhepRepository;
        private readonly IDM_GoiYRepository _dM_GoiYRepository;
        private readonly IDM_LyDoRepository _dM_LyDoRepository;
        private readonly IE_LoaiLyDoRepository _e_LoaiLyDoRepository;
        private readonly IE_LoaiGoiYRepository _e_LoaiGoiYRepository;

        public DBMasterService(IDM_NoiCapChungChiRepository dM_NoiCapChungChiRepository
                            , IDM_PhamViHoatDongChuyenMonRepository dM_PhamViHoatDongChuyenMonRepository
                            , IDM_LinhVucRepository dM_LinhVucRepository
                            , IDM_DuDieuKienHanhNgheRepository dM_DuDieuKienHanhNgheRepository
                            , IDM_PhuongXaRepository dM_PhuongXaRepository
                            , IDM_QuanHuyenRepository dM_QuanHuyenRepository
                            , IDM_TinhThanhRepository dM_TinhThanhRepository
                            , IDM_TrinhDoChuyenMonRepository dM_TrinhDoChuyenMonRepository
                            , IDM_HinhThucToChucRepository dM_HinhThucToChucRepository
                            , IDM_PhongBanRepository dM_PhongBanRepository
                            , IDM_PhamViKinhDoanhRepository dM_PhamViKinhDoanhRepository
                            , IE_LoaiCapPhepRepository e_LoaiCapPhepRepository
                            , IDM_GoiYRepository dM_GoiYRepository
                            , IDM_LyDoRepository dM_LyDoRepository
                            , IE_LoaiLyDoRepository e_LoaiLyDoRepository
                            , IE_LoaiGoiYRepository e_LoaiGoiYRepository
                            )
        {
            _dM_NoiCapChungChiRepository = dM_NoiCapChungChiRepository;
            _dM_PhamViHoatDongChuyenMonRepository = dM_PhamViHoatDongChuyenMonRepository;
            _dM_LinhVucRepository = dM_LinhVucRepository;
            _dM_DuDieuKienHanhNgheRepository = dM_DuDieuKienHanhNgheRepository;
            _dM_PhuongXaRepository = dM_PhuongXaRepository;
            _dM_QuanHuyenRepository = dM_QuanHuyenRepository;
            _dM_TinhThanhRepository = dM_TinhThanhRepository;
            _dM_TrinhDoChuyenMonRepository = dM_TrinhDoChuyenMonRepository;
            _dM_HinhThucToChucRepository = dM_HinhThucToChucRepository;
            _dM_PhongBanRepository = dM_PhongBanRepository;
            _dM_PhamViKinhDoanhRepository = dM_PhamViKinhDoanhRepository;
            _e_LoaiCapPhepRepository = e_LoaiCapPhepRepository;
            _dM_GoiYRepository = dM_GoiYRepository;
            _dM_LyDoRepository = dM_LyDoRepository;
            _e_LoaiLyDoRepository = e_LoaiLyDoRepository;
            _e_LoaiGoiYRepository = e_LoaiGoiYRepository;
        }
        #endregion

        #region Danh mục
        public DanhMucs DBMaster_DM_GetAll()
        {
            try
            {
                cons = new SqlConnection(DBMasterConn);
                cons.Open();
                DanhMucs dms = new DanhMucs();
                //dms.lstlinhvuc = _dM_LinhVucRepository.MotCua_DM_LinhVuc_GetAll().ToList();
                dms.lstnoiCapChungChi = _dM_NoiCapChungChiRepository.DBMaster_DM_NoiCapChungChi_GetAll(cons).ToList();
                dms.lstphamViHoatDongChuyenMon = _dM_PhamViHoatDongChuyenMonRepository
                    .DBMaster_DM_PhamViHoatDongChuyenMon_GetAll(cons).ToList();
                dms.lstdudieukienhanhnghe = _dM_DuDieuKienHanhNgheRepository.DBMaster_DM_DuDieuKienHanhNghe_GetAll(cons)
                    .ToList();
                dms.lsttinhthanh = _dM_TinhThanhRepository.DBMaster_DM_TinhThanh_GetAll(cons).ToList();
                dms.lstquanhuyen = _dM_QuanHuyenRepository.DBMaster_DM_QuanHuyen_GetAll(cons).ToList();
                dms.lstphuongxa = _dM_PhuongXaRepository.DBMaster_DM_PhuongXa_GetAll(cons).ToList();
                dms.lsttrinhdochuyenmon =
                    _dM_TrinhDoChuyenMonRepository.DBMaster_DM_TrinhDoChuyenMon_GetAll(cons).ToList();
                dms.lstphamViKinhDoanh =
                    _dM_PhamViKinhDoanhRepository.DBMaster_DM_PhamViKinhDoanh_GetAll(cons).ToList();
                return dms;
            }
            catch (Exception ex)
            {
                XmlConfigurator.Configure();
                log.Error(ex.Message, ex);
                return null;
            }
            finally
            {
                cons.Close();
                cons.Dispose();
            }
        }
        #endregion

        public IEnumerable<MTDanhMuc> DBMaster_DM_TinhThanh_GetAll()
        {
            try
            {
                cons = new SqlConnection(DBMasterConn);
                cons.Open();
                return _dM_TinhThanhRepository.DBMaster_DM_TinhThanh_GetAll(cons);
            }
            catch (Exception ex)
            {
                XmlConfigurator.Configure();
                log.Error(ex.Message, ex);
                return null;
            }
            finally
            {
                cons.Close();
                cons.Dispose();
            }
        }

        public IEnumerable<DanhMucParentID> DBMaster_DM_QuanHuyen_GetByTinhID(int TinhThanhID)
        {
            try
            {
                cons = new SqlConnection(DBMasterConn);
                cons.Open();
                return _dM_QuanHuyenRepository.DBMaster_DM_QuanHuyen_GetByTinhID(TinhThanhID, cons);
            }
            catch (Exception ex)
            {
                XmlConfigurator.Configure();
                log.Error(ex.Message, ex);
                return null;
            }
            finally
            {
                cons.Close();
                cons.Dispose();
            }
        }
        public IEnumerable<DanhMucParentID> DBMaster_DM_PhuongXa_GetByQuanID(int QuanID)
        {
            try
            {
                cons = new SqlConnection(DBMasterConn);
                cons.Open();
                return _dM_PhuongXaRepository.DBMaster_DM_PhuongXa_GetByQuanID(QuanID, cons);
            }
            catch (Exception ex)
            {
                XmlConfigurator.Configure();
                log.Error(ex.Message, ex);
                return null;
            }
            finally
            {
                cons.Close();
                cons.Dispose();
            }
        }

        public IEnumerable<MTDanhMuc> DBMaster_DM_TrinhDoChuyenMon_GetAll()
        {
            try
            {
                cons = new SqlConnection(DBMasterConn);
                cons.Open();
                return _dM_TrinhDoChuyenMonRepository.DBMaster_DM_TrinhDoChuyenMon_GetAll(cons);
            }
            catch (Exception ex)
            {
                XmlConfigurator.Configure();
                log.Error(ex.Message, ex);
                return null;
            }
            finally
            {
                cons.Close();
                cons.Dispose();
            }
        }
        //DM_HinhThucToChuc
        public IEnumerable<MTDanhMuc> DBMaster_DM_HinhThucToChuc_GetAll()
        {
            try
            {
                return _dM_HinhThucToChucRepository.DBMaster_DM_HinhThucToChuc_GetAll().ToList();
            }
            catch (Exception ex)
            {
                XmlConfigurator.Configure();
                log.Error(ex.Message, ex);
                return null;
            }
        }

        //CanBoPhongBanList
        public IEnumerable<CanBoPhongBanList> DBMaster_ListCanBo_PhongBan()
        {
            try
            {
                return _dM_PhongBanRepository.DBMaster_ListCanBo_PhongBan().ToList();
            }
            catch (Exception ex)
            {
                XmlConfigurator.Configure();
                log.Error(ex.Message, ex);
                return null;
            }
        }

        //E_TrangThaiHoSo
        public List<E_LoaiCapPhep> DBMaster_E_LoaiCapPhep_GetAll()
        {
            try
            {
                return _e_LoaiCapPhepRepository.DBMaster_E_LoaiCapPhep_GetAll().ToList();
            }
            catch (Exception ex)
            {
                XmlConfigurator.Configure();
                log.Error(ex.Message, ex);
                return null;
            }
        }

        //DM_GoiY
        public IEnumerable<DM_GoiY> DBMaster_DM_GoiY_GetByLoaiGoiYID(int loaiGoiYID, int thuTucId,string search)
        {
            try
            {
                cons = new SqlConnection(DBMasterConn);
                cons.Open();
                return _dM_GoiYRepository.DBMaster_DM_GoiY_GetByLoaiGoiYID(loaiGoiYID, thuTucId, search, cons);
            }
            catch (Exception ex)
            {
                XmlConfigurator.Configure();
                log.Error(ex.Message, ex);
                return null;
            }
        }
        public int DBMaster_DM_GoiY_PopupUpd(DM_GoiYSave dM_GoiYSave)
        {
            try
            {
                cons = new SqlConnection(DBMasterConn);
                cons.Open();
                trans = cons.BeginTransaction();
                if (dM_GoiYSave.GoiYID == 0)
                {

                    var result = _dM_GoiYRepository.DBMaster_DM_GoiY_PopupIns(dM_GoiYSave, cons, trans);
                    if (result <= 0)
                    {
                        trans.Rollback();
                        XmlConfigurator.Configure();
                        log.Error("result = DBMaster_DM_GoiY_PopupIns(EdXml);");
                    }
                    trans.Commit();
                    return result;
                }
                else
                {
                    var result = _dM_GoiYRepository.DBMaster_DM_GoiY_PopupUpd(dM_GoiYSave, cons, trans);
                    if (result <= 0)
                    {
                        trans.Rollback();
                        XmlConfigurator.Configure();
                        log.Error("result = DBMaster_DM_GoiY_PopupUpd(EdXml);");
                    }
                    trans.Commit();
                    return result;
                }
            }
            catch (Exception ex)
            {
                XmlConfigurator.Configure();
                log.Error(ex.Message, ex);
                return -1;
            }
        }
        public bool DBMaster_DM_GoiY_PopupDel(int GoiYID)
        {
            try
            {
                cons = new SqlConnection(DBMasterConn);
                cons.Open();
                trans = cons.BeginTransaction();
                var result = _dM_GoiYRepository.DBMaster_DM_GoiY_PopupDel(GoiYID, cons, trans);
                if (!result)
                {
                    trans.Rollback();
                    XmlConfigurator.Configure();
                    log.Error("result = DBMaster_DM_GoiY_PopupDel(EdXml);");
                }
                trans.Commit();
                return result;
            }
            catch (Exception ex)
            {
                XmlConfigurator.Configure();
                log.Error(ex.Message, ex);
                return false;
            }
        }

        //E_LoaiLyDo
        public List<E_LoaiLyDo> DBMaster_E_LoaiLyDo_GetAll()
        {
            try
            {
                return _e_LoaiLyDoRepository.DBMaster_E_LoaiLyDo_GetAll().ToList();
            }
            catch (Exception ex)
            {
                XmlConfigurator.Configure();
                log.Error(ex.Message, ex);
                return null;
            }
        }

        //E_LoaiGoiY
        public List<E_LoaiGoiY> DBMaster_E_LoaiGoiY_GetAll()
        {
            try
            {
                return _e_LoaiGoiYRepository.DBMaster_E_LoaiGoiY_GetAll().ToList();
            }
            catch (Exception ex)
            {
                XmlConfigurator.Configure();
                log.Error(ex.Message, ex);
                return null;
            }
        }

        //DM_LyDo
        public PagedData<DM_LyDoList> DBMaster_DM_LyDo_List(string LoaiCapPhepID, string LoaiLyDoID, string tuKhoa, int pageIndex, int pageSize)
        {
            try
            {
                int totalItems;
                var datas = _dM_LyDoRepository.DBMaster_DM_LyDo_List(LoaiCapPhepID.ToIntNullable(), LoaiLyDoID.ToIntNullable(), tuKhoa, pageIndex, pageSize, out totalItems).ToList();

                return new PagedData<DM_LyDoList>
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
        public DM_LyDo DBMaster_DM_LyDo_GetByLyDoID(int LyDoID)
        {
            try
            {
                return _dM_LyDoRepository.DBMaster_DM_LyDo_GetByLyDoID(LyDoID);
            }
            catch (Exception ex)
            {
                XmlConfigurator.Configure();
                log.Error(ex.Message, ex);
                return null;
            }
        }
        public bool DBMaster_DM_LyDo_Save(DM_LyDo dm_lydo)
        {
            int lyDoID = 0;
            try
            {
                bool flagupd = true; //1: insert - 0: update
                cons = new SqlConnection(DBMasterConn);
                cons.Open();
                trans = cons.BeginTransaction();

                if (dm_lydo.LyDoID != 0)
                {
                    flagupd = false;
                    lyDoID = dm_lydo.LyDoID;
                }
                else { flagupd = true; }
                if (flagupd)
                {
                    var insDM_LyDo = _dM_LyDoRepository.DBMaster_DM_LyDo_Ins(dm_lydo, cons, trans);
                    if (!insDM_LyDo)
                    {
                        XmlConfigurator.Configure();
                        log.Error("result = DBMaster_DM_LyDo_Ins(EdXml);");
                        trans.Rollback();
                        return false;
                    }
                }
                else
                {
                    var updDM_LyDo = _dM_LyDoRepository.DBMaster_DM_LyDo_UpdByLyDoID(dm_lydo, cons, trans);
                    if (!updDM_LyDo)
                    {
                        XmlConfigurator.Configure();
                        log.Error("result = DBMaster_DM_LyDo_UpdByLyDoID(EdXml);");
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

        //DM_GoiY
        public PagedData<DM_GoiYList> DBMaster_DM_GoiY_List(string LoaiCapPhepID, string LoaiGoiYID, string tuKhoa, int pageIndex, int pageSize)
        {
            try
            {
                int totalItems;
                var datas = _dM_GoiYRepository.DBMaster_DM_GoiY_List(LoaiCapPhepID.ToIntNullable(), LoaiGoiYID.ToIntNullable(), tuKhoa, pageIndex, pageSize, out totalItems).ToList();

                return new PagedData<DM_GoiYList>
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
        public DM_GoiY DBMaster_DM_GoiY_GetByGoiYID(int GoiYID)
        {
            try
            {
                return _dM_GoiYRepository.DBMaster_DM_GoiY_GetByGoiYID(GoiYID);
            }
            catch (Exception ex)
            {
                XmlConfigurator.Configure();
                log.Error(ex.Message, ex);
                return null;
            }
        }
        public bool DBMaster_DM_GoiY_Save(DM_GoiY dm_goiy)
        {
            int goiYID = 0;
            try
            {
                bool flagupd = true; //1: insert - 0: update
                cons = new SqlConnection(DBMasterConn);
                cons.Open();
                trans = cons.BeginTransaction();

                if (dm_goiy.GoiYID != 0)
                {
                    flagupd = false;
                    goiYID = dm_goiy.GoiYID;
                }
                else { flagupd = true; }
                if (flagupd)
                {
                    var insDM_GoiY = _dM_GoiYRepository.DBMaster_DM_GoiY_Ins(dm_goiy, cons, trans);
                    if (!insDM_GoiY)
                    {
                        XmlConfigurator.Configure();
                        log.Error("result = DBMaster_DM_GoiY_Ins(EdXml);");
                        trans.Rollback();
                        return false;
                    }
                }
                else
                {
                    var updDM_GoiY = _dM_GoiYRepository.DBMaster_DM_GoiY_UpdByGoiYID(dm_goiy, cons, trans);
                    if (!updDM_GoiY)
                    {
                        XmlConfigurator.Configure();
                        log.Error("result = DBMaster_DM_GoiY_UpdByGoiYID(EdXml);");
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
    }
}
