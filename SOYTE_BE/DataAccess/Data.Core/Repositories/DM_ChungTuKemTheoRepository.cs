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
    public class DM_ChungTuKemTheoRepository : Repository<DM_ChungTuKemTheo>, IDM_ChungTuKemTheoRepository
    {
        private readonly ILog _logger;
        private const string TableName = "DM_ChungTuKemTheo";
        private static readonly string MotCuaConn = ConfigurationManager.ConnectionStrings["MotCua.ConnString"].ConnectionString;


        public DM_ChungTuKemTheoRepository(ILog logger) : base(TableName, MotCuaConn)
        {
            _logger = logger;
        }
        //--------------------------------------------------//
        public IEnumerable<DM_ChungTuKemTheo> MotCua_DM_ChungTuKemTheo_GetAll()
        {
            try
            {
                using (IDbConnection conns = Connection)
                {
                    conns.Open();
                    var datas = conns.Query<DM_ChungTuKemTheo>("MotCua_DM_ChungTuKemTheo_GetAll", commandType: CommandType.StoredProcedure);

                    var lstdm = datas as IList<DM_ChungTuKemTheo> ?? datas.ToList();

                    return lstdm;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return null;
            }
        }
        public IEnumerable<DM_ChungTuKemTheo> MotCua_DM_ChungTuKemTheo_GetByThuTucID(int ThuTucID)
        {
            try
            {
                using (IDbConnection conns = Connection)
                {
                    conns.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("ThuTucID", ThuTucID, DbType.Int32, ParameterDirection.Input);

                    var retval = conns.Query<DM_ChungTuKemTheo>("MotCua_DM_ChungTuKemTheo_GetByThuTucID", parameters
                        , commandType: CommandType.StoredProcedure);
                    return retval.ToList();
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return null;
            }
        }
        public bool MotCua_DM_ChungTuKemTheo_Ins(DM_ChungTuKemTheo model, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("ThuTucID", model.ThuTucID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("TenChungTu", model.TenChungTu, DbType.String, ParameterDirection.Input);
                parameters.Add("SLBanChinh", model.SLBanChinh, DbType.Int32, ParameterDirection.Input);
                parameters.Add("SLBanSao", model.SLBanSao, DbType.Int32, ParameterDirection.Input);
                parameters.Add("SLPhoto", model.SLPhoto, DbType.Int32, ParameterDirection.Input);

                conns.ExecuteScalar("MotCua_DM_ChungTuKemTheo_Ins", parameters, trans, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return false;
            }
        }
        public bool MotCua_DM_ChungTuKemTheo_DelByThuTucID(int ThuTucID, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("ThuTucID", ThuTucID, DbType.Int32, ParameterDirection.Input);

                conns.ExecuteScalar("MotCua_DM_ChungTuKemTheo_DelByThuTucID", parameters, trans, commandType: CommandType.StoredProcedure);
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