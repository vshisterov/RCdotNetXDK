using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RingCentral.SDK;
using RingCentral.XDK;

namespace RingCentral.TestConsole
{
    class Program
    {

        private const string appKey = "";
        private const string appSecret = "";
        private const string apiEndpoint = "https://api.ringcentral.com";
        private const string appName = "TestConsole";
        private const string appVersion = "1.0";

        private const string phoneNumber = "";
        private const string password = "";

        private const string senderPhoneNumber = "";
        private const string recipientPhoneNumber = "";

        static void Main(string[] args)
        {            
            SDK.SDK rcsdk = new SDK.SDK(appKey, appSecret, apiEndpoint, appName, appVersion);

            var ringCentral = new RingCentral.XDK.ApiClient(rcsdk);

            ringCentral.Login(phoneNumber, password);
            ringCentral.SMS.Send(senderPhoneNumber, recipientPhoneNumber, "Hello World");            

        }
    }
}
