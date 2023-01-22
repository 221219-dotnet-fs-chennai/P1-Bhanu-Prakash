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
    public class UpdateCompany : IMenu
    {
        static Company newcompany = new Company();
        static string constr = File.ReadAllText("../../../../Database/log.txt");
        ISqlRepo<Company> repo = new CompanyRepo(constr);
        int pid = Validate.Pid();
        public void Display()
        {
            newcompany = repo.GetAll(pid);
            System.Console.WriteLine("-----------------------------------------------------------------------------------------------");
            System.Console.WriteLine("****************************************** Update Experience **********************************");
            System.Console.WriteLine("-----------------------------------------------------------------------------------------------\n");
            System.Console.WriteLine("[1] Update Previous Company           - " + newcompany.PreviousCompany);
            System.Console.WriteLine("[2] Update Technology                 - " + newcompany.Technology);
            System.Console.WriteLine("[3] Update Experience Years           - " + newcompany.ExperienceYear);
            System.Console.WriteLine("[4] save");
            System.Console.WriteLine("[5] Go Back");

        }

        public string UserChoice()
        {
            string userInput = System.Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    System.Console.WriteLine("Please enter Previous Company!");
                    newcompany.PreviousCompany = System.Console.ReadLine();
                    using (SqlConnection connection = new SqlConnection(constr))
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand($"UPDATE Company SET PreviousCompany = @PreviousCompany where userid = {pid}", connection))
                        {
                            command.Parameters.AddWithValue("@PreviousCompany", newcompany.PreviousCompany);
                            command.ExecuteNonQuery();
                        }
                    }
                    return "UpdateCompany";
                case "2":
                    System.Console.WriteLine("Please enter Technology!");
                    newcompany.Technology = System.Console.ReadLine();
                    using (SqlConnection connection = new SqlConnection(constr))
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand($"UPDATE Company SET Technology = @Technology where userid = {pid}", connection))
                        {
                            command.Parameters.AddWithValue("@Technology", newcompany.Technology);
                            command.ExecuteNonQuery();
                        }
                    }
                    return "UpdateCompany";
                case "3":
                    System.Console.WriteLine("Please enter Experience Years!");
                    newcompany.ExperienceYear = Convert.ToInt32(System.Console.ReadLine());
                    using (SqlConnection connection = new SqlConnection(constr))
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand($"UPDATE Company SET experienceyear = @ExperienceYear where userid = {pid}", connection))
                        {
                            command.Parameters.AddWithValue("@Experienceyear", newcompany.ExperienceYear);
                            command.ExecuteNonQuery();
                        }
                    }
                    return "UpdateCompany";
                case "4":
                    /*try
                    {
                        Log.Information("Adding record \n" + newcompany);
                        repo.Add(newcompany);
                        Log.Information("Successful at adding Record!");
                    }
                    catch (Exception exc)
                    {
                        Log.Error($"Failed to add Record - {exc.Message}");
                        System.Console.WriteLine(exc.Message);
                        System.Console.WriteLine("Please press Enter to continue");
                        System.Console.ReadLine();
                    }*/
                    System.Console.WriteLine("saved successfully");
                    System.Console.ReadKey();
                    return "UpdateCompany";
                case "5":
                    return "GetCompany";
                default:
                    System.Console.WriteLine("Please input a valid response");
                    System.Console.WriteLine("Please press Enter to continue");
                    System.Console.ReadLine();
                    return "UpdateCompany";
            }
        }
    }
}
