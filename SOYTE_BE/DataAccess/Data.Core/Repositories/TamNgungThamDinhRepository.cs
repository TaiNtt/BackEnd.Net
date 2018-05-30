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
    public class TamNgungThamDinhRepository : Repository<TamNgungThamDinh>, ITamNgungThamDinhRepository
    {
        private readonly ILog _logger;
        private const string TableName = "TamNgungThamDinh";
        private static readonly string MotCuaConn = ConfigurationManager.ConnectionStrings["MotCua.ConnString"].ConnectionString;

        public TamNgungThamDinhRepository(ILog logger) : base(TableName, MotCuaConn)
        {
            _logger = logger;
        }

        public bool MotCua_TamNgungThamDinh_Ins(TamNgungThamDinh model, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("QuaTrinhXuLyID", model.QuaTrinhXuLyID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("NgayYeuCauTamNgung", model.NgayYeuCauTamNgung, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("LyDoTamNgung", model.LyDoTamNgung, DbType.String, ParameterDirection.Input);

                conns.ExecuteScalar("MotCua_TamNgungThamDinh_Ins", parameters, trans, commandType: CommandType.StoredProcedure);
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
