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
            System.Console.WriteLine("[5] Update Teritiary Skills - " + newskills.Teritiaryskill);
            System.Console.WriteLine("[6] Update Proficiency 3 - " + newskills.proficiency3);
            System.Console.WriteLine("[7] save");

        }

        public string UserChoice()
        {
            string userInput = System.Console.ReadLine();
            switch (userInput)
            {
                case "0":
                    return "Update";
                case "1":
                    System.Console.WriteLine("Please enter a Primary Skill!");
                    newskills.Primaryskill  = System.Console.ReadLine();
                    using (SqlConnection connection = new SqlConnection(constr))
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand($"UPDATE Skills SET primaryskill = @primaryskill where userid = {pid}", connection))
                        {
                            command.Parameters.AddWithValue("@primaryskill", newskills.Primaryskill);
                            command.ExecuteNonQuery();
                        }
                    }
                    return "UpdateSkills";
                case "2":
                    System.Console.WriteLine("Please enter a Primary Skill Proficiency!");
                    newskills.Proficiency1 = System.Console.ReadLine();
                    using (SqlConnection connection = new SqlConnection(constr))
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand($"UPDATE Skills SET proficiency1 = @proficiency1 where userid = {pid}", connection))
                        {
                            command.Parameters.AddWithValue("@proficiency1", newskills.Proficiency1);
                            command.ExecuteNonQuery();
                        }
                    }
                    return "UpdateSkills";
                case "3":
                    System.Console.WriteLine("Please enter a secondary Skill!");
                    newskills.Secondaryskill = System.Console.ReadLine();
                    using (SqlConnection connection = new SqlConnection(constr))
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand($"UPDATE Skills SET Secondaryskill = @secondaryskill where userid = {pid}", connection))
                        {
                            command.Parameters.AddWithValue("@Secondaryskill", newskills.Secondaryskill);
                            command.ExecuteNonQuery();
                        }
                    }
                    return "UpdateSkills";
                case "4":
                    System.Console.WriteLine("Please enter a Secondary Skill Proficiency!");
                    newskills.Proficiency2 = System.Console.ReadLine();
                    using (SqlConnection connection = new SqlConnection(constr))
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand($"UPDATE Skills SET proficiency2 = @proficiency2 where userid = {pid}", connection))
                        {
                            command.Parameters.AddWithValue("@proficiency2", newskills.Proficiency2);
                            command.ExecuteNonQuery();
                        }
                    }
                    return "UpdateSkills";
                case "5":
                    System.Console.WriteLine("Please enter a Teritiary Skill!");
                    newskills.Teritiaryskill = System.Console.ReadLine();
                    using (SqlConnection connection = new SqlConnection(constr))
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand($"UPDATE Skills SET Teritiaryskill = @Teritiaryskill where userid = {pid}", connection))
                        {
                            command.Parameters.AddWithValue("@Teritiaryskill", newskills.Teritiaryskill);
                            command.ExecuteNonQuery();
                        }
                    }
                    return "UpdateSkills";
                case "6":
                    System.Console.WriteLine("Please enter a Teritiary Skill Proficiency!");
                    newskills.proficiency3 = System.Console.ReadLine();
                    using (SqlConnection connection = new SqlConnection(constr))
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand($"UPDATE Skills SET proficiency3 = @proficiency3 where userid = {pid}", connection))
                        {
                            command.Parameters.AddWithValue("@proficiency3", newskills.proficiency3);
                            command.ExecuteNonQuery();
                        }
                    }
                    return "UpdateSkills";
                case "7":
                    try
                    {
                        Log.Information("Adding record \n" + newskills);
                        repo.Add(newskills);
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
