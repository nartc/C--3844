using System;
using System.Collections.Generic;
using System.Threading;
using System.IO;
using System.Xml.Serialization;

namespace Employee_Payroll
{
    class Payroll
    {
        public List<Employee> empList = new List<Employee>();
        string dir = @"./output.xml";

        public static void Main(string[] args)
        {
            Payroll myEmp = new Payroll();

            myEmp.readEmployee();
            myEmp.empMenu();
            myEmp.writeEmployee();

        }

        public void readEmployee()
        {
            try
            {
                using (FileStream stream = new FileStream(dir, FileMode.Open))
                {
                    //var bFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                    //acctList = (List<Account>)bFormatter.Deserialize(stream);

                    XmlSerializer xDeserialize = new XmlSerializer(typeof(List<Employee>));
                    empList = (List<Employee>)xDeserialize.Deserialize(stream);
                    stream.Close();
                    if (empList.Count <= 0)
                    {
                        createEmp();
                    }
                }
            }
            catch (Exception e)
            {
                //Console.WriteLine("Error: " + e.Message);
                createEmp();
            }
        }

        public void empMenu()
        {
            int input;
            int number;
            string str;

            do
            {
                Console.Clear();
                Console.WriteLine("EMPLOYEE PORTAL");
                Console.WriteLine("-------------------------------");
                Console.WriteLine("1. Create an employee");
                Console.WriteLine("2. Remove an old employee");
                Console.WriteLine("3. Access employee portal");
                Console.WriteLine("4. Exit");
                Console.WriteLine("-------------------------------");
                str = Console.ReadLine();
                Console.Clear();

                if (!int.TryParse(str, out number) || string.IsNullOrEmpty(str))
                {
                    Console.WriteLine("Please enter [1-4] to pick an option.");
                    Console.WriteLine();

                }
                else
                {
                    input = Convert.ToInt32(str);
                    if (input == 1)
                    {
                        createEmp();
                        Console.WriteLine();
                    }
                    else if (input == 2)
                    {
                        removeEmp();
                        Console.WriteLine();
                    }
                    else if (input == 3)
                    {
                        accessEmp();
                        Console.WriteLine();
                    }
                    else if (input == 4)
                    {
                        Console.WriteLine("Goodbye!");
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please try again.");
                        Console.WriteLine();
                    }
                }
            } while (!int.TryParse(str, out number) || string.IsNullOrEmpty(str) || Convert.ToInt32(str) != 4);
        }

        public void createEmp()
        {
            String eName;
            int eType;
            bool empAlreadyExists = false;

            Console.WriteLine("Please enter your name: ");
            eName = Convert.ToString(Console.ReadLine());
            Thread.Sleep(1 * 1000);
            Console.WriteLine();

            if (string.IsNullOrEmpty(eName))
            {
                Console.WriteLine("Name is required. Please try again.");
                Console.WriteLine();
                createEmp();
            }
            else
            {
                Console.WriteLine("Which type of employee are you? ");
                Console.WriteLine("--------------");
                Console.WriteLine("1. Hourly");
                Console.WriteLine("2. Salary");
                Console.WriteLine("3. Commission");
                Console.WriteLine("--------------");
                Console.Write("Please pick one: ");
                eType = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                if(eType == 1)
                {
                    eName += " (Hourly)";
                }
                else if(eType == 2)
                {
                    eName += " (Salary)";
                }
                else if(eType == 3)
                {
                    eName += " (Commission)";
                }
                else
                {
                    Console.WriteLine("Invalid input.");
                    Console.WriteLine();
                    return;
                }

                for(int i = 0; i < empList.Count; i++)
                {
                    if (eName.Equals(empList[i].Emp))
                    {
                        empAlreadyExists = true;
                    }
                }

                if (empAlreadyExists)
                {
                    Console.WriteLine("Sorry, there is already an employee of this type associated with this name.");
                    Console.WriteLine("\n\n");
                    Console.WriteLine("Hit ENTER to try again...");
                    Console.ReadLine();
                    Console.Clear();
                }
                else
                {
                    if (eName.EndsWith("(Hourly)"))
                    {
                        empList.Add(new Hourly(eName));
                    }
                    else if (eName.EndsWith("(Salary)"))
                    {
                        empList.Add(new Salary(eName));
                    }
                    else if (eName.EndsWith("(Commission)"))
                    {
                        empList.Add(new Commission(eName));
                    }

                    Console.WriteLine("Employee " + "|" + eName.ToUpper() + "|" + " was successfully created.");
                    Thread.Sleep(1 * 1000);
                    Console.Clear();
                }
            }
        }

        public void removeEmp()
        {
            int empNum;
            string str;
            String employeeName;

            if (empList.Count > 0)
            {
                Console.WriteLine("CURRENT EMPLOYEES");
                Console.WriteLine("-----------------");

                for (int i = 0; i < empList.Count; i++)
                {
                    Console.WriteLine("Employee " + (i + 1) + ": " + empList[i].Emp.ToUpper());
                }

                Console.WriteLine("-----------------");
                Console.WriteLine("Please enter the employee number you want to remove or -1 to go back.");
                str = Console.ReadLine();
                Thread.Sleep(1 * 1000);
                Console.Clear();

                int number;

                if (!int.TryParse(str, out number) || string.IsNullOrEmpty(str))
                {
                    Console.WriteLine("Please enter a number.");
                    Console.WriteLine();
                }
                else
                {
                    empNum = Convert.ToInt32(str);
                    if (empNum == -1)
                    {
                        //Exit back to the menu.
                    }
                    else if(empNum <= empList.Count && empNum > 0)
                    {
                        for(int i = 0; i < empList.Count; i++)
                        {
                            if(empNum == (i + 1))
                            {
                                employeeName = empList[i].Emp;
                                empList.RemoveAt(i);
                                Console.WriteLine();
                                Console.WriteLine("Employee " + "|" + employeeName.ToUpper() + " was successfully removed.");
                                Thread.Sleep(1 * 1000);
                                Console.Clear();
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("There is no employee associated with that number. Please try again.");
                        Console.WriteLine();
                        removeEmp();
                    }
                }
            }
            else
            {
                Console.WriteLine("There are currently no employees in the system.");
                Console.WriteLine("\n\n");
                Console.WriteLine("Hit ENTER to go back to main MENU...");
                Console.ReadLine();
                Console.Clear();
            }
        }

        public void accessEmp()
        {
            int input;
            string str;

            if(empList.Count > 0)
            {
                Console.WriteLine("CURRENT EMPLOYEES");
                Console.WriteLine("-----------------");

                for (int i = 0; i < empList.Count; i++)
                {
                    Console.WriteLine("Employee " + (i + 1) + ": " + empList[i].Emp.ToUpper());
                }

                Console.WriteLine("-----------------");
                Console.WriteLine("Please enter the employee number you want to access or -1 to go back: ");
                str = Console.ReadLine();
                Thread.Sleep(1 * 1000);
                Console.Clear();

                int number;

                if(!int.TryParse(str, out number) || string.IsNullOrEmpty(str))
                {
                    Console.WriteLine("Please enter a number.");
                    Console.WriteLine();
                    accessEmp();
                }
                else
                {
                    input = Convert.ToInt32(str);
                    if(input == -1)
                    {
                        //Exit back to menu.
                    }
                    else if(input <= empList.Count && input > 0)
                    {
                        for(int i = 0; i < empList.Count; i++)
                        {
                            if (input == (i + 1))
                            {
                                empList[i].empMenu();
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("There is no employee associated with that number. Please try again.");
                        Console.WriteLine();
                        accessEmp();
                    }
                }
            }
            else
            {
                Console.WriteLine("There are currently no employees in the system.");
                Console.WriteLine("\n\n");
                Console.WriteLine("Hit ENTER to go back to main MENU...");
                Console.ReadLine();
                Console.Clear();
            }
        }

        public void writeEmployee()
        {
            try
            {
                using (FileStream stream = new FileStream(dir, FileMode.Create))
                {
                    //var bFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                    //bFormatter.Serialize(stream, acctList);

                    XmlSerializer xSerialize = new XmlSerializer(typeof(List<Employee>));
                    xSerialize.Serialize(stream, empList);
                    stream.Flush();
                    stream.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
