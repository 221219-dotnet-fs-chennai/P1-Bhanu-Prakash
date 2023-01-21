using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console
{
    public class Delete : IMenu
    {
        static string constr = File.ReadAllText("../../../../Database/log.txt");
        public void Display()
        {
            System.Console.WriteLine("[0] - Back");
            System.Console.WriteLine("[1] - Delete");
        }
        public string UserChoice()
        {
            string userinput = System.Console.ReadLine();
            if (userinput == "0")
            {
                return "Login";
            }
            else
            {
                int id = Validate.Pid();
                using SqlConnection con = new SqlConnection(constr);
                con.Open();
                string query = $"Delete UserDetails where id = {id}";
                using SqlCommand sqlcommand = new SqlCommand(query, con);
                sqlcommand.Parameters.AddWithValue("@id", id);
                sqlcommand.ExecuteNonQuery();
                return "Menu";
            }
        }
    }
}
