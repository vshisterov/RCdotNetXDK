using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RingCentral.XDK.CallHandling
{
    public class AnsweringRule
    {

        public string Id { get; internal set; }
        public AnsweringRuleType RuleType { get; internal set; }
        public ForwardingRule Forwarding { get; set; }

        internal static AnsweringRule FromString(string jsonString)
        {
            var rootJsonObject = JObject.Parse(jsonString);
            var forwardingJsonObject = rootJsonObject["forwarding"];

            var result = new AnsweringRule
            {
                Id = rootJsonObject["id"].ToString(),
                RuleType = (AnsweringRuleType)Enum.Parse(typeof(AnsweringRuleType), rootJsonObject["type"].ToString()),
                Forwarding = new ForwardingRule
                {
                    Elements = new List<ForwarindRuleElement>(
                        from ruleJsonObject in forwardingJsonObject["rules"]
                        select new ForwarindRuleElement
                        {
                            Index = int.Parse(ruleJsonObject["index"].ToString()),
                            Numbers = new List<ForwardingNumber>(
                                from forwardingNumberJsonObject in ruleJsonObject["forwardingNumbers"]
                                select new ForwardingNumber
                                {
                                    Id = forwardingNumberJsonObject["id"].ToString(),
                                    PhoneNumber = new PhoneNumber(forwardingNumberJsonObject["phoneNumber"].ToString()),
                                    Label = forwardingNumberJsonObject["label"].ToString()
                                }
                                )
                        })
                }

            };

            return result;
        }

    }

    public enum AnsweringRuleType
    {
        BusinessHours,
        AfterHours,
        Custom
    }

}
