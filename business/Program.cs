using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace business
{
    class Program
    {
        static string path = "D:\\oop\\week1\\sign.txt";
        static string path1 = "D:\\oop\\week1\\bus.txt";
        static string path2 = "D:\\oop\\week1\\serial.txt";
        static string path3 = "D:\\oop\\week1\\numbers.txt";
        static string[] names = new string[20];
        static string[] passwords = new string[20];
        static string[] Roles = new string[20];
        static string[] employees = new string[20];
        static string[] Type = new string[20];
        static int noOfEmployees = 0;
        static string[] busSerial = new string[20];
        static string[] BusTiming = new string[20];
        static string[] BusRoute = new string[20];
        static string[] dates = new string[20];
        static int numbers_bus = 0;
        static string name = "", password = "", role = "";
        static void Main(string[] args)
        {
            readData1(ref noOfEmployees);
            readDatabus(ref numbers_bus);
            main_header();
            Console.ReadKey();
            int choice;
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");

            readData(path, names, passwords, Roles);

            choice = menu();
            Console.Clear();
            if (choice == 1)
            {
                Console.WriteLine("Write name: ");
                name = Console.ReadLine();
                Console.Write("Write password: ");
                password = Console.ReadLine();
                Console.Write("Write Role: ");
                role = Console.ReadLine();
                signUp(path, name, password, role);
                Console.ReadKey();
                choice = menu();

            }

            readData(path, names, passwords, Roles);
            if (choice == 2)
            {
                Console.Clear();
                Console.WriteLine("Write name: ");
                name = Console.ReadLine();
                Console.Write("Write password: ");
                password = Console.ReadLine();

                string option = signin(name, password, names, passwords, Roles);

                Console.ReadKey();
                string A = "Admin";
                string B = "admin";
                if (option == A || option == B)
                {
                    Console.Clear();
                    AdminHeader();
                    Console.ReadKey();
                    int adminchoice = AdminMenu();
                    while (adminchoice != 0)
                    {

                        readData1(ref noOfEmployees);
                        readDatabus(ref numbers_bus);
                        readData(path, names, passwords, Roles);
           
                        if (adminchoice == 1)
                        {
                            Console.Clear();
                            addEmployees();
                            adminchoice = AdminMenu();

                        }

                        else if (adminchoice == 2)
                        {
                            Console.Clear();
                            deleteEmployee();
                            adminchoice = AdminMenu();
                        }
                        else if (adminchoice == 3)
                        {
                            Console.Clear();
                            viewEmployees();
                            adminchoice = AdminMenu();

                        }
                        else if (adminchoice == 4)
                        {
                            Console.Clear();
                            addBus();
                            adminchoice = AdminMenu();

                        }
                        else if (adminchoice == 5)
                        {
                            Console.Clear();
                            deleteBus();
                            adminchoice = AdminMenu();

                        }
                        else if (adminchoice == 6)
                        {
                            Console.Clear();
                            viewBus();
                            adminchoice = AdminMenu();

                        }
                    }

                }

            }
            choice = menu();

            if (choice < 3)
            {
                Console.ReadKey();
            }
        


        }
        static void main_header()
        {

            Console.WriteLine("      >>        >=>              >=======>                                              >=>       >=>              >=>                              ");
            Console.WriteLine("     >>=>       >=>              >=>                      >=>                           >> >=>   >>=>              >=>                              ");
            Console.WriteLine("    >> >=>      >=>              >=>          >=> >=>            >=> >=>  >> >==>       >=> >=> > >=>    >=>     >=>>==>    >=>     >> >==>  >===>  ");
            Console.WriteLine("   >=>  >=>     >=> >====>       >=====>    >=>   >=>     >=>  >=>   >=>   >=>          >=>  >=>  >=>  >=>  >=>    >=>    >=>  >=>   >=>    >=>     ");
            Console.WriteLine("  >=====>>=>    >=>              >=>       >=>    >=>     >=> >=>    >=>   >=>          >=>   >>  >=> >=>    >=>   >=>   >=>    >=>  >=>      >==>  ");
            Console.WriteLine(" >=>      >=>   >=>              >=>        >=>   >=>     >=>  >=>   >=>   >=>          >=>       >=>  >=>  >=>    >=>    >=>  >=>   >=>        >=> ");
            Console.WriteLine(">=>        >=> >==>              >=>         >==>>>==>    >=>   >==>>>==> >==>          >=>       >=>    >=>        >=>     >=>     >==>    >=> >=> ");
            Console.WriteLine("                                                       >==>                                                                                         ");
            Console.WriteLine("");
            Console.WriteLine("");

        }

        static int menu()
        {
            Console.WriteLine("1. Sign up");
            Console.WriteLine("2. Sign In");
            Console.WriteLine("3. Exit");
            string option;
            option = (Console.ReadLine());
            int option1 = Intvalidation(option);
            return option1;
        }
        static string dataParse(string line, int field)
        {
            string item = "";
            int commacount = 1;
            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] == ',')
                {
                    commacount++;
                }
                else if (commacount == field)
                {
                    item = item + line[i];
                }
            }
            return item;
        }
        static void readData(string path, string[] names, string[] passwords, string[] Roles)
        {
            int x = 0;

            if (File.Exists(path))
            {
                StreamReader file = new StreamReader(path);
                string line;
                while ((line = file.ReadLine()) != null)
                {

                    names[x] = dataParse(line, 1);
                    passwords[x] = dataParse(line, 2);
                    Roles[x] = dataParse(line, 3);
                    x++;
                    if (x >= 20)
                    {
                        break;

                    }


                }
                file.Close();
            }
            else
            {
                Console.WriteLine("File does not exists");
            }

        }
        static string signin(string name, string passsword, string[] names, string[] passswords, string[] Roles)
        {
            bool flag = false;
            for (int x = 0; x < 20; x++)
            {
               
                if (name == names[x] && passsword == passswords[x])
                {
                    Console.WriteLine("valid user");
                    flag = true;
                    return Roles[x];

                }
            }
            if (flag == false)
            {

                Console.WriteLine("Invalid user");

            }
            return "";

        }
        static void signUp(string path, string name, string password, string role)
        {

            StreamWriter file = new StreamWriter(path, true);
            file.WriteLine(name + "," + password + "," + role);
            file.Flush();
            file.Close();
        }
        static void AdminHeader()
        {

            Console.WriteLine("   _   _   _   _   _   _   _     _   _   _   _     _   _   _   _   _  ");
            Console.WriteLine("  / \\ / \\ / \\ / \\ / \\ / \\ / \\   / \\ / \\ / \\ / \\   / \\ / \\ / \\ / \\ / \\ ");
            Console.WriteLine(" ( W | e | l | c | o | m | e ) ( D | e | a | r ) ( A | d | m | i | n )");
            Console.WriteLine("  \\_/ \\_/ \\_/ \\_/ \\_/ \\_/ \\_/   \\_/ \\_/ \\_/ \\_/   \\_/ \\_/ \\_/ \\_/ \\_/ ");


        }
        static int AdminMenu()
        {
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine(" You can do these tasks .");
            Console.WriteLine(" -----------------------------------------");
            Console.WriteLine(" 1.  add employee .");
            Console.WriteLine(" 2.  delete employee .");
            Console.WriteLine(" 3.  view all employees .");
            Console.WriteLine(" 4.  add bus with timing and route .");
            Console.WriteLine(" 5.  delete bus .");
            Console.WriteLine(" 6.  view all buses .");
            Console.WriteLine(" 0.   exit.");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Your choice: ");
            string opt = (Console.ReadLine());
            int option = Intvalidation(opt);
            return option;

        }
        static int Intvalidation(string number)
        {
            if (int.TryParse(number, out int result))
            {
                return result;
            }
            string num = "er";
            int res = 0;
            while (!int.TryParse(num.ToString(), out res))
            {
                Console.WriteLine("Enter integer number: ");
                num = Console.ReadLine();
            }
            return res;
        }
        static void addEmployees()
        {
            int number;
            string numbers;
            Console.WriteLine("Enter the number of employees: ");
            numbers = (Console.ReadLine());
            number = Intvalidation(numbers);


            for (int x = 0; x < number; x++)
            {
                Console.WriteLine("Enter employee name: ");
                employees[x] = Console.ReadLine();
                Console.WriteLine("Enter employee type: ");
                Type[x] = Console.ReadLine();
                noOfEmployees++;
            }
            storeEmployees();
        }
        static void storeEmployees()
        {
            StreamWriter file = new StreamWriter(path1, true);

            for (int i = 0; i < noOfEmployees; i++)
            {
                file.WriteLine(employees[i] + "," + Type[i]);
            }
            file.Flush();
            file.Close();
        }
        
        string parse_data2(string line1, int field)
        {
            string item = "";
            int commacount = 1;
            for (int i = 0; i < line1.Length; i++)
            {
                if (line1[i] == ',')
                {
                    commacount++;
                }
                else if (commacount == field)
                {
                    item = item + line1[i];
                }
            }
            return item;
        }
        static void readData1(ref int noOfEmployees)
        {
            int x = 0;
           

            if (File.Exists(path1))
            {
                StreamReader file = new StreamReader(path1);

                string line;
                while (!file.EndOfStream)
                {
                    line = file.ReadLine();

                    employees[x] = dataParse(line, 1);
                    Type[x] = dataParse(line, 2);



                    x++;
                    if (x >= 20)
                    {
                        break;

                    }


                }
                file.Close();
            }
            else
            {
                Console.WriteLine("File does not exists");
            }
            noOfEmployees = noOfEmployees + x;


        }
        static void deleteEmployee()
        {
            int index = 0;
            Console.WriteLine("Enter the name of employee to delete: ");
            string name = Console.ReadLine();
            for (int i = 0; i < noOfEmployees; i++) // this loop will give the index to delete
            {
                if (name == employees[i])
                {
                    index = i;
                }
            }
            for (int j = index; j < noOfEmployees; j++)
            {

                employees[j] = employees[j + 1];
                Type[j] = Type[j + 1];
            }
            noOfEmployees--;
            storeEmployees();
        }
        static void viewEmployees()
        {
            readData1(ref noOfEmployees);
            Console.WriteLine("Here is the list of all employees ");
            Console.WriteLine("Total no of Employees are {0} ", noOfEmployees);
            Console.WriteLine("Name\t\t Type");
            for (int i = 0; i < noOfEmployees; i++)
            {
                Console.WriteLine(employees[i] + "\t\t" + Type[i]);
            }
        }
        static void addBus()
        {
            int number_bus = 0;
            Console.WriteLine("Enter the number of buses : ");
            string number = (Console.ReadLine());
            number_bus = Intvalidation(number);


            for (int i = 0; i < number_bus; i++)
            {
               
                Console.WriteLine("Enter the serial number of bus: ");
                busSerial[i] = Console.ReadLine();
                Console.WriteLine("Enter the timing of bus: ");
                BusTiming[i] = Console.ReadLine();
                Console.WriteLine("Enter the route of bus: ");

                BusRoute[i] = Console.ReadLine();
                Console.WriteLine("Enter the date of  departure of bus: ");
                dates[i] = Console.ReadLine();

            }
            numbers_bus = numbers_bus + number_bus;
            storeBus();

        }
        static void storeBus()
        {
            StreamWriter file = new StreamWriter(path2, true);

            for (int i = 0; i < numbers_bus; i++)
            {

                file.WriteLine(busSerial[i] + "," + BusTiming[i] + "," + BusRoute[i] + "," + dates[i]);
            }
            file.Flush();
            file.Close();
        }
        static void readDatabus(ref int numbers_bus)
        {
            int x = 0;

            if (File.Exists(path2))
            {
                StreamReader file = new StreamReader(path2);
                string line;
                while (!file.EndOfStream)
                {
                    line = file.ReadLine();

                    busSerial[x] = dataParse(line, 1);
                    BusTiming[x] = dataParse(line, 2);
                    BusRoute[x] = dataParse(line, 3);
                    dates[x] = dataParse(line, 4);
                    x++;
                    if (x >= 20)
                    {
                        break;

                    }


                }
                file.Close();
            }
            else
            {
                Console.WriteLine("File does not exists");
            }
            numbers_bus = numbers_bus + x;

        }
        static void deleteBus()
        {
            string deleteSerial = "";
            Console.WriteLine("Enter the serial of bus to delete: ");
            deleteSerial = Console.ReadLine();
            int index = 0;
            for (int i = 0; i < numbers_bus; i++)
            {
                if (deleteSerial == busSerial[i])
                {
                    index = i; // it is done to give the index where we have to delete bus
                }
            }
            for (int j = index; j < numbers_bus; j++)
            {

                busSerial[j] = busSerial[j + 1];
                BusTiming[j] = BusTiming[j + 1];
                BusRoute[j] = BusRoute[j + 1];
                dates[j] = dates[j + 1];
            }

            numbers_bus--;
            storeBus();

        }
        static void viewBus()
        {
            readDatabus(ref numbers_bus);
            Console.WriteLine("Here is the list of all buses ");
            Console.WriteLine("Serial\tTiming\tDate\t\tRoute");
            for (int i = 0; i < numbers_bus; i++)
            {

                Console.WriteLine(busSerial[i] + "\t" + BusTiming[i] + "\t" + dates[i] + "\t\t" + BusRoute[i]);

            }

        }



    }
}
