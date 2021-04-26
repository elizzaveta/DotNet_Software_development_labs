using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet_lab_3
{
    class ClientData
    {
        public DataField first_name;
        public DataField last_name;
        public DataField petronym;
        public DataField email;
        public DataField delivery_address;
        public DataField delivery_type;
        //public DataField post_office;

        public ClientData(string f_name, string l_name, string pnym, string eml, string del_addr, string del_type)
        {
            first_name = new DataField("f_name", f_name); 
            last_name = new DataField("l_name", l_name);
            petronym = new DataField("pnym", pnym);
            email = new DataField("eml", eml);
            delivery_address = new DataField("del_addr", del_addr);
            delivery_type = new DataField("del_type", del_type);
        }


        //public string first_name;
        //public string last_name;
        //public string petronym;
        //public string email;
        //public string delivery_address;
        //public string delivery_type;
        //public string post_office;
    }
    class DataField
    {
        public string type;
        public string value;
        public DataField(string t, string v)
        {
            this.type = t;
            this.value = v;
        }
    }

}
