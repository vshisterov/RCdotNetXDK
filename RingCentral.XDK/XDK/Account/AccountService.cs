namespace RingCentral.XDK.Account
{
    public class AccountService
    {
        private const string API_RESOURCE = "/account";

        private ApiClient ApiClient { get; set; }

        internal AccountService(ApiClient xdk)
        {
            this.ApiClient = xdk;
        }

        public Account GetCurrent()
        {
            return GetById("~");
        }

        public Account GetById(string id)
        {
            return Account.FromString(ApiClient.GetById(API_RESOURCE, id));
        }
    }
}
