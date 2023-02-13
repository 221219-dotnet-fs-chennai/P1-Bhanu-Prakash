using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Company
    {
        public Company() { }
        public Company(int userid, string previouscompany, string technology, int experienceyear,int CompanyId)
        {
            this.UserId = userid;
            this.PreviousCompany = previouscompany;
            this.Technology = technology;
            this.Experienceyear = experienceyear;
            this.CmpId= CompanyId;
        }

        public int? UserId { get; set; }
        public string? PreviousCompany { get; set; }
        public string? Technology { get; set; }
        public int? Experienceyear { get; set; }

        public int CmpId { get; set; }

        public override string ToString()
        {
            return (
                $"*Company ID                                -              {CmpId} " + "\n" +
                $"*Previous Company                          -              {PreviousCompany} " + "\n" +
                $"*Technology                                -              {Technology} " + "\n" +
                $"*Experience in Years                       -              {Experienceyear}");
        }
    }
}
