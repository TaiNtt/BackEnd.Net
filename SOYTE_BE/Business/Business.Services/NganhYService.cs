using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using Business.Entities;
using Business.Entities.ViewModels;
using Business.Services.Contracts;
using Core.Common.Utilities;
using Data.Core.Repositories.Interfaces;
using log4net;
namespace Business.Services
{
    public class NganhYService : INganhYService
    {
        #region Private Repository & constructor

        private IDbConnection _cons;
        private IDbTransaction _trans;
        protected static readonly ILog Logger = LogManager.GetLogger(typeof(NganhYService));

        private static readonly string NganhYConn =
            ConfigurationManager.ConnectionStrings["NganhY.ConnString"].ConnectionString;

        private readonly IChungChiHanhNgheYRepository _chungChiHanhNgheYRepository;
        private readonly IChungChiHanhNgheY_TDCMRepository _chungChiHanhNgheY_TDCMRepository;
        private readonly IChungChiHanhNgheY_QTTHRepository _chungChiHanhNgheY_QTTHRepository;
        private readonly IChungChiHanhNgheY_CapLaiRepository _chungChiHanhNgheY_CapLaiRepository;
        private readonly IChungChiHanhNgheY_CapLaiCTRepository _chungChiHanhNgheY_CapLaiCTRepository;
        private readonly IChungChiHanhNgheY_DieuChinhRepository _chungChiHanhNgheY_DieuChinhRepository;
        private readonly IChungChiHanhNgheY_DieuChinhCTRepository _chungChiHanhNgheY_DieuChinhCTRepository;
        private readonly IChungChiHanhNgheY_ThuHoiRepository _chungChiHanhNgheY_ThuHoiRepository;
        private readonly IChungChiHanhNgheY_RutChungChiRepository _chungChiHanhNgheY_RutChungChiRepository;
        private readonly IDangKyQCTrangThietBiRepository _dangKyQCTrangThietBiRepository;
        private readonly IGiayPhepHoatDongKCBRepository _giayPhepHoatDongKCBRepository;
        private readonly IGiayPhepHoatDongKCB_DSNhanSuRepository _giayPhepHoatDongKCB_DSNhanSuRepository;
        private readonly IGiayPhepHoatDongKCB_CapLaiRepository _giayPhepHoatDongKCB_CapLaiRepository;
        private readonly IGiayPhepHoatDongKCB_CapLaiCTRepository _giayPhepHoatDongKCB_CapLaiCTRepository;
        private readonly IGiayChungNhanLuongYRepository _giayChungNhanLuongYRepository;
        private readonly IGiayChungNhanLuongY_QTHanhNgheRepository _giayChungNhanLuongY_QTHanhNgheRepository;
        private readonly IGiayChungNhanATSHRepository _giayChungNhanATSHRepository;
        private readonly IGiayChungNhanATSH_DSThietBiRepository _giayChungNhanATSH_DSThietBiRepository;
        private readonly IGiayChungNhanATSH_DSNhanSuRepository _giayChungNhanATSH_DSNhanSuRepository;
        private readonly IGiayChungNhanATSH_CapLaiRepository _giayChungNhanATSH_CapLaiRepository;
        private readonly IGiayChungNhanATSH_CapLaiCTRepository _giayChungNhanATSH_CapLaiCTRepository;
        private readonly IGiayChungNhanBTGT_CapLaiCTRepository _giayChungNhanBTGT_CapLaiCTRepository;
        private readonly IGiayChungNhanBTGT_CapLaiRepository _giayChungNhanBTGT_CapLaiRepository;
        private readonly IGiayChungNhanBTGT_ThanhPhanRepository _giayChungNhanBTGT_ThanhPhanRepository;
        private readonly IGiayChungNhanBTGTRepository _giayChungNhanBTGTRepository;
        private readonly IGiayPhepDoanKCB_ThanhVienRepository _giayPhepDoanKCB_ThanhVienRepository;
        private readonly IGiayPhepDoanKCBRepository _giayPhepDoanKCBRepository;
        private readonly IGiayPhepHoatDongChuThapDo_CapLaiCTRepository _giayPhepHoatDongChuThapDo_CapLaiCTRepository;
        private readonly IGiayPhepHoatDongChuThapDo_CapLaiRepository _giayPhepHoatDongChuThapDo_CapLaiRepository;
        private readonly IGiayPhepHoatDongChuThapDoRepository _giayPhepHoatDongChuThapDoRepository;

        public NganhYService(IChungChiHanhNgheYRepository chungChiHanhNgheYRepository
            , IChungChiHanhNgheY_TDCMRepository chungChiHanhNgheY_TDCMRepository
            , IChungChiHanhNgheY_QTTHRepository chungChiHanhNgheY_QTTHRepository
            , IChungChiHanhNgheY_CapLaiRepository chungChiHanhNgheY_CapLaiRepository
            , IChungChiHanhNgheY_CapLaiCTRepository chungChiHanhNgheY_CapLaiCTRepository
            , IChungChiHanhNgheY_DieuChinhRepository chungChiHanhNgheY_DieuChinhRepository
            , IChungChiHanhNgheY_DieuChinhCTRepository chungChiHanhNgheY_DieuChinhCTRepository
            , IChungChiHanhNgheY_ThuHoiRepository chungChiHanhNgheY_ThuHoiRepository
            , IChungChiHanhNgheY_RutChungChiRepository chungChiHanhNgheY_RutChungChiRepository
            , IDangKyQCTrangThietBiRepository dangKyQCTrangThietBiRepository
            , IGiayPhepHoatDongKCBRepository giayPhepHoatDongKCBRepository
            , IGiayPhepHoatDongKCB_DSNhanSuRepository giayPhepHoatDongKCB_DSNhanSuRepository
            , IGiayPhepHoatDongKCB_CapLaiRepository giayPhepHoatDongKCB_CapLaiRepository
            , IGiayPhepHoatDongKCB_CapLaiCTRepository giayPhepHoatDongKCB_CapLaiCTRepository
            , IGiayChungNhanLuongYRepository giayChungNhanLuongYRepository
            , IGiayChungNhanLuongY_QTHanhNgheRepository giayChungNhanLuongY_QTHanhNgheRepository
            , IGiayChungNhanATSHRepository giayChungNhanATSHRepository
            , IGiayChungNhanATSH_DSThietBiRepository giayChungNhanATSH_DSThietBiRepository
            , IGiayChungNhanATSH_DSNhanSuRepository giayChungNhanATSH_DSNhanSuRepository
            , IGiayChungNhanATSH_CapLaiRepository giayChungNhanATSH_CapLaiRepository
            , IGiayChungNhanATSH_CapLaiCTRepository giayChungNhanATSH_CapLaiCTRepository
            , IGiayChungNhanBTGT_CapLaiCTRepository giayChungNhanBTGT_CapLaiCTRepository
            , IGiayChungNhanBTGT_CapLaiRepository giayChungNhanBTGT_CapLaiRepository
            , IGiayChungNhanBTGT_ThanhPhanRepository giayChungNhanBTGT_ThanhPhanRepository
            , IGiayChungNhanBTGTRepository giayChungNhanBTGTRepository
            , IGiayPhepDoanKCB_ThanhVienRepository giayPhepDoanKCB_ThanhVienRepository
            , IGiayPhepDoanKCBRepository giayPhepDoanKCBRepository
            , IGiayPhepHoatDongChuThapDo_CapLaiCTRepository giayPhepHoatDongChuThapDo_CapLaiCTRepository
            , IGiayPhepHoatDongChuThapDo_CapLaiRepository giayPhepHoatDongChuThapDo_CapLaiRepository
            , IGiayPhepHoatDongChuThapDoRepository giayPhepHoatDongChuThapDoRepository

        )
        {
            _chungChiHanhNgheYRepository = chungChiHanhNgheYRepository;
            _chungChiHanhNgheY_TDCMRepository = chungChiHanhNgheY_TDCMRepository;
            _chungChiHanhNgheY_QTTHRepository = chungChiHanhNgheY_QTTHRepository;
            _chungChiHanhNgheY_CapLaiRepository = chungChiHanhNgheY_CapLaiRepository;
            _chungChiHanhNgheY_CapLaiCTRepository = chungChiHanhNgheY_CapLaiCTRepository;
            _chungChiHanhNgheY_DieuChinhRepository = chungChiHanhNgheY_DieuChinhRepository;
            _chungChiHanhNgheY_DieuChinhCTRepository = chungChiHanhNgheY_DieuChinhCTRepository;
            _chungChiHanhNgheY_ThuHoiRepository = chungChiHanhNgheY_ThuHoiRepository;
            _chungChiHanhNgheY_RutChungChiRepository = chungChiHanhNgheY_RutChungChiRepository;
            _dangKyQCTrangThietBiRepository = dangKyQCTrangThietBiRepository;
            _giayPhepHoatDongKCBRepository = giayPhepHoatDongKCBRepository;
            _giayPhepHoatDongKCB_DSNhanSuRepository = giayPhepHoatDongKCB_DSNhanSuRepository;
            _giayPhepHoatDongKCB_CapLaiRepository = giayPhepHoatDongKCB_CapLaiRepository;
            _giayPhepHoatDongKCB_CapLaiCTRepository = giayPhepHoatDongKCB_CapLaiCTRepository;
            _giayChungNhanLuongYRepository = giayChungNhanLuongYRepository;
            _giayChungNhanLuongY_QTHanhNgheRepository = giayChungNhanLuongY_QTHanhNgheRepository;
            _giayChungNhanATSHRepository = giayChungNhanATSHRepository;
            _giayChungNhanATSH_DSThietBiRepository = giayChungNhanATSH_DSThietBiRepository;
            _giayChungNhanATSH_DSNhanSuRepository = giayChungNhanATSH_DSNhanSuRepository;
            _giayChungNhanATSH_CapLaiRepository = giayChungNhanATSH_CapLaiRepository;
            _giayChungNhanATSH_CapLaiCTRepository = giayChungNhanATSH_CapLaiCTRepository;
            _giayChungNhanBTGT_CapLaiCTRepository = giayChungNhanBTGT_CapLaiCTRepository;
            _giayChungNhanBTGT_CapLaiRepository = giayChungNhanBTGT_CapLaiRepository;
            _giayChungNhanBTGT_ThanhPhanRepository = giayChungNhanBTGT_ThanhPhanRepository;
            _giayChungNhanBTGTRepository = giayChungNhanBTGTRepository;
            _giayPhepDoanKCB_ThanhVienRepository = giayPhepDoanKCB_ThanhVienRepository;
            _giayPhepDoanKCBRepository = giayPhepDoanKCBRepository;
            _giayPhepHoatDongChuThapDo_CapLaiCTRepository = giayPhepHoatDongChuThapDo_CapLaiCTRepository;
            _giayPhepHoatDongChuThapDo_CapLaiRepository = giayPhepHoatDongChuThapDo_CapLaiRepository;
            _giayPhepHoatDongChuThapDoRepository = giayPhepHoatDongChuThapDoRepository;

        }

        #endregion

        #region XML converter

        private string GenObject2XML(ChungChiHanhNgheYSave objT)
        {
            var stream = new StringWriter();
            try
            {
                var serializer1 = new XmlSerializer(typeof(ChungChiHanhNgheYSave));
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

        private ChungChiHanhNgheYSave GenXML2Object(string xml)
        {
            StringReader strReader = null;
            XmlSerializer serializer = null;
            XmlTextReader xmlReader = null;
            var objReturn = new ChungChiHanhNgheYSave();
            try
            {
                strReader = new StringReader(xml);
                serializer = new XmlSerializer(typeof(ChungChiHanhNgheYSave));
                xmlReader = new XmlTextReader(strReader);
                using (var sr = new StringReader(xml))
                {
                    objReturn = (ChungChiHanhNgheYSave)serializer.Deserialize(sr);
                    return objReturn;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return new ChungChiHanhNgheYSave();
            }
            finally
            {
                xmlReader?.Close();
                strReader?.Close();
            }
        }

        private string GenObject2XML_GPKCB(GiayPhepHoatDongKCBSave objT)
        {
            var stream = new StringWriter();
            try
            {
                var serializer1 = new XmlSerializer(typeof(GiayPhepHoatDongKCBSave));
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

        private GiayPhepHoatDongKCBSave GenXML2Object_GPKCB(string xml)
        {
            StringReader strReader = null;
            XmlTextReader xmlReader = null;
            try
            {
                strReader = new StringReader(xml);
                var serializer = new XmlSerializer(typeof(GiayPhepHoatDongKCBSave));
                xmlReader = new XmlTextReader(strReader);
                using (var sr = new StringReader(xml))
                {
                    var objReturn = (GiayPhepHoatDongKCBSave)serializer.Deserialize(sr);
                    return objReturn;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return new GiayPhepHoatDongKCBSave();
            }
            finally
            {
                xmlReader?.Close();
                strReader?.Close();
            }
        }

        private string GenObject2XML_GCNATSH(GiayChungNhanATSHSave objT)
        {
            var stream = new StringWriter();
            try
            {
                var serializer1 = new XmlSerializer(typeof(GiayChungNhanATSHSave));
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

        private GiayChungNhanATSHSave GenXML2Object_GCNATSH(string xml)
        {
            StringReader strReader = null;
            XmlTextReader xmlReader = null;
            try
            {
                strReader = new StringReader(xml);
                var serializer = new XmlSerializer(typeof(GiayChungNhanATSHSave));
                xmlReader = new XmlTextReader(strReader);
                using (var sr = new StringReader(xml))
                {
                    var objReturn = (GiayChungNhanATSHSave)serializer.Deserialize(sr);
                    return objReturn;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return new GiayChungNhanATSHSave();
            }
            finally
            {
                xmlReader?.Close();
                strReader?.Close();
            }
        }

        private string GenObject2XML_GCNBTGT(GiayChungNhanBTGTSave objT)
        {
            var stream = new StringWriter();
            try
            {
                var serializer1 = new XmlSerializer(typeof(GiayChungNhanBTGTSave));
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

        private GiayChungNhanBTGTSave GenXML2Object_GCNBTGT(string xml)
        {
            StringReader strReader = null;
            XmlTextReader xmlReader = null;
            try
            {
                strReader = new StringReader(xml);
                var serializer = new XmlSerializer(typeof(GiayChungNhanBTGTSave));
                xmlReader = new XmlTextReader(strReader);
                using (var sr = new StringReader(xml))
                {
                    var objReturn = (GiayChungNhanBTGTSave)serializer.Deserialize(sr);
                    return objReturn;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return new GiayChungNhanBTGTSave();
            }
            finally
            {
                xmlReader?.Close();
                strReader?.Close();
            }
        }

        private string GenObject2XML_GPHDCTD(GiayPhepHoatDongChuThapDo objT)
        {
            var stream = new StringWriter();
            try
            {
                var serializer1 = new XmlSerializer(typeof(GiayPhepHoatDongChuThapDo));
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

        private GiayPhepHoatDongChuThapDo GenXML2Object_GPHDCTD(string xml)
        {
            StringReader strReader = null;
            XmlTextReader xmlReader = null;
            try
            {
                strReader = new StringReader(xml);
                var serializer = new XmlSerializer(typeof(GiayPhepHoatDongChuThapDo));
                xmlReader = new XmlTextReader(strReader);
                using (var sr = new StringReader(xml))
                {
                    var objReturn = (GiayPhepHoatDongChuThapDo)serializer.Deserialize(sr);
                    return objReturn;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return new GiayPhepHoatDongChuThapDo();
            }
            finally
            {
                xmlReader?.Close();
                strReader?.Close();
            }
        }

        #endregion

        #region CheckExist

        public bool CheckExistSoChungChi(string id, string val)
        {
            return _chungChiHanhNgheYRepository.CheckExistSoChungChi(id, val,
                "ChungChiHanhNgheYID", "SoChungChi");
        }

        public bool CheckExistSoTiepNhanDangKyQuangCaoNganhY(string id, string val)
        {
            return _dangKyQCTrangThietBiRepository.CheckExistSoTiepNhanDangKyQuangCaoNganhY(id, val,
                "DangKyQCTrangThietBiID", "SoTiepNhan");
        }

        public bool CheckExistSoGiayChungNhanATSH(string id, string val)
        {
            return _giayChungNhanATSHRepository.CheckExistSoGiayChungNhanATSH(id, val,
                "GiayChungNhanATSHID", "SoGiayChungNhan");
        }

        public bool CheckExistSoChungNhanLuongY(string id, string val)
        {
            return _giayChungNhanLuongYRepository.CheckExistSoChungNhanLuongY(id, val,
                "GiayChungNhanLuongYID", "SoGiayChungNhan");
        }

        #endregion

        #region Load DS ChungChiY

        public ChungChiHanhNgheYSave NganhY_ChungChiHanhNgheY_GetByHoSoID(long HoSoID)
        {
            try
            {
                var objreturn = new ChungChiHanhNgheYSave();
                objreturn.chungChiHanhNgheY = _chungChiHanhNgheYRepository.NganhY_ChungChiHanhNgheY_GetByHoSoID(HoSoID);
                objreturn.lstChungChiHanhNgheY_TDCM = _chungChiHanhNgheY_TDCMRepository
                    .NganhY_ChungChiHanhNgheY_TDCM_GetByCCHNYID(objreturn.chungChiHanhNgheY.ChungChiHanhNgheYID)
                    .ToList();
                objreturn.lstChungChiHanhNgheY_QTTH = _chungChiHanhNgheY_QTTHRepository
                    .NganhY_ChungChiHanhNgheY_QTTH_GetByCCHNYID(objreturn.chungChiHanhNgheY.ChungChiHanhNgheYID)
                    .ToList();

                return objreturn;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return null;
            }
        }

        public ChungChiHanhNgheYSave NganhY_ChungChiHanhNgheY_GetByID(long ChungChiHanhNgheYId)
        {
            try
            {
                var objreturn = new ChungChiHanhNgheYSave();
                objreturn.chungChiHanhNgheY =
                    _chungChiHanhNgheYRepository.NganhY_ChungChiHanhNgheY_GetByID(ChungChiHanhNgheYId);
                objreturn.lstChungChiHanhNgheY_TDCM = _chungChiHanhNgheY_TDCMRepository
                    .NganhY_ChungChiHanhNgheY_TDCM_GetByCCHNYID(objreturn.chungChiHanhNgheY.ChungChiHanhNgheYID)
                    .ToList();
                objreturn.lstChungChiHanhNgheY_QTTH = _chungChiHanhNgheY_QTTHRepository
                    .NganhY_ChungChiHanhNgheY_QTTH_GetByCCHNYID(objreturn.chungChiHanhNgheY.ChungChiHanhNgheYID)
                    .ToList();

                return objreturn;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return null;
            }
        }

        public ChungChiHanhNgheYSave NganhY_ChungChiHanhNgheY_GetBySoChungChi(string soChungChi)
        {
            try
            {
                var objreturn = new ChungChiHanhNgheYSave
                {
                    chungChiHanhNgheY =
                        _chungChiHanhNgheYRepository.NganhY_ChungChiHanhNgheY_GetBySoChungChi(soChungChi)
                };
                if (objreturn.chungChiHanhNgheY != null)
                {
                    objreturn.lstChungChiHanhNgheY_TDCM = _chungChiHanhNgheY_TDCMRepository
                        .NganhY_ChungChiHanhNgheY_TDCM_GetByCCHNYID(objreturn.chungChiHanhNgheY.ChungChiHanhNgheYID)
                        .ToList();
                    objreturn.lstChungChiHanhNgheY_QTTH = _chungChiHanhNgheY_QTTHRepository
                        .NganhY_ChungChiHanhNgheY_QTTH_GetByCCHNYID(objreturn.chungChiHanhNgheY.ChungChiHanhNgheYID)
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

        public PagedData<ChungChiHanhNgheYViewModel> NganhY_ChungChiHanhNgheY_Search(string SoChungChi, string tuNgay,
            string denNgay
            , string HoTen, string SoGiayTo, string lstTrangThai, int pageIndex, int pageSize)
        {
            int totalItems;
            var datas = _chungChiHanhNgheYRepository.NganhY_ChungChiHanhNgheY_Search(SoChungChi,
                tuNgay.ToDateTimeNullable(), denNgay.ToDateTimeNullable(), HoTen, SoGiayTo, lstTrangThai, pageIndex,
                pageSize, out totalItems).ToList();

            return new PagedData<ChungChiHanhNgheYViewModel>
            {
                Data = datas,
                PageIndex = pageIndex,
                PageSize = pageSize,
                TotalItems = totalItems
            };
        }

        public PagedData<ChungChiHanhNgheYViewModel> NganhY_ChungChiHanhNgheY_Lst(string SoChungChi, string tuNgay,
            string denNgay
            , string HoTen, string SoGiayTo, string TrangThai, int pageIndex, int pageSize)
        {
            int totalItems;
            var datas = _chungChiHanhNgheYRepository.NganhY_ChungChiHanhNgheY_Lst(SoChungChi,
                tuNgay.ToDateTimeNullable(), denNgay.ToDateTimeNullable(), HoTen, SoGiayTo, TrangThai, pageIndex,
                pageSize, out totalItems).ToList();

            return new PagedData<ChungChiHanhNgheYViewModel>
            {
                Data = datas,
                PageIndex = pageIndex,
                PageSize = pageSize,
                TotalItems = totalItems
            };
        }

        public ChungChiHanhNgheYCapLaiSave NganhY_ChungChiHanhNgheY_CapLai_GetByHoSoID(long hoSoId)
        {
            try
            {
                var capLai = _chungChiHanhNgheY_CapLaiRepository.NganhY_ChungChiHanhNgheY_CapLai_GetByHoSoID(hoSoId);
                if (capLai == null) return null;
                var capLaiId = capLai.CapLaiID;
                var capLaiCt =
                    _chungChiHanhNgheY_CapLaiCTRepository.NganhY_ChungChiHanhNgheY_CapLaiCT_GetByCapLaiID(capLaiId);
                var noidungcuoitruoc = capLaiCt.NoiDungTruoc;
                var noidungcuoicung = capLaiCt.NoiDungSau;

                var objReturn = new ChungChiHanhNgheYCapLaiSave
                {
                    chungChiHanhNgheY_caplai = capLai,
                    chungChiHanhNgheY_caplaict = capLaiCt,
                    noidungtruoc = GenXML2Object(noidungcuoitruoc),
                    noidungsau = GenXML2Object(noidungcuoicung)
                };
                return objReturn;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                _trans.Rollback();
                return null;
            }
        }


        public ChungChiHanhNgheYSave NganhY_ChungChiHanhNgheY_CapLai_GetNoiDungSauByHoSoID(long hoSoId)
        {
            try
            {
                var capLai = _chungChiHanhNgheY_CapLaiRepository.NganhY_ChungChiHanhNgheY_CapLai_GetByHoSoID(hoSoId);
                if (capLai == null) return null;
                var capLaiId = capLai.CapLaiID;
                var capLaiCt =
                    _chungChiHanhNgheY_CapLaiCTRepository.NganhY_ChungChiHanhNgheY_CapLaiCT_GetByCapLaiID(capLaiId);
                var noidungsau = GenXML2Object(capLaiCt.NoiDungSau);
                return noidungsau;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                _trans.Rollback();
                return null;
            }
        }



        public ChungChiHanhNgheYDieuChinhSave NganhY_ChungChiHanhNgheY_DieuChinh_GetByHoSoID(long HoSoID)
        {
            try
            {
                var dieuchinh =
                    _chungChiHanhNgheY_DieuChinhRepository.NganhY_ChungChiHanhNgheY_DieuChinh_GetByHoSoID(HoSoID);
                var dieuChinhId = dieuchinh.DieuChinhID;
                var dieuChinhCt =
                    _chungChiHanhNgheY_DieuChinhCTRepository.NganhY_ChungChiHanhNgheY_DieuChinhCT_GetByDieuChinhID(
                        dieuChinhId);
                var noidungtruoc = dieuChinhCt.NoiDungTruoc;
                var noidungcuoicung = dieuChinhCt.NoiDungSau;

                var objReturn = new ChungChiHanhNgheYDieuChinhSave
                {
                    chungChiHanhNgheY_dieuchinh = dieuchinh,
                    chungChiHanhNgheY_dieuchinhct = dieuChinhCt,
                    noidungtruoc = GenXML2Object(noidungtruoc),
                    noidungsau = GenXML2Object(noidungcuoicung)
                };

                return objReturn;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return null;
            }
        }

        #endregion

        #region Cấp mới ChungChiY

        public long NganhY_ChungChiHanhNgheY_Save(ChungChiHanhNgheYSave chungChiHanhNgheYSave)
        {
            try
            {
                if (chungChiHanhNgheYSave?.chungChiHanhNgheY == null) return -1;
                var chungchihanhngheYid = chungChiHanhNgheYSave.chungChiHanhNgheY.ChungChiHanhNgheYID;
                _cons = new SqlConnection(NganhYConn);
                _cons.Open();
                _trans = _cons.BeginTransaction();
                if (chungchihanhngheYid == 0)
                {
                    chungChiHanhNgheYSave.chungChiHanhNgheY.CreatedDate = DateTime.Now;
                    chungchihanhngheYid =
                        _chungChiHanhNgheYRepository.NganhY_ChungChiHanhNgheY_Ins(
                            chungChiHanhNgheYSave.chungChiHanhNgheY, _cons, _trans);
                    if (chungchihanhngheYid == -1)
                    {
                        _trans.Rollback();
                        return -1;
                    }
                    if (chungChiHanhNgheYSave.lstChungChiHanhNgheY_TDCM?.Any() == true)
                    {
                        foreach (var tdcm in chungChiHanhNgheYSave.lstChungChiHanhNgheY_TDCM)
                            tdcm.ChungChiHanhNgheYID = chungchihanhngheYid;
                        var instdcm =
                            _chungChiHanhNgheY_TDCMRepository.NganhY_ChungChiHanhNgheY_TDCM_Ins(
                                chungChiHanhNgheYSave.lstChungChiHanhNgheY_TDCM, _cons, _trans);
                        if (!instdcm)
                        {
                            _trans.Rollback();
                            return -1;
                        }
                    }
                    if (chungChiHanhNgheYSave.lstChungChiHanhNgheY_QTTH?.Any() == true)
                    {
                        foreach (var qtth in chungChiHanhNgheYSave.lstChungChiHanhNgheY_QTTH)
                            qtth.ChungChiHanhNgheYID = chungchihanhngheYid;
                        var insqtth =
                            _chungChiHanhNgheY_QTTHRepository.NganhY_ChungChiHanhNgheY_QTTH_Ins(
                                chungChiHanhNgheYSave.lstChungChiHanhNgheY_QTTH, _cons, _trans);
                        if (!insqtth)
                        {
                            _trans.Rollback();
                            return -1;
                        }
                    }
                }
                else
                {
                    var updcchn =
                        _chungChiHanhNgheYRepository.NganhY_ChungChiHanhNgheY_UpdByCCHNYID(
                            chungChiHanhNgheYSave.chungChiHanhNgheY, _cons, _trans);
                    if (!updcchn)
                    {
                        _trans.Rollback();
                        return -1;
                    }
                    var deltdcm =
                        _chungChiHanhNgheY_TDCMRepository.NganhY_ChungChiHanhNgheY_TDCM_DelByCCHNYID(
                            chungchihanhngheYid, _cons, _trans);
                    if (!deltdcm)
                    {
                        _trans.Rollback();
                        return -1;
                    }
                    var delqtth =
                        _chungChiHanhNgheY_QTTHRepository.NganhY_ChungChiHanhNgheY_QTTH_DelByCCHNYID(
                            chungchihanhngheYid, _cons, _trans);
                    if (!delqtth)
                    {
                        _trans.Rollback();
                        return -1;
                    }
                    var instdcm =
                        _chungChiHanhNgheY_TDCMRepository.NganhY_ChungChiHanhNgheY_TDCM_Ins(
                            chungChiHanhNgheYSave.lstChungChiHanhNgheY_TDCM, _cons, _trans);
                    if (!instdcm)
                    {
                        _trans.Rollback();
                        return -1;
                    }
                    var insqtth =
                        _chungChiHanhNgheY_QTTHRepository.NganhY_ChungChiHanhNgheY_QTTH_Ins(
                            chungChiHanhNgheYSave.lstChungChiHanhNgheY_QTTH, _cons, _trans);
                    if (!insqtth)
                    {
                        _trans.Rollback();
                        return -1;
                    }
                }
                _trans.Commit();
                return chungchihanhngheYid;
            }
            catch (Exception ex)
            {
                _trans.Rollback();
                Logger.Error(ex.Message);
                return -1;
            }
        }

        public bool NganhY_ChungChiHanhNgheY_UpdDaCap(List<long> HoSoIDs)
        {
            try
            {
                _cons = new SqlConnection(NganhYConn);
                _cons.Open();
                _trans = _cons.BeginTransaction();

                foreach (var HoSoID in HoSoIDs)
                {
                    var updCCDaCap =
                        _chungChiHanhNgheYRepository.NganhY_ChungChiHanhNgheY_UpdDaCap(HoSoID, _cons, _trans);
                    if (!updCCDaCap)
                    {
                        _trans.Rollback();
                        return false;
                    }
                }

                _trans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                _trans.Rollback();
                return false;
            }
        }

        public bool NganhY_ChungChiHanhNgheY_DelByHoSoID(long HoSoID, long ChungChiHanhNgheYID)
        {
            try
            {
                _cons = new SqlConnection(NganhYConn);
                _cons.Open();
                _trans = _cons.BeginTransaction();

                var delQTTH =
                    _chungChiHanhNgheY_QTTHRepository.NganhY_ChungChiHanhNgheY_QTTH_DelByCCHNYID(ChungChiHanhNgheYID,
                        _cons, _trans);
                if (!delQTTH)
                {
                    _trans.Rollback();
                    return false;
                }

                var delTDCM =
                    _chungChiHanhNgheY_TDCMRepository.NganhY_ChungChiHanhNgheY_TDCM_DelByCCHNYID(ChungChiHanhNgheYID,
                        _cons, _trans);
                if (!delTDCM)
                {
                    _trans.Rollback();
                    return false;
                }

                var delCCHNY = _chungChiHanhNgheYRepository.NganhY_ChungChiHanhNgheY_DelByHoSoID(HoSoID, _cons, _trans);
                if (!delCCHNY)
                {
                    _trans.Rollback();
                    return false;
                }

                _trans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                _trans.Rollback();
                Logger.Error(ex.Message);
                return false;
            }
        }

        #endregion

        #region Cấp lại ChungChiY

        public long NganhY_ChungChiHanhNgheY_CapLai_Save(ChungChiHanhNgheYCapLaiSave chungChiHanhNgheYCapLaiSave)
        {

            try
            {
                _cons = new SqlConnection(NganhYConn);
                _cons.Open();
                _trans = _cons.BeginTransaction();
                if (chungChiHanhNgheYCapLaiSave?.chungChiHanhNgheY_caplai == null) return -1;
                chungChiHanhNgheYCapLaiSave.chungChiHanhNgheY_caplaict = chungChiHanhNgheYCapLaiSave.chungChiHanhNgheY_caplaict ?? new ChungChiHanhNgheY_CapLaiCT();
                var capLaiId = chungChiHanhNgheYCapLaiSave.chungChiHanhNgheY_caplai.CapLaiID;
                if (capLaiId == 0)
                {
                    capLaiId = _chungChiHanhNgheY_CapLaiRepository.NganhY_ChungChiHanhNgheY_CapLai_Ins(
                        chungChiHanhNgheYCapLaiSave.chungChiHanhNgheY_caplai, _cons, _trans);
                    if (capLaiId == -1)
                    {
                        _trans.Rollback();
                        return -1;
                    }
                    chungChiHanhNgheYCapLaiSave.chungChiHanhNgheY_caplaict.CapLaiID = capLaiId;
                    var noidungtruoc = GenObject2XML(chungChiHanhNgheYCapLaiSave.noidungtruoc);
                    var noidungsau = GenObject2XML(chungChiHanhNgheYCapLaiSave.noidungsau);
                    chungChiHanhNgheYCapLaiSave.chungChiHanhNgheY_caplaict.NoiDungTruoc = noidungtruoc;
                    chungChiHanhNgheYCapLaiSave.chungChiHanhNgheY_caplaict.NoiDungSau = noidungsau;
                    var insCapLaiCt =
                        _chungChiHanhNgheY_CapLaiCTRepository.NganhY_ChungChiHanhNgheY_CapLaiCT_Ins(
                            chungChiHanhNgheYCapLaiSave.chungChiHanhNgheY_caplaict, _cons, _trans);
                    if (!insCapLaiCt)
                    {
                        _trans.Rollback();
                        return -1;
                    }
                }
                else
                {
                    var updcaplai =
                        _chungChiHanhNgheY_CapLaiRepository.NganhY_ChungChiHanhNgheY_CapLai_Upd(
                            chungChiHanhNgheYCapLaiSave.chungChiHanhNgheY_caplai, _cons, _trans);
                    if (!updcaplai)
                    {
                        _trans.Rollback();
                        return -1;
                    }

                    var noidungsau = GenObject2XML(chungChiHanhNgheYCapLaiSave.noidungsau);
                    chungChiHanhNgheYCapLaiSave.chungChiHanhNgheY_caplaict.NoiDungSau = noidungsau;
                    chungChiHanhNgheYCapLaiSave.chungChiHanhNgheY_caplaict.CapLaiID = capLaiId;
                    var updcaplaict =
                        _chungChiHanhNgheY_CapLaiCTRepository.NganhY_ChungChiHanhNgheY_CapLaiCT_Upd(
                            chungChiHanhNgheYCapLaiSave.chungChiHanhNgheY_caplaict, _cons, _trans);
                    if (!updcaplaict)
                    {
                        _trans.Rollback();
                        return -1;
                    }
                }
                _trans.Commit();
                return capLaiId;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                _trans.Rollback();
                return -1;
            }
        }

        public bool NganhY_ChungChiHanhNgheY_CapLai_UpdDaCap(List<long> HoSoIDs)
        {
            try
            {
                _cons = new SqlConnection(NganhYConn);
                _cons.Open();
                _trans = _cons.BeginTransaction();

                foreach (var HoSoID in HoSoIDs)
                {
                    var updCapLaiDaCap =
                        _chungChiHanhNgheY_CapLaiRepository.NganhY_ChungChiHanhNgheY_CapLai_UpdDaCap(HoSoID, _cons,
                            _trans);
                    if (!updCapLaiDaCap)
                    {
                        _trans.Rollback();
                        return false;
                    }

                    var capLai =
                        _chungChiHanhNgheY_CapLaiRepository.NganhY_ChungChiHanhNgheY_CapLai_GetByHoSoID(HoSoID, _cons,
                            _trans);
                    var chungChiHanhNgheYID = capLai.ChungChiHanhNgheYIDGoc.Value;
                    var capLaiID = capLai.CapLaiID;
                    var capLaiCT =
                        _chungChiHanhNgheY_CapLaiCTRepository.NganhY_ChungChiHanhNgheY_CapLaiCT_GetByCapLaiID(capLaiID,
                            _cons, _trans);
                    var noidungcuoicung = capLaiCT.NoiDungSau;

                    var ObjCapLai = GenXML2Object(noidungcuoicung);
                    ObjCapLai.chungChiHanhNgheY.ChungChiHanhNgheYID = chungChiHanhNgheYID;
                    ObjCapLai.chungChiHanhNgheY.TrangThaiGiayPhepID = 2;
                    ObjCapLai.chungChiHanhNgheY.HoSoID = HoSoID;
                    foreach (var tdcm in ObjCapLai.lstChungChiHanhNgheY_TDCM)
                        tdcm.ChungChiHanhNgheYID = chungChiHanhNgheYID;
                    foreach (var qtth in ObjCapLai.lstChungChiHanhNgheY_QTTH)
                        qtth.ChungChiHanhNgheYID = chungChiHanhNgheYID;

                    var updcchn =
                        _chungChiHanhNgheYRepository.NganhY_ChungChiHanhNgheY_UpdByCCHNYID(ObjCapLai.chungChiHanhNgheY,
                            _cons, _trans);
                    if (!updcchn)
                    {
                        _trans.Rollback();
                        return false;
                    }
                    var deltdcm =
                        _chungChiHanhNgheY_TDCMRepository.NganhY_ChungChiHanhNgheY_TDCM_DelByCCHNYID(
                            chungChiHanhNgheYID, _cons, _trans);
                    if (!deltdcm)
                    {
                        _trans.Rollback();
                        return false;
                    }
                    var delqtth =
                        _chungChiHanhNgheY_QTTHRepository.NganhY_ChungChiHanhNgheY_QTTH_DelByCCHNYID(
                            chungChiHanhNgheYID, _cons, _trans);
                    if (!delqtth)
                    {
                        _trans.Rollback();
                        return false;
                    }

                    var instdcm =
                        _chungChiHanhNgheY_TDCMRepository.NganhY_ChungChiHanhNgheY_TDCM_Ins(
                            ObjCapLai.lstChungChiHanhNgheY_TDCM, _cons, _trans);
                    if (!instdcm)
                    {
                        _trans.Rollback();
                        return false;
                    }
                    var insqtth =
                        _chungChiHanhNgheY_QTTHRepository.NganhY_ChungChiHanhNgheY_QTTH_Ins(
                            ObjCapLai.lstChungChiHanhNgheY_QTTH, _cons, _trans);
                    if (!insqtth)
                    {
                        _trans.Rollback();
                        return false;
                    }
                }

                _trans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                _trans.Rollback();
                return false;
            }
        }

        public bool NganhY_ChungChiHanhNgheY_CapLai_DelByHoSoID(long HoSoID, long CapLaiID)
        {
            try
            {
                _cons = new SqlConnection(NganhYConn);
                _cons.Open();
                _trans = _cons.BeginTransaction();

                var delCapLaiCT =
                    _chungChiHanhNgheY_CapLaiCTRepository.NganhY_ChungChiHanhNgheY_CapLaiCT_DelByCapLaiID(CapLaiID,
                        _cons, _trans);
                if (!delCapLaiCT)
                {
                    _trans.Rollback();
                    return false;
                }

                var delCapLai =
                    _chungChiHanhNgheY_CapLaiRepository
                        .NganhY_ChungChiHanhNgheY_CapLai_DelByHoSoID(HoSoID, _cons, _trans);
                if (!delCapLai)
                {
                    _trans.Rollback();
                    return false;
                }

                _trans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                _trans.Rollback();
                return false;
            }
        }

        #endregion

        #region Dieu Chinh ChungChiY

        public long NganhY_ChungChiHanhNgheY_DieuChinh_Save(
            ChungChiHanhNgheYDieuChinhSave chungChiHanhNgheYDieuChinhSave)
        {
            try
            {
                if (chungChiHanhNgheYDieuChinhSave?.chungChiHanhNgheY_dieuchinh == null) return -1;
                _cons = new SqlConnection(NganhYConn);
                _cons.Open();
                _trans = _cons.BeginTransaction();
                chungChiHanhNgheYDieuChinhSave.chungChiHanhNgheY_dieuchinhct = chungChiHanhNgheYDieuChinhSave.chungChiHanhNgheY_dieuchinhct ?? new ChungChiHanhNgheY_DieuChinhCT();
                var dieuChinhId = chungChiHanhNgheYDieuChinhSave.chungChiHanhNgheY_dieuchinh.DieuChinhID;
                if (dieuChinhId == 0)
                {
                    dieuChinhId =
                        _chungChiHanhNgheY_DieuChinhRepository.NganhY_ChungChiHanhNgheY_DieuChinh_Ins(
                            chungChiHanhNgheYDieuChinhSave.chungChiHanhNgheY_dieuchinh, _cons, _trans);
                    if (dieuChinhId == -1)
                    {
                        _trans.Rollback();
                        return -1;
                    }
                    chungChiHanhNgheYDieuChinhSave.chungChiHanhNgheY_dieuchinhct.DieuChinhID = dieuChinhId;
                    var noidungtruoc = GenObject2XML(chungChiHanhNgheYDieuChinhSave.noidungtruoc);
                    var noidungsau = GenObject2XML(chungChiHanhNgheYDieuChinhSave.noidungsau);
                    chungChiHanhNgheYDieuChinhSave.chungChiHanhNgheY_dieuchinhct.NoiDungTruoc = noidungtruoc;
                    chungChiHanhNgheYDieuChinhSave.chungChiHanhNgheY_dieuchinhct.NoiDungSau = noidungsau;
                    var insDieuChinhCt =
                        _chungChiHanhNgheY_DieuChinhCTRepository.NganhY_ChungChiHanhNgheY_DieuChinhCT_Ins(
                            chungChiHanhNgheYDieuChinhSave.chungChiHanhNgheY_dieuchinhct, _cons, _trans);
                    if (!insDieuChinhCt)
                    {
                        _trans.Rollback();
                        return -1;
                    }
                }
                else
                {
                    var upddieuchinh =
                        _chungChiHanhNgheY_DieuChinhRepository.NganhY_ChungChiHanhNgheY_DieuChinh_Upd(
                            chungChiHanhNgheYDieuChinhSave.chungChiHanhNgheY_dieuchinh, _cons, _trans);
                    if (!upddieuchinh)
                    {
                        _trans.Rollback();
                        return -1;
                    }

                    var noidungsau = GenObject2XML(chungChiHanhNgheYDieuChinhSave.noidungsau);
                    chungChiHanhNgheYDieuChinhSave.chungChiHanhNgheY_dieuchinhct.NoiDungSau = noidungsau;
                    chungChiHanhNgheYDieuChinhSave.chungChiHanhNgheY_dieuchinhct.DieuChinhID = dieuChinhId;

                    var upddieuchinhct =
                        _chungChiHanhNgheY_DieuChinhCTRepository.NganhY_ChungChiHanhNgheY_DieuChinhCT_Upd(
                            chungChiHanhNgheYDieuChinhSave.chungChiHanhNgheY_dieuchinhct, _cons, _trans);
                    if (!upddieuchinhct)
                    {
                        _trans.Rollback();
                        return -1;
                    }
                }
                _trans.Commit();
                return dieuChinhId;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                _trans.Rollback();
                return -1;
            }
        }

        public bool NganhY_ChungChiHanhNgheY_DieuChinh_UpdDaDieuChinh(List<long> HoSoIDs)
        {
            try
            {
                _cons = new SqlConnection(NganhYConn);
                _cons.Open();
                _trans = _cons.BeginTransaction();

                foreach (var HoSoID in HoSoIDs)
                {
                    var updDaDieuChinh =
                        _chungChiHanhNgheY_DieuChinhRepository.NganhY_ChungChiHanhNgheY_DieuChinh_UpdDaDieuChinh(HoSoID,
                            _cons, _trans);
                    if (!updDaDieuChinh)
                    {
                        _trans.Rollback();
                        return false;
                    }

                    var dieuchinh =
                        _chungChiHanhNgheY_DieuChinhRepository.NganhY_ChungChiHanhNgheY_DieuChinh_GetByHoSoID(HoSoID,
                            _cons, _trans);
                    var chungChiHanhNgheYID = dieuchinh.ChungChiHanhNgheYIDGoc.Value;
                    var dieuChinhID = dieuchinh.DieuChinhID;
                    var dieuChinhCT =
                        _chungChiHanhNgheY_DieuChinhCTRepository.NganhY_ChungChiHanhNgheY_DieuChinhCT_GetByDieuChinhID(
                            dieuChinhID, _cons, _trans);
                    var noidungcuoicung = dieuChinhCT.NoiDungSau;

                    var ObjDieuChinh = GenXML2Object(noidungcuoicung);
                    ObjDieuChinh.chungChiHanhNgheY.ChungChiHanhNgheYID = chungChiHanhNgheYID;
                    ObjDieuChinh.chungChiHanhNgheY.TrangThaiGiayPhepID = 2;
                    ObjDieuChinh.chungChiHanhNgheY.HoSoID = HoSoID;
                    foreach (var tdcm in ObjDieuChinh.lstChungChiHanhNgheY_TDCM)
                        tdcm.ChungChiHanhNgheYID = chungChiHanhNgheYID;
                    foreach (var qtth in ObjDieuChinh.lstChungChiHanhNgheY_QTTH)
                        qtth.ChungChiHanhNgheYID = chungChiHanhNgheYID;

                    var updcchn =
                        _chungChiHanhNgheYRepository.NganhY_ChungChiHanhNgheY_UpdByCCHNYID(
                            ObjDieuChinh.chungChiHanhNgheY, _cons, _trans);
                    if (!updcchn)
                    {
                        _trans.Rollback();
                        return false;
                    }
                    var deltdcm =
                        _chungChiHanhNgheY_TDCMRepository.NganhY_ChungChiHanhNgheY_TDCM_DelByCCHNYID(
                            chungChiHanhNgheYID, _cons, _trans);
                    if (!deltdcm)
                    {
                        _trans.Rollback();
                        return false;
                    }
                    var delqtth =
                        _chungChiHanhNgheY_QTTHRepository.NganhY_ChungChiHanhNgheY_QTTH_DelByCCHNYID(
                            chungChiHanhNgheYID, _cons, _trans);
                    if (!delqtth)
                    {
                        _trans.Rollback();
                        return false;
                    }

                    var instdcm =
                        _chungChiHanhNgheY_TDCMRepository.NganhY_ChungChiHanhNgheY_TDCM_Ins(
                            ObjDieuChinh.lstChungChiHanhNgheY_TDCM, _cons, _trans);
                    if (!instdcm)
                    {
                        _trans.Rollback();
                        return false;
                    }
                    var insqtth =
                        _chungChiHanhNgheY_QTTHRepository.NganhY_ChungChiHanhNgheY_QTTH_Ins(
                            ObjDieuChinh.lstChungChiHanhNgheY_QTTH, _cons, _trans);
                    if (!insqtth)
                    {
                        _trans.Rollback();
                        return false;
                    }
                }

                _trans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                _trans.Rollback();
                return false;
            }
        }

        public bool NganhY_ChungChiHanhNgheY_DieuChinh_DelByHoSoID(long HoSoID, long DieuChinhID)
        {
            try
            {
                _cons = new SqlConnection(NganhYConn);
                _cons.Open();
                _trans = _cons.BeginTransaction();

                var delDieuChinhCT =
                    _chungChiHanhNgheY_DieuChinhCTRepository.NganhY_ChungChiHanhNgheY_DieuChinhCT_DelDieuChinhID(
                        DieuChinhID, _cons, _trans);
                if (!delDieuChinhCT)
                {
                    _trans.Rollback();
                    return false;
                }

                var delDieuChinh =
                    _chungChiHanhNgheY_DieuChinhRepository.NganhY_ChungChiHanhNgheY_DieuChinh_DelByHoSoID(HoSoID, _cons,
                        _trans);
                if (!delDieuChinh)
                {
                    _trans.Rollback();
                    return false;
                }

                _trans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                _trans.Rollback();
                return false;
            }
        }

        #endregion

        #region Thu hồi

        public long NganhY_ChungChiHanhNgheY_ThuHoi_Save(ChungChiHanhNgheY_ThuHoi chungChiHanhNgheYThuHoiSave)
        {
            long thuHoiID = 0;
            try
            {
                var flagupd = true; //1: insert - 0: update
                _cons = new SqlConnection(NganhYConn);
                _cons.Open();
                _trans = _cons.BeginTransaction();

                if (chungChiHanhNgheYThuHoiSave.ThuHoiID != 0)
                {
                    flagupd = false;
                    thuHoiID = chungChiHanhNgheYThuHoiSave.ThuHoiID;
                }
                else
                {
                    flagupd = true;
                }

                if (flagupd)
                {
                    thuHoiID = _chungChiHanhNgheY_ThuHoiRepository.NganhY_ChungChiHanhNgheY_ThuHoi_Ins(
                        chungChiHanhNgheYThuHoiSave, _cons, _trans);
                    if (thuHoiID == -1)
                    {
                        _trans.Rollback();
                        return -1;
                    }
                    var updTrangThaiCCHNY =
                        _chungChiHanhNgheYRepository.NganhY_ChungChiHanhNgheY_UpdDaCapByCCHNYID(
                            chungChiHanhNgheYThuHoiSave.ChungChiHanhNgheYID.Value, 3, _cons, _trans);
                    if (!updTrangThaiCCHNY)
                    {
                        _trans.Rollback();
                        return -1;
                    }
                }
                else
                {
                    var updThuHoi =
                        _chungChiHanhNgheY_ThuHoiRepository.NganhY_ChungChiHanhNgheY_ThuHoi_Upd(
                            chungChiHanhNgheYThuHoiSave, _cons, _trans);
                    if (!updThuHoi)
                    {
                        _trans.Rollback();
                        return -1;
                    }
                }
                _trans.Commit();
                return thuHoiID;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                _trans.Rollback();
                return -1;
            }
        }

        public bool NganhY_ChungChiHanhNgheY_ThuHoi_UpdXoaThuHoi(long ChungChiHanhNgheYID)
        {
            try
            {
                _cons = new SqlConnection(NganhYConn);
                _cons.Open();
                _trans = _cons.BeginTransaction();

                //Upd hủy thu hồi
                var updHuyThuHoi =
                    _chungChiHanhNgheY_ThuHoiRepository.NganhY_ChungChiHanhNgheY_ThuHoi_HuyThuHoi(ChungChiHanhNgheYID,
                        _cons, _trans);
                if (!updHuyThuHoi)
                {
                    _trans.Rollback();
                    return false;
                }

                //Upd hoạt động
                var updHoatDongCCHNY =
                    _chungChiHanhNgheYRepository.NganhY_ChungChiHanhNgheY_UpdDaCapByCCHNYID(ChungChiHanhNgheYID, 2,
                        _cons, _trans);
                if (!updHoatDongCCHNY)
                {
                    _trans.Rollback();
                    return false;
                }

                _trans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                _trans.Rollback();
                return false;
            }
        }

        #endregion

        #region Rút chứng chỉ

        public long NganhY_ChungChiHanhNgheY_RutChungChi_Save(
            ChungChiHanhNgheY_RutChungChi chungChiHanhNgheYRutChungChiSave)
        {
            long rutChungChiID = 0;
            try
            {
                var flagupd = true; //1: insert - 0: update
                _cons = new SqlConnection(NganhYConn);
                _cons.Open();
                _trans = _cons.BeginTransaction();

                if (chungChiHanhNgheYRutChungChiSave.RutChungChiID != 0)
                {
                    flagupd = false;
                    rutChungChiID = chungChiHanhNgheYRutChungChiSave.RutChungChiID;
                }
                else
                {
                    flagupd = true;
                }

                if (flagupd)
                {
                    rutChungChiID =
                        _chungChiHanhNgheY_RutChungChiRepository.NganhY_ChungChiHanhNgheY_RutChungChi_Ins(
                            chungChiHanhNgheYRutChungChiSave, _cons, _trans);
                    if (rutChungChiID == -1)
                    {
                        _trans.Rollback();
                        return -1;
                    }
                    var updTrangThaiCCHNY =
                        _chungChiHanhNgheYRepository.NganhY_ChungChiHanhNgheY_UpdDaCapByCCHNYID(
                            chungChiHanhNgheYRutChungChiSave.ChungChiHanhNgheYID.Value, 4, _cons, _trans);
                    if (!updTrangThaiCCHNY)
                    {
                        _trans.Rollback();
                        return -1;
                    }
                }
                else
                {
                    var updRutChungChi =
                        _chungChiHanhNgheY_RutChungChiRepository.NganhY_ChungChiHanhNgheY_RutChungChi_Upd(
                            chungChiHanhNgheYRutChungChiSave, _cons, _trans);
                    if (!updRutChungChi)
                    {
                        _trans.Rollback();
                        return -1;
                    }
                }
                _trans.Commit();
                return rutChungChiID;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                _trans.Rollback();
                return -1;
            }
        }

        public bool NganhY_ChungChiHanhNgheY_RutChungChi_UpdXoaRut(long ChungChiHanhNgheYID)
        {
            try
            {
                _cons = new SqlConnection(NganhYConn);
                _cons.Open();
                _trans = _cons.BeginTransaction();

                //Upd hủy rút chứng chỉ
                var updHuyRut =
                    _chungChiHanhNgheY_RutChungChiRepository.NganhY_ChungChiHanhNgheY_RutChungChi_HuyRut(
                        ChungChiHanhNgheYID, _cons, _trans);
                if (!updHuyRut)
                {
                    _trans.Rollback();
                    return false;
                }

                //Upd lại trạng thái hoạt động của CCHHY
                var updHoatDongCCHNY =
                    _chungChiHanhNgheYRepository.NganhY_ChungChiHanhNgheY_UpdDaCapByCCHNYID(ChungChiHanhNgheYID, 2,
                        _cons, _trans);
                if (!updHoatDongCCHNY)
                {
                    _trans.Rollback();
                    return false;
                }

                _trans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                _trans.Rollback();
                return false;
            }
        }

        #endregion

        #region Đăng ký quảng cáo trang thiết bị

        public DangKyQCTrangThietBi NganhY_DangKyQCTrangThietBi_GetByHoSoID(long HoSoID)
        {
            return _dangKyQCTrangThietBiRepository.NganhY_DangKyQCTrangThietBi_GetByHoSoID(HoSoID);
        }

        public DangKyQCTrangThietBi NganhY_DangKyQCTrangThietBi_GetByID(long DangKyQCTrangThietBiID)
        {
            return _dangKyQCTrangThietBiRepository.NganhY_DangKyQCTrangThietBi_GetByID(DangKyQCTrangThietBiID);
        }

        public PagedData<DangKyQCTrangThietBiViewModel> NganhY_DangKyQCTrangThietBi_Search(string SoTiepNhan,
            string tuNgay, string denNgay
            , string DichVuQuangCao, string DonViDK_Ten, int pageIndex, int pageSize)
        {
            try
            {
                int totalItems;
                var datas = _dangKyQCTrangThietBiRepository.NganhY_DangKyQCTrangThietBi_Search(SoTiepNhan,
                    tuNgay.ToDateTimeNullable(), denNgay.ToDateTimeNullable(), DichVuQuangCao, DonViDK_Ten, pageIndex,
                    pageSize, out totalItems).ToList();

                return new PagedData<DangKyQCTrangThietBiViewModel>
                {
                    Data = datas,
                    PageIndex = pageIndex,
                    PageSize = pageSize,
                    TotalItems = totalItems
                };
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                throw;
            }

        }

        public long NganhY_DangKyQCTrangThietBi_Save(DangKyQCTrangThietBi modelSave)
        {

            try
            {
                if (modelSave == null) return -1;
                var id = modelSave.DangKyQCTrangThietBiID;
                _cons = new SqlConnection(NganhYConn);
                _cons.Open();
                _trans = _cons.BeginTransaction();
                if (id == 0)
                {
                    id =
                        _dangKyQCTrangThietBiRepository.NganhY_DangKyQCTrangThietBi_Ins(modelSave, _cons,
                            _trans);
                    if (id == -1)
                    {
                        _trans.Rollback();
                        return -1;
                    }
                }
                else
                {
                    var upddk =
                        _dangKyQCTrangThietBiRepository.NganhY_DangKyQCTrangThietBi_UpdByID(modelSave,
                            _cons, _trans);
                    if (!upddk)
                    {
                        _trans.Rollback();
                        return -1;
                    }
                }
                _trans.Commit();
                return id;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                _trans.Rollback();
                return -1;
            }
        }

        public bool NganhY_DangKyQCTrangThietBi_UpdDaCap(List<long> HoSoIDs)
        {
            try
            {
                _cons = new SqlConnection(NganhYConn);
                _cons.Open();
                _trans = _cons.BeginTransaction();

                foreach (var HoSoID in HoSoIDs)
                {
                    var updDKDaCap =
                        _dangKyQCTrangThietBiRepository.NganhY_DangKyQCTrangThietBi_UpdDaCap(HoSoID, _cons, _trans);
                    if (!updDKDaCap)
                    {
                        _trans.Rollback();
                        return false;
                    }
                }

                _trans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                _trans.Rollback();
                return false;
            }
        }

        public bool NganhY_DangKyQCTrangThietBi_DelByHoSoID(long HoSoID)
        {
            try
            {
                _cons = new SqlConnection(NganhYConn);
                _cons.Open();
                _trans = _cons.BeginTransaction();

                var delDK = _dangKyQCTrangThietBiRepository
                    .NganhY_DangKyQCTrangThietBi_DelByHoSoID(HoSoID, _cons, _trans);
                if (!delDK)
                {
                    _trans.Rollback();
                    return false;
                }

                _trans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                _trans.Rollback();
                return false;
            }
        }

        #endregion

        #region Cấp mới Giấy phép hoạt động CSKCB

        public GiayPhepHoatDongKCBSave NganhY_GiayPhepHoatDongKCB_GetByHoSoID(long HoSoID)
        {
            try
            {
                var objreturn = new GiayPhepHoatDongKCBSave();
                objreturn.giayPhepHoatDongKCB =
                    _giayPhepHoatDongKCBRepository.NganhY_GiayPhepHoatDongKCB_GetByHoSoID(HoSoID);
                objreturn.lstGiayPhepHoatDongKCB_DSNhanSu = _giayPhepHoatDongKCB_DSNhanSuRepository
                    .NganhY_GiayPhepHoatDongKCB_DSNhanSu_GetByGPID(objreturn.giayPhepHoatDongKCB.GiayPhepKhamChuaBenhID)
                    .ToList();

                return objreturn;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return null;
            }
        }

        public GiayPhepHoatDongKCBSave NganhY_GiayPhepHoatDongKCB_GetByID(long GiayPhepKhamChuaBenhID)
        {
            try
            {
                var objreturn = new GiayPhepHoatDongKCBSave();
                objreturn.giayPhepHoatDongKCB =
                    _giayPhepHoatDongKCBRepository.NganhY_GiayPhepHoatDongKCB_GetByID(GiayPhepKhamChuaBenhID);
                objreturn.lstGiayPhepHoatDongKCB_DSNhanSu = _giayPhepHoatDongKCB_DSNhanSuRepository
                    .NganhY_GiayPhepHoatDongKCB_DSNhanSu_GetByGPID(objreturn.giayPhepHoatDongKCB.GiayPhepKhamChuaBenhID)
                    .ToList();

                return objreturn;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return null;
            }
        }

        public GiayPhepHoatDongKCBSave NganhY_GiayPhepHoatDongKCB_GetBySoGiayPhep(string SoGiayPhep)
        {
            try
            {
                var objreturn = new GiayPhepHoatDongKCBSave();
                objreturn.giayPhepHoatDongKCB =
                    _giayPhepHoatDongKCBRepository.NganhY_GiayPhepHoatDongKCB_GetBySoGiayPhep(SoGiayPhep);
                objreturn.lstGiayPhepHoatDongKCB_DSNhanSu = _giayPhepHoatDongKCB_DSNhanSuRepository
                    .NganhY_GiayPhepHoatDongKCB_DSNhanSu_GetByGPID(objreturn.giayPhepHoatDongKCB.GiayPhepKhamChuaBenhID)
                    .ToList();

                return objreturn;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return null;
            }
        }

        public PagedData<GiayPhepHoatDongKCBViewModel> NganhY_GiayPhepHoatDongKCB_Search(string SoGiayPhep,
            string tuNgay, string denNgay
            , string CoSoDK_Ten, string CoSoDK_HuyenID, string CoSoDK_XaID, int pageIndex, int pageSize)
        {
            int totalItems;
            var datas = _giayPhepHoatDongKCBRepository.NganhY_GiayPhepHoatDongKCB_Search(SoGiayPhep,
                tuNgay.ToDateTimeNullable(), denNgay.ToDateTimeNullable(), CoSoDK_Ten, CoSoDK_HuyenID.ToLongNullable(),
                CoSoDK_XaID.ToLongNullable(),
                pageIndex, pageSize, out totalItems).ToList();

            return new PagedData<GiayPhepHoatDongKCBViewModel>
            {
                Data = datas,
                PageIndex = pageIndex,
                PageSize = pageSize,
                TotalItems = totalItems
            };
        }

        public long NganhY_GiayPhepHoatDongKCB_Save(GiayPhepHoatDongKCBSave giayPhepHoatDongKCBSave)
        {
            long giayPhepKhamChuaBenhID = 0;
            try
            {
                var flagupd = true; //1: insert - 0: update
                _cons = new SqlConnection(NganhYConn);
                _cons.Open();
                _trans = _cons.BeginTransaction();

                if (giayPhepHoatDongKCBSave.giayPhepHoatDongKCB.GiayPhepKhamChuaBenhID != 0)
                {
                    flagupd = false;
                    giayPhepKhamChuaBenhID = giayPhepHoatDongKCBSave.giayPhepHoatDongKCB.GiayPhepKhamChuaBenhID;
                }
                else
                {
                    flagupd = true;
                }

                if (flagupd)
                {
                    giayPhepKhamChuaBenhID =
                        _giayPhepHoatDongKCBRepository.NganhY_GiayPhepHoatDongKCB_Ins(
                            giayPhepHoatDongKCBSave.giayPhepHoatDongKCB, _cons, _trans);
                    if (giayPhepKhamChuaBenhID == -1)
                    {
                        _trans.Rollback();
                        return -1;
                    }
                    foreach (var dsns in giayPhepHoatDongKCBSave.lstGiayPhepHoatDongKCB_DSNhanSu)
                        dsns.GiayPhepKhamChuaBenhID = giayPhepKhamChuaBenhID;
                    var insdsns =
                        _giayPhepHoatDongKCB_DSNhanSuRepository.NganhY_GiayPhepHoatDongKCB_DSNhanSu_Ins(
                            giayPhepHoatDongKCBSave.lstGiayPhepHoatDongKCB_DSNhanSu, _cons, _trans);
                    if (!insdsns)
                    {
                        _trans.Rollback();
                        return -1;
                    }
                }
                else
                {
                    var updgpkcb =
                        _giayPhepHoatDongKCBRepository.NganhY_GiayPhepHoatDongKCB_UpdByID(
                            giayPhepHoatDongKCBSave.giayPhepHoatDongKCB, _cons, _trans);
                    if (!updgpkcb)
                    {
                        _trans.Rollback();
                        return -1;
                    }
                    var deldsns =
                        _giayPhepHoatDongKCB_DSNhanSuRepository.NganhY_GiayPhepHoatDongKCB_DSNhanSu_DelByGPID(
                            giayPhepKhamChuaBenhID, _cons, _trans);
                    if (!deldsns)
                    {
                        _trans.Rollback();
                        return -1;
                    }

                    var insdsns =
                        _giayPhepHoatDongKCB_DSNhanSuRepository.NganhY_GiayPhepHoatDongKCB_DSNhanSu_Ins(
                            giayPhepHoatDongKCBSave.lstGiayPhepHoatDongKCB_DSNhanSu, _cons, _trans);
                    if (!insdsns)
                    {
                        _trans.Rollback();
                        return -1;
                    }
                }
                _trans.Commit();
                return giayPhepKhamChuaBenhID;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                _trans.Rollback();
                return -1;
            }
        }

        public bool NganhY_GiayPhepHoatDongKCB_UpdDaCap(List<long> HoSoIDs)
        {
            try
            {
                _cons = new SqlConnection(NganhYConn);
                _cons.Open();
                _trans = _cons.BeginTransaction();

                foreach (var HoSoID in HoSoIDs)
                {
                    var updGPDaCap =
                        _giayPhepHoatDongKCBRepository.NganhY_GiayPhepHoatDongKCB_UpdDaCap(HoSoID, _cons, _trans);
                    if (!updGPDaCap)
                    {
                        _trans.Rollback();
                        return false;
                    }
                }

                _trans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                _trans.Rollback();
                return false;
            }
        }

        public bool NganhY_GiayPhepHoatDongKCB_DelByHoSoID(long HoSoID, long GiayPhepKhamChuaBenhID)
        {
            try
            {
                _cons = new SqlConnection(NganhYConn);
                _cons.Open();
                _trans = _cons.BeginTransaction();

                var delGPKCB =
                    _giayPhepHoatDongKCBRepository.NganhY_GiayPhepHoatDongKCB_DelByHoSoID(HoSoID,
                        GiayPhepKhamChuaBenhID, _cons, _trans);
                if (!delGPKCB)
                {
                    _trans.Rollback();
                    return false;
                }

                _trans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                _trans.Rollback();
                return false;
            }
        }

        #endregion

        #region Cấp lại Giấy phép hoạt động CSKCB

        public GiayPhepHoatDongKCBCapLaiSave NganhY_GiayPhepHoatDongKCB_CapLai_GetByHoSoID(long HoSoID)
        {
            try
            {
                var capLai =
                    _giayPhepHoatDongKCB_CapLaiRepository.NganhY_GiayPhepHoatDongKCB_CapLai_GetByHoSoID(HoSoID);
                var capLaiID = capLai.CapLaiID;

                var capLaiCT =
                    _giayPhepHoatDongKCB_CapLaiCTRepository.NganhY_GiayPhepHoatDongKCB_CapLaiCT_GetByCapLaiID(capLaiID);
                var noidungcuoitruoc = capLaiCT.NoiDungTruoc;
                var noidungcuoicung = capLaiCT.NoiDungSau;

                var objReturn = new GiayPhepHoatDongKCBCapLaiSave();
                objReturn.giayPhepHoatDongKCB_caplai = capLai;
                objReturn.giayPhepHoatDongKCB_caplaict = capLaiCT;
                objReturn.noidungtruoc = GenXML2Object_GPKCB(noidungcuoitruoc);
                objReturn.noidungsau = GenXML2Object_GPKCB(noidungcuoicung);

                return objReturn;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                _trans.Rollback();
                return null;
            }
        }

        public long NganhY_GiayPhepHoatDongKCB_CapLai_Save(GiayPhepHoatDongKCBCapLaiSave giayPhepHoatDongKCBCapLaiSave)
        {
            long capLaiID = 0;
            try
            {
                var flagupd = true; //1: insert - 0: update
                _cons = new SqlConnection(NganhYConn);
                _cons.Open();
                _trans = _cons.BeginTransaction();

                if (giayPhepHoatDongKCBCapLaiSave.giayPhepHoatDongKCB_caplai.CapLaiID != 0)
                {
                    flagupd = false;
                    capLaiID = giayPhepHoatDongKCBCapLaiSave.giayPhepHoatDongKCB_caplai.CapLaiID;
                }
                else
                {
                    flagupd = true;
                }

                if (flagupd)
                {
                    capLaiID = _giayPhepHoatDongKCB_CapLaiRepository.NganhY_GiayPhepHoatDongKCB_CapLai_Ins(
                        giayPhepHoatDongKCBCapLaiSave.giayPhepHoatDongKCB_caplai, _cons, _trans);
                    if (capLaiID == -1)
                    {
                        _trans.Rollback();
                        return -1;
                    }
                    giayPhepHoatDongKCBCapLaiSave.giayPhepHoatDongKCB_caplaict.CapLaiID = capLaiID;

                    var noidungtruoc = GenObject2XML_GPKCB(giayPhepHoatDongKCBCapLaiSave.noidungtruoc);
                    var noidungsau = GenObject2XML_GPKCB(giayPhepHoatDongKCBCapLaiSave.noidungsau);
                    giayPhepHoatDongKCBCapLaiSave.giayPhepHoatDongKCB_caplaict.NoiDungTruoc = noidungtruoc;
                    giayPhepHoatDongKCBCapLaiSave.giayPhepHoatDongKCB_caplaict.NoiDungSau = noidungsau;

                    var insCapLaiCT =
                        _giayPhepHoatDongKCB_CapLaiCTRepository.NganhY_GiayPhepHoatDongKCB_CapLaiCT_Ins(
                            giayPhepHoatDongKCBCapLaiSave.giayPhepHoatDongKCB_caplaict, _cons, _trans);
                    if (!insCapLaiCT)
                    {
                        _trans.Rollback();
                        return -1;
                    }
                }
                else
                {
                    var updcaplai =
                        _giayPhepHoatDongKCB_CapLaiRepository.NganhY_GiayPhepHoatDongKCB_CapLai_Upd(
                            giayPhepHoatDongKCBCapLaiSave.giayPhepHoatDongKCB_caplai, _cons, _trans);
                    if (!updcaplai)
                    {
                        _trans.Rollback();
                        return -1;
                    }

                    var noidungsau = GenObject2XML_GPKCB(giayPhepHoatDongKCBCapLaiSave.noidungsau);
                    giayPhepHoatDongKCBCapLaiSave.giayPhepHoatDongKCB_caplaict.NoiDungSau = noidungsau;
                    var updcaplaict =
                        _giayPhepHoatDongKCB_CapLaiCTRepository.NganhY_GiayPhepHoatDongKCB_CapLaiCT_Upd(
                            giayPhepHoatDongKCBCapLaiSave.giayPhepHoatDongKCB_caplaict, _cons, _trans);
                    if (!updcaplaict)
                    {
                        _trans.Rollback();
                        return -1;
                    }
                }
                _trans.Commit();
                return capLaiID;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                _trans.Rollback();
                return -1;
            }
        }

        public bool NganhY_GiayPhepHoatDongKCB_CapLai_UpdDaCap(List<long> HoSoIDs)
        {
            try
            {
                _cons = new SqlConnection(NganhYConn);
                _cons.Open();
                _trans = _cons.BeginTransaction();

                foreach (var HoSoID in HoSoIDs)
                {
                    var updCapLaiDaCap =
                        _giayPhepHoatDongKCB_CapLaiRepository.NganhY_GiayPhepHoatDongKCB_CapLai_UpdDaCap(HoSoID, _cons,
                            _trans);
                    if (!updCapLaiDaCap)
                    {
                        _trans.Rollback();
                        return false;
                    }

                    var capLai =
                        _giayPhepHoatDongKCB_CapLaiRepository.NganhY_GiayPhepHoatDongKCB_CapLai_GetByHoSoID(HoSoID,
                            _cons, _trans);
                    var giayPhepKhamChuaBenhID = capLai.GiayPhepKhamChuaBenhIDGoc.Value;
                    var capLaiID = capLai.CapLaiID;
                    var capLaiCT =
                        _giayPhepHoatDongKCB_CapLaiCTRepository.NganhY_GiayPhepHoatDongKCB_CapLaiCT_GetByCapLaiID(
                            capLaiID, _cons, _trans);
                    var noidungcuoicung = capLaiCT.NoiDungSau;

                    var ObjCapLai = GenXML2Object_GPKCB(noidungcuoicung);
                    ObjCapLai.giayPhepHoatDongKCB.GiayPhepKhamChuaBenhID = giayPhepKhamChuaBenhID;
                    ObjCapLai.giayPhepHoatDongKCB.TrangThaiGiayPhepID = 2;
                    ObjCapLai.giayPhepHoatDongKCB.HoSoID = HoSoID;

                    foreach (var dsns in ObjCapLai.lstGiayPhepHoatDongKCB_DSNhanSu)
                        dsns.ChungChiHanhNgheYID = giayPhepKhamChuaBenhID;

                    var updgphd =
                        _giayPhepHoatDongKCBRepository.NganhY_GiayPhepHoatDongKCB_UpdByID(ObjCapLai.giayPhepHoatDongKCB,
                            _cons, _trans);
                    if (!updgphd)
                    {
                        _trans.Rollback();
                        return false;
                    }

                    var deldsns =
                        _giayPhepHoatDongKCB_DSNhanSuRepository.NganhY_GiayPhepHoatDongKCB_DSNhanSu_DelByGPID(
                            giayPhepKhamChuaBenhID, _cons, _trans);
                    if (!deldsns)
                    {
                        _trans.Rollback();
                        return false;
                    }
                    var insdsns =
                        _giayPhepHoatDongKCB_DSNhanSuRepository.NganhY_GiayPhepHoatDongKCB_DSNhanSu_Ins(
                            ObjCapLai.lstGiayPhepHoatDongKCB_DSNhanSu, _cons, _trans);
                    if (!insdsns)
                    {
                        _trans.Rollback();
                        return false;
                    }
                }

                _trans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                _trans.Rollback();
                return false;
            }
        }

        public bool NganhY_GiayPhepHoatDongKCB_CapLai_DelByHoSoID(long HoSoID, long CapLaiID)
        {
            try
            {
                _cons = new SqlConnection(NganhYConn);
                _cons.Open();
                _trans = _cons.BeginTransaction();

                var delCapLai =
                    _giayPhepHoatDongKCB_CapLaiRepository.NganhY_GiayPhepHoatDongKCB_CapLai_DelByHoSoID(HoSoID,
                        CapLaiID, _cons, _trans);
                if (!delCapLai)
                {
                    _trans.Rollback();
                    return false;
                }

                _trans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                _trans.Rollback();
                return false;
            }
        }

        #endregion

        #region Giấy chứng nhận lương Y

        public GiayChungNhanLuongYSave NganhY_GiayChungNhanLuongY_GetByHoSoID(long HoSoID)
        {
            try
            {
                var objreturn = new GiayChungNhanLuongYSave();
                objreturn.giayChungNhanLuongY =
                    _giayChungNhanLuongYRepository.NganhY_GiayChungNhanLuongY_GetByHoSoID(HoSoID);
                objreturn.lstgiayChungNhanLuongY_QTHanhNghe = _giayChungNhanLuongY_QTHanhNgheRepository
                    .NganhY_GiayChungNhanLuongY_QTHanhNghe_GetByGCNLYID(objreturn.giayChungNhanLuongY
                        .GiayChungNhanLuongYID).ToList();

                return objreturn;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return null;
            }
        }

        public GiayChungNhanLuongYSave NganhY_GiayChungNhanLuongY_GetByID(long GiayChungNhanLuongYID)
        {
            try
            {
                var objreturn = new GiayChungNhanLuongYSave();
                objreturn.giayChungNhanLuongY =
                    _giayChungNhanLuongYRepository.NganhY_GiayChungNhanLuongY_GetByID(GiayChungNhanLuongYID);
                objreturn.lstgiayChungNhanLuongY_QTHanhNghe = _giayChungNhanLuongY_QTHanhNgheRepository
                    .NganhY_GiayChungNhanLuongY_QTHanhNghe_GetByGCNLYID(objreturn.giayChungNhanLuongY
                        .GiayChungNhanLuongYID).ToList();

                return objreturn;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return null;
            }
        }

        public PagedData<GiayChungNhanLuongYViewModel> NganhY_GiayChungNhanLuongY_Search(string SoGiayChungNhan,
            string tuNgay, string denNgay
            , string HoTen, string SoGiayTo, int pageIndex, int pageSize)
        {
            int totalItems;
            var datas = _giayChungNhanLuongYRepository.NganhY_GiayChungNhanLuongY_Search(SoGiayChungNhan,
                tuNgay.ToDateTimeNullable(), denNgay.ToDateTimeNullable(), HoTen, SoGiayTo, pageIndex, pageSize,
                out totalItems).ToList();

            return new PagedData<GiayChungNhanLuongYViewModel>
            {
                Data = datas,
                PageIndex = pageIndex,
                PageSize = pageSize,
                TotalItems = totalItems
            };
        }

        public long NganhY_GiayChungNhanLuongY_Save(GiayChungNhanLuongYSave objYSave)
        {
            try
            {
                if (objYSave?.giayChungNhanLuongY == null) return -1;
                var giayChungNhanLuongYid = objYSave.giayChungNhanLuongY.GiayChungNhanLuongYID;
                _cons = new SqlConnection(NganhYConn);
                _cons.Open();
                _trans = _cons.BeginTransaction();
                if (giayChungNhanLuongYid==0)
                {
                    giayChungNhanLuongYid =
                        _giayChungNhanLuongYRepository.NganhY_GiayChungNhanLuongY_Ins(
                            objYSave.giayChungNhanLuongY, _cons, _trans);
                    if (giayChungNhanLuongYid == -1)
                    {
                        _trans.Rollback();
                        return -1;
                    }
                    foreach (var qthn in objYSave.lstgiayChungNhanLuongY_QTHanhNghe)
                        qthn.GiayChungNhanLuongYID = giayChungNhanLuongYid;
                    var insqthn =
                        _giayChungNhanLuongY_QTHanhNgheRepository.NganhY_GiayChungNhanLuongY_QTHanhNghe_Ins(
                            objYSave.lstgiayChungNhanLuongY_QTHanhNghe, _cons, _trans);
                    if (!insqthn)
                    {
                        _trans.Rollback();
                        return -1;
                    }
                }
                else
                {
                    var updgcn =
                        _giayChungNhanLuongYRepository.NganhY_GiayChungNhanLuongY_UpdByID(
                            objYSave.giayChungNhanLuongY, _cons, _trans);
                    if (!updgcn)
                    {
                        _trans.Rollback();
                        return -1;
                    }
                    var delqthn =
                        _giayChungNhanLuongY_QTHanhNgheRepository.NganhY_GiayChungNhanLuongY_QTHanhNghe_DelByGCNLYID(
                            giayChungNhanLuongYid, _cons, _trans);
                    if (!delqthn)
                    {
                        _trans.Rollback();
                        return -1;
                    }

                    var insqthn =
                        _giayChungNhanLuongY_QTHanhNgheRepository.NganhY_GiayChungNhanLuongY_QTHanhNghe_Ins(
                            objYSave.lstgiayChungNhanLuongY_QTHanhNghe, _cons, _trans);
                    if (!insqthn)
                    {
                        _trans.Rollback();
                        return -1;
                    }
                }
                _trans.Commit();
                return giayChungNhanLuongYid;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                _trans.Rollback();
                return -1;
            }
        }

        public bool NganhY_GiayChungNhanLuongY_UpdDaCap(List<long> HoSoIDs)
        {
            try
            {
                _cons = new SqlConnection(NganhYConn);
                _cons.Open();
                _trans = _cons.BeginTransaction();

                foreach (var HoSoID in HoSoIDs)
                {
                    var updGCNDaCap =
                        _giayChungNhanLuongYRepository.NganhY_GiayChungNhanLuongY_UpdDaCap(HoSoID, _cons, _trans);
                    if (!updGCNDaCap)
                    {
                        _trans.Rollback();
                        return false;
                    }
                }

                _trans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                _trans.Rollback();
                return false;
            }
        }

        public bool NganhY_GiayChungNhanLuongY_DelByHoSoID(long HoSoID, long GiayChungNhanLuongYID)
        {
            try
            {
                _cons = new SqlConnection(NganhYConn);
                _cons.Open();
                _trans = _cons.BeginTransaction();

                var delGCN =
                    _giayChungNhanLuongYRepository.NganhY_GiayChungNhanLuongY_DelByHoSoID(HoSoID, GiayChungNhanLuongYID,
                        _cons, _trans);
                if (!delGCN)
                {
                    _trans.Rollback();
                    return false;
                }

                _trans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                _trans.Rollback();
                return false;
            }
        }

        #endregion

        #region Cấp mới Giấy chứng nhận ATSH

        public GiayChungNhanATSHSave NganhY_GiayChungNhanATSH_GetByHoSoID(long HoSoID)
        {
            try
            {
                var objreturn = new GiayChungNhanATSHSave();
                objreturn.giayChungNhanATSH = _giayChungNhanATSHRepository.NganhY_GiayChungNhanATSH_GetByHoSoID(HoSoID);
                objreturn.lstGiayChungNhanATSH_DSNhanSu = _giayChungNhanATSH_DSNhanSuRepository
                    .NganhY_GiayChungNhanATSH_DSNhanSu_GetByGCNID(objreturn.giayChungNhanATSH.GiayChungNhanATSHID)
                    .ToList();
                objreturn.lstGiayChungNhanATSH_DSThietBi = _giayChungNhanATSH_DSThietBiRepository
                    .NganhY_GiayChungNhanATSH_DSThietBi_GetByGCNID(objreturn.giayChungNhanATSH.GiayChungNhanATSHID)
                    .ToList();

                return objreturn;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);

                return null;
            }
        }

        public GiayChungNhanATSHSave NganhY_GiayChungNhanATSH_GetByID(long GiayChungNhanATSHID)
        {
            try
            {
                var objreturn = new GiayChungNhanATSHSave
                {
                    giayChungNhanATSH =
                        _giayChungNhanATSHRepository.NganhY_GiayChungNhanATSH_GetByID(GiayChungNhanATSHID)
                };
                objreturn.lstGiayChungNhanATSH_DSNhanSu = _giayChungNhanATSH_DSNhanSuRepository
                    .NganhY_GiayChungNhanATSH_DSNhanSu_GetByGCNID(objreturn.giayChungNhanATSH.GiayChungNhanATSHID)
                    .ToList();
                objreturn.lstGiayChungNhanATSH_DSThietBi = _giayChungNhanATSH_DSThietBiRepository
                    .NganhY_GiayChungNhanATSH_DSThietBi_GetByGCNID(objreturn.giayChungNhanATSH.GiayChungNhanATSHID)
                    .ToList();

                return objreturn;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);

                return null;
            }
        }

        public GiayChungNhanATSHSave NganhY_GiayChungNhanATSH_GetBySoGiayChungNhan(string SoGiayChungNhan)
        {
            try
            {
                var objreturn = new GiayChungNhanATSHSave();
                objreturn.giayChungNhanATSH =
                    _giayChungNhanATSHRepository.NganhY_GiayChungNhanATSH_GetBySoGiayChungNhan(SoGiayChungNhan);
                objreturn.lstGiayChungNhanATSH_DSNhanSu = _giayChungNhanATSH_DSNhanSuRepository
                    .NganhY_GiayChungNhanATSH_DSNhanSu_GetByGCNID(objreturn.giayChungNhanATSH.GiayChungNhanATSHID)
                    .ToList();
                objreturn.lstGiayChungNhanATSH_DSThietBi = _giayChungNhanATSH_DSThietBiRepository
                    .NganhY_GiayChungNhanATSH_DSThietBi_GetByGCNID(objreturn.giayChungNhanATSH.GiayChungNhanATSHID)
                    .ToList();

                return objreturn;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);

                return null;
            }
        }

        public PagedData<GiayChungNhanATSHViewModel> NganhY_GiayChungNhanATSH_Search(string SoGiayChungNhan,
            string tuNgay, string denNgay
            , string TenCoSo, string TenPhongXetNghiem, string HuyenID, int pageIndex, int pageSize)
        {
            int totalItems;
            var datas = _giayChungNhanATSHRepository.NganhY_GiayChungNhanATSH_Search(SoGiayChungNhan,
                tuNgay.ToDateTimeNullable(), denNgay.ToDateTimeNullable(), TenCoSo, TenCoSo, HuyenID.ToLongNullable(),
                pageIndex, pageSize, out totalItems).ToList();

            return new PagedData<GiayChungNhanATSHViewModel>
            {
                Data = datas,
                PageIndex = pageIndex,
                PageSize = pageSize,
                TotalItems = totalItems
            };
        }

        public long NganhY_GiayChungNhanATSH_Save(GiayChungNhanATSHSave modelSave)
        {
           
            try
            {
                if (modelSave?.giayChungNhanATSH == null) return -1;
                var id = modelSave.giayChungNhanATSH.GiayChungNhanATSHID;
                _cons = new SqlConnection(NganhYConn);
                _cons.Open();
                _trans = _cons.BeginTransaction();
                if (id == 0)
                {
                    id =
                        _giayChungNhanATSHRepository.NganhY_GiayChungNhanATSH_Ins(
                            modelSave.giayChungNhanATSH, _cons, _trans);
                    if (id == -1)
                    {
                        _trans.Rollback();
                        return -1;
                    }
                    foreach (var dsns in modelSave.lstGiayChungNhanATSH_DSNhanSu)
                        dsns.GiayChungNhanATSHID = id;
                    var insdsns =
                        _giayChungNhanATSH_DSNhanSuRepository.NganhY_GiayChungNhanATSH_DSNhanSu_Ins(
                            modelSave.lstGiayChungNhanATSH_DSNhanSu, _cons, _trans);
                    if (!insdsns)
                    {
                        _trans.Rollback();
                        return -1;
                    }

                    foreach (var dstb in modelSave.lstGiayChungNhanATSH_DSThietBi)
                        dstb.GiayChungNhanATSHID = id;
                    var insdstb =
                        _giayChungNhanATSH_DSThietBiRepository.NganhY_GiayChungNhanATSH_DSThietBi_Ins(
                            modelSave.lstGiayChungNhanATSH_DSThietBi, _cons, _trans);
                    if (!insdstb)
                    {
                        _trans.Rollback();
                        return -1;
                    }
                }
                else
                {
                    var updgcnatsh =
                        _giayChungNhanATSHRepository.NganhY_GiayChungNhanATSH_UpdByID(
                            modelSave.giayChungNhanATSH, _cons, _trans);
                    if (!updgcnatsh)
                    {
                        _trans.Rollback();
                        return -1;
                    }

                    var deldsns =
                        _giayChungNhanATSH_DSNhanSuRepository.NganhY_GiayChungNhanATSH_DSNhanSu_DelByGCNID(
                            id, _cons, _trans);
                    if (!deldsns)
                    {
                        _trans.Rollback();
                        return -1;
                    }
                    var deldstb =
                        _giayChungNhanATSH_DSThietBiRepository.NganhY_GiayChungNhanATSH_DSThietBi_DelByGCNID(
                            id, _cons, _trans);
                    if (!deldstb)
                    {
                        _trans.Rollback();
                        return -1;
                    }

                    var insdsns =
                        _giayChungNhanATSH_DSNhanSuRepository.NganhY_GiayChungNhanATSH_DSNhanSu_Ins(
                            modelSave.lstGiayChungNhanATSH_DSNhanSu, _cons, _trans);
                    if (!insdsns)
                    {
                        _trans.Rollback();
                        return -1;
                    }
                    var insdstb =
                        _giayChungNhanATSH_DSThietBiRepository.NganhY_GiayChungNhanATSH_DSThietBi_Ins(
                            modelSave.lstGiayChungNhanATSH_DSThietBi, _cons, _trans);
                    if (!insdstb)
                    {
                        _trans.Rollback();
                        return -1;
                    }
                }
                _trans.Commit();
                return id;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                _trans.Rollback();
                return -1;
            }
        }

        public bool NganhY_GiayChungNhanATSH_UpdDaCap(List<long> HoSoIDs)
        {
            try
            {
                _cons = new SqlConnection(NganhYConn);
                _cons.Open();
                _trans = _cons.BeginTransaction();

                foreach (var HoSoID in HoSoIDs)
                {
                    var updGCNDaCap =
                        _giayChungNhanATSHRepository.NganhY_GiayChungNhanATSH_UpdDaCap(HoSoID, _cons, _trans);
                    if (!updGCNDaCap)
                    {
                        _trans.Rollback();
                        return false;
                    }
                }

                _trans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                _trans.Rollback();
                return false;
            }
        }

        public bool NganhY_GiayChungNhanATSH_DelByHoSoID(long HoSoID, long GiayChungNhanATSHID)
        {
            try
            {
                _cons = new SqlConnection(NganhYConn);
                _cons.Open();
                _trans = _cons.BeginTransaction();

                var delGCNATSH =
                    _giayChungNhanATSHRepository.NganhY_GiayChungNhanATSH_DelByHoSoID(HoSoID, GiayChungNhanATSHID, _cons,
                        _trans);
                if (!delGCNATSH)
                {
                    _trans.Rollback();
                    return false;
                }

                _trans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                _trans.Rollback();
                return false;
            }
        }

        #endregion

        #region Cấp lại Giấy chứng nhận ATSH

        public GiayChungNhanATSHCapLaiSave NganhY_GiayChungNhanATSH_CapLai_GetByHoSoID(long HoSoID)
        {
            try
            {
                var capLai = _giayChungNhanATSH_CapLaiRepository.NganhY_GiayChungNhanATSH_CapLai_GetByHoSoID(HoSoID);
                var capLaiId = capLai.CapLaiID;

                var capLaiCt =
                    _giayChungNhanATSH_CapLaiCTRepository.NganhY_GiayChungNhanATSH_CapLaiCT_GetByCapLaiID(capLaiId);
                var noidungcuoitruoc = capLaiCt.NoiDungTruoc;
                var noidungcuoicung = capLaiCt.NoiDungSau;

                var objReturn = new GiayChungNhanATSHCapLaiSave();
                objReturn.giayChungNhanATSH_caplai = capLai;
                objReturn.giayChungNhanATSH_caplaict = capLaiCt;
                objReturn.noidungtruoc = GenXML2Object_GCNATSH(noidungcuoitruoc);
                objReturn.noidungsau = GenXML2Object_GCNATSH(noidungcuoicung);

                return objReturn;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                _trans.Rollback();
                return null;
            }
        }

        public long NganhY_GiayChungNhanATSH_CapLai_Save(GiayChungNhanATSHCapLaiSave objSave)
        {
            
            try
            {
                if(objSave?.giayChungNhanATSH_caplai==null) return -1;
                var capLaiId = objSave.giayChungNhanATSH_caplai.CapLaiID;
                objSave.giayChungNhanATSH_caplaict = objSave.giayChungNhanATSH_caplaict ?? new GiayChungNhanATSH_CapLaiCT();
                _cons = new SqlConnection(NganhYConn);
                _cons.Open();
                _trans = _cons.BeginTransaction();

                if (capLaiId==0)
                {
                    capLaiId = _giayChungNhanATSH_CapLaiRepository.NganhY_GiayChungNhanATSH_CapLai_Ins(
                        objSave.giayChungNhanATSH_caplai, _cons, _trans);
                    if (capLaiId == -1)
                    {
                        _trans.Rollback();
                        return -1;
                    }
                    objSave.giayChungNhanATSH_caplaict.CapLaiID = capLaiId;

                    var noidungtruoc = GenObject2XML_GCNATSH(objSave.noidungtruoc);
                    var noidungsau = GenObject2XML_GCNATSH(objSave.noidungsau);
                    objSave.giayChungNhanATSH_caplaict.NoiDungTruoc = noidungtruoc;
                    objSave.giayChungNhanATSH_caplaict.NoiDungSau = noidungsau;

                    var insCapLaiCt =
                        _giayChungNhanATSH_CapLaiCTRepository.NganhY_GiayChungNhanATSH_CapLaiCT_Ins(
                            objSave.giayChungNhanATSH_caplaict, _cons, _trans);
                    if (!insCapLaiCt)
                    {
                        _trans.Rollback();
                        return -1;
                    }
                }
                else
                {
                    var updcaplai =
                        _giayChungNhanATSH_CapLaiRepository.NganhY_GiayChungNhanATSH_CapLai_Upd(
                            objSave.giayChungNhanATSH_caplai, _cons, _trans);
                    if (!updcaplai)
                    {
                        _trans.Rollback();
                        return -1;
                    }

                    var noidungsau = GenObject2XML_GCNATSH(objSave.noidungsau);
                    objSave.giayChungNhanATSH_caplaict.NoiDungSau = noidungsau;
                    objSave.giayChungNhanATSH_caplaict.CapLaiID = capLaiId;
                    var updcaplaict =
                        _giayChungNhanATSH_CapLaiCTRepository.NganhY_GiayChungNhanATSH_CapLaiCT_Upd(
                            objSave.giayChungNhanATSH_caplaict, _cons, _trans);
                    if (!updcaplaict)
                    {
                        _trans.Rollback();
                        return -1;
                    }
                }
                _trans.Commit();
                return capLaiId;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                _trans.Rollback();
                return -1;
            }
        }

        public bool NganhY_GiayChungNhanATSH_CapLai_UpdDaCap(List<long> HoSoIDs)
        {
            try
            {
                _cons = new SqlConnection(NganhYConn);
                _cons.Open();
                _trans = _cons.BeginTransaction();

                foreach (var HoSoID in HoSoIDs)
                {
                    var updCapLaiDaCap =
                        _giayChungNhanATSH_CapLaiRepository.NganhY_GiayChungNhanATSH_CapLai_UpdDaCap(HoSoID, _cons,
                            _trans);
                    if (!updCapLaiDaCap)
                    {
                        _trans.Rollback();
                        return false;
                    }

                    var capLai =
                        _giayChungNhanATSH_CapLaiRepository.NganhY_GiayChungNhanATSH_CapLai_GetByHoSoID(HoSoID, _cons,
                            _trans);
                    var GiayChungNhanATSHID = capLai.GiayChungNhanATSHIDGoc.Value;
                    var capLaiID = capLai.CapLaiID;
                    var capLaiCT =
                        _giayChungNhanATSH_CapLaiCTRepository.NganhY_GiayChungNhanATSH_CapLaiCT_GetByCapLaiID(capLaiID,
                            _cons, _trans);
                    var noidungcuoicung = capLaiCT.NoiDungSau;

                    var ObjCapLai = GenXML2Object_GCNATSH(noidungcuoicung);
                    ObjCapLai.giayChungNhanATSH.GiayChungNhanATSHID = GiayChungNhanATSHID;
                    ObjCapLai.giayChungNhanATSH.TrangThaiGiayPhepID = 2;
                    ObjCapLai.giayChungNhanATSH.HoSoID = HoSoID;

                    foreach (var dsns in ObjCapLai.lstGiayChungNhanATSH_DSNhanSu)
                        dsns.GiayChungNhanATSHID = GiayChungNhanATSHID;

                    foreach (var dstb in ObjCapLai.lstGiayChungNhanATSH_DSThietBi)
                        dstb.GiayChungNhanATSHID = GiayChungNhanATSHID;


                    var updgcnatsh =
                        _giayChungNhanATSHRepository.NganhY_GiayChungNhanATSH_UpdByID(ObjCapLai.giayChungNhanATSH, _cons,
                            _trans);
                    if (!updgcnatsh)
                    {
                        _trans.Rollback();
                        return false;
                    }

                    var deldsns =
                        _giayChungNhanATSH_DSNhanSuRepository.NganhY_GiayChungNhanATSH_DSNhanSu_DelByGCNID(
                            GiayChungNhanATSHID, _cons, _trans);
                    if (!deldsns)
                    {
                        _trans.Rollback();
                        return false;
                    }
                    var deldstb =
                        _giayChungNhanATSH_DSThietBiRepository.NganhY_GiayChungNhanATSH_DSThietBi_DelByGCNID(
                            GiayChungNhanATSHID, _cons, _trans);
                    if (!deldstb)
                    {
                        _trans.Rollback();
                        return false;
                    }

                    var insdsns =
                        _giayChungNhanATSH_DSNhanSuRepository.NganhY_GiayChungNhanATSH_DSNhanSu_Ins(
                            ObjCapLai.lstGiayChungNhanATSH_DSNhanSu, _cons, _trans);
                    if (!insdsns)
                    {
                        _trans.Rollback();
                        return false;
                    }
                    var insdstb =
                        _giayChungNhanATSH_DSThietBiRepository.NganhY_GiayChungNhanATSH_DSThietBi_Ins(
                            ObjCapLai.lstGiayChungNhanATSH_DSThietBi, _cons, _trans);
                    if (!insdstb)
                    {
                        _trans.Rollback();
                        return false;
                    }
                }

                _trans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                _trans.Rollback();
                return false;
            }
        }

        public bool NganhY_GiayChungNhanATSH_CapLai_DelByHoSoID(long HoSoID, long CapLaiID)
        {
            try
            {
                _cons = new SqlConnection(NganhYConn);
                _cons.Open();
                _trans = _cons.BeginTransaction();

                var delCapLai =
                    _giayChungNhanATSH_CapLaiRepository.NganhY_GiayChungNhanATSH_CapLai_DelByHoSoID(HoSoID, CapLaiID,
                        _cons, _trans);
                if (!delCapLai)
                {
                    _trans.Rollback();
                    return false;
                }

                _trans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                _trans.Rollback();
                return false;
            }
        }

        #endregion

        //Chưa INganhYService

        #region Cấp mới Giấy chứng nhận BTGT

        public GiayChungNhanBTGTSave NganhY_GiayChungNhanBTGT_GetByHoSoID(long HoSoID)
        {
            try
            {
                var objreturn = new GiayChungNhanBTGTSave();
                objreturn.giayChungNhanBTGT = _giayChungNhanBTGTRepository.NganhY_GiayChungNhanBTGT_GetByHoSoID(HoSoID);
                objreturn.lstGiayChungNhanBTGT_ThanhPhan = _giayChungNhanBTGT_ThanhPhanRepository
                    .NganhY_GiayChungNhanBTGT_ThanhPhan_GetByGCNID(objreturn.giayChungNhanBTGT.GiayChungNhanBTGTID)
                    .ToList();

                return objreturn;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return null;
            }
        }

        public GiayChungNhanBTGTSave NganhY_GiayChungNhanBTGT_GetByID(long GiayChungNhanBTGTID)
        {
            try
            {
                var objreturn = new GiayChungNhanBTGTSave();
                objreturn.giayChungNhanBTGT =
                    _giayChungNhanBTGTRepository.NganhY_GiayChungNhanBTGT_GetByID(GiayChungNhanBTGTID);
                objreturn.lstGiayChungNhanBTGT_ThanhPhan = _giayChungNhanBTGT_ThanhPhanRepository
                    .NganhY_GiayChungNhanBTGT_ThanhPhan_GetByGCNID(objreturn.giayChungNhanBTGT.GiayChungNhanBTGTID)
                    .ToList();

                return objreturn;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);

                return null;
            }
        }

        public GiayChungNhanBTGTSave NganhY_GiayChungNhanBTGT_GetBySoGiayChungNhan(string SoGiayChungNhan)
        {
            try
            {
                var objreturn = new GiayChungNhanBTGTSave();
                objreturn.giayChungNhanBTGT =
                    _giayChungNhanBTGTRepository.NganhY_GiayChungNhanBTGT_GetBySoGiayChungNhan(SoGiayChungNhan);
                objreturn.lstGiayChungNhanBTGT_ThanhPhan = _giayChungNhanBTGT_ThanhPhanRepository
                    .NganhY_GiayChungNhanBTGT_ThanhPhan_GetByGCNID(objreturn.giayChungNhanBTGT.GiayChungNhanBTGTID)
                    .ToList();

                return objreturn;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);

                return null;
            }
        }

        public PagedData<GiayChungNhanBTGTViewModel> NganhY_GiayChungNhanBTGT_Search(string SoGiayChungNhan,
            string tuNgay, string denNgay
            , string HoTen, string TenBaiThuoc, int pageIndex, int pageSize)
        {
            int totalItems;
            var datas = _giayChungNhanBTGTRepository.NganhY_GiayChungNhanBTGT_Search(SoGiayChungNhan,
                tuNgay.ToDateTimeNullable(), denNgay.ToDateTimeNullable(), HoTen, TenBaiThuoc,
                pageIndex, pageSize, out totalItems).ToList();

            return new PagedData<GiayChungNhanBTGTViewModel>
            {
                Data = datas,
                PageIndex = pageIndex,
                PageSize = pageSize,
                TotalItems = totalItems
            };
        }

        public long NganhY_GiayChungNhanBTGT_Save(GiayChungNhanBTGTSave giayChungNhanBTGTSave)
        {
            long giayChungNhanBTGTID = 0;
            try
            {
                var flagupd = true; //1: insert - 0: update
                _cons = new SqlConnection(NganhYConn);
                _cons.Open();
                _trans = _cons.BeginTransaction();

                if (giayChungNhanBTGTSave.giayChungNhanBTGT.GiayChungNhanBTGTID != 0)
                {
                    flagupd = false;
                    giayChungNhanBTGTID = giayChungNhanBTGTSave.giayChungNhanBTGT.GiayChungNhanBTGTID;
                }
                else
                {
                    flagupd = true;
                }

                if (flagupd)
                {
                    giayChungNhanBTGTID =
                        _giayChungNhanBTGTRepository.NganhY_GiayChungNhanBTGT_Ins(
                            giayChungNhanBTGTSave.giayChungNhanBTGT, _cons, _trans);
                    if (giayChungNhanBTGTID == -1)
                    {
                        _trans.Rollback();
                        return -1;
                    }
                    foreach (var tp in giayChungNhanBTGTSave.lstGiayChungNhanBTGT_ThanhPhan)
                        tp.GiayChungNhanBTGTID = giayChungNhanBTGTID;
                    var instp = _giayChungNhanBTGT_ThanhPhanRepository.NganhY_GiayChungNhanBTGT_ThanhPhan_Ins(
                        giayChungNhanBTGTSave.lstGiayChungNhanBTGT_ThanhPhan, _cons, _trans);
                    if (!instp)
                    {
                        _trans.Rollback();
                        return -1;
                    }
                }
                else
                {
                    var updgcnbtgt =
                        _giayChungNhanBTGTRepository.NganhY_GiayChungNhanBTGT_UpdByID(
                            giayChungNhanBTGTSave.giayChungNhanBTGT, _cons, _trans);
                    if (!updgcnbtgt)
                    {
                        _trans.Rollback();
                        return -1;
                    }

                    var deltp =
                        _giayChungNhanBTGT_ThanhPhanRepository.NganhY_GiayChungNhanBTGT_ThanhPhan_DelByGCNID(
                            giayChungNhanBTGTID, _cons, _trans);
                    if (!deltp)
                    {
                        _trans.Rollback();
                        return -1;
                    }

                    var instp = _giayChungNhanBTGT_ThanhPhanRepository.NganhY_GiayChungNhanBTGT_ThanhPhan_Ins(
                        giayChungNhanBTGTSave.lstGiayChungNhanBTGT_ThanhPhan, _cons, _trans);
                    if (!instp)
                    {
                        _trans.Rollback();
                        return -1;
                    }
                }
                _trans.Commit();
                return giayChungNhanBTGTID;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);

                _trans.Rollback();
                return -1;
            }
        }

        public bool NganhY_GiayChungNhanBTGT_UpdDaCap(List<long> HoSoIDs)
        {
            try
            {
                _cons = new SqlConnection(NganhYConn);
                _cons.Open();
                _trans = _cons.BeginTransaction();

                foreach (var HoSoID in HoSoIDs)
                {
                    var updGCNDaCap =
                        _giayChungNhanBTGTRepository.NganhY_GiayChungNhanBTGT_UpdDaCap(HoSoID, _cons, _trans);
                    if (!updGCNDaCap)
                    {
                        _trans.Rollback();
                        return false;
                    }
                }

                _trans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);

                _trans.Rollback();
                return false;
            }
        }

        public bool NganhY_GiayChungNhanBTGT_DelByHoSoID(long HoSoID, long GiayChungNhanBTGTID)
        {
            try
            {
                _cons = new SqlConnection(NganhYConn);
                _cons.Open();
                _trans = _cons.BeginTransaction();

                var delGCNBTGT =
                    _giayChungNhanBTGTRepository.NganhY_GiayChungNhanBTGT_DelByHoSoID(HoSoID, GiayChungNhanBTGTID, _cons,
                        _trans);
                if (!delGCNBTGT)
                {
                    _trans.Rollback();
                    return false;
                }

                _trans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);

                _trans.Rollback();
                return false;
            }
        }

        #endregion

        #region Cấp lại Giấy chứng nhận BTGT

        public GiayChungNhanBTGTCapLaiSave NganhY_GiayChungNhanBTGT_CapLai_GetByHoSoID(long HoSoID)
        {
            try
            {
                var capLai = _giayChungNhanBTGT_CapLaiRepository.NganhY_GiayChungNhanBTGT_CapLai_GetByHoSoID(HoSoID);
                var capLaiID = capLai.CapLaiID;

                var capLaiCT =
                    _giayChungNhanBTGT_CapLaiCTRepository.NganhY_GiayChungNhanBTGT_CapLaiCT_GetByCapLaiID(capLaiID);
                var noidungcuoitruoc = capLaiCT.NoiDungTruoc;
                var noidungcuoicung = capLaiCT.NoiDungSau;

                var objReturn = new GiayChungNhanBTGTCapLaiSave();
                objReturn.giayChungNhanBTGT_CapLai = capLai;
                objReturn.giayChungNhanBTGT_CapLaiCT = capLaiCT;
                objReturn.noidungtruoc = GenXML2Object_GCNBTGT(noidungcuoitruoc);
                objReturn.noidungsau = GenXML2Object_GCNBTGT(noidungcuoicung);

                return objReturn;
            }
            catch (Exception ex)
            {
                _trans.Rollback();
                return null;
            }
        }

        public long NganhY_GiayChungNhanBTGT_CapLai_Save(GiayChungNhanBTGTCapLaiSave giayChungNhanBTGTCapLaiSave)
        {
            long capLaiID = 0;
            try
            {
                var flagupd = true; //1: insert - 0: update
                _cons = new SqlConnection(NganhYConn);
                _cons.Open();
                _trans = _cons.BeginTransaction();

                if (giayChungNhanBTGTCapLaiSave.giayChungNhanBTGT_CapLai.CapLaiID != 0)
                {
                    flagupd = false;
                    capLaiID = giayChungNhanBTGTCapLaiSave.giayChungNhanBTGT_CapLai.CapLaiID;
                }
                else
                {
                    flagupd = true;
                }

                if (flagupd)
                {
                    capLaiID = _giayChungNhanBTGT_CapLaiRepository.NganhY_GiayChungNhanBTGT_CapLai_Ins(
                        giayChungNhanBTGTCapLaiSave.giayChungNhanBTGT_CapLai, _cons, _trans);
                    if (capLaiID == -1)
                    {
                        _trans.Rollback();
                        return -1;
                    }
                    giayChungNhanBTGTCapLaiSave.giayChungNhanBTGT_CapLaiCT.CapLaiID = capLaiID;

                    var noidungtruoc = GenObject2XML_GCNBTGT(giayChungNhanBTGTCapLaiSave.noidungtruoc);
                    var noidungsau = GenObject2XML_GCNBTGT(giayChungNhanBTGTCapLaiSave.noidungsau);
                    giayChungNhanBTGTCapLaiSave.giayChungNhanBTGT_CapLaiCT.NoiDungTruoc = noidungtruoc;
                    giayChungNhanBTGTCapLaiSave.giayChungNhanBTGT_CapLaiCT.NoiDungSau = noidungsau;

                    var insCapLaiCT =
                        _giayChungNhanBTGT_CapLaiCTRepository.NganhY_GiayChungNhanBTGT_CapLaiCT_Ins(
                            giayChungNhanBTGTCapLaiSave.giayChungNhanBTGT_CapLaiCT, _cons, _trans);
                    if (!insCapLaiCT)
                    {
                        _trans.Rollback();
                        return -1;
                    }
                }
                else
                {
                    var updcaplai =
                        _giayChungNhanBTGT_CapLaiRepository.NganhY_GiayChungNhanBTGT_CapLai_Upd(
                            giayChungNhanBTGTCapLaiSave.giayChungNhanBTGT_CapLai, _cons, _trans);
                    if (!updcaplai)
                    {
                        _trans.Rollback();
                        return -1;
                    }

                    var noidungsau = GenObject2XML_GCNBTGT(giayChungNhanBTGTCapLaiSave.noidungsau);
                    giayChungNhanBTGTCapLaiSave.giayChungNhanBTGT_CapLaiCT.NoiDungSau = noidungsau;
                    var updcaplaict =
                        _giayChungNhanBTGT_CapLaiCTRepository.NganhY_GiayChungNhanBTGT_CapLaiCT_Upd(
                            giayChungNhanBTGTCapLaiSave.giayChungNhanBTGT_CapLaiCT, _cons, _trans);
                    if (!updcaplaict)
                    {
                        _trans.Rollback();
                        return -1;
                    }
                }
                _trans.Commit();
                return capLaiID;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);

                _trans.Rollback();
                return -1;
            }
        }

        public bool NganhY_GiayChungNhanBTGT_CapLai_UpdDaCap(List<long> HoSoIDs)
        {
            try
            {
                _cons = new SqlConnection(NganhYConn);
                _cons.Open();
                _trans = _cons.BeginTransaction();

                foreach (var HoSoID in HoSoIDs)
                {
                    var updCapLaiDaCap =
                        _giayChungNhanBTGT_CapLaiRepository.NganhY_GiayChungNhanBTGT_CapLai_UpdDaCap(HoSoID, _cons,
                            _trans);
                    if (!updCapLaiDaCap)
                    {
                        _trans.Rollback();
                        return false;
                    }

                    var capLai =
                        _giayChungNhanBTGT_CapLaiRepository.NganhY_GiayChungNhanBTGT_CapLai_GetByHoSoID(HoSoID, _cons,
                            _trans);
                    var GiayChungNhanBTGTID = capLai.GiayChungNhanBTGTIDGoc.Value;
                    var capLaiID = capLai.CapLaiID;
                    var capLaiCT =
                        _giayChungNhanBTGT_CapLaiCTRepository.NganhY_GiayChungNhanBTGT_CapLaiCT_GetByCapLaiID(capLaiID,
                            _cons, _trans);
                    var noidungcuoicung = capLaiCT.NoiDungSau;

                    var ObjCapLai = GenXML2Object_GCNBTGT(noidungcuoicung);
                    ObjCapLai.giayChungNhanBTGT.GiayChungNhanBTGTID = GiayChungNhanBTGTID;
                    ObjCapLai.giayChungNhanBTGT.TrangThaiGiayPhepID = 2;
                    ObjCapLai.giayChungNhanBTGT.HoSoID = HoSoID;

                    foreach (var tp in ObjCapLai.lstGiayChungNhanBTGT_ThanhPhan)
                        tp.GiayChungNhanBTGTID = GiayChungNhanBTGTID;

                    var updgcnBTGT =
                        _giayChungNhanBTGTRepository.NganhY_GiayChungNhanBTGT_UpdByID(ObjCapLai.giayChungNhanBTGT, _cons,
                            _trans);
                    if (!updgcnBTGT)
                    {
                        _trans.Rollback();
                        return false;
                    }

                    var deltp =
                        _giayChungNhanBTGT_ThanhPhanRepository.NganhY_GiayChungNhanBTGT_ThanhPhan_DelByGCNID(
                            GiayChungNhanBTGTID, _cons, _trans);
                    if (!deltp)
                    {
                        _trans.Rollback();
                        return false;
                    }

                    var instp = _giayChungNhanBTGT_ThanhPhanRepository.NganhY_GiayChungNhanBTGT_ThanhPhan_Ins(
                        ObjCapLai.lstGiayChungNhanBTGT_ThanhPhan, _cons, _trans);
                    if (!instp)
                    {
                        _trans.Rollback();
                        return false;
                    }
                }

                _trans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                _trans.Rollback();
                return false;
            }
        }

        public bool NganhY_GiayChungNhanBTGT_CapLai_DelByHoSoID(long HoSoID, long CapLaiID)
        {
            try
            {
                _cons = new SqlConnection(NganhYConn);
                _cons.Open();
                _trans = _cons.BeginTransaction();

                var delCapLai =
                    _giayChungNhanBTGT_CapLaiRepository.NganhY_GiayChungNhanBTGT_CapLai_DelByHoSoID(HoSoID, CapLaiID,
                        _cons, _trans);
                if (!delCapLai)
                {
                    _trans.Rollback();
                    return false;
                }

                _trans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                _trans.Rollback();
                return false;
            }
        }

        #endregion

        #region Giấy phép Đoàn KCB

        public GiayPhepDoanKCBSave NganhY_GiayPhepDoanKCB_GetByHoSoID(long HoSoID)
        {
            try
            {
                var objreturn = new GiayPhepDoanKCBSave();
                objreturn.giayPhepDoanKCB = _giayPhepDoanKCBRepository.NganhY_GiayPhepDoanKCB_GetByHoSoID(HoSoID);
                objreturn.lstgiayPhepDoanKCB_ThanhVien = _giayPhepDoanKCB_ThanhVienRepository
                    .NganhY_GiayPhepDoanKCB_ThanhVien_GetByGPID(objreturn.giayPhepDoanKCB.GiayPhepDoanKCBID).ToList();

                return objreturn;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public GiayPhepDoanKCBSave NganhY_GiayPhepDoanKCB_GetByID(long GiayPhepDoanKCBID)
        {
            try
            {
                var objreturn = new GiayPhepDoanKCBSave();
                objreturn.giayPhepDoanKCB =
                    _giayPhepDoanKCBRepository.NganhY_GiayPhepDoanKCB_GetByID(GiayPhepDoanKCBID);
                objreturn.lstgiayPhepDoanKCB_ThanhVien = _giayPhepDoanKCB_ThanhVienRepository
                    .NganhY_GiayPhepDoanKCB_ThanhVien_GetByGPID(objreturn.giayPhepDoanKCB.GiayPhepDoanKCBID).ToList();

                return objreturn;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public PagedData<GiayPhepDoanKCBViewModel> NganhY_GiayPhepDoanKCB_Search(string SoGiayPhep, string tuNgay,
            string denNgay
            , string TenDoanKCB, string tuNgayKCB, string denNgayKCB, string NoiKCB_HuyenID, string NoiKCB_XaID,
            int pageIndex, int pageSize)
        {
            int totalItems;
            var datas = _giayPhepDoanKCBRepository.NganhY_GiayPhepDoanKCB_Search(SoGiayPhep,
                    tuNgay.ToDateTimeNullable(), denNgay.ToDateTimeNullable(), TenDoanKCB,
                    tuNgayKCB.ToDateTimeNullable(), denNgayKCB.ToDateTimeNullable(),
                    NoiKCB_HuyenID.ToLongNullable(), NoiKCB_XaID.ToLongNullable(), pageIndex, pageSize, out totalItems)
                .ToList();

            return new PagedData<GiayPhepDoanKCBViewModel>
            {
                Data = datas,
                PageIndex = pageIndex,
                PageSize = pageSize,
                TotalItems = totalItems
            };
        }

        public long NganhY_GiayPhepDoanKCB_Save(GiayPhepDoanKCBSave giayPhepDoanKCBSave)
        {
            long giayPhepDoanKCBID = 0;
            try
            {
                var flagupd = true; //1: insert - 0: update
                _cons = new SqlConnection(NganhYConn);
                _cons.Open();
                _trans = _cons.BeginTransaction();

                if (giayPhepDoanKCBSave.giayPhepDoanKCB.GiayPhepDoanKCBID != 0)
                {
                    flagupd = false;
                    giayPhepDoanKCBID = giayPhepDoanKCBSave.giayPhepDoanKCB.GiayPhepDoanKCBID;
                }
                else
                {
                    flagupd = true;
                }

                if (flagupd)
                {
                    giayPhepDoanKCBID =
                        _giayPhepDoanKCBRepository.NganhY_GiayPhepDoanKCB_Ins(giayPhepDoanKCBSave.giayPhepDoanKCB, _cons,
                            _trans);
                    if (giayPhepDoanKCBID == -1)
                    {
                        _trans.Rollback();
                        return -1;
                    }
                    foreach (var tv in giayPhepDoanKCBSave.lstgiayPhepDoanKCB_ThanhVien)
                        tv.GiayPhepDoanKCBID = giayPhepDoanKCBID;
                    var instv = _giayPhepDoanKCB_ThanhVienRepository.NganhY_GiayPhepDoanKCB_ThanhVien_Ins(
                        giayPhepDoanKCBSave.lstgiayPhepDoanKCB_ThanhVien, _cons, _trans);
                    if (!instv)
                    {
                        _trans.Rollback();
                        return -1;
                    }
                }
                else
                {
                    var updgp = _giayPhepDoanKCBRepository.NganhY_GiayPhepDoanKCB_UpdByID(
                        giayPhepDoanKCBSave.giayPhepDoanKCB, _cons, _trans);
                    if (!updgp)
                    {
                        _trans.Rollback();
                        return -1;
                    }

                    var deltv =
                        _giayPhepDoanKCB_ThanhVienRepository.NganhY_GiayPhepDoanKCB_ThanhVien_DelByGPID(
                            giayPhepDoanKCBID, _cons, _trans);
                    if (!deltv)
                    {
                        _trans.Rollback();
                        return -1;
                    }

                    var instv = _giayPhepDoanKCB_ThanhVienRepository.NganhY_GiayPhepDoanKCB_ThanhVien_Ins(
                        giayPhepDoanKCBSave.lstgiayPhepDoanKCB_ThanhVien, _cons, _trans);
                    if (!instv)
                    {
                        _trans.Rollback();
                        return -1;
                    }
                }
                _trans.Commit();
                return giayPhepDoanKCBID;
            }
            catch (Exception ex)
            {
                _trans.Rollback();
                return -1;
            }
        }

        public bool NganhY_GiayPhepDoanKCB_UpdDaCap(List<long> HoSoIDs)
        {
            try
            {
                _cons = new SqlConnection(NganhYConn);
                _cons.Open();
                _trans = _cons.BeginTransaction();

                foreach (var HoSoID in HoSoIDs)
                {
                    var updGCNDaCap = _giayPhepDoanKCBRepository.NganhY_GiayPhepDoanKCB_UpdDaCap(HoSoID, _cons, _trans);
                    if (!updGCNDaCap)
                    {
                        _trans.Rollback();
                        return false;
                    }
                }

                _trans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                _trans.Rollback();
                return false;
            }
        }

        public bool NganhY_GiayPhepDoanKCB_DelByHoSoID(long HoSoID, long GiayPhepDoanKCBID)
        {
            try
            {
                _cons = new SqlConnection(NganhYConn);
                _cons.Open();
                _trans = _cons.BeginTransaction();

                var delGP = _giayPhepDoanKCBRepository.NganhY_GiayPhepDoanKCB_DelByHoSoID(HoSoID, GiayPhepDoanKCBID,
                    _cons, _trans);
                if (!delGP)
                {
                    _trans.Rollback();
                    return false;
                }

                _trans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                _trans.Rollback();
                return false;
            }
        }

        #endregion

        #region Cấp mới Giấy phép hoạt động Chu Thap Do

        public GiayPhepHoatDongChuThapDo NganhY_GiayPhepHoatDongChuThapDo_GetByHoSoID(long HoSoID)
        {
            try
            {
                return _giayPhepHoatDongChuThapDoRepository.NganhY_GiayPhepHoatDongChuThapDo_GetByHoSoID(HoSoID);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public GiayPhepHoatDongChuThapDo NganhY_GiayPhepHoatDongChuThapDo_GetByID(long GiayPhepHoatDongChuThapDoID)
        {
            try
            {
                return _giayPhepHoatDongChuThapDoRepository.NganhY_GiayPhepHoatDongChuThapDo_GetByID(
                    GiayPhepHoatDongChuThapDoID);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public GiayPhepHoatDongChuThapDo NganhY_GiayPhepHoatDongChuThapDo_GetBySoGiayPhep(string SoGiayPhep)
        {
            try
            {
                return _giayPhepHoatDongChuThapDoRepository
                    .NganhY_GiayPhepHoatDongChuThapDo_GetBySoGiayPhep(SoGiayPhep);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public PagedData<GiayPhepHoatDongChuThapDoViewModel> NganhY_GiayPhepHoatDongChuThapDo_Search(string SoGiayPhep,
            string tuNgay, string denNgay
            , string TenDiem, int pageIndex, int pageSize)
        {
            int totalItems;
            var datas = _giayPhepHoatDongChuThapDoRepository.NganhY_GiayPhepHoatDongChuThapDo_Search(SoGiayPhep,
                    tuNgay.ToDateTimeNullable(), denNgay.ToDateTimeNullable(), TenDiem, pageIndex, pageSize,
                    out totalItems)
                .ToList();

            return new PagedData<GiayPhepHoatDongChuThapDoViewModel>
            {
                Data = datas,
                PageIndex = pageIndex,
                PageSize = pageSize,
                TotalItems = totalItems
            };
        }

        public long NganhY_GiayPhepHoatDongChuThapDo_Save(GiayPhepHoatDongChuThapDo giayPhepHoatDongChuThapDoSave)
        {
            long giayPhepHoatDongChuThapDoID = 0;
            try
            {
                var flagupd = true; //1: insert - 0: update
                _cons = new SqlConnection(NganhYConn);
                _cons.Open();
                _trans = _cons.BeginTransaction();

                if (giayPhepHoatDongChuThapDoSave.GiayPhepHoatDongChuThapDoID != 0)
                {
                    flagupd = false;
                    giayPhepHoatDongChuThapDoID = giayPhepHoatDongChuThapDoSave.GiayPhepHoatDongChuThapDoID;
                }
                else
                {
                    flagupd = true;
                }

                if (flagupd)
                {
                    giayPhepHoatDongChuThapDoID =
                        _giayPhepHoatDongChuThapDoRepository.NganhY_GiayPhepHoatDongChuThapDo_Ins(
                            giayPhepHoatDongChuThapDoSave, _cons, _trans);
                    if (giayPhepHoatDongChuThapDoID == -1)
                    {
                        _trans.Rollback();
                        return -1;
                    }
                }
                else
                {
                    var updgphdctd =
                        _giayPhepHoatDongChuThapDoRepository.NganhY_GiayPhepHoatDongChuThapDo_UpdByID(
                            giayPhepHoatDongChuThapDoSave, _cons, _trans);
                    if (!updgphdctd)
                    {
                        _trans.Rollback();
                        return -1;
                    }
                }
                _trans.Commit();
                return giayPhepHoatDongChuThapDoID;
            }
            catch (Exception ex)
            {
                _trans.Rollback();
                return -1;
            }
        }

        public bool NganhY_GiayPhepHoatDongChuThapDo_UpdDaCap(List<long> HoSoIDs)
        {
            try
            {
                _cons = new SqlConnection(NganhYConn);
                _cons.Open();
                _trans = _cons.BeginTransaction();

                foreach (var HoSoID in HoSoIDs)
                {
                    var updGPDaCap =
                        _giayPhepHoatDongChuThapDoRepository.NganhY_GiayPhepHoatDongChuThapDo_UpdDaCap(HoSoID, _cons,
                            _trans);
                    if (!updGPDaCap)
                    {
                        _trans.Rollback();
                        return false;
                    }
                }

                _trans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                _trans.Rollback();
                return false;
            }
        }

        public bool NganhY_GiayPhepHoatDongChuThapDo_DelByHoSoID(long HoSoID)
        {
            try
            {
                _cons = new SqlConnection(NganhYConn);
                _cons.Open();
                _trans = _cons.BeginTransaction();

                var delGPKCB =
                    _giayPhepHoatDongChuThapDoRepository.NganhY_GiayPhepHoatDongChuThapDo_DelByHoSoID(HoSoID, _cons,
                        _trans);
                if (!delGPKCB)
                {
                    _trans.Rollback();
                    return false;
                }

                _trans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                _trans.Rollback();
                return false;
            }
        }

        #endregion

        #region Cấp lại Giấy phép hoạt động CSKCB

        public GiayPhepHoatDongChuThapDoCapLaiSave NganhY_GiayPhepHoatDongChuThapDo_CapLai_GetByHoSoID(long HoSoID)
        {
            try
            {
                var capLai = _giayPhepHoatDongChuThapDo_CapLaiRepository
                    .NganhY_GiayPhepHoatDongChuThapDo_CapLai_GetByHoSoID(HoSoID);
                var capLaiID = capLai.CapLaiID;

                var capLaiCT = _giayPhepHoatDongChuThapDo_CapLaiCTRepository
                    .NganhY_GiayPhepHoatDongChuThapDo_CapLaiCT_GetByCapLaiID(capLaiID);
                var noidungcuoitruoc = capLaiCT.NoiDungTruoc;
                var noidungcuoicung = capLaiCT.NoiDungSau;

                var objReturn = new GiayPhepHoatDongChuThapDoCapLaiSave();
                objReturn.giayPhepHoatDongChuThapDo_caplai = capLai;
                objReturn.giayPhepHoatDongChuThapDo_caplaict = capLaiCT;
                objReturn.noidungtruoc = GenXML2Object_GPHDCTD(noidungcuoitruoc);
                objReturn.noidungsau = GenXML2Object_GPHDCTD(noidungcuoicung);

                return objReturn;
            }
            catch (Exception ex)
            {
                _trans.Rollback();
                return null;
            }
        }

        public long NganhY_GiayPhepHoatDongChuThapDo_CapLai_Save(
            GiayPhepHoatDongChuThapDoCapLaiSave giayPhepHoatDongChuThapDoCapLaiSave)
        {
            long capLaiID = 0;
            try
            {
                var flagupd = true; //1: insert - 0: update
                _cons = new SqlConnection(NganhYConn);
                _cons.Open();
                _trans = _cons.BeginTransaction();

                if (giayPhepHoatDongChuThapDoCapLaiSave.giayPhepHoatDongChuThapDo_caplai.CapLaiID != 0)
                {
                    flagupd = false;
                    capLaiID = giayPhepHoatDongChuThapDoCapLaiSave.giayPhepHoatDongChuThapDo_caplai.CapLaiID;
                }
                else
                {
                    flagupd = true;
                }

                if (flagupd)
                {
                    capLaiID = _giayPhepHoatDongChuThapDo_CapLaiRepository.NganhY_GiayPhepHoatDongChuThapDo_CapLai_Ins(
                        giayPhepHoatDongChuThapDoCapLaiSave.giayPhepHoatDongChuThapDo_caplai, _cons, _trans);
                    if (capLaiID == -1)
                    {
                        _trans.Rollback();
                        return -1;
                    }
                    giayPhepHoatDongChuThapDoCapLaiSave.giayPhepHoatDongChuThapDo_caplaict.CapLaiID = capLaiID;

                    var noidungtruoc = GenObject2XML_GPHDCTD(giayPhepHoatDongChuThapDoCapLaiSave.noidungtruoc);
                    var noidungsau = GenObject2XML_GPHDCTD(giayPhepHoatDongChuThapDoCapLaiSave.noidungsau);
                    giayPhepHoatDongChuThapDoCapLaiSave.giayPhepHoatDongChuThapDo_caplaict.NoiDungTruoc = noidungtruoc;
                    giayPhepHoatDongChuThapDoCapLaiSave.giayPhepHoatDongChuThapDo_caplaict.NoiDungSau = noidungsau;

                    var insCapLaiCT =
                        _giayPhepHoatDongChuThapDo_CapLaiCTRepository.NganhY_GiayPhepHoatDongChuThapDo_CapLaiCT_Ins(
                            giayPhepHoatDongChuThapDoCapLaiSave.giayPhepHoatDongChuThapDo_caplaict, _cons, _trans);
                    if (!insCapLaiCT)
                    {
                        _trans.Rollback();
                        return -1;
                    }
                }
                else
                {
                    var updcaplai =
                        _giayPhepHoatDongChuThapDo_CapLaiRepository.NganhY_GiayPhepHoatDongChuThapDo_CapLai_Upd(
                            giayPhepHoatDongChuThapDoCapLaiSave.giayPhepHoatDongChuThapDo_caplai, _cons, _trans);
                    if (!updcaplai)
                    {
                        _trans.Rollback();
                        return -1;
                    }

                    var noidungsau = GenObject2XML_GPHDCTD(giayPhepHoatDongChuThapDoCapLaiSave.noidungsau);
                    giayPhepHoatDongChuThapDoCapLaiSave.giayPhepHoatDongChuThapDo_caplaict.NoiDungSau = noidungsau;
                    var updcaplaict =
                        _giayPhepHoatDongChuThapDo_CapLaiCTRepository.NganhY_GiayPhepHoatDongChuThapDo_CapLaiCT_Upd(
                            giayPhepHoatDongChuThapDoCapLaiSave.giayPhepHoatDongChuThapDo_caplaict, _cons, _trans);
                    if (!updcaplaict)
                    {
                        _trans.Rollback();
                        return -1;
                    }
                }
                _trans.Commit();
                return capLaiID;
            }
            catch (Exception ex)
            {
                _trans.Rollback();
                return -1;
            }
        }

        public bool NganhY_GiayPhepHoatDongChuThapDo_CapLai_UpdDaCap(List<long> HoSoIDs)
        {
            try
            {
                _cons = new SqlConnection(NganhYConn);
                _cons.Open();
                _trans = _cons.BeginTransaction();

                foreach (var HoSoID in HoSoIDs)
                {
                    var updCapLaiDaCap =
                        _giayPhepHoatDongChuThapDo_CapLaiRepository.NganhY_GiayPhepHoatDongChuThapDo_CapLai_UpdDaCap(
                            HoSoID, _cons, _trans);
                    if (!updCapLaiDaCap)
                    {
                        _trans.Rollback();
                        return false;
                    }

                    var capLai =
                        _giayPhepHoatDongChuThapDo_CapLaiRepository.NganhY_GiayPhepHoatDongChuThapDo_CapLai_GetByHoSoID(
                            HoSoID, _cons, _trans);
                    var giayPhepHoatDongChuThapDoID = capLai.GiayPhepHoatDongChuThapDoIDGoc.Value;
                    var capLaiID = capLai.CapLaiID;
                    var capLaiCT =
                        _giayPhepHoatDongChuThapDo_CapLaiCTRepository
                            .NganhY_GiayPhepHoatDongChuThapDo_CapLaiCT_GetByCapLaiID(capLaiID, _cons, _trans);
                    var noidungcuoicung = capLaiCT.NoiDungSau;

                    var ObjCapLai = GenXML2Object_GPHDCTD(noidungcuoicung);
                    ObjCapLai.GiayPhepHoatDongChuThapDoID = giayPhepHoatDongChuThapDoID;
                    ObjCapLai.TrangThaiGiayPhepID = 2;
                    ObjCapLai.HoSoID = HoSoID;

                    var updgphd =
                        _giayPhepHoatDongChuThapDoRepository.NganhY_GiayPhepHoatDongChuThapDo_UpdByID(ObjCapLai, _cons,
                            _trans);
                    if (!updgphd)
                    {
                        _trans.Rollback();
                        return false;
                    }
                }

                _trans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                _trans.Rollback();
                return false;
            }
        }

        public bool NganhY_GiayPhepHoatDongChuThapDo_CapLai_DelByHoSoID(long HoSoID, long CapLaiID)
        {
            try
            {
                _cons = new SqlConnection(NganhYConn);
                _cons.Open();
                _trans = _cons.BeginTransaction();

                var delCapLai =
                    _giayPhepHoatDongChuThapDo_CapLaiRepository.NganhY_GiayPhepHoatDongChuThapDo_CapLai_DelByHoSoID(
                        HoSoID, CapLaiID, _cons, _trans);
                if (!delCapLai)
                {
                    _trans.Rollback();
                    return false;
                }

                _trans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                _trans.Rollback();
                return false;
            }
        }

        #endregion


    }
}