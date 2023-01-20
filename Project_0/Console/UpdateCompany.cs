using projectlib;
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
            System.Console.WriteLine("Update Experience");
            System.Console.WriteLine("[0] Go Back");
            System.Console.WriteLine("[1] Update Previous Company - " + newcompany.PreviousCompany);
            System.Console.WriteLine("[2] Update Technology - " + newcompany.Technology);
            System.Console.WriteLine("[3] Update Experience Years - " + newcompany.ExperienceYear);
        }

        public string UserChoice()
        {
            string userInput = System.Console.ReadLine();
            switch (userInput)
            {
                case "0":
                    return "Login";
                case "1":
                    System.Console.WriteLine("Please enter Previouc Company!");
                    string PreviousCompany = System.Console.ReadLine();
                    using (SqlConnection connection = new SqlConnection(constr))
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand($"UPDATE Company SET PreviousCompany = @PreviousCompany where userid = {pid}", connection))
                        {
                            command.Parameters.AddWithValue("@PreviousCompany", PreviousCompany);
                            command.ExecuteNonQuery();
                        }
                    }
                    return "UpdateCompany";
                case "2":
                    System.Console.WriteLine("Please enter Technology!");
                    string Technology = System.Console.ReadLine();
                    using (SqlConnection connection = new SqlConnection(constr))
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand($"UPDATE Company SET Technology = @Technology where userid = {pid}", connection))
                        {
                            command.Parameters.AddWithValue("@Technology", Technology);
                            command.ExecuteNonQuery();
                        }
                    }
                    return "UpdateCompany";
                case "3":
                    System.Console.WriteLine("Please enter Experience Years!");
                    string ExperienceYear = System.Console.ReadLine();
                    using (SqlConnection connection = new SqlConnection(constr))
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand($"UPDATE Company SET experienceyear = @ExperienceYear where userid = {pid}", connection))
                        {
                            command.Parameters.AddWithValue("@experienceyear", ExperienceYear);
                            command.ExecuteNonQuery();
                        }
                    }
                    return "UpdateCompany";
                default:
                    System.Console.WriteLine("Please input a valid response");
                    System.Console.WriteLine("Please press Enter to continue");
                    System.Console.ReadLine();
                    return "UpdateCompany";
            }
        }
    }
}
