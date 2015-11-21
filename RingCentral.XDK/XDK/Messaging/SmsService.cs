using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingCentral.XDK.Messaging
{
    public class SmsService
    {

        private const string API_RESOURCE = "/sms";

        private ApiClient XDK { get; set; }

        internal SmsService(ApiClient xdk)
        {
            this.XDK = xdk;
        }

        public void Send(SmsMessage message)
        {
            XDK.PostFromExtension(API_RESOURCE, message.ToString());
        }

        public void Send(string from, string to, string text)
        {
            Send(new SmsMessage { Recipient = new PhoneNumber(to), Sender = new PhoneNumber(from), Text = text });
        }

    }
}
