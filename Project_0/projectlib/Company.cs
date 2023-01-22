using System;
namespace Console
{
    public class Company
    {
        public Company() { }
        public Company(int userid, string previouscompany, string technology, int experienceyear)
        {
            this.Userid = userid;
            this.PreviousCompany = previouscompany;
            this.Technology = technology;
            this.ExperienceYear = experienceyear;
        }

        public int Userid { get; set; }
        public string PreviousCompany { get; set; }
        public string Technology { get; set; }
        public int ExperienceYear { get; set; }

        public override string ToString()
        {
            return (
                $"*Previous Company                          -              {PreviousCompany} " + "\n" +
                $"*Technology                                -              {Technology} " + "\n" +
                $"*Experience in Years                       -              {ExperienceYear}");
        }
    }
}
