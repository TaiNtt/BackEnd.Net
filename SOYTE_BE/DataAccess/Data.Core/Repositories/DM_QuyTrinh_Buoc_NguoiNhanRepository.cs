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
    public class DM_QuyTrinh_Buoc_NguoiNhanRepository : Repository<DM_QuyTrinh_Buoc_NguoiNhan>, IDM_QuyTrinh_Buoc_NguoiNhanRepository
    {
        private readonly ILog _logger;
        private const string TableName = "DM_QuyTrinh_Buoc_NguoiNhan";
        private static readonly string MotCuaConn = ConfigurationManager.ConnectionStrings["MotCua.ConnString"].ConnectionString;


        public DM_QuyTrinh_Buoc_NguoiNhanRepository(ILog logger) : base(TableName, MotCuaConn)
        {
            _logger = logger;
        }
        //--------------------------------------------------//
        public DM_QuyTrinh_Buoc_NguoiNhan MotCua_DM_QuyTrinh_Buoc_NguoiNhan_GetByBuocID(int BuocID)
        {
            try
            {
                using (IDbConnection conns = Connection)
                {
                    conns.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("BuocID", BuocID, DbType.Int32, ParameterDirection.Input);

                    var retval = conns.Query<DM_QuyTrinh_Buoc_NguoiNhan>("MotCua_DM_QuyTrinh_Buoc_NguoiNhan_GetByBuocID", parameters
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
        public IEnumerable<DM_QuyTrinh_Buoc_NguoiNhan> MotCua_DM_QuyTrinh_Buoc_NguoiNhan_ListByBuocID(int BuocID)
        {
            try
            {
                using (IDbConnection conns = Connection)
                {
                    conns.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("BuocID", BuocID, DbType.Int32, ParameterDirection.Input);
                    var datas = conns.Query<DM_QuyTrinh_Buoc_NguoiNhan>("MotCua_DM_QuyTrinh_Buoc_NguoiNhan_GetByBuocID", parameters
                        , commandType: CommandType.StoredProcedure);

                    var lstdm = datas as IList<DM_QuyTrinh_Buoc_NguoiNhan> ?? datas.ToList();

                    return lstdm;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return null;
            }
        }
        public bool MotCua_DM_QuyTrinh_Buoc_NguoiNhan_Ins(DM_QuyTrinh_Buoc_NguoiNhan model, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("BuocID", model.BuocID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("NguoiNhanID", model.NguoiNhanID, DbType.Int32, ParameterDirection.Input);

                conns.ExecuteScalar("MotCua_DM_QuyTrinh_Buoc_NguoiNhan_Ins", parameters, trans, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return false;
            }
        }
        public bool MotCua_DM_QuyTrinh_Buoc_NguoiNhan_Del(int BuocID, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("BuocID", BuocID, DbType.Int32, ParameterDirection.Input);

                conns.ExecuteScalar("MotCua_DM_QuyTrinh_Buoc_NguoiNhan_Del", parameters, trans, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return false;
            }
        }
        public IEnumerable<MotCua_ListUsersRoles> MotCua_ListUsersRoles()
        {
            try
            {
                using (IDbConnection conns = Connection)
                {
                    conns.Open();
                    var datas = conns.Query<MotCua_ListUsersRoles>("MotCua_ListUsersRoles", commandType: CommandType.StoredProcedure);

                    var lst = datas as IList<MotCua_ListUsersRoles> ?? datas.ToList();

                    return lst;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return null;
            }
        }
    }
}