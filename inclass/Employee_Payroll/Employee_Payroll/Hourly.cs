using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Globalization;
using System.Xml.Serialization;

namespace Employee_Payroll
{
    [Serializable()]
    public class Hourly: Employee
    {
        public double rate;
        public int hours;

        public Hourly(String eName) : base(eName)
        {

        }

        public Hourly()
        {
            empName = null;
        }

        protected override void calcGross()
        {
            Console.WriteLine("Please enter your hours worked: ");
            hours = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter your rate: ");
            rate = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("----------------------------");
                if(hours > 40)
                {
                    gross = (rate * 40) + ((rate * 1.5) * (hours - 40));
                 
                }
                else
                {
                    gross = rate * hours;
                }
            Console.WriteLine("Your gross pay is: " + gross.ToString("C2"));
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
                Console.WriteLine("Your hours worked: " + hours);
                Console.WriteLine("Your rate: " + rate.ToString("C2"));
                Console.WriteLine("Your gross pay: " + gross.ToString("C2"));
            }
            else
            {
                Console.WriteLine("Your hours worked: Have not entered." );
                Console.WriteLine("Your rate: Have not entered." );
                Console.WriteLine("Your gross pay: Have not calculated.");
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
