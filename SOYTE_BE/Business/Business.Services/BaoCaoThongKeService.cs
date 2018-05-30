using Business.Entities;
using Business.Services.Contracts;
using Data.Core.Repositories.Interfaces;
using Business.Entities.ViewModels;
using System.Data;
using System.Data.Sql;
using System;
using System.Collections.Generic;
using Core.Common.Utilities;
using System.Linq;
using System.Xml.Serialization;
using System.IO;
using System.Xml.Linq;
using System.Xml;
using System.Configuration;
using System.Data.SqlClient;

namespace Business.Services
{
    public class BaoCaoThongKeService : IBaoCaoThongKeService
    {
        #region Private Repository & contractor
        IDbConnection cons;
        IDbTransaction trans;
        private static readonly string BaoCaoThongKeConn = ConfigurationManager.ConnectionStrings["BaoCaoThongKe.ConnString"].ConnectionString;

        private readonly ILichSuBienDongRepository _lichSuBienDongRepository;

        public BaoCaoThongKeService(ILichSuBienDongRepository lichSuBienDongRepository)
        {
            _lichSuBienDongRepository = lichSuBienDongRepository;
        }
        #endregion

        public IEnumerable<LichSuBienDongViewModel> BaoCaoThongKe_LichSuBienDong_GetByGiayPhepID(long GiayPhepID, int LoaiCapPhepID)
        {
            try
            {
                return _lichSuBienDongRepository.BaoCaoThongKe_LichSuBienDong_GetByGiayPhepID(GiayPhepID, LoaiCapPhepID);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public bool BaoCaoThongKe_LichSuBienDong_Save(LichSuBienDong lichSuBienDong)
        {
            try
            {
                cons = new SqlConnection(BaoCaoThongKeConn);
                cons.Open();
                trans = cons.BeginTransaction();

                var insLichsubiendong = _lichSuBienDongRepository.BaoCaoThongKe_LichSuBienDong_Ins(lichSuBienDong, cons, trans);
                if (!insLichsubiendong) { trans.Rollback(); return false; }

                trans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                return false;
            }
        }
    }
}