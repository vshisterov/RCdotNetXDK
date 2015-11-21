using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingCentral.XDK.Messaging
{
    public class SmsMessage
    {
        public PhoneNumber Recipient { get; set; }

        public PhoneNumber Sender { get; set; }

        public string Text { get; set; }

        public override string ToString()
        {
            var obj = JObject.FromObject(new
            {
                to = from r in new List<string> { this.Recipient.GetE164() }
                     select new
                     {
                         phoneNumber = r
                     },
                from = new { phoneNumber = Sender.GetE164() },
                text = Text
            });

            return obj.ToString();
        }
    }
}
