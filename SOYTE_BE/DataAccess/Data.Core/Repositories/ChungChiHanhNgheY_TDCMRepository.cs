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
    public class ChungChiHanhNgheY_TDCMRepository : Repository<ChungChiHanhNgheY_TDCM>, IChungChiHanhNgheY_TDCMRepository
    {
        private readonly ILog _logger;
        private const string TableName = "ChungChiHanhNgheY_TDCM";
        private static readonly string NganhYConn = ConfigurationManager.ConnectionStrings["NganhY.ConnString"].ConnectionString;

        public ChungChiHanhNgheY_TDCMRepository(ILog logger) : base(TableName, NganhYConn)
        {
            _logger = logger;
        }

        public IEnumerable<ChungChiHanhNgheY_TDCM> NganhY_ChungChiHanhNgheY_TDCM_GetByCCHNYID(long ChungChiHanhNgheYId)
        {
            try
            {
                using (IDbConnection conns = Connection)
                {
                    conns.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("ChungChiHanhNgheYId", ChungChiHanhNgheYId, DbType.Int64, ParameterDirection.Input);
                    var datas = conns.Query<ChungChiHanhNgheY_TDCM>("NganhY_ChungChiHanhNgheY_TDCM_GetByCCHNYID", parameters, commandType: CommandType.StoredProcedure);

                    var lstTDCM = datas as IList<ChungChiHanhNgheY_TDCM> ?? datas.ToList();

                    return lstTDCM;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return null;
            }
        }

        public bool NganhY_ChungChiHanhNgheY_TDCM_Ins(List<ChungChiHanhNgheY_TDCM> lstmodel, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                foreach (var model in lstmodel)
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("ChungChiHanhNgheYID", model.ChungChiHanhNgheYID, DbType.Int64, ParameterDirection.Input);
                    parameters.Add("TrinhDoChuyenMonID", model.TrinhDoChuyenMonID, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("NamTotNghiep", model.NamTotNghiep, DbType.String, ParameterDirection.Input);
                    parameters.Add("TenTruongDaoTao", model.TenTruongDaoTao, DbType.String, ParameterDirection.Input);
                    conns.ExecuteScalar("NganhY_ChungChiHanhNgheY_TDCM_Ins", parameters, trans, commandType: CommandType.StoredProcedure);
                }
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return false;
            }
        }

        public bool NganhY_ChungChiHanhNgheY_TDCM_DelByCCHNYID(long ChungChiHanhNgheYID, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("ChungChiHanhNgheYID", ChungChiHanhNgheYID, DbType.Int64, ParameterDirection.Input);

                conns.ExecuteScalar("NganhY_ChungChiHanhNgheY_TDCM_DelByCCHNYID", parameters, trans, commandType: CommandType.StoredProcedure);
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
