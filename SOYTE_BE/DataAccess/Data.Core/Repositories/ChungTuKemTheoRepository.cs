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
    public class ChungTuKemTheoRepository : Repository<ChungTuKemTheo>, IChungTuKemTheoRepository
    {
        private readonly ILog _logger;
        private const string TableName = "ChungTuKemTheo";
        private static readonly string MotCuaConn = ConfigurationManager.ConnectionStrings["MotCua.ConnString"].ConnectionString;


        public ChungTuKemTheoRepository(ILog logger) : base(TableName, MotCuaConn)
        {
            _logger = logger;
        }
        //--------------------------------------------------//
       
        public IEnumerable<ChungTuKemTheo> MotCua_ChungTuKemTheo_GetByHoSoID(long HoSoID)
        {
            try
            {
                using (IDbConnection conns = Connection)
                {
                    conns.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("HoSoID", HoSoID, DbType.Int64, ParameterDirection.Input);

                    var retval = conns.Query<ChungTuKemTheo>("MotCua_ChungTuKemTheo_GetByHoSoID", parameters
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
        
        public bool MotCua_ChungTuKemTheo_Ins(ChungTuKemTheo model, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("TenChungTu", model.TenChungTu, DbType.String, ParameterDirection.Input);
                parameters.Add("SLBanChinh", model.SLBanChinh, DbType.Int32, ParameterDirection.Input);
                parameters.Add("SLBanSao", model.SLBanSao, DbType.Int32, ParameterDirection.Input);
                parameters.Add("SLPhoto", model.SLPhoto, DbType.Int32, ParameterDirection.Input);
                parameters.Add("GhiChu", model.GhiChu, DbType.String, ParameterDirection.Input);
                parameters.Add("HoSoID", model.HoSoID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("AttachFile", model.AttachFile, DbType.String, ParameterDirection.Input);

                conns.ExecuteScalar("MotCua_ChungTuKemTheo_Ins", parameters, trans, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return false;
            }
        }
        public bool MotCua_ChungTuKemTheo_UpdID(ChungTuKemTheo model, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("ChungTuKemTheoID", model.ChungTuKemTheoID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("TenChungTu", model.TenChungTu, DbType.String, ParameterDirection.Input);
                parameters.Add("SLBanChinh", model.SLBanChinh, DbType.Int32, ParameterDirection.Input);
                parameters.Add("SLBanSao", model.SLBanSao, DbType.Int32, ParameterDirection.Input);
                parameters.Add("SLPhoto", model.SLPhoto, DbType.Int32, ParameterDirection.Input);
                parameters.Add("GhiChu", model.GhiChu, DbType.String, ParameterDirection.Input);
                parameters.Add("HoSoID", model.HoSoID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("AttachFile", model.AttachFile, DbType.String, ParameterDirection.Input);

                conns.ExecuteScalar("MotCua_ChungTuKemTheo_UpdID", parameters, trans, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return false;
            }
        }

        public bool MotCua_ChungTuKemTheo_DelAllByHoSoID(long HoSoID, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("HoSoID", HoSoID, DbType.Int64, ParameterDirection.Input);

                conns.ExecuteScalar("MotCua_ChungTuKemTheo_DelAllByHoSoID", parameters, trans, commandType: CommandType.StoredProcedure);
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