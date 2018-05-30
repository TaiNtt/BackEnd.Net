using Core.Common.Domain;
using System;
using System.Collections.Generic;

namespace Business.Entities
{
    public class XN_NoiDungQuangCaoSave : EntityBase
    {
        public XN_NoiDungQuangCao noiDungQuangCao { get; set; }
        public List<XN_NoiDungQuangCao_SanPham> lstnoiDungQuangCao_SanPham { get; set; }
    }
}