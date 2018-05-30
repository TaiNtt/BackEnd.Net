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
    public class CN_LuuHanhMyPham_SanPhamRepository : Repository<CN_LuuHanhMyPham_SanPham>, ICN_LuuHanhMyPham_SanPhamRepository
    {
        private readonly ILog _logger;
        private const string TableName = "CN_LuuHanhMyPham_SanPham";
        private static readonly string NganhDuocConn = ConfigurationManager.ConnectionStrings["NganhDuoc.ConnString"].ConnectionString;

        public CN_LuuHanhMyPham_SanPhamRepository(ILog logger) : base(TableName, NganhDuocConn)
        {
            _logger = logger;
        }
        public IEnumerable<CN_LuuHanhMyPham_SanPham> NganhDuoc_CN_LuuHanhMyPham_SanPham_GetByLuuHanhMyPhamId(long LuuHanhMyPhamId)
        {
            try
            {
                using (IDbConnection conns = Connection)
                {
                    conns.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("LuuHanhMyPhamId", LuuHanhMyPhamId, DbType.Int64, ParameterDirection.Input);
                    var datas = conns.Query<CN_LuuHanhMyPham_SanPham>("NganhDuoc_CN_LuuHanhMyPham_SanPham_GetByLuuHanhMyPhamId"
                        , parameters, commandType: CommandType.StoredProcedure);

                    var lstHT = datas as IList<CN_LuuHanhMyPham_SanPham> ?? datas.ToList();

                    return lstHT;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return null;
            }
        }
        public bool NganhDuoc_CN_LuuHanhMyPham_SanPham_Ins(List<CN_LuuHanhMyPham_SanPham> lstmodel, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                foreach (var model in lstmodel)
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("LuuHanhMyPhamId", model.LuuHanhMyPhamId, DbType.Int64, ParameterDirection.Input);
                    parameters.Add("TenSanPham", model.TenSanPham, DbType.String, ParameterDirection.Input);
                    parameters.Add("SoChungNhan", model.SoChungNhan, DbType.String, ParameterDirection.Input);
                    parameters.Add("SoHieuTieuChuan", model.SoHieuTieuChuan, DbType.String, ParameterDirection.Input);
                    parameters.Add("ThanhPhan", model.ThanhPhan, DbType.String, ParameterDirection.Input);
                    parameters.Add("NuocNhapKhau", model.NuocNhapKhau, DbType.String, ParameterDirection.Input);
                    parameters.Add("GhiChu", model.GhiChu, DbType.String, ParameterDirection.Input);
                    parameters.Add("ACTIVE", model.Active, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("DonViID", model.DonViID, DbType.Int64, ParameterDirection.Input);
                    parameters.Add("CreateUserId", model.CreateUserId, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("CreateDate", model.CreateDate, DbType.DateTime, ParameterDirection.Input);
                    parameters.Add("UpdateUserId", model.UpdateUserId, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("UpdateDate", model.UpdateDate, DbType.DateTime, ParameterDirection.Input);
                    conns.ExecuteScalar("NganhDuoc_CN_LuuHanhMyPham_SanPham_Ins", parameters, trans, commandType: CommandType.StoredProcedure);
                }
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return false;
            }
        }
        public bool NganhDuoc_CN_LuuHanhMyPham_SanPham_DelLuuHanhMyPhamId(long LuuHanhMyPhamId, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("LuuHanhMyPhamId", LuuHanhMyPhamId, DbType.Int64, ParameterDirection.Input);

                conns.ExecuteScalar("NganhDuoc_CN_LuuHanhMyPham_SanPham_DelLuuHanhMyPhamId", parameters, trans, commandType: CommandType.StoredProcedure);
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
