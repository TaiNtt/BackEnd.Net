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
    public class ChungChiHanhNgheY_QTTHRepository : Repository<ChungChiHanhNgheY_QTTH>, IChungChiHanhNgheY_QTTHRepository
    {
        private readonly ILog _logger;
        private const string TableName = "ChungChiHanhNgheY_QTTH";
        private static readonly string NganhYConn = ConfigurationManager.ConnectionStrings["NganhY.ConnString"].ConnectionString;

        public ChungChiHanhNgheY_QTTHRepository(ILog logger) : base(TableName, NganhYConn)
        {
            _logger = logger;
        }

        public IEnumerable<ChungChiHanhNgheY_QTTH> NganhY_ChungChiHanhNgheY_QTTH_GetByCCHNYID(long ChungChiHanhNgheYId)
        {
            try
            {
                using (IDbConnection conns = Connection)
                {
                    conns.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("ChungChiHanhNgheYId", ChungChiHanhNgheYId, DbType.Int64, ParameterDirection.Input);
                    var datas = conns.Query<ChungChiHanhNgheY_QTTH>("NganhY_ChungChiHanhNgheY_QTTH_GetByCCHNYID", parameters, commandType: CommandType.StoredProcedure);

                    var lstTDCM = datas as IList<ChungChiHanhNgheY_QTTH> ?? datas.ToList();

                    return lstTDCM;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return null;
            }
        }


        public bool NganhY_ChungChiHanhNgheY_QTTH_Ins(List<ChungChiHanhNgheY_QTTH> lstmodel, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                foreach (var model in lstmodel)
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("ChungChiHanhNgheYID", model.ChungChiHanhNgheYID, DbType.Int64, ParameterDirection.Input);
                    parameters.Add("ThoiGianThucHanh", model.ThoiGianThucHanh, DbType.String, ParameterDirection.Input);
                    parameters.Add("TenDonViThucHanh", model.TenDonViThucHanh, DbType.String, ParameterDirection.Input);
                    parameters.Add("IsDonViNhaNuoc", model.IsDonViNhaNuoc, DbType.Boolean, ParameterDirection.Input);
                    conns.ExecuteScalar("NganhY_ChungChiHanhNgheY_QTTH_Ins", parameters, trans, commandType: CommandType.StoredProcedure);
                }
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return false;
            }
        }

        public bool NganhY_ChungChiHanhNgheY_QTTH_DelByCCHNYID(long ChungChiHanhNgheYID, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("ChungChiHanhNgheYID", ChungChiHanhNgheYID, DbType.Int64, ParameterDirection.Input);

                conns.ExecuteScalar("NganhY_ChungChiHanhNgheY_QTTH_DelByCCHNYID", parameters, trans, commandType: CommandType.StoredProcedure);
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
