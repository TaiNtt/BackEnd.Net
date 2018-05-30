namespace Business.Entities.BindingModels
{
    public class TTHCMauDonToKhaiBindingModel
    {
        public string Id { get; set; }
        public string ThuTucHanhChinhID { get; set; }

        public string TenMauDonToKhai { get; set; }

        public string URL { get; set; }

        public int? CreatedUserID { get; set; }

        public string CreatedDate { get; set; }

        public int? LastUpdUserID { get; set; }

        public string LastUpdDate { get; set; }
    }
}
