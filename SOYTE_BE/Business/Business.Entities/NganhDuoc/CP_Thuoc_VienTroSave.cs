using Core.Common.Domain;
using System;
using System.Collections.Generic;

namespace Business.Entities
{
    public class CP_Thuoc_VienTroSave : EntityBase
    {
        public CP_Thuoc_VienTro thuocVienTro { get; set; }
        public List<CP_Thuoc_VienTro_DMThuoc> lstthuocVienTro_DMThuoc { get; set; }
    }
}