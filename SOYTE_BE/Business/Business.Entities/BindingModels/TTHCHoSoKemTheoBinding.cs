namespace Business.Entities.BindingModels
{
    public class TTHCHoSoKemTheoBinding
    {
        public string Id { get; set; }
        public string ThuTucHanhChinhID { get; set; }
        public string HoSoKemTheoID { get; set; }
        public int? CreatedUserID { get; set; }
        public string CreatedDate { get; set; }
        public int? LastUpdUserID { get; set; }
        public string LastUpdDate { get; set; }
    }
}
