using projectlib;
using Serilog;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Console
{
    public class GetCompany : IMenu
    {
        int id = Validate.Pid();
        static Company newCompany = new Company();
        static string constr = File.ReadAllText("../../../../Database/log.txt");
        ISqlRepo<Company> repo = new CompanyRepo(constr);
        public void Display()
        {
            System.Console.WriteLine("-----------------------------------------------------------------------------------------------");
            System.Console.WriteLine("********************************************* Experience **************************************");
            System.Console.WriteLine("-----------------------------------------------------------------------------------------------\n");
            System.Console.WriteLine("Please select an option for Experience Details");
            System.Console.WriteLine("1. Display All Details");
            System.Console.WriteLine("2. Update Details");
            System.Console.WriteLine("3. Delete Details");
            System.Console.WriteLine("4. Go back");
        }
        public string UserChoice()
        {
            string userInput = System.Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    Log.Information("Getting all Records");
                    var ob = repo.GetAll(id);
                    System.Console.WriteLine("===============================================================================================");
                    System.Console.WriteLine(ob.ToString());
                    Log.Information("Reading records ends");
                    System.Console.WriteLine("Please press Enter to continue");
                    System.Console.ReadLine();

                    return "GetCompany";
                case "2":
                    return "UpdateCompany";
                case "3":
                    using (SqlConnection connection = new SqlConnection(constr))
                    {
                        connection.Open();
                        string query = $"update Company set PreviousCompany = ' ', Technology = ' ', experienceyear = ' ' where userid ={id}";
                        using SqlCommand sqlcommand = new SqlCommand(query, connection);
                        sqlcommand.Parameters.AddWithValue("@id", id);
                        sqlcommand.ExecuteNonQuery();
                        System.Console.WriteLine("Details Deleted Successfully!!");
                        System.Console.ReadKey();
                    }
                    return "GetCompany";
                case "4":
                    return "Login";
                default:
                    System.Console.WriteLine("Please input a valid response");
                    System.Console.WriteLine("Please press Enter to continue");
                    System.Console.ReadLine();
                    return "GetCompany";

            }
        }
    }
}
