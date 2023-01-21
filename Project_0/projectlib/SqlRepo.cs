using Console;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;

namespace projectlib
{   
    public class SqlRepo : ISqlRepo<UserDetails>
    {
        
        private readonly string connectionstr;
        public SqlRepo(string connectionstr)
        {
            this.connectionstr = connectionstr;
        }
        public UserDetails Add(UserDetails userDetails)
        {
            
           
            string query = $"insert into UserDetails ([firstname], [lastname], [Email], [password], [gender], [age]) values ('{userDetails.Firstname}','{userDetails.Lastname}','{userDetails.Email}','{userDetails.Password}','{userDetails.Gender}',{userDetails.Age}) ";
            using SqlConnection con = new SqlConnection(connectionstr);
            con.Open();
            SqlCommand sqlcommand = new SqlCommand(query, con);
            //sqlcommand.Parameters.AddWithValue("@id", userDetails.Id);
            //sqlcommand.Parameters.AddWithValue("@firstname", userDetails.Firstname);
            //sqlcommand.Parameters.AddWithValue("@lastname", userDetails.Lastname);
            //sqlcommand.Parameters.AddWithValue("@Email", userDetails.Email);
            //sqlcommand.Parameters.AddWithValue("@password", userDetails.Password);
            //sqlcommand.Parameters.AddWithValue("@gender", userDetails.Gender);
            //sqlcommand.Parameters.AddWithValue("@age", userDetails.Age);
            int rows = sqlcommand.ExecuteNonQuery();
            
            return userDetails;
        }

        public UserDetails GetAll(int id)
        {
            //System.Console.WriteLine("Enter user Email to Fetch data");
            //string e = System.Console.ReadLine();
            UserDetails user;
            using SqlConnection con = new SqlConnection(connectionstr);
            con.Open();
            string query = $"select [id], [firstname], [lastname], [Email], [gender], [age] from UserDetails where id = {id}";
            using SqlCommand sqlcommand = new SqlCommand(query, con);
            using SqlDataReader sqlDataReaderreader = sqlcommand.ExecuteReader();
            sqlDataReaderreader.Read();
            user = new UserDetails()
                {
                    Id = sqlDataReaderreader.GetInt32(0),
                    Firstname = sqlDataReaderreader.GetString(1),
                    Lastname = sqlDataReaderreader.GetString(2),
                    Email = sqlDataReaderreader.GetString(3),
                    Gender = sqlDataReaderreader.GetString(4),
                    Age = sqlDataReaderreader.GetInt32(5)
                };
            return user;
        }
    }
}
