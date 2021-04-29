using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet_lab_3
{
    class HandleDataCorrectness : AbstractVerificationHandler
    {
        public override object VerifyOrderData(ClientData order)
        {
            bool should_order_be_handled = check_object_ifNeededToHandle(order);
            if (should_order_be_handled)
            {
                return "Handle Data Correctness: Failed";
            }
            else
            {
                return base.VerifyOrderData(order);
            }
        }
        private bool check_object_ifNeededToHandle(ClientData order)
        {
            if(handle_firstName(order.first_name)) return true;
            if (handle_lastName(order.last_name)) return true;
            if (handle_pnym(order.petronym)) return true;
            if (handle_email(order.email)) return true;
            if (handle_delAddress(order.delivery_address)) return true;
            if (handle_delType(order.delivery_type)) return true;
            return false;

        }
        private bool handle_firstName(string value)
        {
            if (value.Length < 2) return true;
            return false;
        }
        private bool handle_lastName(string value)
        {
            if (value.Length < 4) return true;
            return false;
        }
        private bool handle_pnym(string value)
        {
            if (value.Length < 6) return true;
            return false;
        }
        private bool handle_email(string value)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(value);
                return false;
            }
            catch
            {
                return true;
            }
        }
        private bool handle_delAddress(string value)
        {
            if (value.Length < 1) return true;
            return false;
        }
        private bool handle_delType(string value)
        {
            int number;
            bool success = Int32.TryParse(value, out number);
            return !success;

        }
    }
    
}
