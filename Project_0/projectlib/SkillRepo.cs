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
            string query = @"insert into Skills (userid, primaryskill, proficiency1, Secondaryskill, proficiency2, Teritiaryskill, proficiency3) 
                            values (@id, @primaryskill, @proficiency1, @Secondaryskill, @proficiency2, @Teritiaryskill, @proficiency3)";
            
            using SqlConnection con = new SqlConnection(connectionstr);
            con.Open();
            SqlCommand sqlcommand = new SqlCommand(query, con);
            sqlcommand.Parameters.AddWithValue("@id",userskills.Userid);
            sqlcommand.Parameters.AddWithValue("@proficiency1",userskills.Proficiency1);
            sqlcommand.Parameters.AddWithValue("@primaryskill", userskills.Primaryskill);
            sqlcommand.Parameters.AddWithValue("@Secondaryskill", userskills.Secondaryskill);
            sqlcommand.Parameters.AddWithValue("@proficiency2", userskills.Proficiency2);
            sqlcommand.Parameters.AddWithValue("@Teritiaryskill", userskills.Teritiaryskill);
            sqlcommand.Parameters.AddWithValue("@proficiency3", userskills.proficiency3);
            int rows = sqlcommand.ExecuteNonQuery();
            return userskills;
        }

        public Skills GetAll(int id)
        {
            Skills userskills;
            using SqlConnection con = new SqlConnection(connectionstr);
            con.Open();
            string query = $"select [userid],[primaryskill], [proficiency1], [Secondaryskill], [proficiency2], [Teritiaryskill], [proficiency3] from Skills where userid = {id}";
            using SqlCommand sqlcommand = new SqlCommand(query, con);
            using SqlDataReader sqlDataReaderreader = sqlcommand.ExecuteReader();
            sqlDataReaderreader.Read();
            userskills = new Skills()
                {
                    Userid = id,
                    Primaryskill = sqlDataReaderreader.GetString(1),
                    Proficiency1 = sqlDataReaderreader.GetString(2),
                    Secondaryskill = sqlDataReaderreader.GetString(3),
                    Proficiency2 = sqlDataReaderreader.GetString(4),
                    Teritiaryskill = sqlDataReaderreader.GetString(5),
                    proficiency3 = sqlDataReaderreader.GetString(6)
                };
            return userskills;
        }
    }
}
