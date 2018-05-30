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
    public class KhongPheDuyetRepository : Repository<KhongPheDuyet>, IKhongPheDuyetRepository
    {
        private readonly ILog _logger;
        private const string TableName = "KhongPheDuyet";
        private static readonly string MotCuaConn = ConfigurationManager.ConnectionStrings["MotCua.ConnString"].ConnectionString;

        public KhongPheDuyetRepository(ILog logger) : base(TableName, MotCuaConn)
        {
            _logger = logger;
        }

        public bool MotCua_KhongPheDuyet_Ins(KhongPheDuyet model, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("QuaTrinhXuLyID", model.QuaTrinhXuLyID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("LyDoKhongPheDuyet", model.LyDoKhongPheDuyet, DbType.String, ParameterDirection.Input);

                conns.ExecuteScalar("MotCua_KhongPheDuyet_Ins", parameters, trans, commandType: CommandType.StoredProcedure);
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
