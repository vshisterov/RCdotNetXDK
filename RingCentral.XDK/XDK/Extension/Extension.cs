using Newtonsoft.Json.Linq;
using System;

namespace RingCentral.XDK.Extension
{
    public class Extension
    {

        public ContactInfo ContactInfo { get; set; }

        public override string ToString()
        {
            var obj = JObject.FromObject(new
            {
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

            var result = new Extension
            {
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
