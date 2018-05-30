using Core.Common.Domain;
using System;
using System.Collections.Generic;

namespace Business.Entities
{
    public class DM_ThuTucSave
    {
        public DM_ThuTuc dm_ThuTuc { get; set; }
        public List<DM_ChungTuKemTheo> lstDM_ChungTuKemTheo { get; set; }
    }
}