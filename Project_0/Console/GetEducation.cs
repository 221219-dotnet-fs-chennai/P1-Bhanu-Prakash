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
    public class GetEducation : IMenu
    {
        int id = Validate.Pid();
        static Education newEducation = new Education();
        static string constr = File.ReadAllText("../../../../Database/log.txt");
        ISqlRepo<Education> repo = new EducationRepo(constr);
        public void Display()
        {
            System.Console.WriteLine("-----------------------------------------------------------------------------------------------");
            System.Console.WriteLine("********************************************* Education ***************************************");
            System.Console.WriteLine("-----------------------------------------------------------------------------------------------\n");
            System.Console.WriteLine("Please select an option For Education Details");
            System.Console.WriteLine("1. Display All Data");
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

                    return "GetEducation";
                case "2":
                    return "UpdateEducation";
                case "3":
                    using (SqlConnection connection = new SqlConnection(constr))
                    {
                        connection.Open();
                        string query = $"update Education set HigherEducation = ' ', university = ' ', startyear = ' ', endyear = ' ', grade = ' ' where userid ={id}";
                        using SqlCommand sqlcommand = new SqlCommand(query, connection);
                        sqlcommand.Parameters.AddWithValue("@id", id);
                        sqlcommand.ExecuteNonQuery();
                        System.Console.WriteLine("Details Deleted Successfully!!");
                        System.Console.ReadKey();
                    }
                    return "GetEducation";
                case "4":
                    return "Login";
                default:
                    System.Console.WriteLine("Please input a valid response");
                    System.Console.WriteLine("Please press Enter to continue");
                    System.Console.ReadLine();
                    return "GetEducation";

            }
        }
    }
}
