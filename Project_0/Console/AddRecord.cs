using projectlib;
using Serilog;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console
{
    public class AddRecord : IMenu
    {
        static UserDetails newuser = new UserDetails();
        static string constr = File.ReadAllText("../../../../Database/log.txt");
        ISqlRepo<UserDetails> repo = new SqlRepo(constr);
        static string ema = " ";

        public void Display()
        {
            System.Console.WriteLine("-----------------------------------------------------------------------------------------------");
            System.Console.WriteLine("************************************** Trainer Information ************************************");
            System.Console.WriteLine("-----------------------------------------------------------------------------------------------");
            System.Console.WriteLine("Enter Trainer Information");
            System.Console.WriteLine("1. FirstName      -                               " + newuser.Firstname);
            System.Console.WriteLine("2. LastName       -                               " + newuser.Lastname);
            System.Console.WriteLine("3. Email          -                               " + newuser.Email);
            System.Console.WriteLine("4. Password       -                               " + newuser.Password);
            System.Console.WriteLine("5. Gender         -                               " + newuser.Gender);
            System.Console.WriteLine("6. Age            -                               " + newuser.Age);
            System.Console.WriteLine("7. Save");
            System.Console.WriteLine("8. Go Back");
        }

        public static int Pid()
        {
            int id = 0;
            using SqlConnection con = new SqlConnection(constr);
            con.Open();
            string query = $"select id from UserDetails where email ='{ema}'";
            using SqlCommand sqlcommand = new SqlCommand(query, con);
            //sqlcommand.Parameters.AddWithValue("@email", ema);
            using SqlDataReader sqlDataReaderreader = sqlcommand.ExecuteReader();
            if (sqlDataReaderreader.Read())
            {
                id = sqlDataReaderreader.GetInt32(0);
            }
            return id;
        }

        public string UserChoice()
        {
            string userInput = System.Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    System.Console.WriteLine("Please enter a first name!");
                    newuser.Firstname = System.Console.ReadLine();
                    return "AddRecord";
                case "2":
                    System.Console.WriteLine("Please enter a Last name!");
                    newuser.Lastname = System.Console.ReadLine();
                    return "AddRecord";
                case "3":
                    System.Console.WriteLine("Please enter Email!");
                    newuser.Email = System.Console.ReadLine();
                    ema = newuser.Email;
                    return "AddRecord";
                case "4":
                    System.Console.WriteLine("Please enter Password");
                    newuser.Password = System.Console.ReadLine();
                    return "AddRecord";
                case "5":
                    System.Console.WriteLine("Please enter Gender");
                    newuser.Gender = System.Console.ReadLine();
                    return "AddRecord";
                case "6":
                    System.Console.WriteLine("Please Age");
                    newuser.Age = Convert.ToInt32(System.Console.ReadLine());
                    return "AddRecord";
                case "7":
                    try
                    {
                        Log.Information("Adding record \n" + newuser);
                        repo.Add(newuser);
                        Log.Information("Successful at adding Record!");
                    }
                    catch (System.Exception exc)
                    {
                        Log.Error($"Failed to add Record - {exc.Message}");
                        System.Console.WriteLine(exc.Message);
                        System.Console.WriteLine("Please press Enter to continue");
                        System.Console.ReadLine();
                    }
                    return "Signup";
                case "8":
                    return "Signup";
                default:
                    System.Console.WriteLine("Please input a valid response");
                    System.Console.WriteLine("Please press Enter to continue");
                    System.Console.ReadLine();
                    return "AddRecord";
            }
        }
    }
}
