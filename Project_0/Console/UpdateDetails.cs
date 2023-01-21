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
    public class UpdateDetails : IMenu
    {
        static UserDetails newupdate = new UserDetails();
        static string constr = File.ReadAllText("../../../../Database/log.txt");
        ISqlRepo<UserDetails> repo = new SqlRepo(constr);
        int pid = Validate.Pid();
        public void Display()
        {
            System.Console.WriteLine("Update Trainer Information");
            System.Console.WriteLine("[0] Go Back");
            System.Console.WriteLine("[1] Update FirstName - " + newupdate.Firstname);
            System.Console.WriteLine("[2] Update LastName - " + newupdate.Lastname);
            System.Console.WriteLine("[3] Password - " + newupdate.Password);
            System.Console.WriteLine("[4] Update Gender - " + newupdate.Gender);
            System.Console.WriteLine("[5] Update Age - " + newupdate.Age);
            System.Console.WriteLine("[6] save");

        }

        public string UserChoice()
        {
            string userInput = System.Console.ReadLine();
            switch (userInput)
            {
                case "0":
                    return "Update";
                case "1":
                    System.Console.WriteLine("Please enter a first name!");
                    string Firstname = System.Console.ReadLine();
                    using (SqlConnection connection = new SqlConnection(constr))
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand($"UPDATE UserDetails SET firstname = @Firstname where id = {pid}", connection))
                        {
                            command.Parameters.AddWithValue("@firstname",Firstname);
                            command.ExecuteNonQuery();
                        }
                    }
                    return "UpdateDetails";
                case "2":
                    System.Console.WriteLine("Please enter a Last name!");
                    string Lastname = System.Console.ReadLine();
                    using (SqlConnection connection = new SqlConnection(constr))
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand($"UPDATE UserDetails SET lastname = @Lastname where id = {pid}", connection))
                        {
                            command.Parameters.AddWithValue("@lastname", Lastname);
                            command.ExecuteNonQuery();
                        }
                    }
                    return "UpdateDetails";
                case "3":
                    System.Console.WriteLine("Please enter New Password!");
                    string Password = System.Console.ReadLine();
                    using (SqlConnection connection = new SqlConnection(constr))
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand($"UPDATE UserDetails SET password = @Password where id = {pid}", connection))
                        {
                            command.Parameters.AddWithValue("@password", Password);
                            command.ExecuteNonQuery();
                        }
                    }
                    return "UpdateDetails";
                case "4":
                    System.Console.WriteLine("Please enter Gender");
                    string Gender = System.Console.ReadLine();
                    using (SqlConnection connection = new SqlConnection(constr))
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand($"UPDATE UserDetails SET gender = @Gender where id = {pid}", connection))
                        {
                            command.Parameters.AddWithValue("@gender", Gender);
                            command.ExecuteNonQuery();
                        }
                    }
                    return "UpdateDetails";
                case "5":
                    System.Console.WriteLine("Please enter Age!");
                    int Age = Convert.ToInt32(System.Console.ReadLine());
                    using (SqlConnection connection = new SqlConnection(constr))
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand($"UPDATE UserDetails SET age = @Age where id = {pid}", connection))
                        {
                            command.Parameters.AddWithValue("@age", Age);
                            command.ExecuteNonQuery();
                        }
                    }
                    return "UpdateDetails";
                case "6":
                    try
                    {
                        Log.Information("Adding record \n" + newupdate);
                        repo.Add(newupdate);
                        Log.Information("Successful at adding Record!");
                    }
                    catch (System.Exception exc)
                    {
                        Log.Error($"Failed to add Record - {exc.Message}");
                        System.Console.WriteLine(exc.Message);
                        System.Console.WriteLine("Please press Enter to continue");
                        System.Console.ReadLine();
                    }
                    System.Console.WriteLine("saved successful");
                    return "UpdateDetails";
                default:
                    System.Console.WriteLine("Please input a valid response");
                    System.Console.WriteLine("Please press Enter to continue");
                    System.Console.ReadLine();
                    return "UpdateDetails";
            }
        }

    }
}
