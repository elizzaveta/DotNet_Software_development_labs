using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet_lab_3
{
    class ClientData
    {
        public string first_name;
        public string last_name;
        public string petronym;
        public string email;
        public string delivery_address;
        public string delivery_type;

        public ClientData(string f_name, string l_name, string pnym, string eml, string del_addr, string del_type)
        {
            first_name =  f_name; 
            last_name = l_name;
            petronym =  pnym;
            email = eml;
            delivery_address = del_addr;
            delivery_type = del_type;
        }
    }

}
