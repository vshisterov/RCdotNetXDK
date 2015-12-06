using Newtonsoft.Json.Linq;

namespace RingCentral.XDK.Account
{
    public class Account
    {

        public string Id { get; internal set; }
        public PhoneNumber MainNumber { get; internal set; }

        public override string ToString()
        {
            var obj = JObject.FromObject(new
            {
                mainNumber = MainNumber.GetE164()
            });

            return obj.ToString();
        }

        internal static Account FromString(string jsonString)
        {
            var accountJsonObject = JObject.Parse(jsonString);

            var result = new Account
            {
                Id = accountJsonObject["id"].ToString(),
                MainNumber = new PhoneNumber(accountJsonObject["mainNumber"].ToString())
            };

            return result;
        }

    }
}
