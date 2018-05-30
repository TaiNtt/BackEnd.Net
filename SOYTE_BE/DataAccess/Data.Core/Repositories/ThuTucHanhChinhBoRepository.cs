using Business.Entities;
using Core.Common.Utilities;
using Dapper;
using Data.Core.Repositories.Interfaces;
using log4net;
using System;
using System.Collections.Generic;
using System.Data;
using Data.Core.Repositories.Base;

namespace Data.Core.Repositories
{
    public class ThuTucHanhChinhBoRepository : Repository<ThuTucHanhChinhBo>, IThuTucHanhChinhBoRepository
    {
        private readonly ILog _logger;
        private const string TableName = "ThuTucHanhChinh_Bo";

        public ThuTucHanhChinhBoRepository(ILog logger) : base(TableName,"")
        {
            _logger = logger;
        }

        #region Đồng bộ

        public bool AddTTHCByPaging(List<ThuTucHanhChinhBo> items)
        {
            try
            {
                using (IDbConnection conn = Connection)
                {
                    conn.Open();

                    var table = items.ToDataTable();

                    var parameters = new DynamicParameters();
                    parameters.AddDynamicParams(new { ThuTucTVP = table.AsTableValuedParameter() });

                    var readers = conn.Query("TTHC_ThuTucHanhChinh_Bo_ByPaging_Ins", parameters, commandType: CommandType.StoredProcedure);

                    return true;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return false;
            }
        }

        #endregion
    }
}
