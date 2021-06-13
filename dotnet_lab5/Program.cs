using System;
using System.Linq;
using System.Numerics;
using System.Xml.Linq;
using System.Text;

namespace dotnet_lab_5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            XDocument company = new XDocument(new XElement("company",
                new XElement("employees",
                new XElement("employee",
                    new XElement("first_name", "Іван"),
                    new XElement("last_name", "Савченко"),
                    new XElement("petronym", "Олександрович"),
                    new XElement("birthday", "12.06.1970"),
                    new XElement("tab_numb", "96"),
                    new XElement("pod_numb", "1111111111"),
                    new XElement("education", "bachelor"),
                    new XElement("specialty", "юрист"),
                    new XElement("start_work_date", "12.03.2020")),
                new XElement("employee",
                    new XElement("first_name", "Петро"),
                    new XElement("last_name", "Коваленко"),
                    new XElement("petronym", "Миколайович"),
                    new XElement("birthday", "23.11.1983"),
                    new XElement("tab_numb", "48"),
                    new XElement("pod_numb", "2222222222"),
                    new XElement("education", "bachelor"),
                    new XElement("specialty", "бухгалтер"),
                    new XElement("start_work_date", "13.03.2019")),
                new XElement("employee",
                    new XElement("first_name", "Надія"),
                    new XElement("last_name", "Петренко"),
                    new XElement("petronym", "Юріївна"),
                    new XElement("birthday", "09.11.1999"),
                    new XElement("tab_numb", "73"),
                    new XElement("pod_numb", "3333333333"),
                    new XElement("education", "bachelor"),
                    new XElement("specialty", "юрист"),
                    new XElement("start_work_date", "15.03.2012"))
            ),
            new XElement("salary_per_month", 
                new XElement("salary_m",
                    new XElement("pod_numb", "1111111111"),
                    new XElement("month", "3"),
                    new XElement("salary", "4311")),
                new XElement("salary_m",
                    new XElement("pod_numb", "1111111111"),
                    new XElement("month", "4"),
                    new XElement("salary", "8611")),
                new XElement("salary_m",
                    new XElement("pod_numb", "11"),
                    new XElement("month", "3"),
                    new XElement("salary", "4322")),
                new XElement("salary_m",
                    new XElement("pod_numb", "11"),
                    new XElement("month", "4"),
                    new XElement("salary", "8622")),
                new XElement("salary_m",
                    new XElement("pod_numb", "11"),
                    new XElement("month", "3"),
                    new XElement("salary", "4333")),
                new XElement("salary_m",
                    new XElement("pod_numb", "11"),
                    new XElement("month", "4"),
                    new XElement("salary", "8633"))
            )));
            company.Save("Company.xml");
            Console.WriteLine(company);


            q1_getAllEmployees(company);
            q2_getAllEmployeesOrderedTabNumb(company);
            q3_getSalaryByPodNumb(company, "1111111111");
            q4_getFullYearsOnWork(company);
            q5_getSalaryForMonth(company);
            q6_getEmpSalGraterThan(company, 8630);
            q7_getAvgSalaryByPodNumb(company, "1111111111");
            q8_getEmpOlderThan(company, 50);
            q9_getOveralSalary(company, 18, 78);
            q10_getAMaxMinSalaryForMonth(company, 4);
        }
        static void q1_getAllEmployees(XDocument company)
        {
            Console.WriteLine("\n\n\n1) Перелік усіх робітників фірми");
            Console.WriteLine("--------------------");

            var result = from emp in company.Element("company").Element("employees").Elements("employee")
                         select emp;

            foreach(var emp in result)
                Console.WriteLine($"т.н.: {emp.Element("tab_numb").Value}: {emp.Element("first_name").Value} {emp.Element("last_name").Value} {emp.Element("petronym").Value}");


        }
        static void q2_getAllEmployeesOrderedTabNumb(XDocument company)
        {
            Console.WriteLine("\n\n2) Перелік робітників, відсортований за табельним номером");
            Console.WriteLine("--------------------");

            var result = from emp in company.Element("company").Element("employees").Elements("employee")
                         orderby emp.Element("tab_numb").Value 
                         select emp;

            foreach (var emp in result)
                Console.WriteLine($"т.н.: {emp.Element("tab_numb").Value}: {emp.Element("first_name").Value} {emp.Element("last_name").Value} {emp.Element("petronym").Value}");

        }
        static void q3_getSalaryByPodNumb(XDocument company,  string p_numb)
        {
            Console.WriteLine("\n\n3) Заробітна плата по місяцім робітника з \nномером облікової картки платника податків '{0}'", p_numb);
            Console.WriteLine("--------------------");

            var result = from sal in company.Element("company").Element("salary_per_month").Elements("salary_m")
                         where sal.Element("pod_numb").Value == p_numb
                         select sal;

            foreach (var sal in result)
                Console.WriteLine($"місяць: {sal.Element("month").Value}, заробітна плата {sal.Element("salary").Value}");

        }
        static void q4_getFullYearsOnWork(XDocument company)
        {
            Console.WriteLine("\n\n4) Кількість повних років роботи робітників підприємства");
            Console.WriteLine("--------------------");

            var result = from e in company.Element("company").Element("employees").Elements("employee")
                         select new
                         {
                             employee = string.Format($"т.н.: {e.Element("tab_numb").Value}: {e.Element("last_name").Value} {e.Element("first_name").Value} {e.Element("petronym").Value}"),
                             yearsOnWork = DateTime.Now.Year - Convert.ToDateTime(e.Element("start_work_date").Value).Year
                         };

            foreach (var emp in result)
                Console.WriteLine($"{emp.employee} : {emp.yearsOnWork}");
        }
        static void q5_getSalaryForMonth(XDocument company)
        {
            Console.WriteLine("\n\n5) Сумма сплаченої зарплати підприємством по місяцям");
            Console.WriteLine("--------------------");

            var result = from e in company.Element("company").Element("salary_per_month").Elements("salary_m")
                         group e by e.Element("month").Value;

            foreach (var group in result)
            {
                Console.Write("місяць: {0},", group.Key);
                int sum = group.Sum(group => Int16.Parse(group.Element("salary").Value));
                Console.WriteLine(" сплачені кошти: {0}", sum);
            }

        }
        static void q6_getEmpSalGraterThan(XDocument company,  int salary)
        {
            Console.WriteLine("\n\n6) Перелік робітників, які отримували з.п. меншу за " + salary);
            Console.WriteLine("--------------------");

            var result = (from s in company.Element("company").Element("salary_per_month").Elements("salary_m")
                          where Convert.ToInt32(s.Element("salary").Value) < salary
                          join e in company.Element("company").Element("employees").Elements("employee")
                         on s.Element("pod_numb").Value equals e.Element("pod_numb").Value
                          select new
                         {
                             employee = string.Format($"т.н.: {e.Element("tab_numb").Value}: {e.Element("last_name").Value} {e.Element("first_name").Value} {e.Element("petronym").Value}")
                         }).Distinct();

            foreach (var e in result)
                Console.WriteLine(e.employee);

        }
        static void q7_getAvgSalaryByPodNumb(XDocument company, string p_numb)
        {
            Console.WriteLine("\n\n7) Середня з.п. робітника \nз номером облікової картки платника податків '{0}'", p_numb);
            Console.WriteLine("--------------------");

            var result = company.Element("company").Element("salary_per_month").Elements("salary_m").
                Where(p => p.Element("pod_numb").Value == p_numb).
                Select(p => Convert.ToInt32(p.Element("salary").Value));

            Console.WriteLine(result.Average());
        }
        static void q8_getEmpOlderThan(XDocument company, int age)
        {
            Console.WriteLine("\n\n8) Кількість робітників старших за " + age);
            Console.WriteLine("--------------------");

            var result = company.Element("company").Element("employees").Elements("employee").
                        Where(t => ((DateTime.Now.Year - Convert.ToDateTime(t.Element("birthday").Value).Year) > age)).
                        Count();


            Console.WriteLine(result);

        }
        static void q9_getOveralSalary(XDocument company, int min_age, int max_age)
        {
            Console.WriteLine("\n9) Середня заробітна плата робітників віком від {0} до {1}", min_age, max_age);
            Console.WriteLine("--------------------");

            var result = from e in company.Element("company").Element("employees").Elements("employee")
                         where (DateTime.Now.Year - Convert.ToDateTime(e.Element("birthday").Value).Year) > min_age
                         where (DateTime.Now.Year - Convert.ToDateTime(e.Element("birthday").Value).Year) < max_age
                         join s in company.Element("company").Element("salary_per_month").Elements("salary_m")
                         on e.Element("pod_numb").Value equals s.Element("pod_numb").Value
                         select Convert.ToInt32(s.Element("salary").Value);


              Console.WriteLine("з.п.: {0}", result.Average());

        }
        static void q10_getAMaxMinSalaryForMonth(XDocument company, int month)
        {
            Console.WriteLine("\n\n10) Найбільша та найменша з.п. за місяць {0}: ", month);
            Console.WriteLine("--------------------");

            var result = company.Element("company").Element("salary_per_month").Elements("salary_m").
                Where(s => Convert.ToInt32(s.Element("month").Value) == month).
                Select(s => Convert.ToInt32(s.Element("salary").Value));



            Console.WriteLine($"Найбільша: {result.Max()}, найменша: {result.Min()}");
        }








    }
}
