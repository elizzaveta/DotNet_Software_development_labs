using System;
using System.Text.RegularExpressions;

namespace dotnet_lab_3
{
    class Program
    {
        static void Main(string[] args)
        {
            ClientData client1 = new ClientData("Select * ", "Timchenko", "Yriivna", "mail@gmail.com", "105; DROP TABLE Suppliers", "1");

            HandleDataCorrectness handler1 = new HandleDataCorrectness();
            Console.WriteLine(handler1.VerifyOrderData(client1));

            HandleSqlInjection handler2 = new HandleSqlInjection();
            Console.WriteLine(handler2.VerifyOrderData(client1));
            Console.WriteLine();

            HandleDataCorrectness dataCorrectness_handler = new HandleDataCorrectness();
            HandleSqlInjection sqlInjection_handler = new HandleSqlInjection();
            HandleXssVulnerabilities xssVulnerability_handler = new HandleXssVulnerabilities();

            dataCorrectness_handler.SetNext(sqlInjection_handler).SetNext(xssVulnerability_handler);

            ClientData client2 = new ClientData("65", "Timchenko", "Yriivna", "mail@@gmail.com", "105 street", "1");
            ClientData client3 = new ClientData("Select * ", "Timchenko", "Yriivna", "mail@gmail.com", "105; DROP TABLE Suppliers", "1");
            ClientData client4 = new ClientData("<script>alert(123)</script> ", "Timchenko", "Yriivna", "mail@gmail.com", "105 street", "1");


            Console.WriteLine("client2:");
            Console.WriteLine(dataCorrectness_handler.VerifyOrderData(client2));
            Console.WriteLine("client3:");
            Console.WriteLine(dataCorrectness_handler.VerifyOrderData(client3));
            Console.WriteLine("client4:");
            Console.WriteLine(dataCorrectness_handler.VerifyOrderData(client4));

        }
        public static void test1()
        {
            Console.WriteLine("If needed handle");
            Console.WriteLine("liza " + handle_email("liza"));
            Console.WriteLine("liza@nm " + handle_email("liza@nm"));
            Console.WriteLine("..liza@gmail.com " + handle_email("..liza@gmail.com"));
            Console.WriteLine("liza@@gmail.com " + handle_email("liza@@gmail.com"));
            Console.WriteLine("liza@gmail.com " + handle_email("liza@gmail.com"));
        }
        public static void test2()
        {
            string nameParam = "l9iza";
            Console.Write(nameParam + " ");
            var name = nameParam.Trim();
            if (!Regex.IsMatch(name, @"^[\p{L}\p{M}' \.\-]+$"))
            {
                Console.WriteLine("fail");
            }
            name = name.Replace("'", "&#39;");
            Console.WriteLine(name);
        }
        public static void test3()
        {
            Console.WriteLine("123 " + SQL_injection_detect("123"));
            Console.WriteLine("1 or 1 " + SQL_injection_detect("1 or 1"));
            Console.WriteLine("1 = 1 " + SQL_injection_detect("1 = 1"));
            Console.WriteLine("select " + SQL_injection_detect("select"));
        }
        public static void test4()
        {


            string myString = "input";
            Regex tagRegex = new Regex(@"<\s*([^ >]+)[^>]*>.*?<\s*/\s*\1\s*>");
            Regex tagRegex2 = new Regex(@"<[^>]+>");
            bool hasTags = tagRegex.IsMatch(myString);
            Console.WriteLine(myString + " " + hasTags);

            while (true)
            {
                myString = Console.ReadLine();
                hasTags = tagRegex.IsMatch(myString);
                bool hasTags2 = tagRegex2.IsMatch(myString);
                Console.WriteLine(myString + ": " + (hasTags || hasTags2));
            }
        }
        private static bool handle_email(string value)
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
        public static bool SQL_injection_detect(string userInput)
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

