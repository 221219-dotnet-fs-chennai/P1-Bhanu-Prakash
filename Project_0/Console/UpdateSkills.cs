using projectlib;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console
{
    public class UpdateSkills : IMenu
    {
        static Skills newskills = new Skills();
        static string constr = File.ReadAllText("../../../../Database/log.txt");
        ISqlRepo<Skills> repo = new SkillRepo(constr);
        int pid = Validate.Pid();
        public void Display()
        {
            System.Console.WriteLine("Update Trainer Skills");
            System.Console.WriteLine("[0] Go Back");
            System.Console.WriteLine("[1] Update primary Skill - " + newskills.Primaryskill);
            System.Console.WriteLine("[2] Update Proficiency 1 - " + newskills.Proficiency1);
            System.Console.WriteLine("[3] Update Secondary Skills - " + newskills.Secondaryskill);
            System.Console.WriteLine("[4] Update Proficiency 2 - " + newskills.Proficiency2);
            System.Console.WriteLine("[5] Update Teritiary Skills - " + newskills.Teritaryskill);
            System.Console.WriteLine("[6] Update Proficiency 3 - " + newskills.proficiency3);
        }

        public string UserChoice()
        {
            string userInput = System.Console.ReadLine();
            switch (userInput)
            {
                case "0":
                    return "Login";
                case "1":
                    System.Console.WriteLine("Please enter a Primary Skill!");
                    string primaryskill = System.Console.ReadLine();
                    using (SqlConnection connection = new SqlConnection(constr))
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand($"UPDATE Skills SET primaryskill = @primaryskill where userid = {pid}", connection))
                        {
                            command.Parameters.AddWithValue("@primaryskill", primaryskill);
                            command.ExecuteNonQuery();
                        }
                    }
                    return "UpdateSkills";
                case "2":
                    System.Console.WriteLine("Please enter a Primary Skill Proficiency!");
                    string proficiency1 = System.Console.ReadLine();
                    using (SqlConnection connection = new SqlConnection(constr))
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand($"UPDATE Skills SET proficiency1 = @proficiency1 where userid = {pid}", connection))
                        {
                            command.Parameters.AddWithValue("@proficiency1", proficiency1);
                            command.ExecuteNonQuery();
                        }
                    }
                    return "UpdateSkills";
                case "3":
                    System.Console.WriteLine("Please enter a secondary Skill!");
                    string secondaryskill = System.Console.ReadLine();
                    using (SqlConnection connection = new SqlConnection(constr))
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand($"UPDATE Skills SET Secondaryskill = @secondaryskill where userid = {pid}", connection))
                        {
                            command.Parameters.AddWithValue("@Secondaryskill", secondaryskill);
                            command.ExecuteNonQuery();
                        }
                    }
                    return "UpdateSkills";
                case "4":
                    System.Console.WriteLine("Please enter a Secondary Skill Proficiency!");
                    string proficiency2 = System.Console.ReadLine();
                    using (SqlConnection connection = new SqlConnection(constr))
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand($"UPDATE Skills SET proficiency2 = @proficiency2 where userid = {pid}", connection))
                        {
                            command.Parameters.AddWithValue("@proficiency2", proficiency2);
                            command.ExecuteNonQuery();
                        }
                    }
                    return "UpdateSkills";
                case "5":
                    System.Console.WriteLine("Please enter a Teritiary Skill!");
                    string Teritiaryskill = System.Console.ReadLine();
                    using (SqlConnection connection = new SqlConnection(constr))
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand($"UPDATE Skills SET Teritiaryskill = @Teritiaryskill where userid = {pid}", connection))
                        {
                            command.Parameters.AddWithValue("@Teritiaryskill", Teritiaryskill);
                            command.ExecuteNonQuery();
                        }
                    }
                    return "UpdateSkills";
                case "6":
                    System.Console.WriteLine("Please enter a Teritiary Skill Proficiency!");
                    string proficiency3 = System.Console.ReadLine();
                    using (SqlConnection connection = new SqlConnection(constr))
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand($"UPDATE Skills SET proficiency3 = @proficiency3 where userid = {pid}", connection))
                        {
                            command.Parameters.AddWithValue("@proficiency3", proficiency3);
                            command.ExecuteNonQuery();
                        }
                    }
                    return "UpdateSkills";
                default:
                    System.Console.WriteLine("Please input a valid response");
                    System.Console.WriteLine("Please press Enter to continue");
                    System.Console.ReadLine();
                    return "UpdateSkills";
            }
        }
    }
}
