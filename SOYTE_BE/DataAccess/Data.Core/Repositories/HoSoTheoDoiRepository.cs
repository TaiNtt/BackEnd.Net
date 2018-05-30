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
    public class HoSoTheoDoiRepository : Repository<HoSoTheoDoi>, IHoSoTheoDoiRepository
    {
        private readonly ILog _logger;
        private const string TableName = "HoSoTheoDoi";
        private static readonly string MotCuaConn = ConfigurationManager.ConnectionStrings["MotCua.ConnString"].ConnectionString;

        public HoSoTheoDoiRepository(ILog logger) : base(TableName, MotCuaConn)
        {
            _logger = logger;
        }
        //--------------------------------------------------//
        public long MotCua_HoSoTheoDoi_Ins(HoSoTheoDoi model, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("HoSoID", model.HoSoID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("UserID", model.UserID, DbType.Int64, ParameterDirection.Input);                

                var hoSoId = conns.ExecuteScalar("MotCua_HoSoTheoDoi_Ins", parameters, trans, commandType: CommandType.StoredProcedure);
                if (hoSoId != null)
                    return Convert.ToInt64(hoSoId);
                return -1;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return -1;
            }
        }
        public bool MotCua_HoSoTheoDoi_Del(long HoSoID, long UserID, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("HoSoID", HoSoID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("UserID", UserID, DbType.Int64, ParameterDirection.Input);

                conns.ExecuteScalar("MotCua_HoSoTheoDoi_Del", parameters, trans, commandType: CommandType.StoredProcedure);
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
