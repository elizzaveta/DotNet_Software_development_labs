using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace dotnet_lab_3
{
    class HandleXssVulnerabilities : AbstractVerificationHandler
    {
        public override object VerifyOrderData(ClientData order)
        {
            bool should_order_be_handled = check_object_ifNeededToHandle(order);
            if (should_order_be_handled)
            {
                return "HandleXssVulnerabilities: Failed";
            }
            else
            {
                return base.VerifyOrderData(order);
            }
        }
        private bool check_object_ifNeededToHandle(ClientData order)
        {
            bool b1 = XSS_injection_detect(order.first_name.value);
            bool b2 = XSS_injection_detect(order.last_name.value);
            bool b3 = XSS_injection_detect(order.petronym.value);
            bool b5 = XSS_injection_detect(order.delivery_address.value);
            bool b6 = XSS_injection_detect(order.delivery_type.value);

            return (b1 || b2 || b3 || b5 || b6);

        }
        private bool XSS_injection_detect(string value)
        {
            Regex tagRegex = new Regex(@"<\s*([^ >]+)[^>]*>.*?<\s*/\s*\1\s*>");
            Regex tagRegex2 = new Regex(@"<[^>]+>");
            if (tagRegex.IsMatch(value) || tagRegex2.IsMatch(value)) return true;
            return false;
        }
    }
}
