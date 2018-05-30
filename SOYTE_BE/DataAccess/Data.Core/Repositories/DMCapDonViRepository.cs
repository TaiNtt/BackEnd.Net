using Business.Entities;
using Dapper;
using Data.Core.Repositories.Base;
using Data.Core.Repositories.Interfaces;
using log4net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Data.Core.Repositories
{
    public class DMCapDonViRepository : Repository<DMCapDonVi>, IDMCapDonViRepository
    {
        private const string TableName = "DM_CapDonVi";
        private readonly ILog _logger;

        public DMCapDonViRepository(ILog logger) : base(TableName,"")
        {
            _logger = logger;
        }

        public IEnumerable<DMCapDonVi> GetDanhMucCapDonVi(int? pageSize, int? pageIndex)
        {
            try
            {
                using (IDbConnection conn = Connection)
                {
                    conn.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("@PageSize", pageSize, DbType.Int32);
                    parameters.Add("@PageIndex", pageIndex, DbType.Int32);
                    var result = conn.Query<DMCapDonVi>("PAKN_DM_CapDonVi", parameters, commandType: CommandType.StoredProcedure);
                    return result;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return new List<DMCapDonVi>();
            }
        }

        public List<DMCapDonVi> GetDMCapDonViConditionByPaged(string ten, bool? isActive, int pageSize, int pageIndex)
        {
            try
            {
                using (IDbConnection conn = Connection)
                {
                    conn.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("Ten", ten, DbType.String);
                    parameters.Add("IsActive", isActive, DbType.String);
                    parameters.Add("PageSize", pageSize, DbType.Int32);
                    parameters.Add("PageIndex", pageIndex, DbType.Int32);
                    var result = conn.Query<DMCapDonVi>("QT_DM_CapDonVi_ByCondition_GetPaged", parameters, commandType: CommandType.StoredProcedure);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return null;
            }
        }
    }
}
