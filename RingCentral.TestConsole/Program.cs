using System;

namespace RingCentral.TestConsole
{
    class Program
    {

        private const string appKey = "";
        private const string appSecret = "";

        private const string phoneNumber = "";
        private const string password = "";

        private const string senderPhoneNumber = "";
        private const string recipientPhoneNumber = "";

        static void Main(string[] args)
        {                        

            var ringCentral = new RingCentral.XDK.ApiClient(appKey, appSecret);

            //Login
            ringCentral.Login(phoneNumber, password);

            //Sending SMS
            //ringCentral.SMS.Send(senderPhoneNumber, recipientPhoneNumber, "Hello World");            

            //Reading Extension Info
            var myExtension = ringCentral.Extension.GetCurrent();
            Console.WriteLine("*** My Extension ***");
            Console.WriteLine("First Name: \t{0}", myExtension.ContactInfo.FirstName);
            Console.WriteLine("Last Name: \t{0}", myExtension.ContactInfo.LastName);
            Console.WriteLine("Email: \t\t{0}", myExtension.ContactInfo.Email);
            Console.WriteLine("Company: \t{0}", myExtension.ContactInfo.CompanyName);
            Console.WriteLine();

            //Reading Answering Rules
            var defaultRule = ringCentral.CallHandling.GetBusinessHoursRule();
            Console.WriteLine("*** Business Hours Rule ***");
            foreach (var element in defaultRule.Forwarding.Elements)
            {
                Console.WriteLine("Group {0} numbers:", element.Index);
                foreach (var number in element.Numbers)
                    Console.WriteLine("\t\t{0} ({1})", number.PhoneNumber.GetE164(), number.Label);
            }

            //Updating Forwarding Number
            var firstNumber = defaultRule.Forwarding.Elements[0].Numbers[0];
            firstNumber.PhoneNumber = new XDK.PhoneNumber("+12345678912");
            Console.Write("Updating first forwarding number... ");
            try
            {
                firstNumber = ringCentral.CallHandling.UpdateForwardingNumber(firstNumber);
                Console.WriteLine("succeded, new number: {0}", firstNumber.PhoneNumber.GetE164());
            }
            catch (Exception e)
            {
                Console.WriteLine("failed: {0}", e.Message);
            }
            

            //Waiting
            Console.ReadLine();

            //Logout
            ringCentral.Logout();

        }
    }
}
