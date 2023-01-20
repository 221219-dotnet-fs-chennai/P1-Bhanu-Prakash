using projectlib;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console
{
    public class UpdateEducation : IMenu
    {
        static Education newupdate = new Education();
        static string constr = File.ReadAllText("../../../../Database/log.txt");
        ISqlRepo<Education> repo = new EducationRepo(constr);
        int pid = Validate.Pid();
        public void Display()
        {
            System.Console.WriteLine("Update Education");
            System.Console.WriteLine("[0] Go Back");
            System.Console.WriteLine("[1] Update Higher Education - " + newupdate.HigherEducation);
            System.Console.WriteLine("[2] Update University - " + newupdate.university);
            System.Console.WriteLine("[3] Update startyear - " + newupdate.Startyear);
            System.Console.WriteLine("[4] Update End year - " + newupdate.Endyear);
            System.Console.WriteLine("[5] Update Grade - " + newupdate.Grade);
        }

        public string UserChoice()
        {
            string userInput = System.Console.ReadLine();
            switch (userInput)
            {
                case "0":
                    return "Login";
                case "1":
                    System.Console.WriteLine("Please enter a Higher Education!");
                    string HigherEducation = System.Console.ReadLine();
                    using (SqlConnection connection = new SqlConnection(constr))
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand($"UPDATE Education SET HigherEducation = @HigherEducation where userid = {pid}", connection))
                        {
                            command.Parameters.AddWithValue("@HigherEducation", HigherEducation);
                            command.ExecuteNonQuery();
                        }
                    }
                    return "UpdateEducation";
                case "2":
                    System.Console.WriteLine("Please enter University!");
                    string university = System.Console.ReadLine();
                    using (SqlConnection connection = new SqlConnection(constr))
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand($"UPDATE Education SET university = @university where userid = {pid}", connection))
                        {
                            command.Parameters.AddWithValue("@university", university);
                            command.ExecuteNonQuery();
                        }
                    }
                    return "UpdateEducation";
                case "3":
                    System.Console.WriteLine("Please enter New Start Year!");
                    int startyear = Convert.ToInt32(System.Console.ReadLine());
                    using (SqlConnection connection = new SqlConnection(constr))
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand($"UPDATE Education SET startyear = @startyear where userid = {pid}", connection))
                        {
                            command.Parameters.AddWithValue("@startyear", startyear);
                            command.ExecuteNonQuery();
                        }
                    }
                    return "UpdateEducation";
                case "4":
                    System.Console.WriteLine("Please enter  New Endyear");
                    int endyear = Convert.ToInt32(System.Console.ReadLine());
                    using (SqlConnection connection = new SqlConnection(constr))
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand($"UPDATE Education SET endyear = @endyear where userid = {pid}", connection))
                        {
                            command.Parameters.AddWithValue("@endyear", endyear);
                            command.ExecuteNonQuery();
                        }
                    }
                    return "UpdateEducation";
                case "5":
                    System.Console.WriteLine("Please enter New Grade!");
                    string Grade = System.Console.ReadLine();
                    using (SqlConnection connection = new SqlConnection(constr))
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand($"UPDATE Education SET grade = @Grade where userid = {pid}", connection))
                        {
                            command.Parameters.AddWithValue("@grade", Grade);
                            command.ExecuteNonQuery();
                        }
                    }
                    return "UpdateEducation";
                default:
                    System.Console.WriteLine("Please input a valid response");
                    System.Console.WriteLine("Please press Enter to continue");
                    System.Console.ReadLine();
                    return "UpdateDetails";
            }
        }
    }
}
