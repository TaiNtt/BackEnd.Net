using Business.Entities;
using Core.Common.Utilities;
using System.ServiceModel;
using System.ServiceModel.Web;
using Business.Entities.ViewModels;
using System;
using System.Collections.Generic;

namespace Business.Services.Contracts
{
    [ServiceContract]
    public interface IBaoCaoThongKeService
    {
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
               UriTemplate = "BC/BaoCaoThongKe_LichSuBienDong_GetByGiayPhepID?GiayPhepID={GiayPhepID}" +
                            "&LoaiCapPhepID={LoaiCapPhepID}")]
        IEnumerable<LichSuBienDongViewModel> BaoCaoThongKe_LichSuBienDong_GetByGiayPhepID(long GiayPhepID, int LoaiCapPhepID);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "BC/BaoCaoThongKe_LichSuBienDong_Save")]
        bool BaoCaoThongKe_LichSuBienDong_Save(LichSuBienDong lichSuBienDong);
    }
}
