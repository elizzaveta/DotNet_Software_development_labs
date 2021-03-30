using System;

namespace dotnet_lab_2
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Welcome to composite pattern. ");
            Console.WriteLine("Enter some text. Enter 'q' in new line to quit.\n");

            TextComposite text2 = new TextComposite('t');
            string user_text = "";

            do
            {
                user_text = Console.ReadLine();
                if (user_text != "q")
                {
                    TextComposite user_paragraf = parse_paragraf(user_text);
                    text2.AddComponent(user_paragraf);
                }

            } while (user_text != "q");



            Console.WriteLine("\n\nYour text: \n" + text2.get_text()+"\n");



        }
        public static TextComposite parse_paragraf(string user_paragraf)
        {
            TextComposite paragraf = new TextComposite('p');
            TextComposite sentence = new TextComposite('s');
            string current_word = "";
            for(int i = 0; i < user_paragraf.Length; i++)
            {
                
                if ((user_paragraf[i] == '.' || user_paragraf[i] == ',' || user_paragraf[i] == '?' || user_paragraf[i] == '!') && (i + 1 == user_paragraf.Length || user_paragraf[i+1]==' '))
                {
                    if (current_word != "")
                    {
                        TextComponent word = new LeafComponent_word_separators(current_word);
                        sentence.AddComponent(word);
                        current_word = "";
                    }
                    sentence.AddComponent(new LeafComponent_word_separators(user_paragraf[i].ToString()));
                    if (i + 1 == user_paragraf.Length || user_paragraf[i] != ',' )
                    {
                        paragraf.AddComponent(sentence);
                        sentence = new TextComposite('s');
                    }
                }
                else if (i + 1 == user_paragraf.Length)
                {
                    current_word += user_paragraf[i];
                    TextComponent word = new LeafComponent_word_separators(current_word);
                    sentence.AddComponent(word);
                    current_word = "";

                    paragraf.AddComponent(sentence);
                    sentence = new TextComposite('s');
                }
                else if(user_paragraf[i] == ' ' && current_word != "")
                {
                    TextComponent word = new LeafComponent_word_separators(current_word);
                    sentence.AddComponent(word);
                    current_word = "";
                }
                else if (user_paragraf[i] != ' ')
                {
                    current_word += user_paragraf[i];
                }
            }
            return paragraf;
        }
        public static void test_example_of_structure()
        {
            //Leafs
            TextComponent word1 = new LeafComponent_word_separators("Good");
            TextComponent word2 = new LeafComponent_word_separators("day");
            TextComponent word4 = new LeafComponent_word_separators("John");
            TextComponent word5 = new LeafComponent_word_separators("Nice");
            TextComponent word6 = new LeafComponent_word_separators("work");
            TextComponent separator2 = new LeafComponent_word_separators(".");
            TextComponent separator1 = new LeafComponent_word_separators(",");

            Console.WriteLine("Words and separators: " + word1.get_text() + " " + word2.get_text() + " " + word4.get_text() + " " + word5.get_text() + " " + word6.get_text() + " " + separator1.get_text() + " " + separator2.get_text() + "\n");

            //Composite
            TextComponent sentence1 = new TextComposite('s', word1, word2, separator1, word4, separator2);
            Console.WriteLine("Sentence 1: " + sentence1.get_text());
            TextComponent sentence2 = new TextComposite('s', word5, word6, separator2);
            Console.WriteLine("Sentence 2: " + sentence2.get_text());
            TextComponent sentence3 = new TextComposite('s', word1, word6, separator1, word4, separator2);
            Console.WriteLine("Sentence 3: " + sentence3.get_text() + "\n");


            //Composite2
            TextComponent paragraf1 = new TextComposite('p', sentence1, sentence2);
            Console.Write("Paragraf 1: " + paragraf1.get_text());
            TextComponent paragraf2 = new TextComposite('p', sentence3);
            Console.WriteLine("Paragraf 2: " + paragraf2.get_text());

            //Composite3


            TextComponent text = new TextComposite('t', paragraf1, paragraf2);
            Console.WriteLine("Text : \n" + text.get_text());
        }
    }
}
