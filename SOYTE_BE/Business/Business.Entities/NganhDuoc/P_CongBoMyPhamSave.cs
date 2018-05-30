using Core.Common.Domain;
using System;
using System.Collections.Generic;

namespace Business.Entities
{
    public class P_CongBoMyPhamSave : EntityBase
    {
        public P_CongBoMyPham congBoMyPham { get; set; }
        public List<P_CongBoMyPham_ThanhPhan> lstcongBoMyPham_ThanhPhan { get; set; }
    }
}