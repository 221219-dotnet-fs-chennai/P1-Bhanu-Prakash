using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectlib
{
    public class SkillRepo : ISqlRepo<Skills>
    {
        private readonly string connectionstr;
        public SkillRepo(string connectionstr)
        {
            this.connectionstr = connectionstr;
        }
        public Skills Add(Skills userskills)
        {
            string query = @"insert into Skills ( userid,primaryskill, proficiency1, Secondaryskill, proficiency2, Teritaryskill, proficiency3) 
                            values ( @userid, @primaryskill, @proficiency1, @Secondaryskill, @proficiency2, @Teritaryskill, @proficiency3)";
            using SqlConnection con = new SqlConnection(connectionstr);
            con.Open();
            SqlCommand sqlcommand = new SqlCommand(query, con);
            sqlcommand.Parameters.AddWithValue("@userid", userskills.Userid);
            sqlcommand.Parameters.AddWithValue("@proficiency3", userskills.proficiency3);
            sqlcommand.Parameters.AddWithValue("@Teritaryskill", userskills.Teritaryskill);
            sqlcommand.Parameters.AddWithValue("@proficiency2", userskills.Proficiency2);
            sqlcommand.Parameters.AddWithValue("@Secondaryskill", userskills.Secondaryskill);
            sqlcommand.Parameters.AddWithValue("@proficiency1",userskills.Proficiency1);
            sqlcommand.Parameters.AddWithValue("@primaryskill", userskills.Primaryskill);
            int rows = sqlcommand.ExecuteNonQuery();
            return userskills;
        }

        public List<Skills> GetAll(int id)
        {
            List<Skills> userskills = new List<Skills>();
            using SqlConnection con = new SqlConnection(connectionstr);
            con.Open();
            string query = $"select [userid],[primaryskill], [proficiency1], [Secondaryskill], [proficiency2], [Teritaryskill], [proficiency3] from Skills where userid = {id}";
            using SqlCommand sqlcommand = new SqlCommand(query, con);
            using SqlDataReader sqlDataReaderreader = sqlcommand.ExecuteReader();
            while (sqlDataReaderreader.Read())
            {
                userskills.Add(new Skills()
                {
                    Primaryskill = sqlDataReaderreader.GetString(1),
                    Proficiency1 = sqlDataReaderreader.GetString(2),
                    Secondaryskill = sqlDataReaderreader.GetString(3),
                    Proficiency2 = sqlDataReaderreader.GetString(4),
                    Teritaryskill = sqlDataReaderreader.GetString(5),
                    proficiency3 = sqlDataReaderreader.GetString(6)
                });
            }
            return userskills;
        }
    }
}
