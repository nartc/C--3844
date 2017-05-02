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
    [XmlInclude(typeof(Hourly))]
    [XmlInclude(typeof(Salary))]
    [XmlInclude(typeof(Commission))]
    [Serializable()]
    
    public class Employee
    {
        float taxrate = 0.2f;
        public double gross;
        public double tax;
        public double net;
        public double net_percent;
        public string empName;
        public bool grossed = false;
        public bool taxed = false;
        public bool netted = false;
        public bool perc = false;

        public string Emp
        {
            get { return empName; }
        }

        public Employee()
        {
            empName = null;
        }



        public Employee(String eName)
        {
            empName = eName;
        }


        public void empMenu()
        {

            for(;;)
            {
                
                Console.WriteLine("Employee name: " + empName.ToUpper());
                Console.WriteLine("----------------------------");
                Console.WriteLine("1. Calculate Gross");
                Console.WriteLine("2. Calculate Tax");
                Console.WriteLine("3. Calculate Net");
                Console.WriteLine("4. Calculate Net Percentage");
                Console.WriteLine("5. Display Details");
                Console.WriteLine("6. Reset data.");
                Console.WriteLine("7. Back to main menu");
                Console.WriteLine("----------------------------");
                Console.WriteLine("Please pick one option: ");
                Console.WriteLine();
                Console.WriteLine("Note: Please be advised to go through option 1 - 4 in order.");

                String str = Convert.ToString(Console.ReadLine());
                Thread.Sleep(1 * 200);
                Console.Clear();

                if (string.IsNullOrEmpty(str))
                {
                    Console.WriteLine("Please enter [1-6] to pick an option.");
                    Console.WriteLine();
                }
                else
                {
                    if(str == "1" && str.Length == 1)
                    {
                        if (!grossed)
                        {
                            calcGross();
                        }
                        else
                        {
                            Console.WriteLine("Gross Pay has been calculated.");
                            Console.WriteLine("\n\n");
                            Console.WriteLine("Hit ENTER to go back...");
                            Console.ReadLine();
                            Console.Clear();
                        }
                    }
                    else if (str == "2" && str.Length == 1)
                    {
                        if (!taxed)
                        {
                            calcTax();
                        }
                        else
                        {
                            Console.WriteLine("Tax has been calculated.");
                            Console.WriteLine("\n\n");
                            Console.WriteLine("Hit ENTER to go back...");
                            Console.ReadLine();
                            Console.Clear();
                        }
                    }
                    else if (str == "3" && str.Length == 1)
                    {
                        if (!netted)
                        {
                            calcNet();
                        }
                        else
                        {
                            Console.WriteLine("Net Pay has been calculated.");
                            Console.WriteLine("\n\n");
                            Console.WriteLine("Hit ENTER to go back...");
                            Console.ReadLine();
                            Console.Clear();
                        }
                    }
                    else if (str == "4" && str.Length == 1)
                    {
                        if (!perc)
                        {
                            calcNetPerc();
                        }
                        else
                        {
                            Console.WriteLine("Net Percentage has been calculated.");
                            Console.WriteLine("\n\n");
                            Console.WriteLine("Hit ENTER to go back...");
                            Console.ReadLine();
                            Console.Clear();
                        }
                    }
                    else if(str == "5" && str.Length == 1)
                    {
                        dispEmp();
                    }
                    else if (str == "6" && str.Length == 1)
                    {
                        resetData();
                    }
                    else if(str == "7" && str.Length == 1)
                    {
                        break;
                    }
                    else if(str.Length > 1)
                    {
                        Console.WriteLine("Please enter only one number at a time.");
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine("Invalid input.");
                        Console.WriteLine();
                    }

                }

            }
        }

        protected virtual void calcGross()
        {
            Console.WriteLine("You're in Emp's Calc Gross");
            Console.WriteLine("\n\n");
            Console.WriteLine("Hit ENTER to go back...");
            Console.ReadLine();
            Console.Clear();
        }

        protected void calcTax()
        {
            if(grossed)
            {
                string sFormatted = String.Format("{0:0.##\\%}", taxrate);
                Console.WriteLine("With the tax rate of " + sFormatted);
                tax = gross * taxrate;
                Console.WriteLine("Your tax is: " + tax.ToString("C2"));
                taxed = true;
                Console.WriteLine("\n\n");
                Console.WriteLine("Hit ENTER to go back...");
                Console.ReadLine();
                Console.Clear();
            }
            else
            {
                Console.WriteLine("You have not calculated your gross pay yet.");
                Console.WriteLine("\n\n");
                Console.WriteLine("Hit ENTER to go back...");
                Console.ReadLine();
                Console.Clear();

            }
            
        }

        protected void calcNet()
        {
            if(grossed && taxed)
            {
                Console.WriteLine("Your gross pay is: " + gross.ToString("C2"));
                Console.WriteLine("Your tax is: " + tax.ToString("C2"));
                Console.WriteLine("----------------------------");
                net = gross - tax;
                Console.WriteLine("Your net pay is: " + net.ToString("C2"));
                netted = true;
                Console.WriteLine("\n\n");
                Console.WriteLine("Hit ENTER to go back...");
                Console.ReadLine();
                Console.Clear();
            }
            else
            {
                Console.WriteLine("You have not calculated your gross pay, tax yet.");
                Console.WriteLine("\n\n");
                Console.WriteLine("Hit ENTER to go back...");
                Console.ReadLine();
                Console.Clear();
            }
            
        }

        protected void calcNetPerc()
        {
            if(grossed && taxed && netted)
            {
                Console.WriteLine("Your gross pay is: " + gross.ToString("C2"));
                Console.WriteLine("Your net pay is: " + net.ToString("C2"));
                Console.WriteLine("----------------------------");
                net_percent = (net / gross) * 100;
                string sFormatted = String.Format("{0:0.##\\%}", net_percent);
                Console.WriteLine("Your net percentage is: " + sFormatted);
                perc = true;
                Console.WriteLine("\n\n");
                Console.WriteLine("Hit ENTER to go back...");
                Console.ReadLine();
                Console.Clear();
            }
            else
            {
                Console.WriteLine("You have not calculated your gross pay, tax, and net pay yet.");
                Console.WriteLine("\n\n");
                Console.WriteLine("Hit ENTER to go back...");
                Console.ReadLine();
                Console.Clear();
            }
        }

        protected virtual void dispEmp()
        {
            Console.WriteLine("You are in Emp's Display Emp");
            Console.WriteLine("\n\n");
            Console.WriteLine("Hit ENTER to go back...");
            Console.ReadLine();
            Console.Clear();
        }

        protected void resetData()
        {
            char input;


            Console.WriteLine("This will allow you to re-enter data for this session only. Please enter your data to calculate your new payroll for this session. Are you sure you want to proceed? (Y/N)");
            string str = Convert.ToString(Console.ReadLine());
            Thread.Sleep(1 * 200);

            if (string.IsNullOrEmpty(str))
            {
                Console.WriteLine("Invalid. Please try again.");
                Console.WriteLine();
            }
            else
            {
                input = str[0];
                if((input == 'y' || input == 'Y') && str.Length == 1 )
                {
                    grossed = false;
                    netted = false;
                    taxed = false;
                    perc = false;

                    Console.WriteLine("Please go back to Calculate Gross to re-enter your data.");
                    Console.WriteLine("\n\n");
                    Console.WriteLine("Hit ENTER to go back...");
                    Console.ReadLine();
                    Console.Clear();
                }
                else if ((input == 'n' || input == 'N') && str.Length == 1)
                {
                    Console.WriteLine("Okay.");
                    Thread.Sleep(1 * 200);
                    Console.Clear();
                }
            }
            
        }
    }
}
