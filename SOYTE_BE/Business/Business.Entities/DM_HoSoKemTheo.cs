using Core.Common.Domain;

namespace Business.Entities
{
	public class DM_HoSoKemTheo : EntityBase
	{
		public string LinhVucID { get; set; }
		public string TenHoSoKemTheo { get; set; }
		public int? BanChinh { get; set; }
		public int? BanSao { get; set; }
		public int? BanPhoto { get; set; }
		public string OriginalName { get; set; }
		public string UploadName { get; set; }
		public string PathName { get; set; }
		public bool? IsActive { get; set; }
		public int? CreatedUserID { get; set; }
		public string CreatedDate { get; set; }
		public int? LastUpdUserID { get; set; }
		public string LastUpdDate { get; set; }
	}
}
