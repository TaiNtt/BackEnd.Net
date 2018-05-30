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
    //public class HoSoTiepNhanRepository : Repository<HoSoTiepNhan>, IHoSoTiepNhanRepository
    public class YeuCauBoSungRepository : Repository<YeuCauBoSung>, IYeuCauBoSungRepository
    {
        private readonly ILog _logger;
        private const string TableName = "YeuCauBoSung";
        private static readonly string MotCuaConn = ConfigurationManager.ConnectionStrings["MotCua.ConnString"].ConnectionString;

        public YeuCauBoSungRepository(ILog logger) : base(TableName, MotCuaConn)
        {
            _logger = logger;
        }

        public bool MotCua_YeuCauBoSung_Ins(YeuCauBoSung model, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("QuaTrinhXuLyID", model.QuaTrinhXuLyID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("NgayYeuCauBoSung", model.NgayYeuCauBoSung, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("ThongTinYeuCau", model.ThongTinYeuCau, DbType.String, ParameterDirection.Input);
                parameters.Add("DaBoSung", model.DaBoSung, DbType.Boolean, ParameterDirection.Input);

                conns.ExecuteScalar("MotCua_YeuCauBoSung_Ins", parameters, trans, commandType: CommandType.StoredProcedure);
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
