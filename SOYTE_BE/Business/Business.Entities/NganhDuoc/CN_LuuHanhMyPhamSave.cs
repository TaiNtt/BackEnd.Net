using Core.Common.Domain;
using System;
using System.Collections.Generic;

namespace Business.Entities
{
    public class CN_LuuHanhMyPhamSave : EntityBase
    {
        public CN_LuuHanhMyPham luuHanhMyPham { get; set; }
        public List<CN_LuuHanhMyPham_SanPham> lstluuHanhMyPham_SanPham { get; set; }
    }
}