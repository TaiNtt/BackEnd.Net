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
    public class CC_Duoc_TDCMRepository : Repository<CC_Duoc_TDCM>, ICC_Duoc_TDCMRepository
    {
        private readonly ILog _logger;
        private const string TableName = "CC_Duoc_TDCM";
        private static readonly string NganhDuocConn = ConfigurationManager.ConnectionStrings["NganhDuoc.ConnString"].ConnectionString;

        public CC_Duoc_TDCMRepository(ILog logger) : base(TableName, NganhDuocConn)
        {
            _logger = logger;
        }

        public IEnumerable<CC_Duoc_TDCM> NganhDuoc_CC_Duoc_TDCM_GetByChungChiDuocID(long ChungChiDuocID)
        {
            try
            {
                using (IDbConnection conns = Connection)
                {
                    conns.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("ChungChiDuocID", ChungChiDuocID, DbType.Int64, ParameterDirection.Input);
                    var datas = conns.Query<CC_Duoc_TDCM>("NganhDuoc_CC_Duoc_TDCM_GetByChungChiDuocID", parameters, commandType: CommandType.StoredProcedure);

                    var lstTDCM = datas as IList<CC_Duoc_TDCM> ?? datas.ToList();

                    return lstTDCM;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return null;
            }
        }

        public bool NganhDuoc_CC_Duoc_TDCM_Ins(List<CC_Duoc_TDCM> lstmodel, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                foreach (var model in lstmodel)
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("ChungChiDuocID", model.ChungChiDuocID, DbType.Int64, ParameterDirection.Input);
                    parameters.Add("TrinhDoChuyenMonID", model.TrinhDoChuyenMonID, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("NamTotNghiep", model.NamTotNghiep, DbType.String, ParameterDirection.Input);
                    parameters.Add("TenTruongDaoTao", model.TenTruongDaoTao, DbType.String, ParameterDirection.Input);
                    conns.ExecuteScalar("NganhDuoc_CC_Duoc_TDCM_Ins", parameters, trans, commandType: CommandType.StoredProcedure);
                }
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return false;
            }
        }

        public bool NganhDuoc_CC_Duoc_TDCM_DelByChungChiDuocID(long ChungChiDuocID, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("ChungChiDuocID", ChungChiDuocID, DbType.Int64, ParameterDirection.Input);

                conns.ExecuteScalar("NganhDuoc_CC_Duoc_TDCM_DelByChungChiDuocID", parameters, trans, commandType: CommandType.StoredProcedure);
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
