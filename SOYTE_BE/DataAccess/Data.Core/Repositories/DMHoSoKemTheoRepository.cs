using Data.Core.Repositories.Base;
using Business.Entities;
using Data.Core.Repositories.Interfaces;
using log4net;
using System.Collections.Generic;
using System.Data;
using Dapper;
using System.Linq;
using System;
using Business.Entities.ViewModels;

namespace Data.Core.Repositories
{
	public class DMHoSoKemTheoRepository : Repository<DM_HoSoKemTheo>, IDMHoSoKemTheoRepository
	{
		private const string TableName = "DM_HoSoKemTheo";
		private readonly ILog _logger;

		public DMHoSoKemTheoRepository(ILog logger) : base(TableName,"")
		{
			_logger = logger;
		}

		public List<HoSoKemTheoViewModel> GetDMHoSoKemTheoditionByPaged(bool hoSoMoi, string linhVucId, string hoSoKemTheo,
			int pageSize, int pageIndex)
		{
			try
			{
				using (IDbConnection conn = Connection)
				{
					conn.Open();
					var parameters = new DynamicParameters();
					parameters.Add("HoSoMoi", hoSoMoi, DbType.Boolean, ParameterDirection.Input, 512);
					parameters.Add("LinhVucId", linhVucId, DbType.String, ParameterDirection.Input, 128);
					parameters.Add("HoSoKemTheo", hoSoKemTheo, DbType.String, ParameterDirection.Input);
					parameters.Add("PageIndex", pageIndex, DbType.Int32, ParameterDirection.Input);
					parameters.Add("PageSize", pageSize, DbType.Int32, ParameterDirection.Input);
					var datas = conn.Query<HoSoKemTheoViewModel>("QT_DM_HoSoKemTheos_GetPaged", parameters, commandType: CommandType.StoredProcedure);
					return datas.ToList();
				}
			}
			catch (Exception ex)
			{
				_logger.Error(ex.Message);
				return null;
			}
		}

		public string AddDMHoSoKemTheo(DM_HoSoKemTheo item)
		{
			try
			{
				using (IDbConnection conn = Connection)
				{
					conn.Open();
					var parameters = new DynamicParameters();
					parameters.Add("Id", item.Id, DbType.String, ParameterDirection.Input);
					parameters.Add("LinhVucID", item.LinhVucID, DbType.String, ParameterDirection.Input);
					parameters.Add("TenHoSoKemTheo", item.TenHoSoKemTheo, DbType.String, ParameterDirection.Input);
					parameters.Add("BanChinh", item.BanChinh, DbType.Int32, ParameterDirection.Input);
					parameters.Add("BanSao", item.BanSao, DbType.Int32, ParameterDirection.Input);
					parameters.Add("BanPhoto", item.BanSao, DbType.Int32, ParameterDirection.Input);
					parameters.Add("OriginalName", item.OriginalName, DbType.String, ParameterDirection.Input);
					parameters.Add("UploadName", item.UploadName, DbType.String, ParameterDirection.Input);
					parameters.Add("PathName", item.PathName, DbType.String, ParameterDirection.Input);
					parameters.Add("IsActive", item.IsActive, DbType.Boolean, ParameterDirection.Input);
					parameters.Add("CreatedUserID", item.CreatedUserID, DbType.Int32, ParameterDirection.Input);
					parameters.Add("CreatedDate", item.CreatedDate, DbType.DateTime, ParameterDirection.Input);
					parameters.Add("LastUpdDate", item.CreatedDate, DbType.DateTime, ParameterDirection.Input);
					parameters.Add("LastUpdUserID", item.LastUpdUserID, DbType.Int32, ParameterDirection.Input);
					var readers = conn.ExecuteScalar("QT_DM_HoSoKemTheo_InsUpd", parameters, commandType: CommandType.StoredProcedure);
					return readers.ToString();
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
