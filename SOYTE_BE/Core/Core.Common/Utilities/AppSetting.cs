using System.Configuration;
using System.Web.Configuration;

namespace Core.Common.Utilities
{
    public static class AppSetting
    {
        public static string ReadSetting(string key)
        {
            try
            {
                var appSettings = WebConfigurationManager.AppSettings;
                return appSettings[key];
            }
            catch (ConfigurationErrorsException)
            {
                return string.Empty;
            }
        }
        public static string TTHCUnitId
        {
            get
            {
                return ReadSetting("SoTuPhapSystem.UnitId");
            }
        }
        public static string PathFileUpload
        {
            get
            {
                return ReadSetting("SoYTeSystem.PathFileUpload");
            }
        }
        public static string TTHCApiBaseUrl
        {
            get
            {
                return ReadSetting("SoTuPhapSystem.TTHC.ApiBaseUrl");
            }
        }
        public static string MCApiBaseUrl
        {
            get
            {
                return ReadSetting("SoYTeSystem.MC.ApiBaseUrl");
            }
        }

        public static string HSApiBaseUrl => ReadSetting("SoYTeSystem.HS.ApiBaseUrl");

        public static string NYApiBaseUrl
        {
            get
            {
                return ReadSetting("SoYTeSystem.NY.ApiBaseUrl");
            }
        }
        public static string NDApiBaseUrl
        {
            get
            {
                return ReadSetting("SoYTeSystem.ND.ApiBaseUrl");
            }
        }
        public static string MTApiBaseUrl
        {
            get
            {
                return ReadSetting("SoYTeSystem.MT.ApiBaseUrl");
            }
        }
        public static string PAGYApiBaseUrl
        {
            get
            {
                return ReadSetting("SoTuPhapSystem.PAGY.ApiBaseUrl");
            }
        }
        public static string BCApiBaseUrl
        {
            get
            {
                return ReadSetting("SoYTeSystem.BC.ApiBaseUrl");
            }
        }
        public static string QTApiBaseUrl
        {
            get
            {
                var resulst= ReadSetting("SoTuPhapSystem.QT.ApiBaseUrl");
                return resulst;
            }
        }
        public static string AppId
        {
            get
            {
                return ReadSetting("SoTuPhapSystem.AppId");
            }
        }
        public static string SecretKey
        {
            get
            {
                return ReadSetting("SoTuPhapSystem.SecretKey");
            }
        }

      
    }
}
