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
    public class CP_Thuoc_VienTro_DMThuocRepository : Repository<CP_Thuoc_VienTro_DMThuoc>, ICP_Thuoc_VienTro_DMThuocRepository
    {
        private readonly ILog _logger;
        private const string TableName = "CP_Thuoc_VienTro_DMThuoc";
        private static readonly string NganhDuocConn = ConfigurationManager.ConnectionStrings["NganhDuoc.ConnString"].ConnectionString;

        public CP_Thuoc_VienTro_DMThuocRepository(ILog logger) : base(TableName, NganhDuocConn)
        {
            _logger = logger;
        }
        public IEnumerable<CP_Thuoc_VienTro_DMThuoc> NganhDuoc_CP_Thuoc_VienTro_DMThuoc_GetByThuocVienTroId(long ThuocVienTroId)
        {
            try
            {
                using (IDbConnection conns = Connection)
                {
                    conns.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("ThuocVienTroId", ThuocVienTroId, DbType.Int64, ParameterDirection.Input);
                    var datas = conns.Query<CP_Thuoc_VienTro_DMThuoc>("NganhDuoc_CP_Thuoc_VienTro_DMThuoc_GetByThuocVienTroId"
                        , parameters, commandType: CommandType.StoredProcedure);

                    var lstHT = datas as IList<CP_Thuoc_VienTro_DMThuoc> ?? datas.ToList();

                    return lstHT;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return null;
            }
        }
        public bool NganhDuoc_CP_Thuoc_VienTro_DMThuoc_Ins(List<CP_Thuoc_VienTro_DMThuoc> lstmodel, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                foreach (var model in lstmodel)
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("ThuocVienTroId", model.ThuocVienTroId, DbType.Int64, ParameterDirection.Input);
                    parameters.Add("TenThuoc", model.TenThuoc, DbType.String, ParameterDirection.Input);
                    parameters.Add("DonViTinh", model.DonViTinh, DbType.String, ParameterDirection.Input);
                    parameters.Add("SoLuong", model.SoLuong, DbType.String, ParameterDirection.Input);
                    parameters.Add("HoatChatChinh", model.HoatChatChinh, DbType.String, ParameterDirection.Input);
                    parameters.Add("HanDung", model.HanDung, DbType.String, ParameterDirection.Input);
                    parameters.Add("TenCongTySX", model.TenCongTySX, DbType.String, ParameterDirection.Input);
                    parameters.Add("GhiChu", model.GhiChu, DbType.String, ParameterDirection.Input);
                    parameters.Add("ACTIVE", model.Active, DbType.Int32, ParameterDirection.Input);                    
                    parameters.Add("DonViID", model.DonViID, DbType.Int64, ParameterDirection.Input);
                    parameters.Add("CreateUserId", model.CreateUserId, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("CreateDate", model.CreateDate, DbType.DateTime, ParameterDirection.Input);
                    parameters.Add("UpdateUserId", model.UpdateUserId, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("UpdateDate", model.UpdateDate, DbType.DateTime, ParameterDirection.Input);
                    conns.ExecuteScalar("NganhDuoc_CP_Thuoc_VienTro_DMThuoc_Ins", parameters, trans, commandType: CommandType.StoredProcedure);
                }
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return false;
            }
        }
        public bool NganhDuoc_CP_Thuoc_VienTro_DMThuoc_DelThuocVienTroId(long ThuocVienTroId, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("ThuocVienTroId", ThuocVienTroId, DbType.Int64, ParameterDirection.Input);

                conns.ExecuteScalar("NganhDuoc_CP_Thuoc_VienTro_DMThuoc_DelThuocVienTroId", parameters, trans, commandType: CommandType.StoredProcedure);
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
