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
                return "HandleDataCorrectness: Failed";
            }
            else
            {
                return base.VerifyOrderData(order);
            }
        }
        private bool check_object_ifNeededToHandle(ClientData order)
        {
            bool b1 = check_field(order.first_name);
            bool b2 = check_field(order.last_name);
            bool b3 = check_field(order.petronym);
            bool b4 = check_field(order.email);
            bool b5 = check_field(order.delivery_address);
            bool b6 = check_field(order.delivery_type);

            return (b1 || b2 || b3 || b4 || b5 || b6);

        }
        private bool check_field(DataField dataField)//       
        {
            switch (dataField.type)
            {
                case "f_name": return handle_firstName(dataField.value);
                case "l_name": return handle_lastName(dataField.value);
                case "pnym": return handle_pnym(dataField.value);
                case "eml": return handle_email(dataField.value);
                case "del_addr": return handle_delAddress(dataField.value);
                case "del_type": return handle_delType(dataField.value);
                default: return false;
            }
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
            if (value.Length < 1) return true;
            return false;
        }
    }
    
}
