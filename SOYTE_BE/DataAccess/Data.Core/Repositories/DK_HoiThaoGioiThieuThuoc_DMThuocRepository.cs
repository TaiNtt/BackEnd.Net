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
    public class DK_HoiThaoGioiThieuThuoc_DMThuocRepository : Repository<DK_HoiThaoGioiThieuThuoc_DMThuoc>, IDK_HoiThaoGioiThieuThuoc_DMThuocRepository
    {
        private readonly ILog _logger;
        private const string TableName = "DK_HoiThaoGioiThieuThuoc_DMThuoc";
        private static readonly string NganhDuocConn = ConfigurationManager.ConnectionStrings["NganhDuoc.ConnString"].ConnectionString;

        public DK_HoiThaoGioiThieuThuoc_DMThuocRepository(ILog logger) : base(TableName, NganhDuocConn)
        {
            _logger = logger;
        }
        public IEnumerable<DK_HoiThaoGioiThieuThuoc_DMThuoc> NganhDuoc_DK_HoiThaoGioiThieuThuoc_DMThuoc_GetByHoiThaoThuocID(long HoiThaoThuocID)
        {
            try
            {
                using (IDbConnection conns = Connection)
                {
                    conns.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("HoiThaoThuocID", HoiThaoThuocID, DbType.Int64, ParameterDirection.Input);
                    var datas = conns.Query<DK_HoiThaoGioiThieuThuoc_DMThuoc>("NganhDuoc_DK_HoiThaoGioiThieuThuoc_DMThuoc_GetByHoiThaoThuocID", parameters, commandType: CommandType.StoredProcedure);

                    var lstHT = datas as IList<DK_HoiThaoGioiThieuThuoc_DMThuoc> ?? datas.ToList();

                    return lstHT;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return null;
            }
        }
        public bool NganhDuoc_DK_HoiThaoGioiThieuThuoc_DMThuoc_Ins(List<DK_HoiThaoGioiThieuThuoc_DMThuoc> lstmodel, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                foreach (var model in lstmodel)
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("HoiThaoThuocID", model.HoiThaoThuocID, DbType.Int64, ParameterDirection.Input);
                    parameters.Add("TenThuoc", model.TenThuoc, DbType.String, ParameterDirection.Input);
                    parameters.Add("SoDangKy", model.SoDangKy, DbType.String, ParameterDirection.Input);
                    parameters.Add("DoiTuongDuHoiThao", model.DoiTuongDuHoiThao, DbType.String, ParameterDirection.Input);
                    parameters.Add("LanThu", model.LanThu, DbType.String, ParameterDirection.Input);
                    parameters.Add("GhiChu", model.GhiChu, DbType.String, ParameterDirection.Input);
                    parameters.Add("Active", model.Active, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("DonViID", model.DonViID, DbType.Int64, ParameterDirection.Input);
                    parameters.Add("CreateUserId", model.CreateUserId, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("CreateDate", model.CreateDate, DbType.DateTime, ParameterDirection.Input);
                    parameters.Add("UpdateUserId", model.UpdateUserId, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("UpdateDate", model.UpdateDate, DbType.DateTime, ParameterDirection.Input);
                    conns.ExecuteScalar("NganhDuoc_DK_HoiThaoGioiThieuThuoc_DMThuoc_Ins", parameters, trans, commandType: CommandType.StoredProcedure);
                }
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return false;
            }
        }
        public bool NganhDuoc_DK_HoiThaoGioiThieuThuoc_DMThuoc_DelByHoiThaoThuocID(long HoiThaoThuocID, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("HoiThaoThuocID", HoiThaoThuocID, DbType.Int64, ParameterDirection.Input);

                conns.ExecuteScalar("NganhDuoc_DK_HoiThaoGioiThieuThuoc_DMThuoc_DelByHoiThaoThuocID", parameters, trans, commandType: CommandType.StoredProcedure);
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
