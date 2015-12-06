using Newtonsoft.Json.Linq;
using System;

namespace RingCentral.XDK.Extension
{
    public class Extension
    {

        public string Id { get; internal set; }
        public int? ExtensionNumber { get; set; }
        public ContactInfo ContactInfo { get; set; }

        public override string ToString()
        {
            var obj = JObject.FromObject(new
            {
                extensionNumber = ExtensionNumber?.ToString(),
                contact = new
                {
                    firstName = ContactInfo.FirstName,
                    lastName = ContactInfo.LastName,
                    email = ContactInfo.Email,
                    company = ContactInfo.CompanyName
                }               
            });

            return obj.ToString();
        }

        internal static Extension FromString(string jsonString)
        {
            var extensionJsonObject = JObject.Parse(jsonString);
            var contactJsonObject = extensionJsonObject["contact"];

            string extensionNumberString = extensionJsonObject["extensionNumber"]?.ToString();
            int? extensionNumber = string.IsNullOrEmpty(extensionNumberString) ? (int?)null : int.Parse(extensionNumberString);

            var result = new Extension
            {
                Id = extensionJsonObject["id"].ToString(),
                ExtensionNumber = extensionNumber,
                ContactInfo = new ContactInfo
                {
                    FirstName = contactJsonObject["firstName"].ToString(),
                    LastName = contactJsonObject["lastName"].ToString(),
                    Email = contactJsonObject["email"].ToString(),
                    CompanyName = contactJsonObject["company"].ToString()
                }
            };            

            return result;

        }

    }
}
