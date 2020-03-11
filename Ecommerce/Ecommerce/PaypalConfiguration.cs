using PayPal.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ecommerce
{
    public class PaypalConfiguration
    {
        public readonly static string clientId;
        public readonly static string clientSecret;


        static PaypalConfiguration()
        {
            var config = getconfig();
            clientId = "AYzvjs9k6whCPcZ_hTnAVsO81IW0CN0DgHPUVtk4_KLMXLfhS3C9mu5BhTew9WbYtP89F-bERc0hV5Of";
            clientSecret = "ECEvo9p54rA3G2RRAXc2AlivJviV8mR1ZNHiganOpRf63MGBiaMYQQ_yLexEDMjYDZyM7-alXw-roytm";
        }

        private static Dictionary<string, string> getconfig()
        {
            return PayPal.Api.ConfigManager.Instance.GetProperties();
        }

        private static string GetAccessToken()
        {
            string accessToken = new OAuthTokenCredential(clientId, clientSecret, getconfig()).GetAccessToken();
            return accessToken;
        }
        public static APIContext GetAPIContext()
        {
            APIContext apicontext = new APIContext(GetAccessToken());
            apicontext.Config = getconfig();
            return apicontext;
        }
    }
}