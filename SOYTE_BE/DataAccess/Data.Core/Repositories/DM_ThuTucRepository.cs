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
    public class DM_ThuTucRepository : Repository<DM_ThuTuc>, IDM_ThuTucRepository
    {
        private readonly ILog _logger;
        private const string TableName = "DM_ThuTuc";
        private static readonly string MotCuaConn = ConfigurationManager.ConnectionStrings["MotCua.ConnString"].ConnectionString;


        public DM_ThuTucRepository(ILog logger) : base(TableName, MotCuaConn)
        {
            _logger = logger;
        }
        //--------------------------------------------------//
        public IEnumerable<DM_ThuTuc> MotCua_DM_ThuTuc_GetByLinhVucID(int LinhVucID)
        {
            try
            {
                using (IDbConnection conns = Connection)
                {
                    conns.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("LinhVucID", LinhVucID, DbType.Int32, ParameterDirection.Input);

                    var retval = conns.Query<DM_ThuTuc>("MotCua_DM_ThuTuc_GetByLinhVucID", parameters
                        , commandType: CommandType.StoredProcedure);
                    return retval;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return null;
            }
        }
        public DM_ThuTuc MotCua_DM_ThuTuc_GetByThuTucID(int ThuTucID)
        {
            try
            {
                using (IDbConnection conns = Connection)
                {
                    conns.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("ThuTucID", ThuTucID, DbType.Int32, ParameterDirection.Input);

                    var retval = conns.Query<DM_ThuTuc>("MotCua_DM_ThuTuc_GetByThuTucID", parameters
                        , commandType: CommandType.StoredProcedure);
                    return retval.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return null;
            }
        }
        public IEnumerable<DM_ThuTucList> MotCua_DM_ThuTuc_List(string tuKhoa, int pageIndex, int pageSize, out int totalItems)
        {
            try
            {
                using (var conn = Connection)
                {
                    conn.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("tuKhoa", tuKhoa, DbType.String, ParameterDirection.Input);
                    parameters.Add("pageIndex", pageIndex, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("pageSize", pageSize, DbType.Int32, ParameterDirection.Input);

                    var datas = conn.Query<DM_ThuTucList>("MotCua_DM_ThuTuc_List",
                        parameters,
                        commandType: CommandType.StoredProcedure);

                    var dM_ThuTucList = datas as IList<DM_ThuTucList> ??
                                                          datas.ToList();
                    totalItems = dM_ThuTucList.FirstOrDefault() != null
                        ? dM_ThuTucList.First().TotalItems.Value
                        : 0;
                    return dM_ThuTucList;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                totalItems = 0;
                return null;
            }
        }
        public int MotCua_DM_ThuTuc_Ins(DM_ThuTuc model, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("LinhVucID", model.LinhVucID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("TenThuTuc", model.TenThuTuc, DbType.String, ParameterDirection.Input);
                parameters.Add("SoNgayGiaiQuyet", model.SoNgayGiaiQuyet, DbType.Int32, ParameterDirection.Input);
                parameters.Add("ThoiGianNhacDenHan", model.ThoiGianNhacDenHan, DbType.Int32, ParameterDirection.Input);
                parameters.Add("Used", model.Used, DbType.Boolean, ParameterDirection.Input);
                parameters.Add("LoaiCapPhepID", model.LoaiCapPhepID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("MaThuTuc", model.MaThuTuc, DbType.String, ParameterDirection.Input);
                parameters.Add("LePhi", model.LePhi, DbType.Double, ParameterDirection.Input);
                parameters.Add("funcLoad", model.funcLoad, DbType.String, ParameterDirection.Input);
                parameters.Add("funcSave", model.funcSave, DbType.String, ParameterDirection.Input);
                parameters.Add("MapURL", model.MapURL, DbType.String, ParameterDirection.Input);

                var thuTucID = conns.ExecuteScalar("MotCua_DM_ThuTuc_Ins", parameters, trans, commandType: CommandType.StoredProcedure);
                if (thuTucID != null)
                    return Convert.ToInt32(thuTucID);
                return -1;                
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return -1;
            }
        }
        public bool MotCua_DM_ThuTuc_UpdID(DM_ThuTuc model, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("ThuTucID", model.ThuTucID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("LinhVucID", model.LinhVucID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("TenThuTuc", model.TenThuTuc, DbType.String, ParameterDirection.Input);
                parameters.Add("SoNgayGiaiQuyet", model.SoNgayGiaiQuyet, DbType.Int32, ParameterDirection.Input);
                parameters.Add("ThoiGianNhacDenHan", model.ThoiGianNhacDenHan, DbType.Int32, ParameterDirection.Input);
                parameters.Add("Used", model.Used, DbType.Boolean, ParameterDirection.Input);
                parameters.Add("LoaiCapPhepID", model.LoaiCapPhepID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("MaThuTuc", model.MaThuTuc, DbType.String, ParameterDirection.Input);
                parameters.Add("LePhi", model.LePhi, DbType.Double, ParameterDirection.Input);

                conns.ExecuteScalar("MotCua_DM_ThuTuc_UpdID", parameters, trans, commandType: CommandType.StoredProcedure);
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