using System.Data.SqlTypes;
using df = DataFluentAPI.Entities;
namespace BusinessLogic
{
    public class Mapper
    {

        //----------------------------------User Details-------------------------------
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

        //------------------------------Skills---------------------------------------

        public static Models.Skills Map(df.Skills ud)
        {
            return new Models.Skills()
            {
                UserId = ud.UserId,
                Skill = ud.Skill,
                Proficiency = ud.Proficiency,
                SkillId= ud.SkillId
            };
        }

        public static df.Skills Map(Models.Skills ud)
        {
            return new df.Skills()
            {
                UserId = ud.UserId,
                Skill = ud.Skill,
                Proficiency = ud.Proficiency,
                SkillId= ud.SkillId
            };
        }
        public static IEnumerable<Models.Skills> Map(IEnumerable<df.Skills> ud)
        {
            return ud.Select(Map);
        }

        //-----------------------------------------Education--------------------------

        public static Models.Education Map(df.Education ed)
        {
            return new Models.Education()
            {
                UserId = ed.UserId,
                HigherEducation = ed.HigherEducation,
                University = ed.University,
                Startyear = ed.Startyear,
                Endyear = ed.Endyear,
                Grade = ed.Grade,
                EdId = ed.EdId
            };
        }

        public static df.Education Map(Models.Education ed)
        {
            return new df.Education()
            {
                UserId = ed.UserId,
                HigherEducation = ed.HigherEducation,
                University = ed.University,
                Startyear = ed.Startyear,
                Endyear = ed.Endyear,
                Grade = ed.Grade,
                EdId = ed.EdId
            };
        }

        public static IEnumerable<Models.Education> Map(IEnumerable<df.Education> ed)
        {
            return ed.Select(Map);
        }

        //-----------------------------------Company------------------------------------

        public static Models.Company Map(df.Company cd)
        {
            return new Models.Company()
            {
                UserId= cd.UserId,
                PreviousCompany = cd.PreviousCompany,
                Technology= cd.Technology,
                Experienceyear = cd.Experienceyear,
                CmpId =cd.CmpId
            };
        }

        public static df.Company Map(Models.Company cd)
        {
            return new df.Company()
            {
                UserId = cd.UserId,
                PreviousCompany = cd.PreviousCompany,
                Technology = cd.Technology,
                Experienceyear=cd.Experienceyear,
                CmpId = cd.CmpId
            };
        }
        public static IEnumerable<Models.Company> Map(IEnumerable<df.Company> ed)
        {
            return ed.Select(Map);
        }

        //--------------------------------------Contact----------------------------

        public static Models.Contact Map(df.Contact cd)
        {
            return new Models.Contact()
            {
                UserId = cd.UserId,
                phone = cd.Phone,
                City= cd.City,
                State= cd.State,
                zipcode=cd.Zipcode,
                ContactId= cd.ContactId
            };
        }
        public static df.Contact Map(Models.Contact cd)
        {
            return new df.Contact()
            {
                UserId = cd.UserId,
                Phone = cd.Phone,
                City = cd.City,
                State = cd.State,
                Zipcode = cd.Zipcode,
                ContactId = cd.ContactId
            };
        }
        public static IEnumerable<Models.Contact> Map(IEnumerable<df.Contact> ed)
        {
            return ed.Select(Map);
        }
    }
}