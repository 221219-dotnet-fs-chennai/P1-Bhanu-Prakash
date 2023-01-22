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
            string query = @"insert into Contact ( userid,phone, city, state, zipcode) 
                            values ( @id, @phone, @city, @state, @zipcode)";
            using SqlConnection con = new SqlConnection(connectionstr);
            con.Open();
            SqlCommand sqlcommand = new SqlCommand(query, con);
            sqlcommand.Parameters.AddWithValue("@id", usercontact.Userid);
            sqlcommand.Parameters.AddWithValue("@phone", usercontact.Phone);
            sqlcommand.Parameters.AddWithValue("@state", usercontact.State);
            sqlcommand.Parameters.AddWithValue("@city", usercontact.City);
            sqlcommand.Parameters.AddWithValue("@zipcode", usercontact.Zipcode);
            int rows = sqlcommand.ExecuteNonQuery();
            return usercontact;
        }

        public Contact GetAll(int id)
        {
            Contact usercontact;
            using SqlConnection con = new SqlConnection(connectionstr);
            con.Open();
            string query = $"select [userid], [phone], [city], [state], [zipcode] from Contact where userid = {id}";
            using SqlCommand sqlcommand = new SqlCommand(query, con);
            using SqlDataReader sqlDataReaderreader = sqlcommand.ExecuteReader();
            sqlDataReaderreader.Read();
            usercontact = new Contact()
                {
                    Userid = id,
                    Phone = sqlDataReaderreader.GetString(1),
                    City = sqlDataReaderreader.GetString(2),
                    State = sqlDataReaderreader.GetString(3),
                    Zipcode = sqlDataReaderreader.GetString(4)
                };
            return usercontact;
        }
    }
}
