using Core.Common.Domain;
using System;
using System.Collections.Generic;

namespace Business.Entities
{
    public class GiayPhepDoanKCBSave : EntityBase
    {
        public GiayPhepDoanKCB giayPhepDoanKCB { get; set; }
        public List<GiayPhepDoanKCB_ThanhVien> lstgiayPhepDoanKCB_ThanhVien { get; set; }
    }
}