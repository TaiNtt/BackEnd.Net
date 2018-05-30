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
namespace Business.Services
{
    public class NganhDuocService : INganhDuocService
    {
        #region Private Repository & contractor
        IDbConnection cons;
        IDbTransaction trans;
        protected static readonly ILog Logger = LogManager.GetLogger(typeof(NganhYService));
        private static readonly string NganhDuocConn = ConfigurationManager.ConnectionStrings["NganhDuoc.ConnString"].ConnectionString;
        private readonly IDK_HoiThaoGioiThieuThuocRepository _dK_HoiThaoGioiThieuThuocRepository;
        private readonly IDK_HoiThaoGioiThieuThuoc_DMThuocRepository _dK_HoiThaoGioiThieuThuoc_DMThuocRepository;
        private readonly ICN_GDP_DSKhoRepository _cN_GDP_DSKhoRepository;
        private readonly ICN_GDPRepository _cN_GDPRepository;
        private readonly ICN_GPPRepository _cN_GPPRepository;
        private readonly ICV_XNKThuoc_PhiMauDichRepository _cV_XNKThuoc_PhiMauDichRepository;
        private readonly ICV_XNKThuoc_PhiMauDich_DSThuocRepository _cV_XNKThuoc_PhiMauDich_DSThuocRepository;
        private readonly ITD_KeHoachDauThauRepository _tD_KeHoachDauThauRepository;
        private readonly ITD_KeHoachDauThau_DSGoiThauRepository _tD_KeHoachDauThau_DSGoiThauRepository;
        private readonly IPD_Thuoc_GN_HTT_DSThuocRepository _pD_Thuoc_GN_HTT_DSThuocRepository;
        private readonly IPD_Thuoc_GN_HTTRepository _pD_Thuoc_GN_HTTRepository;
        private readonly IPD_Thuoc_Methadone_TinhHinhRepository _pD_Thuoc_Methadone_TinhHinhRepository;
        private readonly IPD_Thuoc_MethadoneRepository _pD_Thuoc_MethadoneRepository;
        private readonly ICP_Thuoc_VienTro_DMThuocRepository _cP_Thuoc_VienTro_DMThuocRepository;
        private readonly ICP_Thuoc_VienTroRepository _cP_Thuoc_VienTroRepository;
        private readonly IXN_NoiDungQuangCao_SanPhamRepository _xN_NoiDungQuangCao_SanPhamRepository;
        private readonly IXN_NoiDungQuangCaoRepository _xN_NoiDungQuangCaoRepository;
        private readonly IP_CongBoMyPham_ThanhPhanRepository _p_CongBoMyPham_ThanhPhanRepository;
        private readonly IP_CongBoMyPhamRepository _p_CongBoMyPhamRepository;
        private readonly ICN_LuuHanhMyPham_SanPhamRepository _cN_LuuHanhMyPham_SanPhamRepository;
        private readonly ICN_LuuHanhMyPhamRepository _cN_LuuHanhMyPhamRepository;
        private readonly ICC_DuocRepository _cC_DuocRepository;
        private readonly ICC_Duoc_TDCMRepository _cC_Duoc_TDCMRepository;
        private readonly ICC_Duoc_QTTHRepository _cC_Duoc_QTTHRepository;
        private readonly ICC_Duoc_CapLaiRepository _cC_Duoc_CapLaiRepository;
        private readonly ICC_Duoc_CapLaiCTRepository _cC_Duoc_CapLaiCTRepository;
        public NganhDuocService(IDK_HoiThaoGioiThieuThuocRepository dK_HoiThaoGioiThieuThuocRepository
                            , IDK_HoiThaoGioiThieuThuoc_DMThuocRepository dK_HoiThaoGioiThieuThuoc_DMThuocRepository
                            , ICN_GDP_DSKhoRepository cN_GDP_DSKhoRepository
                            , ICN_GDPRepository cN_GDPRepository
                            , ICN_GPPRepository cN_GPPRepository
                            , ICV_XNKThuoc_PhiMauDichRepository cV_XNKThuoc_PhiMauDichRepository
                            , ICV_XNKThuoc_PhiMauDich_DSThuocRepository cV_XNKThuoc_PhiMauDich_DSThuocRepository
                            , ITD_KeHoachDauThauRepository tD_KeHoachDauThauRepository
                            , ITD_KeHoachDauThau_DSGoiThauRepository tD_KeHoachDauThau_DSGoiThauRepository
                            , IPD_Thuoc_GN_HTT_DSThuocRepository pD_Thuoc_GN_HTT_DSThuocRepository
                            , IPD_Thuoc_GN_HTTRepository pD_Thuoc_GN_HTTRepository
                            , IPD_Thuoc_Methadone_TinhHinhRepository pD_Thuoc_Methadone_TinhHinhRepository
                            , IPD_Thuoc_MethadoneRepository pD_Thuoc_MethadoneRepository
                            , ICP_Thuoc_VienTro_DMThuocRepository cP_Thuoc_VienTro_DMThuocRepository
                            , ICP_Thuoc_VienTroRepository cP_Thuoc_VienTroRepository
                            , IXN_NoiDungQuangCao_SanPhamRepository xN_NoiDungQuangCao_SanPhamRepository
                            , IXN_NoiDungQuangCaoRepository xN_NoiDungQuangCaoRepository
                            , IP_CongBoMyPham_ThanhPhanRepository p_CongBoMyPham_ThanhPhanRepository
                            , IP_CongBoMyPhamRepository p_CongBoMyPhamRepository
                            , ICN_LuuHanhMyPham_SanPhamRepository cN_LuuHanhMyPham_SanPhamRepository
                            , ICN_LuuHanhMyPhamRepository cN_LuuHanhMyPhamRepository
                            , ICC_DuocRepository cC_DuocRepository
                            ,ICC_Duoc_TDCMRepository cC_Duoc_TDCMRepository
                            ,ICC_Duoc_QTTHRepository cC_Duoc_QTTHRepository
                            , ICC_Duoc_CapLaiRepository cC_Duoc_CapLaiRepository
                            , ICC_Duoc_CapLaiCTRepository cC_Duoc_CapLaiCTRepository
                            )
        {
            _dK_HoiThaoGioiThieuThuocRepository = dK_HoiThaoGioiThieuThuocRepository;
            _dK_HoiThaoGioiThieuThuoc_DMThuocRepository = dK_HoiThaoGioiThieuThuoc_DMThuocRepository;
            _cN_GDP_DSKhoRepository = cN_GDP_DSKhoRepository;
            _cN_GDPRepository = cN_GDPRepository;
            _cN_GPPRepository = cN_GPPRepository;
            _cV_XNKThuoc_PhiMauDichRepository = cV_XNKThuoc_PhiMauDichRepository;
            _cV_XNKThuoc_PhiMauDich_DSThuocRepository = cV_XNKThuoc_PhiMauDich_DSThuocRepository;
            _tD_KeHoachDauThauRepository = tD_KeHoachDauThauRepository;
            _tD_KeHoachDauThau_DSGoiThauRepository = tD_KeHoachDauThau_DSGoiThauRepository;
            _pD_Thuoc_GN_HTT_DSThuocRepository = pD_Thuoc_GN_HTT_DSThuocRepository;
            _pD_Thuoc_GN_HTTRepository = pD_Thuoc_GN_HTTRepository;
            _pD_Thuoc_Methadone_TinhHinhRepository = pD_Thuoc_Methadone_TinhHinhRepository;
            _pD_Thuoc_MethadoneRepository = pD_Thuoc_MethadoneRepository;
            _cP_Thuoc_VienTro_DMThuocRepository = cP_Thuoc_VienTro_DMThuocRepository;
            _cP_Thuoc_VienTroRepository = cP_Thuoc_VienTroRepository;
            _xN_NoiDungQuangCao_SanPhamRepository = xN_NoiDungQuangCao_SanPhamRepository;
            _xN_NoiDungQuangCaoRepository = xN_NoiDungQuangCaoRepository;
            _p_CongBoMyPham_ThanhPhanRepository = p_CongBoMyPham_ThanhPhanRepository;
            _p_CongBoMyPhamRepository = p_CongBoMyPhamRepository;
            _cN_LuuHanhMyPham_SanPhamRepository = cN_LuuHanhMyPham_SanPhamRepository;
            _cN_LuuHanhMyPhamRepository = cN_LuuHanhMyPhamRepository;
            _cC_DuocRepository = cC_DuocRepository;
            _cC_Duoc_TDCMRepository = cC_Duoc_TDCMRepository;
            _cC_Duoc_QTTHRepository = cC_Duoc_QTTHRepository;
            _cC_Duoc_CapLaiRepository = cC_Duoc_CapLaiRepository;
            _cC_Duoc_CapLaiCTRepository = cC_Duoc_CapLaiCTRepository;
        }
        #endregion

        #region XML converter
        private string GenObject2XML<T>(T objT)
        {

            StringWriter stream = new StringWriter();
            try
            {
                XmlSerializer serializer1 = new XmlSerializer(typeof(T));
                serializer1.Serialize(stream, objT);
                return stream.ToString();
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
            finally
            {
                stream.Dispose();
            }
        }
        private T GenXML2Object<T>(string xml)
        {
            StringReader strReader = null;
            XmlSerializer serializer = null;
            XmlTextReader xmlReader = null;
            try
            {
                strReader = new StringReader(xml);
                serializer = new XmlSerializer(typeof(T));
                xmlReader = new XmlTextReader(strReader);
                using (StringReader sr = new StringReader(xml))
                {
                    object objReturn = serializer.Deserialize(sr);
                    return (T)Convert.ChangeType(objReturn, typeof(T));
                }
            }
            catch (Exception ex)
            {
                //Handle Exception Code
                return default(T);
            }
            finally
            {
                if (xmlReader != null)
                {
                    xmlReader.Close();
                }
                if (strReader != null)
                {
                    strReader.Close();
                }
            }
        }
        #endregion

        #region Đăng ký hội thảo giới thiệu thuốc
        public DK_HoiThaoGioiThieuThuocSave NganhDuoc_DK_HoiThaoGioiThieuThuoc_GetByHoSoID(long HoSoID)
        {
            try
            {
                DK_HoiThaoGioiThieuThuocSave objreturn = new DK_HoiThaoGioiThieuThuocSave();
                objreturn.hoiThaoGioiThieuThuoc = _dK_HoiThaoGioiThieuThuocRepository.NganhDuoc_DK_HoiThaoGioiThieuThuoc_GetByHoSoID(HoSoID);
                objreturn.lsthoiThaoGioiThieuThuoc_DMThuoc = _dK_HoiThaoGioiThieuThuoc_DMThuocRepository.NganhDuoc_DK_HoiThaoGioiThieuThuoc_DMThuoc_GetByHoiThaoThuocID(objreturn.hoiThaoGioiThieuThuoc.HoiThaoThuocID).ToList();

                return objreturn;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DK_HoiThaoGioiThieuThuocSave NganhDuoc_DK_HoiThaoGioiThieuThuoc_GetByID(long HoiThaoThuocID)
        {
            try
            {
                DK_HoiThaoGioiThieuThuocSave objreturn = new DK_HoiThaoGioiThieuThuocSave();
                objreturn.hoiThaoGioiThieuThuoc = _dK_HoiThaoGioiThieuThuocRepository.NganhDuoc_DK_HoiThaoGioiThieuThuoc_GetByID(HoiThaoThuocID);
                objreturn.lsthoiThaoGioiThieuThuoc_DMThuoc = _dK_HoiThaoGioiThieuThuoc_DMThuocRepository.NganhDuoc_DK_HoiThaoGioiThieuThuoc_DMThuoc_GetByHoiThaoThuocID(objreturn.hoiThaoGioiThieuThuoc.HoiThaoThuocID).ToList();

                return objreturn;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public PagedData<DK_HoiThaoGioiThieuThuocViewModel> NganhDuoc_DK_HoiThaoGioiThieuThuoc_Search(string SoTiepNhan, string tuNgay, string denNgay
            , string TenDonVi, string HoTen, int pageIndex, int pageSize)
        {
            int totalItems;
            var datas = _dK_HoiThaoGioiThieuThuocRepository.NganhDuoc_DK_HoiThaoGioiThieuThuoc_Search(SoTiepNhan,
                tuNgay.ToDateTimeNullable(), denNgay.ToDateTimeNullable(), TenDonVi, HoTen, pageIndex, pageSize, out totalItems).ToList();

            return new PagedData<DK_HoiThaoGioiThieuThuocViewModel>
            {
                Data = datas,
                PageIndex = pageIndex,
                PageSize = pageSize,
                TotalItems = totalItems
            };
        }
        public long NganhDuoc_DK_HoiThaoGioiThieuThuoc_Save(DK_HoiThaoGioiThieuThuocSave dk_HoiThaoGioiThieuThuocSave)
        {
            long hoiThaoThuocID = 0;
            try
            {

                bool flagupd = true; //1: insert - 0: update
                cons = new SqlConnection(NganhDuocConn);
                cons.Open();
                trans = cons.BeginTransaction();

                if (dk_HoiThaoGioiThieuThuocSave.hoiThaoGioiThieuThuoc.HoiThaoThuocID != 0)
                {
                    flagupd = false;
                    hoiThaoThuocID = dk_HoiThaoGioiThieuThuocSave.hoiThaoGioiThieuThuoc.HoiThaoThuocID;
                }
                else
                {
                    flagupd = true;
                }

                if (flagupd)
                {
                    hoiThaoThuocID = _dK_HoiThaoGioiThieuThuocRepository.NganhDuoc_DK_HoiThaoGioiThieuThuoc_Ins(dk_HoiThaoGioiThieuThuocSave.hoiThaoGioiThieuThuoc, cons, trans);
                    if (hoiThaoThuocID == -1)
                    {
                        trans.Rollback();
                        return -1;
                    }
                    else
                    {
                        foreach (var dmthuoc in dk_HoiThaoGioiThieuThuocSave.lsthoiThaoGioiThieuThuoc_DMThuoc)
                        {
                            dmthuoc.HoiThaoThuocID = hoiThaoThuocID;
                        }
                        var insdmthuoc = _dK_HoiThaoGioiThieuThuoc_DMThuocRepository.NganhDuoc_DK_HoiThaoGioiThieuThuoc_DMThuoc_Ins(dk_HoiThaoGioiThieuThuocSave.lsthoiThaoGioiThieuThuoc_DMThuoc, cons, trans);
                        if (!insdmthuoc) { trans.Rollback(); return -1; }
                    }
                }
                else
                {
                    var updgcn = _dK_HoiThaoGioiThieuThuocRepository.NganhDuoc_DK_HoiThaoGioiThieuThuoc_UpdByID(dk_HoiThaoGioiThieuThuocSave.hoiThaoGioiThieuThuoc, cons, trans);
                    if (!updgcn) { trans.Rollback(); return -1; }
                    var deldmthuoc = _dK_HoiThaoGioiThieuThuoc_DMThuocRepository.NganhDuoc_DK_HoiThaoGioiThieuThuoc_DMThuoc_DelByHoiThaoThuocID(hoiThaoThuocID, cons, trans);
                    if (!deldmthuoc) { trans.Rollback(); return -1; }

                    var insdmthuoc = _dK_HoiThaoGioiThieuThuoc_DMThuocRepository.NganhDuoc_DK_HoiThaoGioiThieuThuoc_DMThuoc_Ins(dk_HoiThaoGioiThieuThuocSave.lsthoiThaoGioiThieuThuoc_DMThuoc, cons, trans);
                    if (!insdmthuoc) { trans.Rollback(); return -1; }

                }
                trans.Commit();
                return hoiThaoThuocID;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                return -1;
            }
        }
        public bool NganhDuoc_DK_HoiThaoGioiThieuThuoc_UpdDaCap(List<long> HoSoIDs)
        {
            try
            {
                cons = new SqlConnection(NganhDuocConn);
                cons.Open();
                trans = cons.BeginTransaction();

                foreach (long HoSoID in HoSoIDs)
                {
                    var updHTDK = _dK_HoiThaoGioiThieuThuocRepository.NganhDuoc_DK_HoiThaoGioiThieuThuoc_UpdDaCap(HoSoID, cons, trans);
                    if (!updHTDK) { trans.Rollback(); return false; }
                }

                trans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                return false;
            }
        }
        public bool NganhDuoc_DK_HoiThaoGioiThieuThuoc_DelByHoSoID(long HoSoID, long HoiThaoThuocID)
        {
            try
            {
                cons = new SqlConnection(NganhDuocConn);
                cons.Open();
                trans = cons.BeginTransaction();

                var delDKHT = _dK_HoiThaoGioiThieuThuocRepository.NganhDuoc_DK_HoiThaoGioiThieuThuoc_DelByHoSoID(HoSoID, HoiThaoThuocID, cons, trans);
                if (!delDKHT) { trans.Rollback(); return false; }

                trans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                return false;
            }
        }
        #endregion

        #region GDP
        public List<CN_GDP_DSKho> NganhDuoc_CN_GDP_DSKho_GetByTHTGDPId(long THTGDPId)
        {
            try
            {
                return _cN_GDP_DSKhoRepository.NganhDuoc_CN_GDP_DSKho_GetByTHTGDPId(THTGDPId).ToList();
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return new List<CN_GDP_DSKho>();
            }
        }
        public CN_GDPSave NganhDuoc_CN_GDP_GetByHoSoID(long HoSoID)
        {
            try
            {
                CN_GDPSave objreturn = new CN_GDPSave();
                objreturn.gDP = _cN_GDPRepository.NganhDuoc_CN_GDP_GetByHoSoID(HoSoID);
                objreturn.lstgDP_DSKho = _cN_GDP_DSKhoRepository.NganhDuoc_CN_GDP_DSKho_GetByTHTGDPId(objreturn.gDP.THTGDPId).ToList();

                return objreturn;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return null;
            }
        }
        public CN_GDPSave NganhDuoc_CN_GDP_GetByID(long THTGDPId)
        {
            try
            {
                CN_GDPSave objreturn = new CN_GDPSave();
                objreturn.gDP = _cN_GDPRepository.NganhDuoc_CN_GDP_GetByID(THTGDPId);
                objreturn.lstgDP_DSKho = _cN_GDP_DSKhoRepository.NganhDuoc_CN_GDP_DSKho_GetByTHTGDPId(objreturn.gDP.THTGDPId).ToList();

                return objreturn;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return null;
            }
        }
     
        public long NganhDuoc_CN_GDP_Save(CN_GDPSave cN_GDPSave)
        {
            long tHTGDPId = 0;
            try
            {

                bool flagupd = true; //1: insert - 0: update
                cons = new SqlConnection(NganhDuocConn);
                cons.Open();
                trans = cons.BeginTransaction();

                if (cN_GDPSave.gDP.THTGDPId != 0)
                {
                    flagupd = false;
                    tHTGDPId = cN_GDPSave.gDP.THTGDPId;
                }
                else
                {
                    flagupd = true;
                }

                if (flagupd)
                {
                    tHTGDPId = _cN_GDPRepository.NganhDuoc_CN_GDP_Ins(cN_GDPSave.gDP, cons, trans);
                    if (tHTGDPId <=0)
                    {
                        trans.Rollback();
                        return tHTGDPId;
                    }
                    else
                    {
                        foreach (var dskho in cN_GDPSave.lstgDP_DSKho)
                        {
                            dskho.THTGDPId = tHTGDPId;
                        }
                        var insdskho = _cN_GDP_DSKhoRepository.NganhDuoc_CN_GDP_DSKho_Ins(cN_GDPSave.lstgDP_DSKho, cons, trans);
                        if (!insdskho) { trans.Rollback(); return -1; }
                    }
                }
                else
                {
                    var upgdp = _cN_GDPRepository.NganhDuoc_CN_GDP_UpdByID(cN_GDPSave.gDP, cons, trans);
                    if (tHTGDPId <= 0)
                    {
                        trans.Rollback();
                        return tHTGDPId;
                    }
                    //var deldskho = _cN_GDP_DSKhoRepository.NganhDuoc_CN_GDP_DSKho_DelByTHTGDPId(tHTGDPId, cons, trans);
                    //if (!deldskho) { trans.Rollback(); return -1; }

                    var insdskho = _cN_GDP_DSKhoRepository.NganhDuoc_CN_GDP_DSKho_InsAndUpd(cN_GDPSave.lstgDP_DSKho, cons, trans);
                    if (!insdskho) { trans.Rollback(); return -1; }

                }
                trans.Commit();
                return tHTGDPId;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                Logger.Error(ex.Message);
                return -1;
            }
        }
        public bool NganhDuoc_CN_GDP_UpdDaCap(List<long> HoSoIDs)
        {
            try
            {
                cons = new SqlConnection(NganhDuocConn);
                cons.Open();
                trans = cons.BeginTransaction();

                foreach (long HoSoID in HoSoIDs)
                {
                    var updHTDK = _cN_GDPRepository.NganhDuoc_CN_GDP_UpdDaCap(HoSoID, cons, trans);
                    if (!updHTDK) { trans.Rollback(); return false; }
                }

                trans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                Logger.Error(ex.Message);
                return false;
            }
        }
      
      
        public PagedData<CN_GDPViewModel> NganhDuoc_CN_GDP_Search(string SoGiayChungNhan, string tuNgay, string denNgay
            , string TenCoSo, string SoDKKD, int pageIndex, int pageSize)
        {
            int totalItems;
            var datas = _cN_GDPRepository.NganhDuoc_CN_GDP_Search(SoGiayChungNhan,
                tuNgay.ToDateTimeNullable(), denNgay.ToDateTimeNullable(), TenCoSo, SoDKKD, pageIndex, pageSize, out totalItems).ToList();

            return new PagedData<CN_GDPViewModel>
            {
                Data = datas,
                PageIndex = pageIndex,
                PageSize = pageSize,
                TotalItems = totalItems
            };
        }
        public bool NganhDuoc_CN_GDP_DelByHoSoID(long HoSoID)
        {
            try
            {
                cons = new SqlConnection(NganhDuocConn);
                cons.Open();
                trans = cons.BeginTransaction();

                var delDKHT = _cN_GDPRepository.NganhDuoc_CN_GDP_DelByHoSoID(HoSoID, cons, trans);
                if (!delDKHT) { trans.Rollback(); return false; }

                trans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                Logger.Error(ex.Message);
                return false;
            }
        }
        public bool NganhDuoc_CN_GDP_DelByTHTGDPID(long THTGDPID)
        {
            try
            {
                cons = new SqlConnection(NganhDuocConn);
                cons.Open();
                trans = cons.BeginTransaction();

                var delDKHT = _cN_GDPRepository.NganhDuoc_CN_GDP_DelByTHTGDPID(THTGDPID, cons, trans);
                if (!delDKHT) { trans.Rollback(); return false; }

                trans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                Logger.Error(ex.Message);
                return false;
            }
        }
        public DataTableViewModel NganhDuoc_CN_GDP_InDeXuat(long Id)
        {
            try
            {
                var datas = _cN_GDPRepository.NganhDuoc_CN_GDP_InDeXuat(Id);
                return datas;

            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return null;
            }
        }
        public DataTableViewModel NganhDuoc_CN_GDP_InChungChi(long Id)
        {
            try
            {
                var datas = _cN_GDPRepository.NganhDuoc_CN_GDP_InChungChi(Id);
                return datas;

            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return null;
            }
        }
        public DataTableViewModel NganhDuoc_CN_GDP_XuatDanhSach(string SoGiayChungNhan, string tuNgay, string denNgay
            , string TenCoSo, string SoDKKD)
        {
            try
            {
                var datas = _cN_GDPRepository.NganhDuoc_CN_GDP_XuatDanhSach(SoGiayChungNhan,
                tuNgay.ToDateTimeNullable(), denNgay.ToDateTimeNullable(), TenCoSo, SoDKKD);
                return datas;

            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return null;
            }
        }
        public DataTableViewModel NganhDuoc_CN_GDP_CongBoWebsite(string SoGiayChungNhan, string tuNgay, string denNgay
           , string TenCoSo, string SoDKKD)
        {
            try
            {
                var datas = _cN_GDPRepository.NganhDuoc_CN_GDP_CongBoWebsite(SoGiayChungNhan,
                tuNgay.ToDateTimeNullable(), denNgay.ToDateTimeNullable(), TenCoSo, SoDKKD);
                return datas;

            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return null;
            }
        }
        #endregion
        #region GPP
        public long NganhDuoc_CN_GPP_Save(CN_GPP cN_GPPSave)
        {
            try
            {
                cons = new SqlConnection(NganhDuocConn);
                cons.Open();
                trans = cons.BeginTransaction();
                var THTGPPId = cN_GPPSave.THTGPPId;
                if (THTGPPId == 0)
                {
                    THTGPPId =
                        _cN_GPPRepository.NganhDuoc_CN_GPP_Ins(
                            cN_GPPSave, cons, trans);
                    if (THTGPPId <= 0)
                    {
                        trans.Rollback();
                        return THTGPPId;
                    }
                }
                else
                {
                    var upd =
                        _cN_GPPRepository.NganhDuoc_CN_GPP_UpdByID(
                            cN_GPPSave, cons, trans);
                    if (upd <=0)
                    {
                        trans.Rollback();
                        return upd;
                    }
                }
                if(cN_GPPSave.HoSoID.HasValue &&cN_GPPSave.HoSoID ==0)//Dau ky
                {
                    _cN_GPPRepository.NganhDuoc_CN_GPP_UpdDaCap(
                          cN_GPPSave.HoSoID.Value, cons, trans);
                }
                    
                trans.Commit();
                return THTGPPId;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                Logger.Error(ex.Message);
                return -1;
            }
        }
        public CN_GPP NganhDuoc_CN_GPP_GetByHoSoID(long HoSoID)
        {
            try
            {
                return _cN_GPPRepository.NganhDuoc_CN_GPP_GetByHoSoID(HoSoID);
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return null;
            }
        }
        public CN_GPP NganhDuoc_CN_GPP_GetByID(long THTGPPId)
        {
            try
            {
                return _cN_GPPRepository.NganhDuoc_CN_GPP_GetByID(THTGPPId);
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return null;
            }
        }
        public PagedData<CN_GPPViewModel> NganhDuoc_CN_GPP_Search(string SoGiayChungNhan, string tuNgay, string denNgay
            , string TenCoSo,string SoDKKD, int pageIndex, int pageSize)
        {
            int totalItems;
            var datas = _cN_GPPRepository.NganhDuoc_CN_GPP_Search(SoGiayChungNhan,
                tuNgay.ToDateTimeNullable(), denNgay.ToDateTimeNullable(), TenCoSo, SoDKKD, pageIndex, pageSize, out totalItems).ToList();

            return new PagedData<CN_GPPViewModel>
            {
                Data = datas,
                PageIndex = pageIndex,
                PageSize = pageSize,
                TotalItems = totalItems
            };
        }
        public bool NganhDuoc_CN_GPP_UpdDaCap(List<long> HoSoIDs)
        {
            try
            {
                cons = new SqlConnection(NganhDuocConn);
                cons.Open();
                trans = cons.BeginTransaction();

                foreach (long HoSoID in HoSoIDs)
                {
                    var updHTDK = _cN_GPPRepository.NganhDuoc_CN_GPP_UpdDaCap(HoSoID, cons, trans);
                    if (!updHTDK) { trans.Rollback(); return false; }
                }

                trans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                Logger.Error(ex.Message);
                return false;
            }
        }
        public bool NganhDuoc_CN_GPP_DelByHoSoID(long HoSoID)
        {
            try
            {
                cons = new SqlConnection(NganhDuocConn);
                cons.Open();
                trans = cons.BeginTransaction();

                var delDKHT = _cN_GPPRepository.NganhDuoc_CN_GPP_DelByHoSoID(HoSoID, cons, trans);
                if (!delDKHT) { trans.Rollback(); return false; }

                trans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                Logger.Error(ex.Message);
                return false;
            }
        }
        public bool NganhDuoc_CN_GPP_DelByTHTGPPID(long THTGPPID)
        {
            try
            {
                cons = new SqlConnection(NganhDuocConn);
                cons.Open();
                trans = cons.BeginTransaction();

                var delDKHT = _cN_GPPRepository.NganhDuoc_CN_GPP_DelByTHTGPPID(THTGPPID, cons, trans);
                if (!delDKHT) { trans.Rollback(); return false; }

                trans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                Logger.Error(ex.Message);
                return false;
            }
        }
        public DataTableViewModel NganhDuoc_CN_GPP_InDeXuat(long Id)
        {
            try
            {
                var datas = _cN_GPPRepository.NganhDuoc_CN_GPP_InDeXuat(Id);
                return datas;

            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return null;
            }
        }
        public DataTableViewModel NganhDuoc_CN_GPP_InChungChi(long Id)
        {
            try
            {
                var datas = _cN_GPPRepository.NganhDuoc_CN_GPP_InChungChi(Id);
                return datas;

            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return null;
            }
        }
        public DataTableViewModel NganhDuoc_CN_GPP_XuatDanhSach(string SoGiayChungNhan, string tuNgay, string denNgay
            , string TenCoSo, string SoDKKD)
        {
            try
            {
                var datas = _cN_GPPRepository.NganhDuoc_CN_GPP_XuatDanhSach(SoGiayChungNhan,
                tuNgay.ToDateTimeNullable(), denNgay.ToDateTimeNullable(), TenCoSo, SoDKKD) ;
                return datas;

            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return null;
            }
        }
        public DataTableViewModel NganhDuoc_CN_GPP_CongBoWebsite(string SoGiayChungNhan, string tuNgay, string denNgay
           , string TenCoSo, string SoDKKD)
        {
            try
            {
                var datas = _cN_GPPRepository.NganhDuoc_CN_GPP_CongBoWebsite(SoGiayChungNhan,
                tuNgay.ToDateTimeNullable(), denNgay.ToDateTimeNullable(), TenCoSo, SoDKKD);
                return datas;

            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return null;
            }
        }
        #endregion

        #region Cho phép tổ chức, cá nhân xuất khẩu/nhập khẩu thuốc theo đường phi mậu dịch
        public CV_XNKThuoc_PhiMauDichSave NganhDuoc_CV_XNKThuoc_PhiMauDich_GetByHoSoID(long HoSoID)
        {
            try
            {
                CV_XNKThuoc_PhiMauDichSave objreturn = new CV_XNKThuoc_PhiMauDichSave();
                objreturn.xNKThuocPhiMauDich = _cV_XNKThuoc_PhiMauDichRepository.NganhDuoc_CV_XNKThuoc_PhiMauDich_GetByHoSoID(HoSoID);
                objreturn.lstxNKThuocPhiMauDich_DSThuoc = _cV_XNKThuoc_PhiMauDich_DSThuocRepository.NganhDuoc_CV_XNKThuoc_PhiMauDich_DSThuoc_GetByXNKThuocPhiMauDichId(objreturn.xNKThuocPhiMauDich.XNKThuocPhiMauDichId).ToList();

                return objreturn;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public CV_XNKThuoc_PhiMauDichSave NganhDuoc_CV_XNKThuoc_PhiMauDich_GetByID(long XNKThuocPhiMauDichId)
        {
            try
            {
                CV_XNKThuoc_PhiMauDichSave objreturn = new CV_XNKThuoc_PhiMauDichSave();
                objreturn.xNKThuocPhiMauDich = _cV_XNKThuoc_PhiMauDichRepository.NganhDuoc_CV_XNKThuoc_PhiMauDich_GetByID(XNKThuocPhiMauDichId);
                objreturn.lstxNKThuocPhiMauDich_DSThuoc = _cV_XNKThuoc_PhiMauDich_DSThuocRepository.NganhDuoc_CV_XNKThuoc_PhiMauDich_DSThuoc_GetByXNKThuocPhiMauDichId(objreturn.xNKThuocPhiMauDich.XNKThuocPhiMauDichId).ToList();

                return objreturn;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public PagedData<CV_XNKThuoc_PhiMauDichViewModel> NganhDuoc_CV_XNKThuoc_PhiMauDich_Search(string SoCongVan, string tuNgay, string denNgay
            , string HoTenNguoiNhanThuoc, int pageIndex, int pageSize)
        {
            int totalItems;
            var datas = _cV_XNKThuoc_PhiMauDichRepository.NganhDuoc_CV_XNKThuoc_PhiMauDich_Search(SoCongVan,
                tuNgay.ToDateTimeNullable(), denNgay.ToDateTimeNullable(), HoTenNguoiNhanThuoc, pageIndex, pageSize, out totalItems).ToList();

            return new PagedData<CV_XNKThuoc_PhiMauDichViewModel>
            {
                Data = datas,
                PageIndex = pageIndex,
                PageSize = pageSize,
                TotalItems = totalItems
            };
        }
        public long NganhDuoc_CV_XNKThuoc_PhiMauDich_Save(CV_XNKThuoc_PhiMauDichSave cV_XNKThuoc_PhiMauDichSave)
        {
            long xNKThuocPhiMauDichId = 0;
            try
            {

                bool flagupd = true; //1: insert - 0: update
                cons = new SqlConnection(NganhDuocConn);
                cons.Open();
                trans = cons.BeginTransaction();

                if (cV_XNKThuoc_PhiMauDichSave.xNKThuocPhiMauDich.XNKThuocPhiMauDichId != 0)
                {
                    flagupd = false;
                    xNKThuocPhiMauDichId = cV_XNKThuoc_PhiMauDichSave.xNKThuocPhiMauDich.XNKThuocPhiMauDichId;
                }
                else
                {
                    flagupd = true;
                }

                if (flagupd)
                {
                    xNKThuocPhiMauDichId = _cV_XNKThuoc_PhiMauDichRepository.NganhDuoc_CV_XNKThuoc_PhiMauDich_Ins(cV_XNKThuoc_PhiMauDichSave.xNKThuocPhiMauDich, cons, trans);
                    if (xNKThuocPhiMauDichId == -1)
                    {
                        trans.Rollback();
                        return -1;
                    }
                    else
                    {
                        foreach (var dsthuoc in cV_XNKThuoc_PhiMauDichSave.lstxNKThuocPhiMauDich_DSThuoc)
                        {
                            dsthuoc.XNKThuocPhiMauDichId = xNKThuocPhiMauDichId;
                        }
                        var insdsthuoc = _cV_XNKThuoc_PhiMauDich_DSThuocRepository.NganhDuoc_CV_XNKThuoc_PhiMauDich_DSThuoc_Ins(cV_XNKThuoc_PhiMauDichSave.lstxNKThuocPhiMauDich_DSThuoc, cons, trans);
                        if (!insdsthuoc) { trans.Rollback(); return -1; }
                    }
                }
                else
                {
                    var upxnk = _cV_XNKThuoc_PhiMauDichRepository.NganhDuoc_CV_XNKThuoc_PhiMauDich_UpdByID(cV_XNKThuoc_PhiMauDichSave.xNKThuocPhiMauDich, cons, trans);
                    if (!upxnk) { trans.Rollback(); return -1; }
                    var deldsthuoc = _cV_XNKThuoc_PhiMauDich_DSThuocRepository.NganhDuoc_CV_XNKThuoc_PhiMauDich_DSThuoc_DelByXNKThuocPhiMauDichId(xNKThuocPhiMauDichId, cons, trans);
                    if (!deldsthuoc) { trans.Rollback(); return -1; }

                    var insdsthuoc = _cV_XNKThuoc_PhiMauDich_DSThuocRepository.NganhDuoc_CV_XNKThuoc_PhiMauDich_DSThuoc_Ins(cV_XNKThuoc_PhiMauDichSave.lstxNKThuocPhiMauDich_DSThuoc, cons, trans);
                    if (!insdsthuoc) { trans.Rollback(); return -1; }
                }
                trans.Commit();
                return xNKThuocPhiMauDichId;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                return -1;
            }
        }
        public bool NganhDuoc_CV_XNKThuoc_PhiMauDich_UpdDaCap(List<long> HoSoIDs)
        {
            try
            {
                cons = new SqlConnection(NganhDuocConn);
                cons.Open();
                trans = cons.BeginTransaction();

                foreach (long HoSoID in HoSoIDs)
                {
                    var updHTDK = _cV_XNKThuoc_PhiMauDichRepository.NganhDuoc_CV_XNKThuoc_PhiMauDich_UpdDaCap(HoSoID, cons, trans);
                    if (!updHTDK) { trans.Rollback(); return false; }
                }

                trans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                return false;
            }
        }
        public bool NganhDuoc_CV_XNKThuoc_PhiMauDich_DelByHoSoID(long HoSoID, long XNKThuocPhiMauDichId)
        {
            try
            {
                cons = new SqlConnection(NganhDuocConn);
                cons.Open();
                trans = cons.BeginTransaction();

                var delXNK = _cV_XNKThuoc_PhiMauDichRepository.NganhDuoc_CV_XNKThuoc_PhiMauDich_DelByHoSoID(HoSoID, XNKThuocPhiMauDichId, cons, trans);
                if (!delXNK) { trans.Rollback(); return false; }

                trans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                return false;
            }
        }
        #endregion

        #region Thẩm định kế hoạch đấu thầu vật tư y tế tiêu hao và hóa chất
        public TD_KeHoachDauThauSave NganhDuoc_TD_KeHoachDauThau_GetByHoSoID(long HoSoID)
        {
            try
            {
                TD_KeHoachDauThauSave objreturn = new TD_KeHoachDauThauSave();
                objreturn.keHoachDauThau = _tD_KeHoachDauThauRepository.NganhDuoc_TD_KeHoachDauThau_GetByHoSoID(HoSoID);
                objreturn.lstkeHoachDauThau_DSGoiThau = _tD_KeHoachDauThau_DSGoiThauRepository.NganhDuoc_TD_KeHoachDauThau_DSGoiThau_GetByKeHoachDauThauID(objreturn.keHoachDauThau.KeHoachDauThauId).ToList();

                return objreturn;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public TD_KeHoachDauThauSave NganhDuoc_TD_KeHoachDauThau_GetByID(long KeHoachDauThauId)
        {
            try
            {
                TD_KeHoachDauThauSave objreturn = new TD_KeHoachDauThauSave();
                objreturn.keHoachDauThau = _tD_KeHoachDauThauRepository.NganhDuoc_TD_KeHoachDauThau_GetByID(KeHoachDauThauId);
                objreturn.lstkeHoachDauThau_DSGoiThau = _tD_KeHoachDauThau_DSGoiThauRepository.NganhDuoc_TD_KeHoachDauThau_DSGoiThau_GetByKeHoachDauThauID(objreturn.keHoachDauThau.KeHoachDauThauId).ToList();

                return objreturn;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public PagedData<TD_KeHoachDauThauViewModel> NganhDuoc_TD_KeHoachDauThau_Search(string SoQuyetDinh, string tuNgay, string denNgay
            , string ChuDauTu, int pageIndex, int pageSize)
        {
            int totalItems;
            var datas = _tD_KeHoachDauThauRepository.NganhDuoc_TD_KeHoachDauThau_Search(SoQuyetDinh,
                tuNgay.ToDateTimeNullable(), denNgay.ToDateTimeNullable(), ChuDauTu, pageIndex, pageSize, out totalItems).ToList();

            return new PagedData<TD_KeHoachDauThauViewModel>
            {
                Data = datas,
                PageIndex = pageIndex,
                PageSize = pageSize,
                TotalItems = totalItems
            };
        }
        public long NganhDuoc_TD_KeHoachDauThau_Save(TD_KeHoachDauThauSave tD_KeHoachDauThauSave)
        {
            long keHoachDauThauId = 0;
            try
            {

                bool flagupd = true; //1: insert - 0: update
                cons = new SqlConnection(NganhDuocConn);
                cons.Open();
                trans = cons.BeginTransaction();

                if (tD_KeHoachDauThauSave.keHoachDauThau.KeHoachDauThauId != 0)
                {
                    flagupd = false;
                    keHoachDauThauId = tD_KeHoachDauThauSave.keHoachDauThau.KeHoachDauThauId;
                }
                else
                {
                    flagupd = true;
                }

                if (flagupd)
                {
                    keHoachDauThauId = _tD_KeHoachDauThauRepository.NganhDuoc_TD_KeHoachDauThau_Ins(tD_KeHoachDauThauSave.keHoachDauThau, cons, trans);
                    if (keHoachDauThauId == -1)
                    {
                        trans.Rollback();
                        return -1;
                    }
                    else
                    {
                        foreach (var dsgoithau in tD_KeHoachDauThauSave.lstkeHoachDauThau_DSGoiThau)
                        {
                            dsgoithau.KeHoachDauThauId = keHoachDauThauId;
                        }
                        var insdsgoithau = _tD_KeHoachDauThau_DSGoiThauRepository.NganhDuoc_TD_KeHoachDauThau_DSGoiThau_Ins(tD_KeHoachDauThauSave.lstkeHoachDauThau_DSGoiThau, cons, trans);
                        if (!insdsgoithau) { trans.Rollback(); return -1; }
                    }
                }
                else
                {
                    var updkh = _tD_KeHoachDauThauRepository.NganhDuoc_TD_KeHoachDauThau_UpdByID(tD_KeHoachDauThauSave.keHoachDauThau, cons, trans);
                    if (!updkh) { trans.Rollback(); return -1; }
                    var deldsgoithau = _tD_KeHoachDauThau_DSGoiThauRepository.NganhDuoc_TD_KeHoachDauThau_DSGoiThau_DelByKeHoachDauThauID(keHoachDauThauId, cons, trans);
                    if (!deldsgoithau) { trans.Rollback(); return -1; }

                    var insdsgoithau = _tD_KeHoachDauThau_DSGoiThauRepository.NganhDuoc_TD_KeHoachDauThau_DSGoiThau_Ins(tD_KeHoachDauThauSave.lstkeHoachDauThau_DSGoiThau, cons, trans);
                    if (!insdsgoithau) { trans.Rollback(); return -1; }
                }
                trans.Commit();
                return keHoachDauThauId;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                return -1;
            }
        }
        public bool NganhDuoc_TD_KeHoachDauThau_UpdDaCap(List<long> HoSoIDs)
        {
            try
            {
                cons = new SqlConnection(NganhDuocConn);
                cons.Open();
                trans = cons.BeginTransaction();

                foreach (long HoSoID in HoSoIDs)
                {
                    var upd = _tD_KeHoachDauThauRepository.NganhDuoc_TD_KeHoachDauThau_UpdDaCap(HoSoID, cons, trans);
                    if (!upd) { trans.Rollback(); return false; }
                }

                trans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                return false;
            }
        }
        public bool NganhDuoc_TD_KeHoachDauThau_DelByHoSoID(long HoSoID, long KeHoachDauThauId)
        {
            try
            {
                cons = new SqlConnection(NganhDuocConn);
                cons.Open();
                trans = cons.BeginTransaction();

                var del = _tD_KeHoachDauThauRepository.NganhDuoc_TD_KeHoachDauThau_DelByHoSoID(HoSoID, KeHoachDauThauId, cons, trans);
                if (!del) { trans.Rollback(); return false; }

                trans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                return false;
            }
        }
        #endregion

        #region Duyệt dự trù thuốc thành phẩm gây nghiện, hướng tâm thần
        public PD_Thuoc_GN_HTTSave NganhDuoc_PD_Thuoc_GN_HTT_GetByHoSoID(long HoSoID)
        {
            try
            {
                PD_Thuoc_GN_HTTSave objreturn = new PD_Thuoc_GN_HTTSave();
                objreturn.thuocGNHTT = _pD_Thuoc_GN_HTTRepository.NganhDuoc_PD_Thuoc_GN_HTT_GetByHoSoID(HoSoID);
                objreturn.lstthuocGNHTT_DSThuoc = _pD_Thuoc_GN_HTT_DSThuocRepository.NganhDuoc_PD_Thuoc_GN_HTT_DSThuoc_GetByPDThuocGNHTTId(objreturn.thuocGNHTT.PDThuocGNHTTId).ToList();

                return objreturn;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public PD_Thuoc_GN_HTTSave NganhDuoc_PD_Thuoc_GN_HTT_GetByID(long PDThuocGNHTTId)
        {
            try
            {
                PD_Thuoc_GN_HTTSave objreturn = new PD_Thuoc_GN_HTTSave();
                objreturn.thuocGNHTT = _pD_Thuoc_GN_HTTRepository.NganhDuoc_PD_Thuoc_GN_HTT_GetByID(PDThuocGNHTTId);
                objreturn.lstthuocGNHTT_DSThuoc = _pD_Thuoc_GN_HTT_DSThuocRepository.NganhDuoc_PD_Thuoc_GN_HTT_DSThuoc_GetByPDThuocGNHTTId(objreturn.thuocGNHTT.PDThuocGNHTTId).ToList();

                return objreturn;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public PagedData<PD_Thuoc_GN_HTTViewModel> NganhDuoc_PD_Thuoc_GN_HTT_Search(string SoPheDuyet, string tuNgay, string denNgay
            , string TenDonVi, string TenCongTyCungUng, int pageIndex, int pageSize)
        {
            int totalItems;
            var datas = _pD_Thuoc_GN_HTTRepository.NganhDuoc_PD_Thuoc_GN_HTT_Search(SoPheDuyet,
                tuNgay.ToDateTimeNullable(), denNgay.ToDateTimeNullable(), TenDonVi, TenCongTyCungUng, pageIndex, pageSize, out totalItems).ToList();

            return new PagedData<PD_Thuoc_GN_HTTViewModel>
            {
                Data = datas,
                PageIndex = pageIndex,
                PageSize = pageSize,
                TotalItems = totalItems
            };
        }
        public long NganhDuoc_PD_Thuoc_GN_HTT_Save(PD_Thuoc_GN_HTTSave pD_Thuoc_GN_HTTSave)
        {
            long pDThuocGNHTTId = 0;
            try
            {

                bool flagupd = true; //1: insert - 0: update
                cons = new SqlConnection(NganhDuocConn);
                cons.Open();
                trans = cons.BeginTransaction();

                if (pD_Thuoc_GN_HTTSave.thuocGNHTT.PDThuocGNHTTId != 0)
                {
                    flagupd = false;
                    pDThuocGNHTTId = pD_Thuoc_GN_HTTSave.thuocGNHTT.PDThuocGNHTTId;
                }
                else
                {
                    flagupd = true;
                }

                if (flagupd)
                {
                    pDThuocGNHTTId = _pD_Thuoc_GN_HTTRepository.NganhDuoc_PD_Thuoc_GN_HTT_Ins(pD_Thuoc_GN_HTTSave.thuocGNHTT, cons, trans);
                    if (pDThuocGNHTTId == -1)
                    {
                        trans.Rollback();
                        return -1;
                    }
                    else
                    {
                        foreach (var dsthuoc in pD_Thuoc_GN_HTTSave.lstthuocGNHTT_DSThuoc)
                        {
                            dsthuoc.PDThuocGNHTTId = pDThuocGNHTTId;
                        }
                        var insdsthuoc = _pD_Thuoc_GN_HTT_DSThuocRepository.NganhDuoc_PD_Thuoc_GN_HTT_DSThuoc_Ins(pD_Thuoc_GN_HTTSave.lstthuocGNHTT_DSThuoc, cons, trans);
                        if (!insdsthuoc) { trans.Rollback(); return -1; }
                    }
                }
                else
                {
                    var upd = _pD_Thuoc_GN_HTTRepository.NganhDuoc_PD_Thuoc_GN_HTT_UpdByID(pD_Thuoc_GN_HTTSave.thuocGNHTT, cons, trans);
                    if (!upd) { trans.Rollback(); return -1; }
                    var deldsthuoc = _pD_Thuoc_GN_HTT_DSThuocRepository.NganhDuoc_PD_Thuoc_GN_HTT_DSThuoc_DelByPDThuocGNHTTId(pDThuocGNHTTId, cons, trans);
                    if (!deldsthuoc) { trans.Rollback(); return -1; }

                    var insdsthuoc = _pD_Thuoc_GN_HTT_DSThuocRepository.NganhDuoc_PD_Thuoc_GN_HTT_DSThuoc_Ins(pD_Thuoc_GN_HTTSave.lstthuocGNHTT_DSThuoc, cons, trans);
                    if (!insdsthuoc) { trans.Rollback(); return -1; }
                }
                trans.Commit();
                return pDThuocGNHTTId;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                return -1;
            }
        }
        public bool NganhDuoc_PD_Thuoc_GN_HTT_UpdDaCap(List<long> HoSoIDs)
        {
            try
            {
                cons = new SqlConnection(NganhDuocConn);
                cons.Open();
                trans = cons.BeginTransaction();

                foreach (long HoSoID in HoSoIDs)
                {
                    var upd = _pD_Thuoc_GN_HTTRepository.NganhDuoc_PD_Thuoc_GN_HTT_UpdDaCap(HoSoID, cons, trans);
                    if (!upd) { trans.Rollback(); return false; }
                }

                trans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                return false;
            }
        }
        public bool NganhDuoc_PD_Thuoc_GN_HTT_DelByHoSoID(long HoSoID, long PDThuocGNHTTId)
        {
            try
            {
                cons = new SqlConnection(NganhDuocConn);
                cons.Open();
                trans = cons.BeginTransaction();

                var del = _pD_Thuoc_GN_HTTRepository.NganhDuoc_PD_Thuoc_GN_HTT_DelByHoSoID(HoSoID, PDThuocGNHTTId, cons, trans);
                if (!del) { trans.Rollback(); return false; }

                trans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                return false;
            }
        }
        #endregion

        #region Duyệt dự trù và phân phối thuốc Methadone
        public PD_Thuoc_MethadoneSave NganhDuoc_PD_Thuoc_Methadone_GetByHoSoID(long HoSoID)
        {
            try
            {
                PD_Thuoc_MethadoneSave objreturn = new PD_Thuoc_MethadoneSave();
                objreturn.thuocMethadone = _pD_Thuoc_MethadoneRepository.NganhDuoc_PD_Thuoc_Methadone_GetByHoSoID(HoSoID);
                objreturn.lstthuocMethadone_TinhHinh = _pD_Thuoc_Methadone_TinhHinhRepository.NganhDuoc_PD_Thuoc_Methadone_TinhHinh_GetByPDMethadoneId(objreturn.thuocMethadone.PDMethadoneId).ToList();

                return objreturn;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public PD_Thuoc_MethadoneSave NganhDuoc_PD_Thuoc_Methadone_GetByID(long PDMethadoneId)
        {
            try
            {
                PD_Thuoc_MethadoneSave objreturn = new PD_Thuoc_MethadoneSave();
                objreturn.thuocMethadone = _pD_Thuoc_MethadoneRepository.NganhDuoc_PD_Thuoc_Methadone_GetByID(PDMethadoneId);
                objreturn.lstthuocMethadone_TinhHinh = _pD_Thuoc_Methadone_TinhHinhRepository.NganhDuoc_PD_Thuoc_Methadone_TinhHinh_GetByPDMethadoneId(objreturn.thuocMethadone.PDMethadoneId).ToList();

                return objreturn;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public PagedData<PD_Thuoc_MethadoneViewModel> NganhDuoc_PD_Thuoc_Methadone_Search(string SoPheDuyet, string tuNgay, string denNgay
            , string TenDonVi, int pageIndex, int pageSize)
        {
            int totalItems;
            var datas = _pD_Thuoc_MethadoneRepository.NganhDuoc_PD_Thuoc_Methadone_Search(SoPheDuyet,
                tuNgay.ToDateTimeNullable(), denNgay.ToDateTimeNullable(), TenDonVi, pageIndex, pageSize, out totalItems).ToList();

            return new PagedData<PD_Thuoc_MethadoneViewModel>
            {
                Data = datas,
                PageIndex = pageIndex,
                PageSize = pageSize,
                TotalItems = totalItems
            };
        }
        public long NganhDuoc_PD_Thuoc_Methadone_Save(PD_Thuoc_MethadoneSave pD_Thuoc_MethadoneSave)
        {
            long pDMethadoneId = 0;
            try
            {

                bool flagupd = true; //1: insert - 0: update
                cons = new SqlConnection(NganhDuocConn);
                cons.Open();
                trans = cons.BeginTransaction();

                if (pD_Thuoc_MethadoneSave.thuocMethadone.PDMethadoneId != 0)
                {
                    flagupd = false;
                    pDMethadoneId = pD_Thuoc_MethadoneSave.thuocMethadone.PDMethadoneId;
                }
                else
                {
                    flagupd = true;
                }

                if (flagupd)
                {
                    pDMethadoneId = _pD_Thuoc_MethadoneRepository.NganhDuoc_PD_Thuoc_Methadone_Ins(pD_Thuoc_MethadoneSave.thuocMethadone, cons, trans);
                    if (pDMethadoneId == -1)
                    {
                        trans.Rollback();
                        return -1;
                    }
                    else
                    {
                        foreach (var dstinhhinh in pD_Thuoc_MethadoneSave.lstthuocMethadone_TinhHinh)
                        {
                            dstinhhinh.PDMethadoneId = pDMethadoneId;
                        }
                        var insdstinhhinh = _pD_Thuoc_Methadone_TinhHinhRepository.NganhDuoc_PD_Thuoc_Methadone_TinhHinh_Ins(pD_Thuoc_MethadoneSave.lstthuocMethadone_TinhHinh, cons, trans);
                        if (!insdstinhhinh) { trans.Rollback(); return -1; }
                    }
                }
                else
                {
                    var upd = _pD_Thuoc_MethadoneRepository.NganhDuoc_PD_Thuoc_Methadone_UpdByID(pD_Thuoc_MethadoneSave.thuocMethadone, cons, trans);
                    if (!upd) { trans.Rollback(); return -1; }
                    var deldstinhhinh = _pD_Thuoc_Methadone_TinhHinhRepository.NganhDuoc_PD_Thuoc_Methadone_TinhHinh_DelByPDMethadoneId(pDMethadoneId, cons, trans);
                    if (!deldstinhhinh) { trans.Rollback(); return -1; }

                    var insdstinhhinh = _pD_Thuoc_Methadone_TinhHinhRepository.NganhDuoc_PD_Thuoc_Methadone_TinhHinh_Ins(pD_Thuoc_MethadoneSave.lstthuocMethadone_TinhHinh, cons, trans);
                    if (!insdstinhhinh) { trans.Rollback(); return -1; }
                }
                trans.Commit();
                return pDMethadoneId;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                return -1;
            }
        }
        public bool NganhDuoc_PD_Thuoc_Methadone_UpdDaCap(List<long> HoSoIDs)
        {
            try
            {
                cons = new SqlConnection(NganhDuocConn);
                cons.Open();
                trans = cons.BeginTransaction();

                foreach (long HoSoID in HoSoIDs)
                {
                    var upd = _pD_Thuoc_MethadoneRepository.NganhDuoc_PD_Thuoc_Methadone_UpdDaCap(HoSoID, cons, trans);
                    if (!upd) { trans.Rollback(); return false; }
                }

                trans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                return false;
            }
        }
        public bool NganhDuoc_PD_Thuoc_Methadone_DelByHoSoID(long HoSoID, long PDMethadoneId)
        {
            try
            {
                cons = new SqlConnection(NganhDuocConn);
                cons.Open();
                trans = cons.BeginTransaction();

                var del = _pD_Thuoc_MethadoneRepository.NganhDuoc_PD_Thuoc_Methadone_DelByHoSoID(HoSoID, PDMethadoneId, cons, trans);
                if (!del) { trans.Rollback(); return false; }

                trans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                return false;
            }
        }
        #endregion

        #region Cấp phép nhập khẩu thuốc viện trợ, viện trợ nhân đạo
        public CP_Thuoc_VienTroSave NganhDuoc_CP_Thuoc_VienTro_GetByHoSoID(long HoSoID)
        {
            try
            {
                CP_Thuoc_VienTroSave objreturn = new CP_Thuoc_VienTroSave();
                objreturn.thuocVienTro = _cP_Thuoc_VienTroRepository.NganhDuoc_CP_Thuoc_VienTro_GetByHoSoID(HoSoID);
                objreturn.lstthuocVienTro_DMThuoc = _cP_Thuoc_VienTro_DMThuocRepository.NganhDuoc_CP_Thuoc_VienTro_DMThuoc_GetByThuocVienTroId(objreturn.thuocVienTro.ThuocVienTroId).ToList();

                return objreturn;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public CP_Thuoc_VienTroSave NganhDuoc_CP_Thuoc_VienTro_GetByID(long ThuocVienTroId)
        {
            try
            {
                CP_Thuoc_VienTroSave objreturn = new CP_Thuoc_VienTroSave();
                objreturn.thuocVienTro = _cP_Thuoc_VienTroRepository.NganhDuoc_CP_Thuoc_VienTro_GetByID(ThuocVienTroId);
                objreturn.lstthuocVienTro_DMThuoc = _cP_Thuoc_VienTro_DMThuocRepository.NganhDuoc_CP_Thuoc_VienTro_DMThuoc_GetByThuocVienTroId(objreturn.thuocVienTro.ThuocVienTroId).ToList();

                return objreturn;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public PagedData<CP_Thuoc_VienTroViewModel> NganhDuoc_CP_Thuoc_VienTro_Search(string SoTiepNhan, string tuNgay, string denNgay
            , string TenDonVi, int pageIndex, int pageSize)
        {
            int totalItems;
            var datas = _cP_Thuoc_VienTroRepository.NganhDuoc_CP_Thuoc_VienTro_Search(SoTiepNhan,
                tuNgay.ToDateTimeNullable(), denNgay.ToDateTimeNullable(), TenDonVi, pageIndex, pageSize, out totalItems).ToList();

            return new PagedData<CP_Thuoc_VienTroViewModel>
            {
                Data = datas,
                PageIndex = pageIndex,
                PageSize = pageSize,
                TotalItems = totalItems
            };
        }
        public long NganhDuoc_CP_Thuoc_VienTro_Save(CP_Thuoc_VienTroSave cP_Thuoc_VienTroSave)
        {
            long thuocVienTroId = 0;
            try
            {

                bool flagupd = true; //1: insert - 0: update
                cons = new SqlConnection(NganhDuocConn);
                cons.Open();
                trans = cons.BeginTransaction();

                if (cP_Thuoc_VienTroSave.thuocVienTro.ThuocVienTroId != 0)
                {
                    flagupd = false;
                    thuocVienTroId = cP_Thuoc_VienTroSave.thuocVienTro.ThuocVienTroId;
                }
                else
                {
                    flagupd = true;
                }

                if (flagupd)
                {
                    thuocVienTroId = _cP_Thuoc_VienTroRepository.NganhDuoc_CP_Thuoc_VienTro_Ins(cP_Thuoc_VienTroSave.thuocVienTro, cons, trans);
                    if (thuocVienTroId == -1)
                    {
                        trans.Rollback();
                        return -1;
                    }
                    else
                    {
                        foreach (var dsthuoc in cP_Thuoc_VienTroSave.lstthuocVienTro_DMThuoc)
                        {
                            dsthuoc.ThuocVienTroId = thuocVienTroId;
                        }
                        var insdsthuoc = _cP_Thuoc_VienTro_DMThuocRepository.NganhDuoc_CP_Thuoc_VienTro_DMThuoc_Ins(cP_Thuoc_VienTroSave.lstthuocVienTro_DMThuoc, cons, trans);
                        if (!insdsthuoc) { trans.Rollback(); return -1; }
                    }
                }
                else
                {
                    var upd = _cP_Thuoc_VienTroRepository.NganhDuoc_CP_Thuoc_VienTro_UpdByID(cP_Thuoc_VienTroSave.thuocVienTro, cons, trans);
                    if (!upd) { trans.Rollback(); return -1; }
                    var deldsthuoc = _cP_Thuoc_VienTro_DMThuocRepository.NganhDuoc_CP_Thuoc_VienTro_DMThuoc_DelThuocVienTroId(thuocVienTroId, cons, trans);
                    if (!deldsthuoc) { trans.Rollback(); return -1; }

                    var insdsthuoc = _cP_Thuoc_VienTro_DMThuocRepository.NganhDuoc_CP_Thuoc_VienTro_DMThuoc_Ins(cP_Thuoc_VienTroSave.lstthuocVienTro_DMThuoc, cons, trans);
                    if (!insdsthuoc) { trans.Rollback(); return -1; }
                }
                trans.Commit();
                return thuocVienTroId;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                return -1;
            }
        }
        public bool NganhDuoc_CP_Thuoc_VienTro_UpdDaCap(List<long> HoSoIDs)
        {
            try
            {
                cons = new SqlConnection(NganhDuocConn);
                cons.Open();
                trans = cons.BeginTransaction();

                foreach (long HoSoID in HoSoIDs)
                {
                    var upd = _cP_Thuoc_VienTroRepository.NganhDuoc_CP_Thuoc_VienTro_UpdDaCap(HoSoID, cons, trans);
                    if (!upd) { trans.Rollback(); return false; }
                }

                trans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                return false;
            }
        }
        public bool NganhDuoc_CP_Thuoc_VienTro_DelByHoSoID(long HoSoID, long ThuocVienTroId)
        {
            try
            {
                cons = new SqlConnection(NganhDuocConn);
                cons.Open();
                trans = cons.BeginTransaction();

                var del = _cP_Thuoc_VienTroRepository.NganhDuoc_CP_Thuoc_VienTro_DelByHoSoID(HoSoID, ThuocVienTroId, cons, trans);
                if (!del) { trans.Rollback(); return false; }

                trans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                return false;
            }
        }
        #endregion

        #region Cấp giấy xác nhận nội dung quảng cáo mỹ phẩm
        public XN_NoiDungQuangCaoSave NganhDuoc_XN_NoiDungQuangCao_GetByHoSoID(long HoSoID)
        {
            try
            {
                XN_NoiDungQuangCaoSave objreturn = new XN_NoiDungQuangCaoSave();
                objreturn.noiDungQuangCao = _xN_NoiDungQuangCaoRepository.NganhDuoc_XN_NoiDungQuangCao_GetByHoSoID(HoSoID);
                objreturn.lstnoiDungQuangCao_SanPham = _xN_NoiDungQuangCao_SanPhamRepository.NganhDuoc_XN_NoiDungQuangCao_SanPham_GetByNoiDungQCId(objreturn.noiDungQuangCao.NoiDungQCId).ToList();

                return objreturn;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public XN_NoiDungQuangCaoSave NganhDuoc_XN_NoiDungQuangCao_GetByID(long NoiDungQCId)
        {
            try
            {
                XN_NoiDungQuangCaoSave objreturn = new XN_NoiDungQuangCaoSave();
                objreturn.noiDungQuangCao = _xN_NoiDungQuangCaoRepository.NganhDuoc_XN_NoiDungQuangCao_GetByID(NoiDungQCId);
                objreturn.lstnoiDungQuangCao_SanPham = _xN_NoiDungQuangCao_SanPhamRepository.NganhDuoc_XN_NoiDungQuangCao_SanPham_GetByNoiDungQCId(objreturn.noiDungQuangCao.NoiDungQCId).ToList();

                return objreturn;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public PagedData<XN_NoiDungQuangCaoViewModel> NganhDuoc_XN_NoiDungQuangCao_Search(string SoXacNhan, string tuNgay, string denNgay
            , string TOCHUC_CANHAN, int pageIndex, int pageSize)
        {
            int totalItems;
            var datas = _xN_NoiDungQuangCaoRepository.NganhDuoc_XN_NoiDungQuangCao_Search(SoXacNhan,
                tuNgay.ToDateTimeNullable(), denNgay.ToDateTimeNullable(), TOCHUC_CANHAN, pageIndex, pageSize, out totalItems).ToList();

            return new PagedData<XN_NoiDungQuangCaoViewModel>
            {
                Data = datas,
                PageIndex = pageIndex,
                PageSize = pageSize,
                TotalItems = totalItems
            };
        }
        public long NganhDuoc_XN_NoiDungQuangCao_Save(XN_NoiDungQuangCaoSave xN_NoiDungQuangCaoSave)
        {
            long noiDungQCId = 0;
            try
            {

                bool flagupd = true; //1: insert - 0: update
                cons = new SqlConnection(NganhDuocConn);
                cons.Open();
                trans = cons.BeginTransaction();

                if (xN_NoiDungQuangCaoSave.noiDungQuangCao.NoiDungQCId != 0)
                {
                    flagupd = false;
                    noiDungQCId = xN_NoiDungQuangCaoSave.noiDungQuangCao.NoiDungQCId;
                }
                else
                {
                    flagupd = true;
                }

                if (flagupd)
                {
                    noiDungQCId = _xN_NoiDungQuangCaoRepository.NganhDuoc_XN_NoiDungQuangCao_Ins(xN_NoiDungQuangCaoSave.noiDungQuangCao, cons, trans);
                    if (noiDungQCId == -1)
                    {
                        trans.Rollback();
                        return -1;
                    }
                    else
                    {
                        foreach (var dssp in xN_NoiDungQuangCaoSave.lstnoiDungQuangCao_SanPham)
                        {
                            dssp.NoiDungQCId = noiDungQCId;
                        }
                        var inssp = _xN_NoiDungQuangCao_SanPhamRepository.NganhDuoc_XN_NoiDungQuangCao_SanPham_Ins(xN_NoiDungQuangCaoSave.lstnoiDungQuangCao_SanPham, cons, trans);
                        if (!inssp) { trans.Rollback(); return -1; }
                    }
                }
                else
                {
                    var upd = _xN_NoiDungQuangCaoRepository.NganhDuoc_XN_NoiDungQuangCao_UpdByID(xN_NoiDungQuangCaoSave.noiDungQuangCao, cons, trans);
                    if (!upd) { trans.Rollback(); return -1; }
                    var delsp = _xN_NoiDungQuangCao_SanPhamRepository.NganhDuoc_XN_NoiDungQuangCao_SanPham_DelByNoiDungQCId(noiDungQCId, cons, trans);
                    if (!delsp) { trans.Rollback(); return -1; }

                    var inssp = _xN_NoiDungQuangCao_SanPhamRepository.NganhDuoc_XN_NoiDungQuangCao_SanPham_Ins(xN_NoiDungQuangCaoSave.lstnoiDungQuangCao_SanPham, cons, trans);
                    if (!inssp) { trans.Rollback(); return -1; }
                }
                trans.Commit();
                return noiDungQCId;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                return -1;
            }
        }
        public bool NganhDuoc_XN_NoiDungQuangCao_UpdDaCap(List<long> HoSoIDs)
        {
            try
            {
                cons = new SqlConnection(NganhDuocConn);
                cons.Open();
                trans = cons.BeginTransaction();

                foreach (long HoSoID in HoSoIDs)
                {
                    var upd = _xN_NoiDungQuangCaoRepository.NganhDuoc_XN_NoiDungQuangCao_UpdDaCap(HoSoID, cons, trans);
                    if (!upd) { trans.Rollback(); return false; }
                }

                trans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                return false;
            }
        }
        public bool NganhDuoc_XN_NoiDungQuangCao_DelByHoSoID(long HoSoID, long NoiDungQCId)
        {
            try
            {
                cons = new SqlConnection(NganhDuocConn);
                cons.Open();
                trans = cons.BeginTransaction();

                var del = _xN_NoiDungQuangCaoRepository.NganhDuoc_XN_NoiDungQuangCao_DelByHoSoID(HoSoID, NoiDungQCId, cons, trans);
                if (!del) { trans.Rollback(); return false; }

                trans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                return false;
            }
        }
        #endregion

        #region Cấp số tiếp nhận phiếu công bố sản phẩm mỹ phẩm sản xuất tại Việt Nam
        public P_CongBoMyPhamSave NganhDuoc_P_CongBoMyPham_GetByHoSoID(long HoSoID)
        {
            try
            {
                P_CongBoMyPhamSave objreturn = new P_CongBoMyPhamSave();
                objreturn.congBoMyPham = _p_CongBoMyPhamRepository.NganhDuoc_P_CongBoMyPham_GetByHoSoID(HoSoID);
                objreturn.lstcongBoMyPham_ThanhPhan = _p_CongBoMyPham_ThanhPhanRepository.NganhDuoc_P_CongBoMyPham_ThanhPhan_GetByCongBoSPMyPhamId(objreturn.congBoMyPham.CongBoSPMyPhamId).ToList();

                return objreturn;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public P_CongBoMyPhamSave NganhDuoc_P_CongBoMyPham_GetByID(long CongBoSPMyPhamId)
        {
            try
            {
                P_CongBoMyPhamSave objreturn = new P_CongBoMyPhamSave();
                objreturn.congBoMyPham = _p_CongBoMyPhamRepository.NganhDuoc_P_CongBoMyPham_GetByID(CongBoSPMyPhamId);
                objreturn.lstcongBoMyPham_ThanhPhan = _p_CongBoMyPham_ThanhPhanRepository.NganhDuoc_P_CongBoMyPham_ThanhPhan_GetByCongBoSPMyPhamId(objreturn.congBoMyPham.CongBoSPMyPhamId).ToList();

                return objreturn;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public PagedData<P_CongBoMyPhamViewModel> NganhDuoc_P_CongBoMyPham_Search(string SoCongBo, string ThoiHanTu, string ThoiHanDen
            , string NhanHang, string TenSanPham, string TenNhaSanXuat, int pageIndex, int pageSize)
        {
            int totalItems;
            var datas = _p_CongBoMyPhamRepository.NganhDuoc_P_CongBoMyPham_Search(SoCongBo,
                ThoiHanTu.ToIntNullable(), ThoiHanDen.ToIntNullable(), NhanHang, TenSanPham, TenNhaSanXuat, pageIndex, pageSize, out totalItems).ToList();

            return new PagedData<P_CongBoMyPhamViewModel>
            {
                Data = datas,
                PageIndex = pageIndex,
                PageSize = pageSize,
                TotalItems = totalItems
            };
        }
        public long NganhDuoc_P_CongBoMyPham_Save(P_CongBoMyPhamSave p_CongBoMyPhamSave)
        {
            long congBoSPMyPhamId = 0;
            try
            {

                bool flagupd = true; //1: insert - 0: update
                cons = new SqlConnection(NganhDuocConn);
                cons.Open();
                trans = cons.BeginTransaction();

                if (p_CongBoMyPhamSave.congBoMyPham.CongBoSPMyPhamId != 0)
                {
                    flagupd = false;
                    congBoSPMyPhamId = p_CongBoMyPhamSave.congBoMyPham.CongBoSPMyPhamId;
                }
                else
                {
                    flagupd = true;
                }

                if (flagupd)
                {
                    congBoSPMyPhamId = _p_CongBoMyPhamRepository.NganhDuoc_P_CongBoMyPham_Ins(p_CongBoMyPhamSave.congBoMyPham, cons, trans);
                    if (congBoSPMyPhamId == -1)
                    {
                        trans.Rollback();
                        return -1;
                    }
                    else
                    {
                        foreach (var dstp in p_CongBoMyPhamSave.lstcongBoMyPham_ThanhPhan)
                        {
                            dstp.CongBoSPMyPhamId = congBoSPMyPhamId;
                        }
                        var instp = _p_CongBoMyPham_ThanhPhanRepository.NganhDuoc_P_CongBoMyPham_ThanhPhan_Ins(p_CongBoMyPhamSave.lstcongBoMyPham_ThanhPhan, cons, trans);
                        if (!instp) { trans.Rollback(); return -1; }
                    }
                }
                else
                {
                    var upd = _p_CongBoMyPhamRepository.NganhDuoc_P_CongBoMyPham_UpdByID(p_CongBoMyPhamSave.congBoMyPham, cons, trans);
                    if (!upd) { trans.Rollback(); return -1; }
                    var deltp = _p_CongBoMyPham_ThanhPhanRepository.NganhDuoc_P_CongBoMyPham_ThanhPhan_DelCongBoSPMyPhamId(congBoSPMyPhamId, cons, trans);
                    if (!deltp) { trans.Rollback(); return -1; }

                    var instp = _p_CongBoMyPham_ThanhPhanRepository.NganhDuoc_P_CongBoMyPham_ThanhPhan_Ins(p_CongBoMyPhamSave.lstcongBoMyPham_ThanhPhan, cons, trans);
                    if (!instp) { trans.Rollback(); return -1; }
                }
                trans.Commit();
                return congBoSPMyPhamId;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                return -1;
            }
        }
        public bool NganhDuoc_P_CongBoMyPham_UpdDaCap(List<long> HoSoIDs)
        {
            try
            {
                cons = new SqlConnection(NganhDuocConn);
                cons.Open();
                trans = cons.BeginTransaction();

                foreach (long HoSoID in HoSoIDs)
                {
                    var upd = _p_CongBoMyPhamRepository.NganhDuoc_P_CongBoMyPham_UpdDaCap(HoSoID, cons, trans);
                    if (!upd) { trans.Rollback(); return false; }
                }

                trans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                return false;
            }
        }
        public bool NganhDuoc_P_CongBoMyPham_DelByHoSoID(long HoSoID, long CongBoSPMyPhamId)
        {
            try
            {
                cons = new SqlConnection(NganhDuocConn);
                cons.Open();
                trans = cons.BeginTransaction();

                var del = _p_CongBoMyPhamRepository.NganhDuoc_P_CongBoMyPham_DelByHoSoID(HoSoID, CongBoSPMyPhamId, cons, trans);
                if (!del) { trans.Rollback(); return false; }

                trans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                return false;
            }
        }
        #endregion

        #region Lưu hành mỹ phẩm
        public CN_LuuHanhMyPhamSave NganhDuoc_CN_LuuHanhMyPham_GetByHoSoID(long HoSoID)
        {
            try
            {
                CN_LuuHanhMyPhamSave objreturn = new CN_LuuHanhMyPhamSave();
                objreturn.luuHanhMyPham = _cN_LuuHanhMyPhamRepository.NganhDuoc_CN_LuuHanhMyPham_GetByHoSoID(HoSoID);
                objreturn.lstluuHanhMyPham_SanPham = _cN_LuuHanhMyPham_SanPhamRepository.NganhDuoc_CN_LuuHanhMyPham_SanPham_GetByLuuHanhMyPhamId(objreturn.luuHanhMyPham.LuuHanhMyPhamId).ToList();

                return objreturn;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public CN_LuuHanhMyPhamSave NganhDuoc_CN_LuuHanhMyPham_GetByID(long LuuHanhMyPhamId)
        {
            try
            {
                CN_LuuHanhMyPhamSave objreturn = new CN_LuuHanhMyPhamSave();
                objreturn.luuHanhMyPham = _cN_LuuHanhMyPhamRepository.NganhDuoc_CN_LuuHanhMyPham_GetByID(LuuHanhMyPhamId);
                objreturn.lstluuHanhMyPham_SanPham = _cN_LuuHanhMyPham_SanPhamRepository.NganhDuoc_CN_LuuHanhMyPham_SanPham_GetByLuuHanhMyPhamId(objreturn.luuHanhMyPham.LuuHanhMyPhamId).ToList();

                return objreturn;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public PagedData<CN_LuuHanhMyPhamViewModel> NganhDuoc_CN_LuuHanhMyPham_Search(string SoChungNhan, string tuNgay, string denNgay
            , string TenCongTy, int pageIndex, int pageSize)
        {
            int totalItems;
            var datas = _cN_LuuHanhMyPhamRepository.NganhDuoc_CN_LuuHanhMyPham_Search(SoChungNhan,
                tuNgay.ToDateTimeNullable(), denNgay.ToDateTimeNullable(), TenCongTy, pageIndex, pageSize, out totalItems).ToList();

            return new PagedData<CN_LuuHanhMyPhamViewModel>
            {
                Data = datas,
                PageIndex = pageIndex,
                PageSize = pageSize,
                TotalItems = totalItems
            };
        }
        public long NganhDuoc_CN_LuuHanhMyPham_Save(CN_LuuHanhMyPhamSave cN_LuuHanhMyPhamSave)
        {
            long luuHanhMyPhamId = 0;
            try
            {

                bool flagupd = true; //1: insert - 0: update
                cons = new SqlConnection(NganhDuocConn);
                cons.Open();
                trans = cons.BeginTransaction();

                if (cN_LuuHanhMyPhamSave.luuHanhMyPham.LuuHanhMyPhamId != 0)
                {
                    flagupd = false;
                    luuHanhMyPhamId = cN_LuuHanhMyPhamSave.luuHanhMyPham.LuuHanhMyPhamId;
                }
                else
                {
                    flagupd = true;
                }

                if (flagupd)
                {
                    luuHanhMyPhamId = _cN_LuuHanhMyPhamRepository.NganhDuoc_CN_LuuHanhMyPham_Ins(cN_LuuHanhMyPhamSave.luuHanhMyPham, cons, trans);
                    if (luuHanhMyPhamId == -1)
                    {
                        trans.Rollback();
                        return -1;
                    }
                    else
                    {
                        foreach (var dsmp in cN_LuuHanhMyPhamSave.lstluuHanhMyPham_SanPham)
                        {
                            dsmp.LuuHanhMyPhamId = luuHanhMyPhamId;
                        }
                        var insmp = _cN_LuuHanhMyPham_SanPhamRepository.NganhDuoc_CN_LuuHanhMyPham_SanPham_Ins(cN_LuuHanhMyPhamSave.lstluuHanhMyPham_SanPham, cons, trans);
                        if (!insmp) { trans.Rollback(); return -1; }
                    }
                }
                else
                {
                    var upd = _cN_LuuHanhMyPhamRepository.NganhDuoc_CN_LuuHanhMyPham_UpdByID(cN_LuuHanhMyPhamSave.luuHanhMyPham, cons, trans);
                    if (!upd) { trans.Rollback(); return -1; }
                    var delmp = _cN_LuuHanhMyPham_SanPhamRepository.NganhDuoc_CN_LuuHanhMyPham_SanPham_DelLuuHanhMyPhamId(luuHanhMyPhamId, cons, trans);
                    if (!delmp) { trans.Rollback(); return -1; }

                    var insmp = _cN_LuuHanhMyPham_SanPhamRepository.NganhDuoc_CN_LuuHanhMyPham_SanPham_Ins(cN_LuuHanhMyPhamSave.lstluuHanhMyPham_SanPham, cons, trans);
                    if (!insmp) { trans.Rollback(); return -1; }
                }
                trans.Commit();
                return luuHanhMyPhamId;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                return -1;
            }
        }
        public bool NganhDuoc_CN_LuuHanhMyPham_UpdDaCap(List<long> HoSoIDs)
        {
            try
            {
                cons = new SqlConnection(NganhDuocConn);
                cons.Open();
                trans = cons.BeginTransaction();

                foreach (long HoSoID in HoSoIDs)
                {
                    var upd = _cN_LuuHanhMyPhamRepository.NganhDuoc_CN_LuuHanhMyPham_UpdDaCap(HoSoID, cons, trans);
                    if (!upd) { trans.Rollback(); return false; }
                }

                trans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                return false;
            }
        }
        public bool NganhDuoc_CN_LuuHanhMyPham_DelByHoSoID(long HoSoID, long LuuHanhMyPhamId)
        {
            try
            {
                cons = new SqlConnection(NganhDuocConn);
                cons.Open();
                trans = cons.BeginTransaction();

                var del = _cN_LuuHanhMyPhamRepository.NganhDuoc_CN_LuuHanhMyPham_DelByHoSoID(HoSoID, LuuHanhMyPhamId, cons, trans);
                if (!del) { trans.Rollback(); return false; }

                trans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                return false;
            }
        }
        #endregion

        #region Cấp chứng chỉ hành nghề dược
        public long NganhDuoc_CC_Duoc_Save(CC_DuocSave cC_DuocSave)
        {
            try
            {
                if (cC_DuocSave?.cC_Duoc == null) return -1;
                var chungChiDuocid = cC_DuocSave.cC_Duoc.ChungChiDuocId;
                cons = new SqlConnection(NganhDuocConn);
                cons.Open();
                trans = cons.BeginTransaction();
                if (chungChiDuocid == 0)
                {
                    cC_DuocSave.cC_Duoc.CreatedDate = DateTime.Now;
                    chungChiDuocid =
                        _cC_DuocRepository.NganhDuoc_CC_Duoc_Ins(
                            cC_DuocSave.cC_Duoc, cons, trans);
                    if (chungChiDuocid == -1 || chungChiDuocid == 0)
                    {
                        trans.Rollback();
                        return chungChiDuocid;
                    }
                    if (cC_DuocSave.lstCC_Duoc_TDCM?.Any() == true)
                    {
                        foreach (var tdcm in cC_DuocSave.lstCC_Duoc_TDCM)
                            tdcm.ChungChiDuocID = chungChiDuocid;
                        var instdcm =
                            _cC_Duoc_TDCMRepository.NganhDuoc_CC_Duoc_TDCM_Ins(
                               cC_DuocSave.lstCC_Duoc_TDCM, cons, trans);
                        if (!instdcm)
                        {
                            trans.Rollback();
                            return -1;
                        }
                    }
                    if (cC_DuocSave.lstCC_Duoc_QTTH?.Any() == true)
                    {
                        foreach (var qtth in cC_DuocSave.lstCC_Duoc_QTTH)
                            qtth.ChungChiDuocID = chungChiDuocid;
                        var insqtth =
                             _cC_Duoc_QTTHRepository.NganhDuoc_CC_Duoc_QTTH_Ins(
                               cC_DuocSave.lstCC_Duoc_QTTH, cons, trans);
                        if (!insqtth)
                        {
                            trans.Rollback();
                            return -1;
                        }
                    }
                }
                else
                {
                    var updcchn =
                        _cC_DuocRepository.NganhDuoc_CC_Duoc_UpdByChungChiDuocID(
                            cC_DuocSave.cC_Duoc, cons, trans);
                    if (updcchn == -1 || updcchn == 0)
                    {
                        trans.Rollback();
                        return updcchn;
                    }
                    var deltdcm =
                        _cC_Duoc_TDCMRepository.NganhDuoc_CC_Duoc_TDCM_DelByChungChiDuocID(
                            chungChiDuocid, cons, trans);
                    if (!deltdcm)
                    {
                        trans.Rollback();
                        return -1;
                    }
                    var delqtth =
                        _cC_Duoc_QTTHRepository.NganhDuoc_CC_Duoc_QTTH_DelByChungChiDuocID(
                            chungChiDuocid, cons, trans);
                    if (!delqtth)
                    {
                        trans.Rollback();
                        return -1;
                    }
                    var instdcm =
                        _cC_Duoc_TDCMRepository.NganhDuoc_CC_Duoc_TDCM_Ins(
                            cC_DuocSave.lstCC_Duoc_TDCM, cons, trans);
                    if (!instdcm)
                    {
                        trans.Rollback();
                        return -1;
                    }
                    var insqtth =
                        _cC_Duoc_QTTHRepository.NganhDuoc_CC_Duoc_QTTH_Ins(
                           cC_DuocSave.lstCC_Duoc_QTTH, cons, trans);
                    if (!insqtth)
                    {
                        trans.Rollback();
                        return -1;
                    }
                }
                trans.Commit();
                return chungChiDuocid;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                Logger.Error(ex.Message);
                return -1;
            }
        }
        public List<CC_Duoc_QTTH> NganhDuoc_CC_Duoc_QTTH_GetByChungChiDuocID(long ChungChiDuocID)
        {
            try
            {
                return _cC_Duoc_QTTHRepository.NganhDuoc_CC_Duoc_QTTH_GetByChungChiDuocID(ChungChiDuocID).ToList();
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return new List<CC_Duoc_QTTH>();
            }
        }
        public List<CC_Duoc_TDCM> NganhDuoc_CC_Duoc_TDCM_GetByChungChiDuocID(long ChungChiDuocID)
        {
            try
            {
                return _cC_Duoc_TDCMRepository.NganhDuoc_CC_Duoc_TDCM_GetByChungChiDuocID(ChungChiDuocID).ToList();
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return new List<CC_Duoc_TDCM>();
            }
        }
        public CC_DuocSave NganhDuoc_CC_Duoc_GetByHoSoID(long HoSoID)
        {
            try
            {
                CC_DuocSave objreturn = new CC_DuocSave();
                objreturn.cC_Duoc = _cC_DuocRepository.NganhDuoc_CC_Duoc_GetByHoSoID(HoSoID);
                objreturn.lstCC_Duoc_QTTH = _cC_Duoc_QTTHRepository.NganhDuoc_CC_Duoc_QTTH_GetByChungChiDuocID(objreturn.cC_Duoc.ChungChiDuocId).ToList();
                objreturn.lstCC_Duoc_TDCM = _cC_Duoc_TDCMRepository.NganhDuoc_CC_Duoc_TDCM_GetByChungChiDuocID(objreturn.cC_Duoc.ChungChiDuocId).ToList();
                return  objreturn;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return null;
            }
        }
        public CC_DuocSave NganhDuoc_CC_Duoc_GetByID(long ChungChiDuocID)
        {
            try
            {
                CC_DuocSave objreturn = new CC_DuocSave();
                objreturn.cC_Duoc = _cC_DuocRepository.NganhDuoc_CC_Duoc_GetByID(ChungChiDuocID);
                objreturn.lstCC_Duoc_QTTH = _cC_Duoc_QTTHRepository.NganhDuoc_CC_Duoc_QTTH_GetByChungChiDuocID(ChungChiDuocID).ToList();
                objreturn.lstCC_Duoc_TDCM = _cC_Duoc_TDCMRepository.NganhDuoc_CC_Duoc_TDCM_GetByChungChiDuocID(ChungChiDuocID).ToList();
                return objreturn;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return null;
            }
        }
      
        public CC_DuocSave NganhDuoc_CC_Duoc_GetBySoChungChi(string soChungChi)
        {
            try
            {
                var objreturn = new CC_DuocSave
                {
                    cC_Duoc = _cC_DuocRepository.NganhDuoc_CC_Duoc_GetBySoChungChi(soChungChi)
                };
                if (objreturn.cC_Duoc != null)
                {
                    objreturn.lstCC_Duoc_TDCM = _cC_Duoc_TDCMRepository
                        .NganhDuoc_CC_Duoc_TDCM_GetByChungChiDuocID(objreturn.cC_Duoc.ChungChiDuocId)
                        .ToList();
                    objreturn.lstCC_Duoc_QTTH = _cC_Duoc_QTTHRepository
                        .NganhDuoc_CC_Duoc_QTTH_GetByChungChiDuocID(objreturn.cC_Duoc.ChungChiDuocId)
                        .ToList();
                }
                else
                {
                    return null;
                }
                return objreturn;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return null;
            }
        }

        public bool NganhDuoc_CC_Duoc_DelByChungChiDuocId(long ChungChiDuocId)
        {
            try
            {
                cons = new SqlConnection(NganhDuocConn);
                cons.Open();
                trans = cons.BeginTransaction();

                var delDKHT = _cC_DuocRepository.NganhDuoc_CC_Duoc_DelByChungChiDuocId(ChungChiDuocId, cons, trans);
                if (!delDKHT) { trans.Rollback(); return false; }

                trans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                Logger.Error(ex.Message);
                return false;
            }
        }
        public DataTableViewModel NganhDuoc_CC_Duoc_InDeXuat(long Id)
        {
            try
            {
                var datas = _cC_DuocRepository.NganhDuoc_CC_Duoc_InDeXuat(Id);
                return datas;

            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return null;
            }
        }
        public DataTableViewModel NganhDuoc_CC_Duoc_InChungChi(long Id)
        {
            try
            {
                var datas = _cC_DuocRepository.NganhDuoc_CC_Duoc_InChungChi(Id);
                return datas;

            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return null;
            }
        }
        public DataTableViewModel NganhDuoc_CC_Duoc_XuatDanhSach(string SoChungChi, string tuNgay, string denNgay
       , string HoTen, string SoGiayTo, string TrangThai)
        {
            try
            {
                var datas = _cC_DuocRepository.NganhDuoc_CC_Duoc_XuatDanhSach(SoChungChi, tuNgay.ToDateTimeNullable(), denNgay.ToDateTimeNullable()
       , HoTen, SoGiayTo, TrangThai);
                return datas;

            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return null;
            }
        }
        public DataTableViewModel NganhDuoc_CC_Duoc_CongBoWebsite(string SoChungChi, string tuNgay, string denNgay
       , string HoTen, string SoGiayTo, string TrangThai)
        {
            try
            {
                var datas = _cC_DuocRepository.NganhDuoc_CC_Duoc_CongBoWebsite(SoChungChi, tuNgay.ToDateTimeNullable(), denNgay.ToDateTimeNullable()
       , HoTen, SoGiayTo, TrangThai);
                return datas;

            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return null;
            }
        }
        public PagedData<CC_DuocViewModel> NganhDuoc_CC_Duoc_Lst(string SoChungChi, string tuNgay,
          string denNgay
          , string HoTen, string SoGiayTo, string TrangThai, int pageIndex, int pageSize)
        {
            int totalItems;
            var datas = _cC_DuocRepository.NganhDuoc_CC_Duoc_Lst(SoChungChi,
                tuNgay.ToDateTimeNullable(), denNgay.ToDateTimeNullable(), HoTen, SoGiayTo, TrangThai, pageIndex,
                pageSize, out totalItems).ToList();

            return new PagedData<CC_DuocViewModel>
            {
                Data = datas,
                PageIndex = pageIndex,
                PageSize = pageSize,
                TotalItems = totalItems
            };
        }
        public CC_Duoc_CapLaiSave NganhDuoc_CC_Duoc_CapLai_GetByHoSoID(long hoSoId)
        {
            try
            {
                var capLai = _cC_Duoc_CapLaiRepository.NganhDuoc_CC_Duoc_CapLai_GetByHoSoID(hoSoId);
                if (capLai == null) return null;
                var capLaiId = capLai.CapLaiID;
                var capLaiCt =
                    _cC_Duoc_CapLaiCTRepository.NganhDuoc_CC_Duoc_CapLaiCT_GetByCapLaiID(capLaiId);
                var noidungcuoitruoc = capLaiCt.NoiDungTruoc;
                var noidungcuoicung = capLaiCt.NoiDungSau;

                var objReturn = new CC_Duoc_CapLaiSave
                {
                    cc_duoc_caplai = capLai,
                    cc_duoc_caplaict = capLaiCt,
                    noidungtruoc = GenXML2Object<CC_DuocSave>(noidungcuoitruoc),
                    noidungsau = GenXML2Object<CC_DuocSave>(noidungcuoicung)
                };
                return objReturn;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                trans.Rollback();
                return null;
            }
        }
     
        #endregion
        #region func Dùng chung
        #endregion
    }
}