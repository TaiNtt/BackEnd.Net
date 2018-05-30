using Core.Common.Domain;
using System;
using System.Collections.Generic;

namespace Business.Entities
{
    public class DM_QuyTrinh_Buoc_NguoiNhanSave
    {
        public DM_QuyTrinh_Buoc dm_QuyTrinh_Buoc { get; set; }
        public List<DM_QuyTrinh_Buoc_NguoiNhan> lstDM_QuyTrinh_Buoc_NguoiNhan { get; set; }
    }
}