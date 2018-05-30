using System;
using Module.Framework.UltimateClient;

namespace Module.Framework.Utilities
{
    public static class ParameterSetting
    {
        private static QuanTriServiceClient _quanTriService;

        public static string ReadValueSetting(string key)
        {
            try
            {
                using (_quanTriService = new QuanTriServiceClient())
                {
                    var response = _quanTriService.GetParameterByKey(key);
                    if (response != null) return response.Value;
                }
            }
            catch (Exception)
            {
                return string.Empty;
            }

            return string.Empty;
        }

        public static string PathFileUpload
        {
            get
            {
                return ReadValueSetting("PathFileUpload");
            }
        }

		public static string DMHoSoKemTheoFolder
		{
			get
			{
				return ReadValueSetting("DM_HoSoKemTheo_Folder");
			}
		}

		public static string TTHCDongBoFileName
        {
            get
            {
                return ReadValueSetting("TTHCDongBo_FileName");
            }
        }

        public static string TTHCDongBoFolder
        {
            get
            {
                return ReadValueSetting("TTHCDongBo_Folder");
            }
        }

        public static string TTHCDonViHCMId
        {
            get
            {
                return ReadValueSetting("TTHC_DonViHCMID");
            }
        }

        public static string PageIndex
        {
            get
            {
                return ReadValueSetting("PageIndex");
            }
        }

        public static string PageSize
        {
            get
            {
                return ReadValueSetting("PageSize");
            }
        }

        public static string PageIndexDongBo
        {
            get
            {
                return ReadValueSetting("PageIndex_DongBo");
            }
        }

        public static string PageSizeDongBo
        {
            get
            {
                return ReadValueSetting("PageSize_DongBo");
            }
        }
    }
}
