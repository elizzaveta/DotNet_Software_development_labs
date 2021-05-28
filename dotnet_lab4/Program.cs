using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Personnel Number


namespace dotnet_lab_4
{
    class Program
    {
        public class Employee
        {
            public string last_name;
            public string first_name;
            public string petronym;
            public string birthday;
            public string tab_numb;
            public string pod_numb;
            public string education;
            public string specialty;
            public string start_work_date;
            public Employee(string lname, string fname, string petr, string bday, string tnumb, string pnumb, string ed, string sp, string st_work_date )
            {
                this.last_name = lname;
                this.first_name = fname;
                this.petronym = petr;
                this.birthday = bday;
                this.tab_numb = tnumb;
                this.pod_numb = pnumb;
                this.education = ed;
                this.specialty = sp;
                this.start_work_date = st_work_date;
            }
            public override string ToString()
            {
                return "т.н.: "+this.tab_numb + ": " +this.last_name.ToString() + " " + this.first_name + " " +
               this.petronym;
            }
        }
        class Salary_per_month
        {
            public string pod_numb;
            public int month;
            public int salary;
            public Salary_per_month(string pnumb, int m, int sal)
            {
                this.pod_numb = pnumb;
                this.month = m;
                this.salary = sal;
            }
            public override string ToString()
            {
                return "(" + this.pod_numb.ToString() + "; " + this.month + "; " +
               this.salary + ")";
            }
        }
        
        /// <summary>
        /// ///////////////////////////////////////////////////////////////////////////////////////////////
        /// </summary>
       
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            List<Employee> employees = new List<Employee>
            {
                new Employee("Савченко","Іван","Олександрович","12.06.1970","96","1111111111","bachelor's degree","юрист","12.03.2020"),
                new Employee("Коваленко","Петро","Миколайович","23.11.1983","48","2222222222","bachelor's degree","бухгалтер","13.03.2019"),
                new Employee("Петренко","Надія","Юріївна","09.11.1999","73","3333333333","bachelor's degree","юрист","15.03.2012")
            };
            List<Salary_per_month> salary = new List<Salary_per_month>
            {
                new Salary_per_month("1111111111",3,4311),
                new Salary_per_month("1111111111",4,8611),
                new Salary_per_month("2222222222",3,4322),
                new Salary_per_month("2222222222",4,8622),
                new Salary_per_month("3333333333",3,4333),
                new Salary_per_month("3333333333",4,8633)
            };

            q1_getAllEmployees(employees);
            q2_getAllEmployees_orderTabNumber(employees);
            q3_getSalariesOfEmployee(salary, "1111111111");
            q4_getFullWorkYears(employees);
            q5_getSalaryForMonth(salary);
            q6_getListOfMOfEachEmployee(employees, salary);
            q7_getEmpSalGraterThan(employees, salary, 8630);
            q8_getOvaralSalaryForEach(salary, "1111111111");
            q9_getGreatestSalaryEmployee(employees, salary);
            q10_getOrderedEmp(employees, salary);
            q11_getOlderThan(employees, 50);
            q12_getAvgSalaryOfworker(employees, salary);
            q13_getMaxMinSalaryForMonth(salary, 4);
            q14_get(employees, salary, 18, 78);
            q15_get(employees, salary, "юрист");

        }
        static void q1_getAllEmployees(List<Employee> emp)
        {
            Console.WriteLine("1) Перелік усіх робітників фірми");
            Console.WriteLine("--------------------");

            var result = from e in emp
                         select e;

            foreach (var e in result)
                Console.WriteLine(e);
        }
        static void q2_getAllEmployees_orderTabNumber(List<Employee> emp)
        {
            Console.WriteLine("\n\n2) Перелік робітників, відсортований за табельним номером");
            Console.WriteLine("--------------------");

            var result = from e in emp
                         orderby e.tab_numb
                         select e;

            foreach (var e in result)
                Console.WriteLine(e);
        }
        static void q3_getSalariesOfEmployee(List<Salary_per_month> salary, string p_numb)
        {
            Console.WriteLine("\n\n3) Заробітна плата по місяцім робітника з \nномером облікової картки платника податків '{0}'", p_numb);
            Console.WriteLine("--------------------");

            var result = from e in salary
                         where e.pod_numb == p_numb
                         select e;

            foreach (var e in result)
                Console.WriteLine("місяць: {0}, заробітна плата: {1}", e.month, e.salary);
        }
        static void q4_getFullWorkYears(List<Employee> emp)
        {
            Console.WriteLine("\n\n4) Кількість повних років роботи робітників підприємства");
            Console.WriteLine("--------------------");

            var result = from e in emp
                         select new
                         {
                             employee = string.Format("т.н.: {0}: {1} {2} {3}", e.tab_numb, e.last_name, e.first_name, e.petronym),
                             yearsOnWork = DateTime.Now.Year - Convert.ToDateTime(e.start_work_date).Year
                         };

            foreach (var e in result)
                Console.WriteLine(e.employee + " : " + e.yearsOnWork);

        }
        static void q5_getSalaryForMonth(List<Salary_per_month> salary)
        {
            Console.WriteLine("\n5) Сумма сплаченої зарплати підприємством по місяцям");
            Console.WriteLine("--------------------");

            var result = from s in salary
                         group s by s.month;

            foreach (var group in result)
            {
                Console.Write("місяць: {0},", group.Key);
                int sum = group.Sum(group => group.salary);
                Console.WriteLine(" сплачені кошти: {0}", sum);
            }
        }
        static void q6_getListOfMOfEachEmployee(List<Employee> emp, List<Salary_per_month> sal)
        {
            Console.WriteLine("\n6) Перелік місяців, за які була отримана зарплата по кожному робітнику");
            Console.WriteLine("--------------------");
            

            var result3 = emp.GroupJoin(
                        sal, 
                        s => s.pod_numb, 
                        e => e.pod_numb, 
                        (team, pls) => new  
                        {
                            Name = team.last_name,
                            Players = pls.Select(p => p.month)
                        });


            foreach (var team in result3)
            {
                Console.WriteLine(team.Name);
                foreach (int player in team.Players)
                {
                    Console.WriteLine("  "+player);
                }
                Console.WriteLine();
            }

           
        }
        static void q7_getEmpSalGraterThan(List<Employee> emp, List<Salary_per_month> sal, int salary)
        {
            Console.WriteLine("\n7) Перелік робітників, які отримували з.п. вищу за " + salary);
            Console.WriteLine("--------------------");

            var result = (from s in sal
                          where s.salary > salary
                          join e in emp on s.pod_numb equals e.pod_numb
                          select new
                          {
                              employee = string.Format("т.н.: {0}: {1} {2} {3}", e.tab_numb, e.last_name, e.first_name, e.petronym)
                          }).Distinct();

            foreach (var e in result)
                Console.WriteLine( e.employee);
        }
        static void q8_getOvaralSalaryForEach(List<Salary_per_month> sal, string p_numb)
        {

            Console.WriteLine("\n8) Середня з.п. робітника \nз номером облікової картки платника податків '{0}'", p_numb);
            Console.WriteLine("--------------------");

            var result = sal. Where(t => (t.pod_numb == p_numb)).Select(t => t.salary);

            Console.WriteLine("Середня з.п.: {0}", result.Average());


        }
        static void q9_getGreatestSalaryEmployee(List<Employee> emp, List<Salary_per_month> sal)
        {
            Console.WriteLine("\n9) Робітник з найвищою забобітною платою");
            Console.WriteLine("--------------------");

            var result = (from s in sal
                         group s by s.pod_numb into sg
                         join e in emp on sg.FirstOrDefault().pod_numb equals e.pod_numb
                         orderby sg.Sum(sg => sg.salary)
                         select new
                         {
                             employee = string.Format("т.н.: {0}: {1} {2} {3}", e.tab_numb, e.last_name, e.first_name, e.petronym),
                             salary = sg.Sum(sg => sg.salary)
                         }).Last();


             Console.WriteLine(result.employee + " : " + result.salary);
        }
        static void q10_getOrderedEmp(List<Employee> emp, List<Salary_per_month> sal)
        {
            Console.WriteLine("\n10) Перелік робітників в алфафвітному порядку");
            Console.WriteLine("--------------------");

            var result = emp.Select(e => new { lname = e.last_name, fname = e.first_name, petronym = e.petronym, tab_numb = e.tab_numb })
                .OrderBy(t => t.lname).ThenBy(t => t.fname).ThenBy(t => t.petronym);

            foreach (var row in result)
            {
                Console.WriteLine(string.Format("т.н.: {0}: {1} {2} {3}", row.tab_numb, row.lname, row.fname, row.petronym));
            }
        }
        static void q11_getOlderThan(List<Employee> emp, int age)
        {

            Console.WriteLine("\n11) Кількість робітників старших за "+ age);
            Console.WriteLine("--------------------");

            var result = emp. Where(t => ((DateTime.Now.Year - Convert.ToDateTime(t.birthday).Year) > age) ).Count();

            Console.WriteLine(result);
        }
        static void q12_getAvgSalaryOfworker(List<Employee> emp, List<Salary_per_month> sal)
        {
            Console.WriteLine("\n12) Загальна зарплата по всім місяцям кожного робітника ");
            Console.WriteLine("--------------------");

            var result = from s in sal
                         group s by s.pod_numb into sg
                         join e in emp on sg.FirstOrDefault().pod_numb equals e.pod_numb
                         select new
                         {
                             employee = string.Format("т.н.: {0}: {1} {2} {3}", e.tab_numb, e.last_name, e.first_name, e.petronym),
                             salary = sg.Sum(sg => sg.salary)
                         };

            foreach (var e in result)
                Console.WriteLine(e.employee + " : " + e.salary);
        }
        static void q13_getMaxMinSalaryForMonth(List<Salary_per_month> sal, int month)
        {
            Console.WriteLine("\n13) Найбільша та найменша з.п. за місяць: ", month);
            Console.WriteLine("--------------------");

            var result = sal.Where(s => (s.month == month)).Select(s => s.salary);
            
            Console.WriteLine("Найбільша: {0}, найменша: {1}", result.Max(), result.Min());

        }
        static void q14_get(List<Employee> emp, List<Salary_per_month> sal, int min_age, int max_age)
        {
            Console.WriteLine("\n14) Середня заробітна плата робітників віком від {0} до {1}", min_age, max_age);
            Console.WriteLine("--------------------");

            var result = from e in emp
                         where (DateTime.Now.Year - Convert.ToDateTime(e.birthday).Year) > min_age
                         where (DateTime.Now.Year - Convert.ToDateTime(e.birthday).Year) < max_age
                         join s in sal on e.pod_numb equals s.pod_numb
                         select s.salary;
            
            Console.WriteLine("з.п.: {0}", result.Average());
        }
        static void q15_get(List<Employee> emp, List<Salary_per_month> sal, string job_title)
        {
            Console.WriteLine("\n15) Відсоток отриманих коштів від усіх сплачених коштів робітників спеціальності {0}", job_title);
            Console.WriteLine("--------------------");

            var result = from e in emp
                         where e.specialty == job_title
                         join s in sal on e.pod_numb equals s.pod_numb into a
                         let overal = sal.Sum(sal => sal.salary)
                         let job = a.Sum(a => a.salary)
                         let res = ((Convert.ToDouble(job) / (Convert.ToDouble(overal) )))*100
                         select res;

            Console.WriteLine("{0}%", Convert.ToInt16(result.Average()));
        }


    }
}
