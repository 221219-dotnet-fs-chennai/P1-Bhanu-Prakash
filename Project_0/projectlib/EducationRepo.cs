using Console;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectlib
{
    public class EducationRepo : ISqlRepo<Education>
    {
        private readonly string connectionstr;
        public EducationRepo(string connectionstr)
        {
            this.connectionstr = connectionstr;
        }
        public Education Add(Education usereducation)
        {
            string query = @"insert into Education ( userid, HigherEducation, university, startyear, endyear, grade) 
                            values ( @id, @HigherEducation, @university, @startyear, @endyear, @grade)";
            using SqlConnection con = new SqlConnection(connectionstr);
            con.Open();
            SqlCommand sqlcommand = new SqlCommand(query, con);
            sqlcommand.Parameters.AddWithValue("@id", usereducation.Userid);
            sqlcommand.Parameters.AddWithValue("@HigherEducation", usereducation.HigherEducation);
            sqlcommand.Parameters.AddWithValue("@university", usereducation.university);
            sqlcommand.Parameters.AddWithValue("@startyear", usereducation.Startyear);
            sqlcommand.Parameters.AddWithValue("@endyear", usereducation.Endyear);
            sqlcommand.Parameters.AddWithValue("@grade", usereducation.Grade);
            int rows = sqlcommand.ExecuteNonQuery();
            return usereducation;
        }

        public Education GetAll(int id)
        {
            Education userEducation;
            using SqlConnection con = new SqlConnection(connectionstr);
            con.Open();
            string query = $"select [userid],[HigherEducation], [university], [startyear], [endyear], [grade] from Education where userid = {id}";
            using SqlCommand sqlcommand = new SqlCommand(query, con);
            using SqlDataReader sqlDataReaderreader = sqlcommand.ExecuteReader();
            sqlDataReaderreader.Read();
                userEducation = new Education()
                {
                    Userid= sqlDataReaderreader.GetInt32(0),
                    HigherEducation = sqlDataReaderreader.GetString(1),
                    university = sqlDataReaderreader.GetString(2),
                    Startyear = sqlDataReaderreader.GetInt32(3),
                    Endyear = sqlDataReaderreader.GetInt32(4),
                    Grade = sqlDataReaderreader.GetString(5)
                };
            return userEducation;
        }
    }
}
