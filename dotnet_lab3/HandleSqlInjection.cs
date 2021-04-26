using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet_lab_3
{
    class HandleSqlInjection : AbstractVerificationHandler
    {
        public override object VerifyOrderData(ClientData order)
        {
            bool should_order_be_handled = check_object_ifNeededToHandle(order);
            if (should_order_be_handled)
            {
                return "HandleSqlInjection: Failed";
            }
            else
            {
                return base.VerifyOrderData(order);
            }
        }
        private bool check_object_ifNeededToHandle(ClientData order)
        {
            bool b1 = handle_dataField(order.first_name.value);
            bool b2 = handle_dataField(order.last_name.value);
            bool b3 = handle_dataField(order.petronym.value);
            bool b5 = handle_dataField(order.delivery_address.value);
            bool b6 = handle_dataField(order.delivery_type.value);

            return (b1 || b2 || b3 || b5 || b6);

        }
        private bool handle_dataField(string value)
        {
            if (SQL_injection_detect(value)) return true;
            return false;
        }
        private static bool SQL_injection_detect(string userInput)
        {
            bool isSQLInjection = false;
            string[] sqlCheckList = { "--", ";--", ";",   "/*",  "*/",   "@@",   "@",   "char",  "nchar", "%", "=",
                                       "varchar",  "nvarchar",  "alter",    "begin",   "cast",    "create",   "cursor",   "declare",  "delete",
                                       "drop",   "end",   "exec",    "execute",    "fetch", "insert", "kill", "select", "sys", "sysobjects",
                                        "syscolumns",    "table",  "update"
                                       };
            string CheckString = userInput.Replace("'", "''");

            for (int i = 0; i <= sqlCheckList.Length - 1; i++)
            {
                if ((CheckString.IndexOf(sqlCheckList[i], StringComparison.OrdinalIgnoreCase) >= 0))
                {
                    isSQLInjection = true;
                }
            }
            return isSQLInjection;
        }
    }
}
