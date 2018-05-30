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
    public class DM_LinhVucRepository : Repository<DM_LinhVuc>, IDM_LinhVucRepository
    {
        private readonly ILog _logger;
        private const string TableName = "DM_LinhVuc";
        private static readonly string MotCuaConn = ConfigurationManager.ConnectionStrings["MotCua.ConnString"].ConnectionString;


        public DM_LinhVucRepository(ILog logger) : base(TableName, MotCuaConn)
        {
            _logger = logger;
        }
        //--------------------------------------------------//
        public IEnumerable<DM_LinhVuc> MotCua_DM_LinhVuc_GetAll()
        {
            try
            {
                using (IDbConnection conns = Connection)
                {
                    conns.Open();
                    var datas = conns.Query<DM_LinhVuc>("MotCua_DM_LinhVuc_GetAll", commandType: CommandType.StoredProcedure);

                    var lstdm = datas as IList<DM_LinhVuc> ?? datas.ToList();

                    return lstdm;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return null;
            }
        }
        public DM_LinhVuc MotCua_DM_LinhVuc_GetByLinhVucID(int LinhVucID)
        {
            try
            {
                using (IDbConnection conns = Connection)
                {
                    conns.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("LinhVucID", LinhVucID, DbType.Int32, ParameterDirection.Input);

                    var retval = conns.Query<DM_LinhVuc>("MotCua_DM_LinhVuc_GetByLinhVucID", parameters
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
        public IEnumerable<DM_LinhVucList> MotCua_DM_LinhVuc_List(string tuKhoa, int pageIndex, int pageSize, out int totalItems)
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

                    var datas = conn.Query<DM_LinhVucList>("MotCua_DM_LinhVuc_List",
                        parameters,
                        commandType: CommandType.StoredProcedure);

                    var dM_LinhVucList = datas as IList<DM_LinhVucList> ??
                                                          datas.ToList();
                    totalItems = dM_LinhVucList.FirstOrDefault() != null
                        ? dM_LinhVucList.First().TotalItems.Value
                        : 0;
                    return dM_LinhVucList;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                totalItems = 0;
                return null;
            }
        }
        public bool MotCua_DM_LinhVuc_Ins(DM_LinhVuc model, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("TenLinhVuc", model.TenLinhVuc, DbType.String, ParameterDirection.Input);
                parameters.Add("MoTa", model.MoTa, DbType.String, ParameterDirection.Input);
                parameters.Add("Used", model.Used, DbType.Boolean, ParameterDirection.Input);
                parameters.Add("MaLinhVuc", model.MaLinhVuc, DbType.String, ParameterDirection.Input);

                conns.ExecuteScalar("MotCua_DM_LinhVuc_Ins", parameters, trans, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return false;
            }
        }
        public bool MotCua_DM_LinhVuc_UpdID(DM_LinhVuc model, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("LinhVucID", model.LinhVucID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("TenLinhVuc", model.TenLinhVuc, DbType.String, ParameterDirection.Input);
                parameters.Add("MoTa", model.MoTa, DbType.String, ParameterDirection.Input);
                parameters.Add("Used", model.Used, DbType.Boolean, ParameterDirection.Input);
                parameters.Add("MaLinhVuc", model.MaLinhVuc, DbType.String, ParameterDirection.Input);

                conns.ExecuteScalar("MotCua_DM_LinhVuc_UpdID", parameters, trans, commandType: CommandType.StoredProcedure);
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