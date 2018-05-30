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
    public class DM_LyDoRepository : Repository<DM_LyDo>, IDM_LyDoRepository
    {
        private readonly ILog _logger;
        private const string TableName = "DM_LyDo";
        private static readonly string DBMasterConn = ConfigurationManager.ConnectionStrings["DBMaster.ConnString"].ConnectionString;


        public DM_LyDoRepository(ILog logger) : base(TableName, DBMasterConn)
        {
            _logger = logger;
        }
        //--------------------------------------------------//

        public IEnumerable<DM_LyDoList> DBMaster_DM_LyDo_List(int? LoaiCapPhepID, int? LoaiLyDoID, string tuKhoa, int pageIndex, int pageSize, out int totalItems)
        {
            try
            {
                using (var conn = Connection)
                {
                    conn.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("LoaiCapPhepID", LoaiCapPhepID, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("LoaiLyDoID", LoaiLyDoID, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("tuKhoa", tuKhoa, DbType.String, ParameterDirection.Input);
                    parameters.Add("pageIndex", pageIndex, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("pageSize", pageSize, DbType.Int32, ParameterDirection.Input);

                    var datas = conn.Query<DM_LyDoList>("DBMaster_DM_LyDo_List",
                        parameters,
                        commandType: CommandType.StoredProcedure);

                    var dM_LyDoList = datas as IList<DM_LyDoList> ??
                                                          datas.ToList();
                    totalItems = dM_LyDoList.FirstOrDefault() != null
                        ? dM_LyDoList.First().TotalItems.Value
                        : 0;
                    return dM_LyDoList;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                totalItems = 0;
                return null;
            }
        }
        public DM_LyDo DBMaster_DM_LyDo_GetByLyDoID(int LyDoID)
        {
            try
            {
                using (IDbConnection conns = Connection)
                {
                    conns.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("LyDoID", LyDoID, DbType.Int32, ParameterDirection.Input);

                    var retval = conns.Query<DM_LyDo>("DBMaster_DM_LyDo_GetByLyDoID", parameters
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
        public bool DBMaster_DM_LyDo_Ins(DM_LyDo model, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("LoaiCapPhepID", model.LoaiCapPhepID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("LoaiLyDoID", model.LoaiLyDoID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("Ten", model.Ten, DbType.String, ParameterDirection.Input);
                parameters.Add("Used", model.Used, DbType.Boolean, ParameterDirection.Input);

                conns.ExecuteScalar("DBMaster_DM_LyDo_Ins", parameters, trans, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return false;
            }
        }
        public bool DBMaster_DM_LyDo_UpdByLyDoID(DM_LyDo model, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("LyDoID", model.LyDoID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("LoaiCapPhepID", model.LoaiCapPhepID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("LoaiLyDoID", model.LoaiLyDoID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("Ten", model.Ten, DbType.String, ParameterDirection.Input);
                parameters.Add("Used", model.Used, DbType.Boolean, ParameterDirection.Input);

                conns.ExecuteScalar("DBMaster_DM_LyDo_UpdByLyDoID", parameters, trans, commandType: CommandType.StoredProcedure);
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
