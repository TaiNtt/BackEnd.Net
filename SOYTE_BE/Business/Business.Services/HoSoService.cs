using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Transactions;
using Business.Entities.HoSo;
using Business.Services.Contracts;
using Data.Core.Repositories.Interfaces;

namespace Business.Services
{
    public class HoSoService : IHoSoService
    {
        public KetQuaTraVe ChungChiY_SaveFullProcess(HoSoSaveFull hoSoFullSave)
        {
            long hosoid = 0;
            long chungchihanhngheYID = 0;
            var flagupd = true; //1: insert - 0: update
            if (hoSoFullSave == null) return null;
            try
            {
                using (var myScope = new TransactionScope())
                {
                    using (var connectionMotCua = new SqlConnection(MotCuaConn))
                    {
                        connectionMotCua.Open();
                        if (hoSoFullSave.HoSoTiepNhan.hosotiepnhan.HoSoID != 0)
                        {
                            flagupd = false;
                            hosoid = hoSoFullSave.HoSoTiepNhan.hosotiepnhan.HoSoID;
                        }
                        if (flagupd)
                        {
                            hosoid = _hoSoTiepNhanRepository.MotCua_HoSoTiepNhan_Ins(
                                hoSoFullSave.HoSoTiepNhan.hosotiepnhan, connectionMotCua, trans);
                            if (hosoid == -1)
                            {
                                myScope.Dispose();
                                return null;
                            }
                            hoSoFullSave.HoSoTiepNhan.quatrinhxuly.HoSoID = hosoid;
                            var kqQuaTrinhXuLyIns =
                                _quaTrinhXuLyRepository.MotCua_QuaTrinhXuLy_Ins(
                                    hoSoFullSave.HoSoTiepNhan.quatrinhxuly, connectionMotCua, trans);
                            _hoSoTiepNhanRepository.MotCua_HoSoTiepNhan_UpdQuaTrinhXuLyHienTaiByHoSoID(hosoid,
                                kqQuaTrinhXuLyIns, connectionMotCua, trans);
                            _workListRepository.MotCua_WorkList_InsUpdByUserIDandTrangThaiHoSoID(
                                hoSoFullSave.HoSoTiepNhan.UserId,
                                hoSoFullSave.HoSoTiepNhan.TrangThaiHoSoId,
                                hoSoFullSave.HoSoTiepNhan.TrangThaiCapNhat,
                                connectionMotCua, trans);
                        }
                        else
                        {
                            _hoSoTiepNhanRepository.MotCua_HoSoTiepNhan_UpdByHoSoID(
                                hoSoFullSave.HoSoTiepNhan.hosotiepnhan, connectionMotCua, trans);
                        }

                        using (var connectionNganhY = new SqlConnection(NganhYConn))
                        {
                            flagupd = true;
                            connectionNganhY.Open();
                            hoSoFullSave.ChungChiHanhNgheY.chungChiHanhNgheY.HoSoID = hosoid;
                            if (hoSoFullSave.ChungChiHanhNgheY.chungChiHanhNgheY.ChungChiHanhNgheYID != 0)
                            {
                                flagupd = false;
                                chungchihanhngheYID =
                                    hoSoFullSave.ChungChiHanhNgheY.chungChiHanhNgheY.ChungChiHanhNgheYID;
                            }
                            if (flagupd)
                            {
                                chungchihanhngheYID =
                                    _chungChiHanhNgheYRepository.NganhY_ChungChiHanhNgheY_Ins(
                                        hoSoFullSave.ChungChiHanhNgheY.chungChiHanhNgheY, connectionNganhY, trans);
                                if (chungchihanhngheYID == -1)
                                {
                                    myScope.Dispose();
                                    return null;
                                }
                                if (hoSoFullSave.ChungChiHanhNgheY.lstChungChiHanhNgheY_TDCM?.Any() == true)
                                {
                                    foreach (var tdcm in hoSoFullSave.ChungChiHanhNgheY.lstChungChiHanhNgheY_TDCM)
                                        tdcm.ChungChiHanhNgheYID = chungchihanhngheYID;
                                    var instdcm = _chungChiHanhNgheY_TDCMRepository.NganhY_ChungChiHanhNgheY_TDCM_Ins(
                                        hoSoFullSave.ChungChiHanhNgheY.lstChungChiHanhNgheY_TDCM, connectionNganhY, trans);
                                    if (!instdcm)
                                    {
                                        myScope.Dispose();
                                        return null;
                                    }
                                }
                                if (hoSoFullSave.ChungChiHanhNgheY.lstChungChiHanhNgheY_QTTH?.Any() == true)
                                {
                                    foreach (var qtth in hoSoFullSave.ChungChiHanhNgheY.lstChungChiHanhNgheY_QTTH)
                                        qtth.ChungChiHanhNgheYID = chungchihanhngheYID;
                                    var insqtth = _chungChiHanhNgheY_QTTHRepository.NganhY_ChungChiHanhNgheY_QTTH_Ins(
                                        hoSoFullSave.ChungChiHanhNgheY.lstChungChiHanhNgheY_QTTH, connectionNganhY, trans);
                                    if (!insqtth)
                                    {
                                        myScope.Dispose();
                                        return null;
                                    }
                                }
                            }
                            else
                            {
                                var updcchn =
                                    _chungChiHanhNgheYRepository.NganhY_ChungChiHanhNgheY_UpdByCCHNYID(
                                        hoSoFullSave.ChungChiHanhNgheY.chungChiHanhNgheY, connectionNganhY, trans);
                                if (!updcchn)
                                {
                                    myScope.Dispose();
                                    return null;
                                }
                                var deltdcm =
                                    _chungChiHanhNgheY_TDCMRepository.NganhY_ChungChiHanhNgheY_TDCM_DelByCCHNYID(
                                        chungchihanhngheYID, connectionNganhY, trans);
                                if (!deltdcm)
                                {
                                    myScope.Dispose();
                                    return null;
                                }
                                var delqtth =
                                    _chungChiHanhNgheY_QTTHRepository.NganhY_ChungChiHanhNgheY_QTTH_DelByCCHNYID(
                                        chungchihanhngheYID, connectionNganhY, trans);
                                if (!delqtth)
                                {
                                    myScope.Dispose();
                                    return null;
                                }

                                var instdcm =
                                    _chungChiHanhNgheY_TDCMRepository.NganhY_ChungChiHanhNgheY_TDCM_Ins(
                                        hoSoFullSave.ChungChiHanhNgheY.lstChungChiHanhNgheY_TDCM, connectionNganhY, trans);
                                if (!instdcm)
                                {
                                    myScope.Dispose();
                                    return null;
                                }
                                var insqtth =
                                    _chungChiHanhNgheY_QTTHRepository.NganhY_ChungChiHanhNgheY_QTTH_Ins(
                                        hoSoFullSave.ChungChiHanhNgheY.lstChungChiHanhNgheY_QTTH, connectionNganhY, trans);
                                if (!insqtth)
                                {
                                    myScope.Dispose();
                                    return null;
                                }
                            }
                        }
                    }
                    myScope.Complete();
                    return new KetQuaTraVe
                    {
                        ChungChiId = chungchihanhngheYID,
                        HoSoId = hosoid
                    };
                }
            }
            catch (TransactionAbortedException ex)
            {
                Console.WriteLine("TransactionAbortedException Message: {0}", ex.Message);
                return null;
            }
            catch (ApplicationException ex)
            {
                Console.WriteLine("ApplicationException Message: {0}", ex.Message);
                return null;
            }
        }

        #region Private Repository & contractor

        private IDbConnection cons;
        private IDbTransaction trans;

        private static readonly string MotCuaConn =
            ConfigurationManager.ConnectionStrings["MotCua.ConnString"].ConnectionString;

        private static readonly string NganhYConn =
            ConfigurationManager.ConnectionStrings["NganhY.ConnString"].ConnectionString;

        private readonly IHoSoTiepNhanRepository _hoSoTiepNhanRepository;
        private readonly IChungChiHanhNgheYRepository _chungChiHanhNgheYRepository;
        private readonly IQuaTrinhXuLyRepository _quaTrinhXuLyRepository;
        private readonly IWorkListRepository _workListRepository;
        private readonly ITamNgungThamDinhRepository _tamNgungThamDinhRepository;
        private readonly IKhongPheDuyetRepository _khongPheDuyetRepository;
        private readonly IKhongGiaiQuyetRepository _khongGiaiQuyetRepository;
        private readonly IQuyTrinhRepository _quyTrinhRepository;
        private readonly IDM_LinhVucRepository _dM_LinhVucRepository;
        private readonly IDM_ThuTucRepository _dM_ThuTucRepository;
        private readonly IDM_QuyTrinh_Buoc_NguoiNhanRepository _dM_QuyTrinh_Buoc_NguoiNhanRepository;
        private readonly IChungChiHanhNgheY_TDCMRepository _chungChiHanhNgheY_TDCMRepository;
        private readonly IChungChiHanhNgheY_QTTHRepository _chungChiHanhNgheY_QTTHRepository;

        public HoSoService(IHoSoTiepNhanRepository hoSoTiepNhanRepository
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
            , IChungChiHanhNgheYRepository chungChiHanhNgheYRepository
            , IChungChiHanhNgheY_TDCMRepository chungChiHanhNgheY_TDCMRepository
            , IChungChiHanhNgheY_QTTHRepository chungChiHanhNgheY_QTTHRepository
        )
        {
            _hoSoTiepNhanRepository = hoSoTiepNhanRepository;
            _quaTrinhXuLyRepository = quaTrinhXuLyRepository;
            _workListRepository = workListRepository;
            _tamNgungThamDinhRepository = tamNgungThamDinhRepository;
            _khongPheDuyetRepository = khongPheDuyetRepository;
            _khongGiaiQuyetRepository = khongGiaiQuyetRepository;
            _quyTrinhRepository = quyTrinhRepository;
            _dM_LinhVucRepository = dM_LinhVucRepository;
            _dM_ThuTucRepository = dM_ThuTucRepository;
            _dM_QuyTrinh_Buoc_NguoiNhanRepository = dM_QuyTrinh_Buoc_NguoiNhanRepository;
            _chungChiHanhNgheYRepository = chungChiHanhNgheYRepository;
            _chungChiHanhNgheY_TDCMRepository = chungChiHanhNgheY_TDCMRepository;
            _chungChiHanhNgheY_QTTHRepository = chungChiHanhNgheY_QTTHRepository;
        }

        #endregion
    }
}