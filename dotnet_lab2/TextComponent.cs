using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet_lab_2
{
    abstract class TextComponent
    {
        public abstract string get_text();
        public abstract string get_explained_text();

    }

    class LeafComponent_word_separators : TextComponent
    {
        public string value;
        public LeafComponent_word_separators(string val)
        {
            value = val;
        }
        public override string get_text()
        {
            return value;

        }
        public override string get_explained_text()
        {
            return (" word: " + value);
        }
    }

    
}
