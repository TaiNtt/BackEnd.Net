using Core.Common.Domain;
using System;
using System.Collections.Generic;

namespace Business.Entities
{
    public class PD_Thuoc_MethadoneSave : EntityBase
    {
        public PD_Thuoc_Methadone thuocMethadone { get; set; }
        public List<PD_Thuoc_Methadone_TinhHinh> lstthuocMethadone_TinhHinh { get; set; }
    }
}