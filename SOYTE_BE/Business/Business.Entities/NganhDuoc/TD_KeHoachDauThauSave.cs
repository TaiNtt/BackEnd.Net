using Core.Common.Domain;
using System;
using System.Collections.Generic;

namespace Business.Entities
{
    public class TD_KeHoachDauThauSave : EntityBase
    {
        public TD_KeHoachDauThau keHoachDauThau { get; set; }
        public List<TD_KeHoachDauThau_DSGoiThau> lstkeHoachDauThau_DSGoiThau { get; set; }
    }
}