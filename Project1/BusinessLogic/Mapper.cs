using System.Data.SqlTypes;
using df = DataFluentAPI.Entities;
namespace BusinessLogic
{
    public class Mapper
    {
        public static Models.UserDetails Map(df.UserDetails ud)
        {
            return new Models.UserDetails()
            {
                Id= ud.Id,
                Firstname=ud.Firstname,
                Lastname=ud.Lastname,
                email=ud.Email,
                password=ud.Password,
                Gender=ud.Gender,
                Age=ud.Age
            };
        }

        public static df.UserDetails Map(Models.UserDetails ud)
        {
            return new df.UserDetails()
            {
                Id = ud.Id,
                Firstname = ud.Firstname,
                Lastname = ud.Lastname,
                Email = ud.Email,
                Password = ud.Password,
                Gender = ud.Gender,
                Age = ud.Age
            };
        }

        public static IEnumerable<Models.UserDetails> Map(IEnumerable<df.UserDetails> ud)
        {
            return ud.Select(Map);
        } 


    }
}