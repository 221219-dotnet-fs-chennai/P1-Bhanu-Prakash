using Console;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectlib
{
    public class ContactRepo : ISqlRepo<Contact>
    {
        private readonly string connectionstr;
        public ContactRepo(string connectionstr)
        {
            this.connectionstr = connectionstr;
        }
        public Contact Add(Contact usercontact)
        {
            string query = @"insert into Contact ( phone, city, state, zipcode, userid) 
                            values ( @phone, @city, @state, @zipcode, @userid)";
            using SqlConnection con = new SqlConnection(connectionstr);
            con.Open();
            SqlCommand sqlcommand = new SqlCommand(query, con);
            sqlcommand.Parameters.AddWithValue("@phone", usercontact.Phone);
            sqlcommand.Parameters.AddWithValue("@state", usercontact.State);
            sqlcommand.Parameters.AddWithValue("@city", usercontact.City);
            sqlcommand.Parameters.AddWithValue("@zipcode", usercontact.Zipcode);
            sqlcommand.Parameters.AddWithValue("@userid", usercontact.Userid);
            int rows = sqlcommand.ExecuteNonQuery();
            return usercontact;
        }

        public List<Contact> GetAll(int id)
        {
            List<Contact> usercontact = new List<Contact>();
            using SqlConnection con = new SqlConnection(connectionstr);
            con.Open();
            string query = $"select [userid], [phone], [city], [state], [zipcode] from Contact where userid = {id}";
            using SqlCommand sqlcommand = new SqlCommand(query, con);
            using SqlDataReader sqlDataReaderreader = sqlcommand.ExecuteReader();
            while (sqlDataReaderreader.Read())
            {
                usercontact.Add(new Contact()
                {
                    Phone = sqlDataReaderreader.GetString(1),
                    City = sqlDataReaderreader.GetString(2),
                    State = sqlDataReaderreader.GetString(3),
                    Zipcode = sqlDataReaderreader.GetString(4)
                });
            }
            return usercontact;
        }
    }
}
