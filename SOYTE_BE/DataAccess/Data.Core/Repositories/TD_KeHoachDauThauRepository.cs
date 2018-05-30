using System;
using System.Data;
using System.Linq;
using Business.Entities;
using Dapper;
using Data.Core.Repositories.Base;
using Data.Core.Repositories.Interfaces;
using log4net;
using Core.Common.Utilities;
using System.Collections.Generic;
using System.Configuration;
using Business.Entities.ViewModels;

namespace Data.Core.Repositories
{
    public class TD_KeHoachDauThauRepository : Repository<TD_KeHoachDauThau>, ITD_KeHoachDauThauRepository
    {
        private readonly ILog _logger;
        private const string TableName = "TD_KeHoachDauThau";
        private static readonly string NganhDuocConn = ConfigurationManager.ConnectionStrings["NganhDuoc.ConnString"].ConnectionString;


        public TD_KeHoachDauThauRepository(ILog logger) : base(TableName, NganhDuocConn)
        {
            _logger = logger;
        }
        //--------------------------------------------------//
        public TD_KeHoachDauThau NganhDuoc_TD_KeHoachDauThau_GetByHoSoID(long HoSoID)
        {
            try
            {
                using (IDbConnection conn = Connection)
                {
                    conn.Open();

                    var parameters = new DynamicParameters();
                    parameters.Add("HoSoID", HoSoID, DbType.Int64, ParameterDirection.Input);

                    var retval = conn.Query<TD_KeHoachDauThau>("NganhDuoc_TD_KeHoachDauThau_GetByHoSoID", parameters
                        , commandType: CommandType.StoredProcedure);
                    return retval.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return new TD_KeHoachDauThau();
            }
        }
        public TD_KeHoachDauThau NganhDuoc_TD_KeHoachDauThau_GetByID(long KeHoachDauThauId)
        {
            try
            {
                using (IDbConnection conn = Connection)
                {
                    conn.Open();

                    var parameters = new DynamicParameters();
                    parameters.Add("KeHoachDauThauId", KeHoachDauThauId, DbType.Int64, ParameterDirection.Input);

                    var retval = conn.Query<TD_KeHoachDauThau>("NganhDuoc_TD_KeHoachDauThau_GetByID", parameters
                        , commandType: CommandType.StoredProcedure);
                    return retval.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return new TD_KeHoachDauThau();
            }
        }
        public IEnumerable<TD_KeHoachDauThauViewModel> NganhDuoc_TD_KeHoachDauThau_Search(string SoQuyetDinh, DateTime? tuNgay, DateTime? denNgay
            , string ChuDauTu, int pageIndex, int pageSize, out int totalItems)
        {
            try
            {
                using (var conn = Connection)
                {
                    conn.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("SoQuyetDinh", SoQuyetDinh, DbType.String, ParameterDirection.Input);
                    parameters.Add("tuNgay", tuNgay, DbType.DateTime, ParameterDirection.Input);
                    parameters.Add("denNgay", denNgay, DbType.DateTime, ParameterDirection.Input);
                    parameters.Add("ChuDauTu", ChuDauTu, DbType.String, ParameterDirection.Input);
                    parameters.Add("pageIndex", pageIndex, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("pageSize", pageSize, DbType.Int32, ParameterDirection.Input);

                    var datas = conn.Query<TD_KeHoachDauThauViewModel>("NganhDuoc_TD_KeHoachDauThau_Search",
                        parameters,
                        commandType: CommandType.StoredProcedure);

                    var tD_KeHoachDauThauViewModels = datas as IList<TD_KeHoachDauThauViewModel> ??
                                                          datas.ToList();
                    totalItems = tD_KeHoachDauThauViewModels.FirstOrDefault() != null
                        ? tD_KeHoachDauThauViewModels.First().TotalItems.Value
                        : 0;
                    return tD_KeHoachDauThauViewModels;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                totalItems = 0;
                return null;
            }
        }
        public long NganhDuoc_TD_KeHoachDauThau_Ins(TD_KeHoachDauThau model, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("HoSoID", model.HoSoID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("SoBienNhan", model.SoBienNhan, DbType.String, ParameterDirection.Input);
                parameters.Add("DonViTrinh", model.DonViTrinh, DbType.String, ParameterDirection.Input);
                parameters.Add("SoToTrinh", model.SoToTrinh, DbType.String, ParameterDirection.Input);
                parameters.Add("NgayTrinh", model.NgayTrinh, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("SoQuyetDinh", model.SoQuyetDinh, DbType.String, ParameterDirection.Input);
                parameters.Add("NgayQuyetDinh", model.NgayQuyetDinh, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("TieuDe", model.TieuDe, DbType.String, ParameterDirection.Input);
                parameters.Add("ChuDauTu", model.ChuDauTu, DbType.String, ParameterDirection.Input);
                parameters.Add("TongChiPhi", model.TongChiPhi, DbType.String, ParameterDirection.Input);
                parameters.Add("NguonVon", model.NguonVon, DbType.String, ParameterDirection.Input);
                parameters.Add("NhanXet", model.NhanXet, DbType.String, ParameterDirection.Input);
                parameters.Add("KetLuan", model.KetLuan, DbType.String, ParameterDirection.Input);
                parameters.Add("TapTinDinhKem", model.TapTinDinhKem, DbType.String, ParameterDirection.Input);
                parameters.Add("TapTinDinhKemGoc", model.TapTinDinhKemGoc, DbType.String, ParameterDirection.Input);
                parameters.Add("ACTIVE", model.Active, DbType.Int32, ParameterDirection.Input);
                parameters.Add("GhiChu", model.GhiChu, DbType.String, ParameterDirection.Input);
                parameters.Add("TrangThaiGiayPhepID", model.TrangThaiGiayPhepID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("DonViID", model.DonViID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("CreateUserId", model.CreateUserId, DbType.Int32, ParameterDirection.Input);
                parameters.Add("CreateDate", model.CreateDate, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("UpdateUserId", model.UpdateUserId, DbType.Int32, ParameterDirection.Input);
                parameters.Add("UpdateDate", model.UpdateDate, DbType.DateTime, ParameterDirection.Input);

                var iD = conns.ExecuteScalar("NganhDuoc_TD_KeHoachDauThau_Ins", parameters, trans, commandType: CommandType.StoredProcedure);
                if (iD != null)
                    return Convert.ToInt64(iD);
                return -1;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return -1;
            }
        }
        public bool NganhDuoc_TD_KeHoachDauThau_UpdByID(TD_KeHoachDauThau model, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("KeHoachDauThauId", model.KeHoachDauThauId, DbType.Int64, ParameterDirection.Input);
                parameters.Add("HoSoID", model.HoSoID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("SoBienNhan", model.SoBienNhan, DbType.String, ParameterDirection.Input);
                parameters.Add("DonViTrinh", model.DonViTrinh, DbType.String, ParameterDirection.Input);
                parameters.Add("SoToTrinh", model.SoToTrinh, DbType.String, ParameterDirection.Input);
                parameters.Add("NgayTrinh", model.NgayTrinh, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("SoQuyetDinh", model.SoQuyetDinh, DbType.String, ParameterDirection.Input);
                parameters.Add("NgayQuyetDinh", model.NgayQuyetDinh, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("TieuDe", model.TieuDe, DbType.String, ParameterDirection.Input);
                parameters.Add("ChuDauTu", model.ChuDauTu, DbType.String, ParameterDirection.Input);
                parameters.Add("TongChiPhi", model.TongChiPhi, DbType.String, ParameterDirection.Input);
                parameters.Add("NguonVon", model.NguonVon, DbType.String, ParameterDirection.Input);
                parameters.Add("NhanXet", model.NhanXet, DbType.String, ParameterDirection.Input);
                parameters.Add("KetLuan", model.KetLuan, DbType.String, ParameterDirection.Input);
                parameters.Add("TapTinDinhKem", model.TapTinDinhKem, DbType.String, ParameterDirection.Input);
                parameters.Add("TapTinDinhKemGoc", model.TapTinDinhKemGoc, DbType.String, ParameterDirection.Input);
                parameters.Add("ACTIVE", model.Active, DbType.Int32, ParameterDirection.Input);
                parameters.Add("GhiChu", model.GhiChu, DbType.String, ParameterDirection.Input);
                parameters.Add("TrangThaiGiayPhepID", model.TrangThaiGiayPhepID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("DonViID", model.DonViID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("UpdateUserId", model.UpdateUserId, DbType.Int32, ParameterDirection.Input);
                parameters.Add("UpdateDate", model.UpdateDate, DbType.DateTime, ParameterDirection.Input);

                conns.ExecuteScalar("NganhDuoc_TD_KeHoachDauThau_UpdByID", parameters, trans, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return false;
            }
        }
        public bool NganhDuoc_TD_KeHoachDauThau_UpdDaCap(long HoSoID, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("HoSoID", HoSoID, DbType.Int64, ParameterDirection.Input);

                conns.ExecuteScalar("NganhDuoc_TD_KeHoachDauThau_UpdDaCap", parameters, trans, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return false;
            }
        }
        public bool NganhDuoc_TD_KeHoachDauThau_DelByHoSoID(long HoSoID, long KeHoachDauThauId, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("HoSoID", HoSoID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("KeHoachDauThauId", KeHoachDauThauId, DbType.Int64, ParameterDirection.Input);

                conns.ExecuteScalar("NganhDuoc_TD_KeHoachDauThau_DelByHoSoID", parameters, trans, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return false;
            }
        }
    }
}
