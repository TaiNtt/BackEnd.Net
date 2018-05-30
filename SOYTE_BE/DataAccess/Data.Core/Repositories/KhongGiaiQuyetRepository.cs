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
    public class KhongGiaiQuyetRepository : Repository<KhongGiaiQuyet>, IKhongGiaiQuyetRepository
    {
        private readonly ILog _logger;
        private const string TableName = "KhongGiaiQuyet";
        private static readonly string MotCuaConn = ConfigurationManager.ConnectionStrings["MotCua.ConnString"].ConnectionString;

        public KhongGiaiQuyetRepository(ILog logger) : base(TableName, MotCuaConn)
        {
            _logger = logger;
        }

        public bool MotCua_KhongGiaiQuyet_Ins(KhongGiaiQuyet model, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("QuaTrinhXuLyID", model.QuaTrinhXuLyID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("LyDoKhongGiaiQuyet", model.LyDoKhongGiaiQuyet, DbType.String, ParameterDirection.Input);

                conns.ExecuteScalar("MotCua_KhongGiaiQuyet_Ins", parameters, trans, commandType: CommandType.StoredProcedure);
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
