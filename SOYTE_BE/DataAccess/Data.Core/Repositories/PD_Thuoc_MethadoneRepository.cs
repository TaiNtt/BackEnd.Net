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
    public class PD_Thuoc_MethadoneRepository : Repository<PD_Thuoc_Methadone>, IPD_Thuoc_MethadoneRepository
    {
        private readonly ILog _logger;
        private const string TableName = "PD_Thuoc_Methadone";
        private static readonly string NganhDuocConn = ConfigurationManager.ConnectionStrings["NganhDuoc.ConnString"].ConnectionString;


        public PD_Thuoc_MethadoneRepository(ILog logger) : base(TableName, NganhDuocConn)
        {
            _logger = logger;
        }
        //--------------------------------------------------//
        public PD_Thuoc_Methadone NganhDuoc_PD_Thuoc_Methadone_GetByHoSoID(long HoSoID)
        {
            try
            {
                using (IDbConnection conn = Connection)
                {
                    conn.Open();

                    var parameters = new DynamicParameters();
                    parameters.Add("HoSoID", HoSoID, DbType.Int64, ParameterDirection.Input);

                    var retval = conn.Query<PD_Thuoc_Methadone>("NganhDuoc_PD_Thuoc_Methadone_GetByHoSoID", parameters
                        , commandType: CommandType.StoredProcedure);
                    return retval.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return new PD_Thuoc_Methadone();
            }
        }
        public PD_Thuoc_Methadone NganhDuoc_PD_Thuoc_Methadone_GetByID(long PDMethadoneId)
        {
            try
            {
                using (IDbConnection conn = Connection)
                {
                    conn.Open();

                    var parameters = new DynamicParameters();
                    parameters.Add("PDMethadoneId", PDMethadoneId, DbType.Int64, ParameterDirection.Input);

                    var retval = conn.Query<PD_Thuoc_Methadone>("NganhDuoc_PD_Thuoc_Methadone_GetByID", parameters
                        , commandType: CommandType.StoredProcedure);
                    return retval.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return new PD_Thuoc_Methadone();
            }
        }
        public IEnumerable<PD_Thuoc_MethadoneViewModel> NganhDuoc_PD_Thuoc_Methadone_Search(string SoPheDuyet, DateTime? tuNgay, DateTime? denNgay
            , string TenDonVi, int pageIndex, int pageSize, out int totalItems)
        {
            try
            {
                using (var conn = Connection)
                {
                    conn.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("SoPheDuyet", SoPheDuyet, DbType.String, ParameterDirection.Input);
                    parameters.Add("tuNgay", tuNgay, DbType.DateTime, ParameterDirection.Input);
                    parameters.Add("denNgay", denNgay, DbType.DateTime, ParameterDirection.Input);
                    parameters.Add("TenDonVi", TenDonVi, DbType.String, ParameterDirection.Input);
                    parameters.Add("pageIndex", pageIndex, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("pageSize", pageSize, DbType.Int32, ParameterDirection.Input);

                    var datas = conn.Query<PD_Thuoc_MethadoneViewModel>("NganhDuoc_PD_Thuoc_Methadone_Search",
                        parameters,
                        commandType: CommandType.StoredProcedure);

                    var pD_Thuoc_MethadoneViewModels = datas as IList<PD_Thuoc_MethadoneViewModel> ??
                                                          datas.ToList();
                    totalItems = pD_Thuoc_MethadoneViewModels.FirstOrDefault() != null
                        ? pD_Thuoc_MethadoneViewModels.First().TotalItems.Value
                        : 0;
                    return pD_Thuoc_MethadoneViewModels;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                totalItems = 0;
                return null;
            }
        }
        public long NganhDuoc_PD_Thuoc_Methadone_Ins(PD_Thuoc_Methadone model, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("HoSoID", model.HoSoID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("SoBienNhan", model.SoBienNhan, DbType.String, ParameterDirection.Input);
                parameters.Add("NgayHoanThanhBaoCao", model.NgayHoanThanhBaoCao, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("SoPheDuyet", model.SoPheDuyet, DbType.String, ParameterDirection.Input);
                parameters.Add("NgayDuyet", model.NgayDuyet, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("ThoiHan", model.ThoiHan, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("TenDonViTH", model.TenDonViTH, DbType.String, ParameterDirection.Input);
                parameters.Add("ACTIVE", model.Active, DbType.Int32, ParameterDirection.Input);
                parameters.Add("GhiChu", model.GhiChu, DbType.String, ParameterDirection.Input);
                parameters.Add("TrangThaiGiayPhepID", model.TrangThaiGiayPhepID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("DonViID", model.DonViID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("CreateUserId", model.CreateUserId, DbType.Int32, ParameterDirection.Input);
                parameters.Add("CreateDate", model.CreateDate, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("UpdateUserId", model.UpdateUserId, DbType.Int32, ParameterDirection.Input);
                parameters.Add("UpdateDate", model.UpdateDate, DbType.DateTime, ParameterDirection.Input);

                var iD = conns.ExecuteScalar("NganhDuoc_PD_Thuoc_Methadone_Ins", parameters, trans, commandType: CommandType.StoredProcedure);
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
        public bool NganhDuoc_PD_Thuoc_Methadone_UpdByID(PD_Thuoc_Methadone model, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("PDMethadoneId", model.PDMethadoneId, DbType.Int64, ParameterDirection.Input);
                parameters.Add("HoSoID", model.HoSoID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("SoBienNhan", model.SoBienNhan, DbType.String, ParameterDirection.Input);
                parameters.Add("NgayHoanThanhBaoCao", model.NgayHoanThanhBaoCao, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("SoPheDuyet", model.SoPheDuyet, DbType.String, ParameterDirection.Input);
                parameters.Add("NgayDuyet", model.NgayDuyet, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("ThoiHan", model.ThoiHan, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("TenDonViTH", model.TenDonViTH, DbType.String, ParameterDirection.Input);
                parameters.Add("ACTIVE", model.Active, DbType.Int32, ParameterDirection.Input);
                parameters.Add("GhiChu", model.GhiChu, DbType.String, ParameterDirection.Input);
                parameters.Add("TrangThaiGiayPhepID", model.TrangThaiGiayPhepID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("DonViID", model.DonViID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("UpdateUserId", model.UpdateUserId, DbType.Int32, ParameterDirection.Input);
                parameters.Add("UpdateDate", model.UpdateDate, DbType.DateTime, ParameterDirection.Input);

                conns.ExecuteScalar("NganhDuoc_PD_Thuoc_Methadone_UpdByID", parameters, trans, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return false;
            }
        }
        public bool NganhDuoc_PD_Thuoc_Methadone_UpdDaCap(long HoSoID, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("HoSoID", HoSoID, DbType.Int64, ParameterDirection.Input);

                conns.ExecuteScalar("NganhDuoc_PD_Thuoc_Methadone_UpdDaCap", parameters, trans, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return false;
            }
        }
        public bool NganhDuoc_PD_Thuoc_Methadone_DelByHoSoID(long HoSoID, long PDMethadoneId, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("HoSoID", HoSoID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("PDMethadoneId", PDMethadoneId, DbType.Int64, ParameterDirection.Input);

                conns.ExecuteScalar("NganhDuoc_PD_Thuoc_Methadone_DelByHoSoID", parameters, trans, commandType: CommandType.StoredProcedure);
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
