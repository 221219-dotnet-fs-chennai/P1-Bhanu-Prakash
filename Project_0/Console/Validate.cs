using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.CompilerServices;
using System.Collections;

namespace Console
{
    public class Validate : IMenu
    {
        static string constr = File.ReadAllText("../../../../Database/log.txt");
        static string wrongpswd = "";
        static string e = "";
        
        public void Display()
        {
            System.Console.WriteLine("Enter User Details");
            System.Console.WriteLine($"{wrongpswd}");
        }

        public string UserChoice()
        {
            System.Console.Write("Enter Email:");
            e = System.Console.ReadLine();
            string path = "../../../../Database/log.txt";
            string cs = File.ReadAllText(path);
            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT Email FROM UserDetails WHERE email = @email", connection))
                {
                    command.Parameters.AddWithValue("@email", e);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Close();
                            System.Console.Write("Enter Password:");
                            string p = System.Console.ReadLine();
                            SqlCommand cmd = new SqlCommand("SELECT Password from UserDetails where password = @password", connection);
                            cmd.Parameters.AddWithValue("@password", p);
                            SqlDataReader reader1 = cmd.ExecuteReader();
                            if (reader1.HasRows)
                            {
                                return "Login";
                            }
                            else
                            {
                                wrongpswd = "wrong password please retry...";
                                return "Validate";
                            }
                        }
                        else
                        {
                            return "Signup";
                        }
                    }
                }
            }
        }

        public static int Pid()
        {
            using SqlConnection con = new SqlConnection(constr);
            con.Open();
            string query = $"select id from UserDetails where email = @email";
            using SqlCommand sqlcommand = new SqlCommand(query, con);
            sqlcommand.Parameters.AddWithValue("@email", e);
            using SqlDataReader sqlDataReaderreader = sqlcommand.ExecuteReader();
            sqlDataReaderreader.Read();
            return sqlDataReaderreader.GetInt32(0);
        }
    }
}
