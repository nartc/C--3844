using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Globalization;

namespace Employee_Payroll
{
    [Serializable()]
    public class Salary: Employee
    {
        public string staffType;
       

        public Salary(String eName) : base(eName)
        {

        }

        public Salary()
        {
            empName = null;
        }

        protected override void calcGross()
        {

            
            Console.WriteLine("Which type of salary staff are you?");
            Console.WriteLine("-----------------");
            Console.WriteLine("1. Regular Staff");
            Console.WriteLine("2. Executive Staff");
            Console.WriteLine("-----------------");
            Console.Write("Please pick one: ");
            int input = Convert.ToInt32(Console.ReadLine());

            if(input == 1)
            {
                staffType = "Regular";
                empName += " -" + staffType.ToUpper();
                gross = 50000;

                //Console.WriteLine("Your gross pay is: " + gross.ToString("C2"));
                //Console.WriteLine("based on your staff type: " + staffType);
                //grossed = true;
                //Console.WriteLine("\n\n");
                //Console.WriteLine("Hit ENTER to go back...");
                //Console.ReadLine();
                //Console.Clear();

            }
            else if(input == 2)
            {
                staffType = "Executive";
                empName += " -" + staffType.ToUpper();
                gross = 100000;
            }

            Console.WriteLine("Your gross pay is: " + gross.ToString("C2"));
            Console.WriteLine("based on your staff type: " + staffType);
            grossed = true;
            Console.WriteLine("\n\n");
            Console.WriteLine("Hit ENTER to go back...");
            Console.ReadLine();
            Console.Clear();
        }

        protected override void dispEmp()
        {
            Console.WriteLine("Employee Name: " + empName.ToUpper());
            Console.WriteLine("----------------------------");

            if (grossed)
            {
                Console.WriteLine("Your gross pay: " + gross.ToString("C2"));
            }
            else
            {
                Console.WriteLine("Your gross pay: Have not specified.");
            }
            

            if (netted)
            {
                Console.WriteLine("Your net pay: " + net.ToString("C2"));
            }
            else
            {
                Console.WriteLine("Your net pay: Have not calculated.");
            }

            string sFormatted = String.Format("{0:0.##\\%}", net_percent);

            if (perc)
            {
                Console.WriteLine("Your net percentage is: " + sFormatted);
            }
            else
            {
                Console.WriteLine("Your net percentage is: Have not calculated.");
            }

            Console.WriteLine("\n\n");
            Console.WriteLine("Hit ENTER to go back...");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
