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
    public class TD_KeHoachDauThau_DSGoiThauRepository : Repository<TD_KeHoachDauThau_DSGoiThau>, ITD_KeHoachDauThau_DSGoiThauRepository
    {
        private readonly ILog _logger;
        private const string TableName = "TD_KeHoachDauThau_DSGoiThau";
        private static readonly string NganhDuocConn = ConfigurationManager.ConnectionStrings["NganhDuoc.ConnString"].ConnectionString;

        public TD_KeHoachDauThau_DSGoiThauRepository(ILog logger) : base(TableName, NganhDuocConn)
        {
            _logger = logger;
        }
        public IEnumerable<TD_KeHoachDauThau_DSGoiThau> NganhDuoc_TD_KeHoachDauThau_DSGoiThau_GetByKeHoachDauThauID(long KeHoachDauThauId)
        {
            try
            {
                using (IDbConnection conns = Connection)
                {
                    conns.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("KeHoachDauThauId", KeHoachDauThauId, DbType.Int64, ParameterDirection.Input);
                    var datas = conns.Query<TD_KeHoachDauThau_DSGoiThau>("NganhDuoc_TD_KeHoachDauThau_DSGoiThau_GetByKeHoachDauThauID"
                        , parameters, commandType: CommandType.StoredProcedure);

                    var lstHT = datas as IList<TD_KeHoachDauThau_DSGoiThau> ?? datas.ToList();

                    return lstHT;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return null;
            }
        }
        public bool NganhDuoc_TD_KeHoachDauThau_DSGoiThau_Ins(List<TD_KeHoachDauThau_DSGoiThau> lstmodel, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                foreach (var model in lstmodel)
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("KeHoachDauThauId", model.KeHoachDauThauId, DbType.Int64, ParameterDirection.Input);
                    parameters.Add("TenGoiThau", model.TenGoiThau, DbType.String, ParameterDirection.Input);
                    parameters.Add("GiaGoiThau", model.GiaGoiThau, DbType.String, ParameterDirection.Input);
                    parameters.Add("HinhThucLuaChon", model.HinhThucLuaChon, DbType.String, ParameterDirection.Input);
                    parameters.Add("PhuongThucLuaChon", model.PhuongThucLuaChon, DbType.String, ParameterDirection.Input);
                    parameters.Add("ThoiGianBatDauLuaChon", model.ThoiGianBatDauLuaChon, DbType.String, ParameterDirection.Input);
                    parameters.Add("LoaiHopDong", model.LoaiHopDong, DbType.String, ParameterDirection.Input);
                    parameters.Add("ThoiGianThucHienHD", model.ThoiGianThucHienHD, DbType.String, ParameterDirection.Input);
                    parameters.Add("GhiChu", model.GhiChu, DbType.String, ParameterDirection.Input);
                    parameters.Add("ACTIVE", model.Active, DbType.Int32, ParameterDirection.Input);                    
                    parameters.Add("DonViID", model.DonViID, DbType.Int64, ParameterDirection.Input);
                    parameters.Add("CreateUserId", model.CreateUserId, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("CreateDate", model.CreateDate, DbType.DateTime, ParameterDirection.Input);
                    parameters.Add("UpdateUserId", model.UpdateUserId, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("UpdateDate", model.UpdateDate, DbType.DateTime, ParameterDirection.Input);
                    conns.ExecuteScalar("NganhDuoc_TD_KeHoachDauThau_DSGoiThau_Ins", parameters, trans, commandType: CommandType.StoredProcedure);
                }
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return false;
            }
        }
        public bool NganhDuoc_TD_KeHoachDauThau_DSGoiThau_DelByKeHoachDauThauID(long KeHoachDauThauId, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("KeHoachDauThauId", KeHoachDauThauId, DbType.Int64, ParameterDirection.Input);

                conns.ExecuteScalar("NganhDuoc_TD_KeHoachDauThau_DSGoiThau_DelByKeHoachDauThauID", parameters, trans, commandType: CommandType.StoredProcedure);
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
