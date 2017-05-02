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
    public class Commission: Employee
    {
        public double itemPrice;
        public int itemQty;

        public Commission(String eName) : base(eName)
        {

        }

        public Commission()
        {
            empName = null;
        }

        protected override void calcGross()
        {
            Console.Write("Please enter number of units sold: ");
            itemQty = Convert.ToInt32(Console.ReadLine());
            Console.Write("Please enter the unit price: ");
            itemPrice = Convert.ToDouble(Console.ReadLine());

            gross = (itemQty * itemPrice) * .50;
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
                Console.WriteLine("Items sold: " + itemQty);
                Console.WriteLine("Unit price: " + itemPrice.ToString("C2"));
                Console.WriteLine("Your gross pay: " + gross.ToString("C2"));
            }
            else
            {
                Console.WriteLine("Items sold: Have not entered.");
                Console.WriteLine("Unit price: Have not entered." );
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
