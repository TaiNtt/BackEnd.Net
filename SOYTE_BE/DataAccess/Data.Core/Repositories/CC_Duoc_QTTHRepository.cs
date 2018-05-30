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
    public class CC_Duoc_QTTHRepository : Repository<CC_Duoc_QTTH>, ICC_Duoc_QTTHRepository
    {
        private readonly ILog _logger;
        private const string TableName = "CC_Duoc_QTTH";
        private static readonly string NganhDuocConn = ConfigurationManager.ConnectionStrings["NganhDuoc.ConnString"].ConnectionString;

        public CC_Duoc_QTTHRepository(ILog logger) : base(TableName, NganhDuocConn)
        {
            _logger = logger;
        }

        public IEnumerable<CC_Duoc_QTTH> NganhDuoc_CC_Duoc_QTTH_GetByChungChiDuocID(long ChungChiDuocID)
        {
            try
            {
                using (IDbConnection conns = Connection)
                {
                    conns.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("ChungChiDuocID", ChungChiDuocID, DbType.Int64, ParameterDirection.Input);
                    var datas = conns.Query<CC_Duoc_QTTH>("NganhDuoc_CC_Duoc_QTTH_GetByChungChiDuocID", parameters, commandType: CommandType.StoredProcedure);

                    var lstTDCM = datas as IList<CC_Duoc_QTTH> ?? datas.ToList();

                    return lstTDCM;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return null;
            }
        }


        public bool NganhDuoc_CC_Duoc_QTTH_Ins(List<CC_Duoc_QTTH> lstmodel, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                foreach (var model in lstmodel)
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("ChungChiDuocID", model.ChungChiDuocID, DbType.Int64, ParameterDirection.Input);
                    parameters.Add("ThoiGianThucHanh", model.ThoiGianThucHanh, DbType.String, ParameterDirection.Input);
                    parameters.Add("TenDonViThucHanh", model.TenDonViThucHanh, DbType.String, ParameterDirection.Input);
                    parameters.Add("IsDonViNhaNuoc", model.IsDonViNhaNuoc, DbType.Boolean, ParameterDirection.Input);
                    conns.ExecuteScalar("NganhDuoc_CC_Duoc_QTTH_Ins", parameters, trans, commandType: CommandType.StoredProcedure);
                }
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return false;
            }
        }

        public bool NganhDuoc_CC_Duoc_QTTH_DelByChungChiDuocID(long ChungChiDuocID, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("ChungChiDuocID", ChungChiDuocID, DbType.Int64, ParameterDirection.Input);

                conns.ExecuteScalar("NganhDuoc_CC_Duoc_QTTH_DelByChungChiDuocID", parameters, trans, commandType: CommandType.StoredProcedure);
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
