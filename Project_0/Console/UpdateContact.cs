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
    public class UpdateContact : IMenu
    {
        static Contact newcontact = new Contact();
        static string constr = File.ReadAllText("../../../../Database/log.txt");
        ISqlRepo<Contact> repo = new ContactRepo(constr);
        int pid = Validate.Pid();
        public void Display()
        {
            newcontact = repo.GetAll(pid);
            System.Console.WriteLine("-----------------------------------------------------------------------------------------------");
            System.Console.WriteLine("****************************************** Update Contact *************************************");
            System.Console.WriteLine("-----------------------------------------------------------------------------------------------\n");
            System.Console.WriteLine("[1] Update Phone               - " + newcontact.Phone);
            System.Console.WriteLine("[2] Update City                - " + newcontact.City);
            System.Console.WriteLine("[3] Update State               - " + newcontact.State);
            System.Console.WriteLine("[4] Update Zipcode             - " + newcontact.Zipcode);
            System.Console.WriteLine("[5] save");
            System.Console.WriteLine("[6] Go Back");
        }

        public string UserChoice()
        {
            string userInput = System.Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    System.Console.WriteLine("Please enter a New Phone Number!");
                    newcontact.Phone = System.Console.ReadLine();
                    using (SqlConnection connection = new SqlConnection(constr))
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand($"UPDATE Contact SET phone = @phone where userid = {pid}", connection))
                        {
                            command.Parameters.AddWithValue("@phone", newcontact.Phone);
                            command.ExecuteNonQuery();
                        }
                    }
                    return "UpdateContact";
                case "2":
                    System.Console.WriteLine("Please enter New City!");
                    newcontact.City = System.Console.ReadLine();
                    using (SqlConnection connection = new SqlConnection(constr))
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand($"UPDATE Contact SET city = @city where userid = {pid}", connection))
                        {
                            command.Parameters.AddWithValue("@city", newcontact.City);
                            command.ExecuteNonQuery();
                        }
                    }
                    return "UpdateContact";
                case "3":
                    System.Console.WriteLine("Please enter New State!");
                    newcontact.State = System.Console.ReadLine();
                    using (SqlConnection connection = new SqlConnection(constr))
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand($"UPDATE Contact SET state = @state where userid = {pid}", connection))
                        {
                            command.Parameters.AddWithValue("@state", newcontact.State);
                            command.ExecuteNonQuery();
                        }
                    }
                    return "UpdateContact";
                case "4":
                    System.Console.WriteLine("Please enter a Zipcode!");
                    newcontact.Zipcode = System.Console.ReadLine();
                    using (SqlConnection connection = new SqlConnection(constr))
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand($"UPDATE Contact SET zipcode = @zipcode where userid = {pid}", connection))
                        {
                            command.Parameters.AddWithValue("@zipcode", newcontact.Zipcode);
                            command.ExecuteNonQuery();
                        }
                    }
                    return "UpdateContact";
                case "5":
                    System.Console.WriteLine("saved successfully");
                    System.Console.ReadKey();
                    return "UpdateContact";
                case "6":
                    return "GetContact";
                default:
                    System.Console.WriteLine("Please input a valid response");
                    System.Console.WriteLine("Please press Enter to continue");
                    System.Console.ReadLine();
                    return "UpdateContact";
            }
        }
    }
}
