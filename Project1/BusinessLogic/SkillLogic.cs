using DataFluentAPI;
using DataFluentAPI.Entities;
using Microsoft.IdentityModel.Tokens;

namespace BusinessLogic
{
    public class SkillLogic : ISkillLogic
    {
        ProjectContext _context;
        IRepo<UserDetails> _repo;
        ISkillRepo _skillrepo;
        Validate _id;

        public SkillLogic(ISkillRepo skillrepo, ProjectContext context,Validate id)
        {
            _skillrepo = skillrepo;
            _context = context;
            _id = id;
        }

        public Models.Skills AddSkillDetails(string email,Models.Skills user)
        {
            user.UserId = _id.Pid(email);
            return Mapper.Map( _skillrepo.Add(Mapper.Map(user)));
        }
        public IEnumerable<Models.Skills> GetskillDetails()
        {
            return Mapper.Map(_skillrepo.GetAll());
        }
        public IEnumerable<Models.Skills> Get(string email)
        {
            int id = _id.Pid(email);
            return Mapper.Map(_skillrepo.Get(id).ToList());
        }

        public Models.Skills Remove(string email, string skillname)
        {
            int id = _id.Pid(email);
            /*var mail = (from i in _skillrepo.GetAll()
                        where i.UserId == id && i.Skill == skillname
                        select i).FirstOrDefault();*/
            return Mapper.Map(_skillrepo.Delete(id,skillname));
        }

        public Skills UpdateUser(string email,string oldskill, Models.Skills user)
        {
            int id = _id.Pid(email);
            var sk = _context.Skills.Where(item=>item.UserId == id && item.Skill == oldskill).FirstOrDefault();
            if(sk != null)
            {
                sk.SkillId = sk.SkillId;
                sk.UserId = sk.UserId;
                if(sk.Skill.IsNullOrEmpty() && sk.Skill != null) sk.Skill = sk.Skill;
                else sk.Skill = user.Skill;
                if (sk.Proficiency.IsNullOrEmpty() && sk.Proficiency != null) sk.Proficiency = sk.Proficiency;
                else sk.Proficiency = user.Proficiency;
            }
            return _skillrepo.UpdateUser(sk);
        }
    }
}
