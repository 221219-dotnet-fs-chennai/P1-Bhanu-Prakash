using DataFluentAPI.Entities;
using System.Text.RegularExpressions;

namespace BusinessLogic
{
    public class Validate
    {
        ProjectContext _context;
        public Validate(ProjectContext context)
        {
            _context = context;
        }

        public int Pid(string email)
        {
            int id = 0;
            var res = _context.UserDetails.Where(i => i.Email == email).FirstOrDefault();
            if (res.Email == email)
            {
                id = res.Id;
            }
            return id;
        }

        public bool CheckUser(string email,string password)
        {
            try
            {
                var mail = _context.UserDetails.Where(i => i.Email == email).First();
                if(mail.Email == email && mail.Password == password)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }

        public Skills GetSkillName(int id, string name)
        {
            return _context.Skills.Where(i => i.SkillId == id && i.Skill == name).First();
        }

        public static bool IsValidEmail(string str)
        {
            if(str !=null)
            {
                try
                {
                    string pattern = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";
                    if (Regex.IsMatch(str, pattern))
                    {
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Email Format");
                        return false;
                    }
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (RegexMatchTimeoutException e)
                {
                    Console.WriteLine(e.Message);
                }

            }
            return false; 
        }

        public static bool IsValidPassword(string str)
        {
            if (str != null)
            {
                try
                {
                    string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$";
                    if (Regex.IsMatch(str, pattern))
                    {
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Password is not Strong" + "\n" +
                                                "It should contains atleast one Special Characters \"@$!%*?&\" and length should be of minimum 8 characters");
                        return false;
                    }
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (RegexMatchTimeoutException e)
                {
                    Console.WriteLine(e.Message);
                }

            }
            return false;
        }

        public static bool IsValidPhone(string str)
        {
            if (str != null)
            {
                try
                {
                    string pattern = @"^[6-9][0-9]{9}$";
                    if (Regex.IsMatch(str, pattern))
                    {
                        return true;
                    }
                    else
                    {
                        System.Console.WriteLine("Invalid Phone Number Format");
                        return false;
                    }
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (RegexMatchTimeoutException e)
                {
                    Console.WriteLine(e.Message);
                }

            }
            return false;
        }

        public static bool IsValidZipcode(string str)
        {
            if (str != null)
            {
                try
                {
                    string pattern = @"^[1-9][0-9]{5}$";
                    if (Regex.IsMatch(str, pattern))
                    {
                        return true;
                    }
                    else
                    {
                        System.Console.WriteLine("Invalid Zipcode" + "\n" +
                                                "Zipcode should be of length 6");
                        return false;
                    }
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (RegexMatchTimeoutException e)
                {
                    Console.WriteLine(e.Message);
                }

            }
            return false;
        }

    }
}