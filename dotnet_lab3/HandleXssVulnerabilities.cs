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
                return "Handle Xss Vulnerabilities: Failed";
            }
            else
            {
                return base.VerifyOrderData(order);
            }
        }
        private bool check_object_ifNeededToHandle(ClientData order)
        {
            if (XSS_injection_detect(order.first_name)) return true;
            if (XSS_injection_detect(order.last_name)) return true;
            if (XSS_injection_detect(order.petronym)) return true;
            if (XSS_injection_detect(order.delivery_address)) return true;
            if (XSS_injection_detect(order.delivery_type)) return true;

            return false;

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
