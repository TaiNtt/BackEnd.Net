using Core.Common.Domain;
using System;
using System.Collections.Generic;

namespace Business.Entities
{
    public class CV_XNKThuoc_PhiMauDichSave : EntityBase
    {
        public CV_XNKThuoc_PhiMauDich xNKThuocPhiMauDich { get; set; }
        public List<CV_XNKThuoc_PhiMauDich_DSThuoc> lstxNKThuocPhiMauDich_DSThuoc { get; set; }
    }
}