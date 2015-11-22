using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace RingCentral.XDK.CallHandling
{
    public class ForwardingNumber
    {

        public string Id { get; internal set; }
        public PhoneNumber PhoneNumber { get; set; }
        public string Label { get; set; }        

        internal static ForwardingNumber FromString(string jsonString)
        {
            var jsonObject = JObject.Parse(jsonString);
            var result = new ForwardingNumber
            {
                Id = jsonObject["id"].ToString(),
                PhoneNumber = new PhoneNumber(jsonObject["phoneNumber"].ToString()),
                Label = jsonObject["label"].ToString()
            };
            return result;
        }

        internal string ToStringForUpdate()
        {
            var obj = JObject.FromObject(new
            {
                phoneNumber = PhoneNumber.GetE164(),
                label = Label
            });

            return obj.ToString();
        }

    }
}
