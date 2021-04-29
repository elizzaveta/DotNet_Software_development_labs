using System;
using System.Text.RegularExpressions;

namespace dotnet_lab_3
{
    class Program
    {
        static void Main(string[] args)
        {
            HandleDataCorrectness dataCorrectness_handler = new HandleDataCorrectness();
            HandleSqlInjection sqlInjection_handler = new HandleSqlInjection();
            HandleXssVulnerabilities xssVulnerability_handler = new HandleXssVulnerabilities();

            dataCorrectness_handler.SetNext(sqlInjection_handler).SetNext(xssVulnerability_handler);

            ClientData client1 = new ClientData("Anna", "Ivanova", "Yriivna", "mail@@gmail.com", "105 street", "1");
            ClientData client2 = new ClientData("Anna", "Ivanova", "Yriivna", "mail@gmail.com", "105; DROP TABLE Suppliers", "1");
            ClientData client3 = new ClientData("<script>alert(123)</script> ", "Ivanova", "Yriivna", "mail@gmail.com", "105 street", "1");


            Console.WriteLine("client1:");
            Console.WriteLine(dataCorrectness_handler.VerifyOrderData(client1));
            Console.WriteLine("client2:");
            Console.WriteLine(dataCorrectness_handler.VerifyOrderData(client2));
            Console.WriteLine("client3:");
            Console.WriteLine(dataCorrectness_handler.VerifyOrderData(client3));


            input_test_func();
        }
        public static void input_test_func()
        {

            HandleDataCorrectness dataCorrectness_handler = new HandleDataCorrectness();
            HandleSqlInjection sqlInjection_handler = new HandleSqlInjection();
            HandleXssVulnerabilities xssVulnerability_handler = new HandleXssVulnerabilities();

            dataCorrectness_handler.SetNext(sqlInjection_handler).SetNext(xssVulnerability_handler);

            while (true)
            {
                Console.Write("\nData:\nFirst Name: ");
                string fn = Console.ReadLine();
                Console.Write("Last Name: ");
                string ln = Console.ReadLine();
                Console.Write("Petronym: ");
                string pm = Console.ReadLine();
                Console.Write("Email: ");
                string em = Console.ReadLine();
                Console.Write("Delivety Address: ");
                string da = Console.ReadLine();
                Console.Write("Delivety Type: ");
                string dt = Console.ReadLine();

                ClientData client = new ClientData(fn, ln, pm, em, da, dt);


                Console.WriteLine("\nclient:");
                Console.WriteLine(dataCorrectness_handler.VerifyOrderData(client));

            }
        }

    }
}

