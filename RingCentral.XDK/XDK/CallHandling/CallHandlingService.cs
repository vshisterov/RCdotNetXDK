using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingCentral.XDK.CallHandling
{
    public class CallHandlingService
    {

        private const string ANSWERING_RULE_API_RESOURCE = "/answering-rule";
        private const string FORWARDING_NUMBER_API_RESOURCE = "/forwarding-number";

        private const string BUSINESS_HOURS_RULE_ID = "business-hours-rule";
        private const string AFTER_HOURS_RULE_ID = "after-hours-rule";

        private ApiClient ApiClient { get; set; }

        internal CallHandlingService(ApiClient apiClient)
        {
            this.ApiClient = apiClient;
        }

        public AnsweringRule GetBusinessHoursRule()
        {
            return GetAnsweringRuleById(BUSINESS_HOURS_RULE_ID);
        }

        public AnsweringRule GetAnsweringRuleById(string id)
        {
            return AnsweringRule.FromString(ApiClient.GetByIdFromExtension(ANSWERING_RULE_API_RESOURCE, id));
        }

        public ForwardingNumber UpdateForwardingNumber(ForwardingNumber forwardingNumber)
        {
            return ForwardingNumber.FromString(ApiClient.PutByIdFromExtension(FORWARDING_NUMBER_API_RESOURCE, forwardingNumber.Id, forwardingNumber.ToStringForUpdate()));
        }

    }
}
