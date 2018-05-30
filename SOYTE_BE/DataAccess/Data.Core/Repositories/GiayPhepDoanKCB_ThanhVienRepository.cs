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
    public class GiayPhepDoanKCB_ThanhVienRepository : Repository<GiayPhepDoanKCB_ThanhVien>, IGiayPhepDoanKCB_ThanhVienRepository
    {
        private readonly ILog _logger;
        private const string TableName = "GiayPhepDoanKCB_ThanhVien";
        private static readonly string NganhYConn = ConfigurationManager.ConnectionStrings["NganhY.ConnString"].ConnectionString;

        public GiayPhepDoanKCB_ThanhVienRepository(ILog logger) : base(TableName, NganhYConn)
        {
            _logger = logger;
        }

        public IEnumerable<GiayPhepDoanKCB_ThanhVien> NganhY_GiayPhepDoanKCB_ThanhVien_GetByGPID(long GiayPhepDoanKCBID)
        {
            try
            {
                using (IDbConnection conns = Connection)
                {
                    conns.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("GiayPhepDoanKCBID", GiayPhepDoanKCBID, DbType.Int64, ParameterDirection.Input);
                    var datas = conns.Query<GiayPhepDoanKCB_ThanhVien>("NganhY_GiayPhepDoanKCB_ThanhVien_GetByGPID", parameters, commandType: CommandType.StoredProcedure);

                    var lstTV = datas as IList<GiayPhepDoanKCB_ThanhVien> ?? datas.ToList();

                    return lstTV;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return null;
            }
        }

        public bool NganhY_GiayPhepDoanKCB_ThanhVien_Ins(List<GiayPhepDoanKCB_ThanhVien> lstmodel, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                foreach (var model in lstmodel)
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("GiayPhepDoanKCBID", model.GiayPhepDoanKCBID, DbType.Int64, ParameterDirection.Input);
                    parameters.Add("HoTen", model.HoTen, DbType.String, ParameterDirection.Input);
                    parameters.Add("SoCCHN", model.SoCCHN, DbType.String, ParameterDirection.Input);
                    parameters.Add("PhamViHoatDong", model.PhamViHoatDong, DbType.String, ParameterDirection.Input);
                    parameters.Add("ThoiGianDangKyKCB", model.ThoiGianDangKyKCB, DbType.DateTime, ParameterDirection.Input);
                    parameters.Add("ViTriChuyenMonID", model.ViTriChuyenMonID, DbType.Int32, ParameterDirection.Input);
                    conns.ExecuteScalar("NganhY_GiayPhepDoanKCB_ThanhVien_Ins", parameters, trans, commandType: CommandType.StoredProcedure);
                }
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return false;
            }
        }

        public bool NganhY_GiayPhepDoanKCB_ThanhVien_DelByGPID(long GiayPhepDoanKCBID, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("GiayPhepDoanKCBID", GiayPhepDoanKCBID, DbType.Int64, ParameterDirection.Input);

                conns.ExecuteScalar("NganhY_GiayPhepDoanKCB_ThanhVien_DelByGPID", parameters, trans, commandType: CommandType.StoredProcedure);
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
