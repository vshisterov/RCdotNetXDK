using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingCentral.XDK
{
    public class PhoneNumber
    {

        //TODO: replace with phone number parts
        private string phoneNumber;

        public PhoneNumber(string phoneNumber)
        {
            //TODO: parsing
            this.phoneNumber = phoneNumber;
        }

        public string GetE164()
        {
            //TODO: replace with compilation from parts
            return this.phoneNumber;
        }

        public override string ToString()
        {
            return phoneNumber;
        }

    }
}
