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
    public class GiayPhepHoatDongKCB_DSNhanSuRepository : Repository<GiayPhepHoatDongKCB_DSNhanSu>, IGiayPhepHoatDongKCB_DSNhanSuRepository
    {
        private readonly ILog _logger;
        private const string TableName = "GiayPhepHoatDongKCB_DSNhanSu";
        private static readonly string NganhYConn = ConfigurationManager.ConnectionStrings["NganhY.ConnString"].ConnectionString;

        public GiayPhepHoatDongKCB_DSNhanSuRepository(ILog logger) : base(TableName, NganhYConn)
        {
            _logger = logger;
        }

        public IEnumerable<GiayPhepHoatDongKCB_DSNhanSu> NganhY_GiayPhepHoatDongKCB_DSNhanSu_GetByGPID(long ChungChiHanhNgheYId)
        {
            try
            {
                using (IDbConnection conns = Connection)
                {
                    conns.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("ChungChiHanhNgheYId", ChungChiHanhNgheYId, DbType.Int64, ParameterDirection.Input);
                    var datas = conns.Query<GiayPhepHoatDongKCB_DSNhanSu>("NganhY_GiayPhepHoatDongKCB_DSNhanSu_GetByGPID", parameters, commandType: CommandType.StoredProcedure);

                    var lstNS = datas as IList<GiayPhepHoatDongKCB_DSNhanSu> ?? datas.ToList();

                    return lstNS;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return null;
            }
        }

        public bool NganhY_GiayPhepHoatDongKCB_DSNhanSu_Ins(List<GiayPhepHoatDongKCB_DSNhanSu> lstmodel, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                foreach (var model in lstmodel)
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("GiayPhepKhamChuaBenhID", model.GiayPhepKhamChuaBenhID, DbType.Int64, ParameterDirection.Input);
                    parameters.Add("HoTen", model.HoTen, DbType.String, ParameterDirection.Input);
                    parameters.Add("ChungChiHanhNgheYID", model.ChungChiHanhNgheYID, DbType.Int64, ParameterDirection.Input);                    
                    parameters.Add("ThoiGianLamViec", model.ThoiGianLamViec, DbType.String, ParameterDirection.Input);
                    parameters.Add("ViTriChuyenMonID", model.ViTriChuyenMonID, DbType.Int32, ParameterDirection.Input);
                    conns.ExecuteScalar("NganhY_GiayPhepHoatDongKCB_DSNhanSu_Ins", parameters, trans, commandType: CommandType.StoredProcedure);
                }
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return false;
            }
        }

        public bool NganhY_GiayPhepHoatDongKCB_DSNhanSu_DelByGPID(long GiayPhepKhamChuaBenhID, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("GiayPhepKhamChuaBenhID", GiayPhepKhamChuaBenhID, DbType.Int64, ParameterDirection.Input);

                conns.ExecuteScalar("NganhY_GiayPhepHoatDongKCB_DSNhanSu_DelByGPID", parameters, trans, commandType: CommandType.StoredProcedure);
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
