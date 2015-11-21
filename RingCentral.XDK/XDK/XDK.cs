using System;
using RingCentral;
using RingCentral.SDK;
using RingCentral.SDK.Http;

namespace RingCentral.XDK
{
    public class ApiClient
    {

        #region Const

        private const string DEFAULT_API_ENDPOINT = "https://api.ringcentral.com";
        private const string DEFAULT_API_VERSION = "1.0";
        private const string BASE_API_PATH = "/restapi/v{0}";
        private const string ACCOUNT_API_PATH = "/account/{0}";
        private const string EXTENSION_API_PATH = "/extension/{0}";
        private const string CURRENT_ACCOUNT_ID = "~";
        private const string CURRENT_EXTENSION_ID = "~";

        #endregion

        #region Private Members

        private string apiVersion;

        private Messaging.SmsService smsService;

        #endregion

        #region Properties

        private SDK.SDK RCSDK { get; set; }
        private Platform Platform { get { return RCSDK.GetPlatform(); } }

        private string ApiVersion
        {
            get
            {
                if (string.IsNullOrEmpty(apiVersion))
                    apiVersion = DEFAULT_API_VERSION;
                return apiVersion;
            }
            set { apiVersion = value; }
        }

        public Messaging.SmsService SMS
        {
            get
            {
                if (smsService == null)
                    smsService = new Messaging.SmsService(this);
                return smsService;
            }
        }

        #endregion

        #region .ctor

        public ApiClient(SDK.SDK rcsdk)
        {
            this.RCSDK = rcsdk;            
        }

        public ApiClient(string appKey, string appSecret)
        {
            this.RCSDK = new SDK.SDK(appKey, appSecret, DEFAULT_API_ENDPOINT, string.Empty, string.Empty);
        }

        public ApiClient(string appKey, string appSecret, string apiEndpoint)
        {
            this.RCSDK = new SDK.SDK(appKey, appSecret, DEFAULT_API_ENDPOINT, string.Empty, string.Empty);
        }

        #endregion

        #region Methods

        public void Login(string phoneNumber, string password)
        {
            Login(phoneNumber, string.Empty, password);
        }

        public void Login(string phoneNumber, string extensionNumber, string password)
        {
            Platform.Authorize(phoneNumber, extensionNumber, password, true);
        }


        public void Logout()
        {
            Platform.Logout();
        }


        internal string PostFromExtension(string resource, string body)
        {
            return Post(string.Concat(GetExtensionApiPath(), resource), body);
        }

        internal string Post(string resource, string body)
        {
            Request request = new Request(string.Concat(GetBaseApiPath(), resource), body);
            return this.Platform.Post(request).GetBody();
        }


        private string GetBaseApiPath()
        {
            return string.Format(BASE_API_PATH, ApiVersion);
        }

        private string GetAccountApiPath()
        {
            return GetAccountApiPath(CURRENT_ACCOUNT_ID);
        }

        private string GetAccountApiPath(string accountId)
        {
            return string.Format(ACCOUNT_API_PATH, accountId);
        }

        private string GetExtensionApiPath()
        {
            return GetExtensionApiPath(CURRENT_EXTENSION_ID);
        }

        private string GetExtensionApiPath(string extensionId)
        {
            return GetExtensionApiPath(CURRENT_ACCOUNT_ID, extensionId);
        }

        private string GetExtensionApiPath(string accountId, string extensionId)
        {
            return string.Concat(GetAccountApiPath(accountId), string.Format(EXTENSION_API_PATH, extensionId));
        }

        #endregion

    }
}
