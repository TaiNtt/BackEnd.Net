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
    public class DM_GoiYRepository : Repository<DM_GoiY>, IDM_GoiYRepository
    {
        private readonly ILog _logger;
        private const string TableName = "DM_GoiY";
        private static readonly string DBMasterConn = ConfigurationManager.ConnectionStrings["DBMaster.ConnString"].ConnectionString;


        public DM_GoiYRepository(ILog logger) : base(TableName, DBMasterConn)
        {
            _logger = logger;
        }
        //--------------------------------------------------//
        public IEnumerable<DM_GoiY> DBMaster_DM_GoiY_GetByLoaiGoiYID(int loaiGoiYID, int thuTucId, string search)
        {
            try
            {
                using (IDbConnection conns = Connection)
                {
                    conns.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("LoaiGoiYID", loaiGoiYID, DbType.Int64, ParameterDirection.Input);
                    parameters.Add("ThuTucID", thuTucId, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("Search", search, DbType.String, ParameterDirection.Input);
                    var datas = conns.Query<DM_GoiY>("DBMaster_DM_GoiY_GetByLoaiGoiYID", parameters, commandType: CommandType.StoredProcedure);
                    var lstdm = datas as IList<DM_GoiY> ?? datas.ToList();

                    return lstdm;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return null;
            }
        }
        public IEnumerable<DM_GoiY> DBMaster_DM_GoiY_GetByLoaiGoiYID(int loaiGoiYID, int thuTucId, string search, IDbConnection conns)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("LoaiGoiYID", loaiGoiYID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("ThuTucID", thuTucId, DbType.Int32, ParameterDirection.Input);
                parameters.Add("Search", search, DbType.String, ParameterDirection.Input);
                var datas = conns.Query<DM_GoiY>("DBMaster_DM_GoiY_GetByLoaiGoiYID", parameters, commandType: CommandType.StoredProcedure);

                var lstdm = datas as IList<DM_GoiY> ?? datas.ToList();

                return lstdm;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return null;
            }
        }
        public int DBMaster_DM_GoiY_PopupIns(DM_GoiYSave model, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("ThuTucID", model.ThuTucID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("LoaiGoiYID", model.LoaiGoiYID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("Ten", model.Ten, DbType.String, ParameterDirection.Input);
                parameters.Add("Used", model.Used, DbType.Boolean, ParameterDirection.Input);
                var Id = conns.ExecuteScalar("DBMaster_DM_GoiY_PopupIns", parameters, trans, commandType: CommandType.StoredProcedure);
                if (Id != null)
                    return Convert.ToInt32(Id);
                return -1;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return -1;
            }
        }
        public int DBMaster_DM_GoiY_PopupUpd(DM_GoiYSave model, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("GoiYID", model.GoiYID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("ThuTucID", model.ThuTucID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("LoaiGoiYID", model.LoaiGoiYID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("Ten", model.Ten, DbType.String, ParameterDirection.Input);
                parameters.Add("Used", model.Used, DbType.Boolean, ParameterDirection.Input);
                conns.ExecuteScalar("DBMaster_DM_GoiY_PopupUpd", parameters, trans, commandType: CommandType.StoredProcedure);
                return model.GoiYID;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return -1;
            }
        }
        public bool DBMaster_DM_GoiY_PopupDel(int GoiYID, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("GoiYID", GoiYID, DbType.Int32, ParameterDirection.Input);
                conns.ExecuteScalar("DBMaster_DM_GoiY_PopupDel", parameters, trans, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return false;
            }
        }
        public IEnumerable<DM_GoiYList> DBMaster_DM_GoiY_List(int? LoaiCapPhepID, int? LoaiGoiYID, string tuKhoa, int pageIndex, int pageSize, out int totalItems)
        {
            try
            {
                using (var conn = Connection)
                {
                    conn.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("LoaiCapPhepID", LoaiCapPhepID, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("LoaiGoiYID", LoaiGoiYID, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("tuKhoa", tuKhoa, DbType.String, ParameterDirection.Input);
                    parameters.Add("pageIndex", pageIndex, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("pageSize", pageSize, DbType.Int32, ParameterDirection.Input);

                    var datas = conn.Query<DM_GoiYList>("DBMaster_DM_GoiY_List",
                        parameters,
                        commandType: CommandType.StoredProcedure);

                    var dM_GoiYList = datas as IList<DM_GoiYList> ??
                                                          datas.ToList();
                    totalItems = dM_GoiYList.FirstOrDefault() != null
                        ? dM_GoiYList.First().TotalItems.Value
                        : 0;
                    return dM_GoiYList;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                totalItems = 0;
                return null;
            }
        }
        public DM_GoiY DBMaster_DM_GoiY_GetByGoiYID(int GoiYID)
        {
            try
            {
                using (IDbConnection conns = Connection)
                {
                    conns.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("GoiYID", GoiYID, DbType.Int32, ParameterDirection.Input);

                    var retval = conns.Query<DM_GoiY>("DBMaster_DM_GoiY_GetByGoiYID", parameters
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
        public bool DBMaster_DM_GoiY_Ins(DM_GoiY model, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("LoaiCapPhepID", model.LoaiCapPhepID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("LoaiGoiYID", model.LoaiGoiYID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("Ten", model.Ten, DbType.String, ParameterDirection.Input);
                parameters.Add("Used", model.Used, DbType.Boolean, ParameterDirection.Input);

                conns.ExecuteScalar("DBMaster_DM_GoiY_Ins", parameters, trans, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return false;
            }
        }
        public bool DBMaster_DM_GoiY_UpdByGoiYID(DM_GoiY model, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("GoiYID", model.GoiYID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("LoaiCapPhepID", model.LoaiCapPhepID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("LoaiGoiYID", model.LoaiGoiYID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("Ten", model.Ten, DbType.String, ParameterDirection.Input);
                parameters.Add("Used", model.Used, DbType.Boolean, ParameterDirection.Input);

                conns.ExecuteScalar("DBMaster_DM_GoiY_UpdByGoiYID", parameters, trans, commandType: CommandType.StoredProcedure);
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
