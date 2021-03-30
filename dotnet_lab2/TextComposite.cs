using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet_lab_2
{
    class TextComposite : TextComponent
    {
        public  List<TextComponent> ListOfComponents = new List<TextComponent>();
        private char _type;
        public TextComposite(char type, params TextComponent[] values) 
        {
            _type = type;
            for (int i = 0; i < values.Length; i++)
            {
                ListOfComponents.Add(values[i]);
            }
        }

        public override string get_text()
        {
            string result = "";
            for(int i = 0; i< ListOfComponents.Count; i++)
            {
                result += ListOfComponents[i].get_text();
                if (_type!='t' && i+1 != ListOfComponents.Count && ListOfComponents[i+1].get_text()!= "," && ListOfComponents[i + 1].get_text() != "." && ListOfComponents[i + 1].get_text() != "!" && ListOfComponents[i + 1].get_text() != "?")
                    result += " ";
            }
            if (_type == 'p') result += "\n";
            return result;
        }
        public void AddComponent(TextComponent new_component) {
            ListOfComponents.Add(new_component);
        }
        public void RemoveComponents() {
            ListOfComponents.Clear();
        }
        
    }



  
}
