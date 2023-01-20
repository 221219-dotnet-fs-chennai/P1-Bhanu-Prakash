using Console;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectlib
{
    public class CompanyRepo : ISqlRepo<Company>
    {
        private readonly string connectionstr;
        public CompanyRepo(string connectionstr)
        {
            this.connectionstr = connectionstr;
        }
        public Company Add(Company usercompany)
        {
            string query = @"insert into Company ( PreviousCompany, Technology, experienceyear, userid) 
                            values ( @PreviousCompany, @Technology, @experienceyear, @userid)";
            using SqlConnection con = new SqlConnection(connectionstr);
            con.Open();
            SqlCommand sqlcommand = new SqlCommand(query, con);
            sqlcommand.Parameters.AddWithValue("@PreviousCompany", usercompany.PreviousCompany);
            sqlcommand.Parameters.AddWithValue("@Technology", usercompany.Technology);
            sqlcommand.Parameters.AddWithValue("@experienceyear", usercompany.Technology);
            sqlcommand.Parameters.AddWithValue("@userid", usercompany.Userid);
            int rows = sqlcommand.ExecuteNonQuery();
            return usercompany;
        }

        public List<Company> GetAll(int id)
        {
            List<Company> user = new List<Company>();
            using SqlConnection con = new SqlConnection(connectionstr);
            con.Open();
            string query = $"select [userid], [PreviousCompany], [Technology], [experienceyear] from Company where userid = {id}";
            using SqlCommand sqlcommand = new SqlCommand(query, con);
            using SqlDataReader sqlDataReaderreader = sqlcommand.ExecuteReader();
            while (sqlDataReaderreader.Read())
            {
                user.Add(new Company()
                {
                    Userid = id,
                    PreviousCompany = sqlDataReaderreader.GetString(1),
                    Technology = sqlDataReaderreader.GetString(2),
                    ExperienceYear = sqlDataReaderreader.GetInt32(3),
                });
            }
            return user;
        }
    }
}
