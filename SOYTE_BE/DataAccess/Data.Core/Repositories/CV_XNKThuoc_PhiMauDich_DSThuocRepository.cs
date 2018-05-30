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
    public class CV_XNKThuoc_PhiMauDich_DSThuocRepository : Repository<CV_XNKThuoc_PhiMauDich_DSThuoc>, ICV_XNKThuoc_PhiMauDich_DSThuocRepository
    {
        private readonly ILog _logger;
        private const string TableName = "CV_XNKThuoc_PhiMauDich_DSThuoc";
        private static readonly string NganhDuocConn = ConfigurationManager.ConnectionStrings["NganhDuoc.ConnString"].ConnectionString;

        public CV_XNKThuoc_PhiMauDich_DSThuocRepository(ILog logger) : base(TableName, NganhDuocConn)
        {
            _logger = logger;
        }
        public IEnumerable<CV_XNKThuoc_PhiMauDich_DSThuoc> NganhDuoc_CV_XNKThuoc_PhiMauDich_DSThuoc_GetByXNKThuocPhiMauDichId(long XNKThuocPhiMauDichId)
        {
            try
            {
                using (IDbConnection conns = Connection)
                {
                    conns.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("XNKThuocPhiMauDichId", XNKThuocPhiMauDichId, DbType.Int64, ParameterDirection.Input);
                    var datas = conns.Query<CV_XNKThuoc_PhiMauDich_DSThuoc>("NganhDuoc_CV_XNKThuoc_PhiMauDich_DSThuoc_GetByXNKThuocPhiMauDichId"
                        , parameters, commandType: CommandType.StoredProcedure);

                    var lstHT = datas as IList<CV_XNKThuoc_PhiMauDich_DSThuoc> ?? datas.ToList();

                    return lstHT;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return null;
            }
        }
        public bool NganhDuoc_CV_XNKThuoc_PhiMauDich_DSThuoc_Ins(List<CV_XNKThuoc_PhiMauDich_DSThuoc> lstmodel, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                foreach (var model in lstmodel)
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("XNKThuocPhiMauDichId", model.XNKThuocPhiMauDichId, DbType.Int64, ParameterDirection.Input);
                    parameters.Add("TenThuoc", model.TenThuoc, DbType.String, ParameterDirection.Input);
                    parameters.Add("TinhChatThuoc", model.TinhChatThuoc, DbType.String, ParameterDirection.Input);
                    parameters.Add("QuyCachDongGoi", model.QuyCachDongGoi, DbType.String, ParameterDirection.Input);
                    parameters.Add("SoLuong", model.SoLuong, DbType.String, ParameterDirection.Input);
                    parameters.Add("GhiChu", model.GhiChu, DbType.String, ParameterDirection.Input);
                    parameters.Add("Active", model.Active, DbType.Int32, ParameterDirection.Input);                    
                    parameters.Add("DonViID", model.DonViID, DbType.Int64, ParameterDirection.Input);
                    parameters.Add("CreateUserId", model.CreateUserId, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("CreateDate", model.CreateDate, DbType.DateTime, ParameterDirection.Input);
                    parameters.Add("UpdateUserId", model.UpdateUserId, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("UpdateDate", model.UpdateDate, DbType.DateTime, ParameterDirection.Input);
                    conns.ExecuteScalar("NganhDuoc_CV_XNKThuoc_PhiMauDich_DSThuoc_Ins", parameters, trans, commandType: CommandType.StoredProcedure);
                }
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return false;
            }
        }
        public bool NganhDuoc_CV_XNKThuoc_PhiMauDich_DSThuoc_DelByXNKThuocPhiMauDichId(long XNKThuocPhiMauDichId, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("XNKThuocPhiMauDichId", XNKThuocPhiMauDichId, DbType.Int64, ParameterDirection.Input);

                conns.ExecuteScalar("NganhDuoc_CV_XNKThuoc_PhiMauDich_DSThuoc_DelByXNKThuocPhiMauDichId", parameters, trans, commandType: CommandType.StoredProcedure);
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
