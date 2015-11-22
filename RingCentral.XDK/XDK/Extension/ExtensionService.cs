namespace RingCentral.XDK.Extension
{
    public class ExtensionService
    {

        private const string API_RESOURCE = "/extension";

        private ApiClient ApiClient { get; set; }

        internal ExtensionService(ApiClient xdk)
        {
            this.ApiClient = xdk;
        }

        public Extension GetCurrent()
        {
            return GetById("~");
        }

        public Extension GetById(string id)
        {
            return Extension.FromString(ApiClient.GetByIdFromAccount(API_RESOURCE, id));
        }

    }
}
