using projectlib;
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
        static Skills newskills = new Skills();
        static string constr = File.ReadAllText("../../../../Database/log.txt");
        ISqlRepo<Skills> repo = new SkillRepo(constr);
        int pid = Validate.Pid();
        public void Display()
        {
            System.Console.WriteLine("Update Contact Information");
            System.Console.WriteLine("[0] Go Back");
            System.Console.WriteLine("[1] Update Phone - " + newskills.Primaryskill);
            System.Console.WriteLine("[2] Update City - " + newskills.Proficiency1);
            System.Console.WriteLine("[3] Update State - " + newskills.Secondaryskill);
            System.Console.WriteLine("[4] Update Zipcode - " + newskills.Proficiency2);
        }

        public string UserChoice()
        {
            string userInput = System.Console.ReadLine();
            switch (userInput)
            {
                case "0":
                    return "Login";
                case "1":
                    System.Console.WriteLine("Please enter a New Phone Number!");
                    string phone = System.Console.ReadLine();
                    using (SqlConnection connection = new SqlConnection(constr))
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand($"UPDATE Contact SET phone = @phone where userid = {pid}", connection))
                        {
                            command.Parameters.AddWithValue("@phone", phone);
                            command.ExecuteNonQuery();
                        }
                    }
                    return "UpdateContact";
                case "2":
                    System.Console.WriteLine("Please enter New City!");
                    string city = System.Console.ReadLine();
                    using (SqlConnection connection = new SqlConnection(constr))
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand($"UPDATE Contact SET city = @city where userid = {pid}", connection))
                        {
                            command.Parameters.AddWithValue("@city", city);
                            command.ExecuteNonQuery();
                        }
                    }
                    return "UpdateContact";
                case "3":
                    System.Console.WriteLine("Please enter New State!");
                    string state = System.Console.ReadLine();
                    using (SqlConnection connection = new SqlConnection(constr))
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand($"UPDATE Contact SET state = @state where userid = {pid}", connection))
                        {
                            command.Parameters.AddWithValue("@state", state);
                            command.ExecuteNonQuery();
                        }
                    }
                    return "UpdateContact";
                case "4":
                    System.Console.WriteLine("Please enter a Zipcode!");
                    string zipcode = System.Console.ReadLine();
                    using (SqlConnection connection = new SqlConnection(constr))
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand($"UPDATE Contact SET zipcode = @zipcode where userid = {pid}", connection))
                        {
                            command.Parameters.AddWithValue("@zipcode", zipcode);
                            command.ExecuteNonQuery();
                        }
                    }
                    return "UpdateContact";
                default:
                    System.Console.WriteLine("Please input a valid response");
                    System.Console.WriteLine("Please press Enter to continue");
                    System.Console.ReadLine();
                    return "UpdateContact";
            }
        }
    }
}
