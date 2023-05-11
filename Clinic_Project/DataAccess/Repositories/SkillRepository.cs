using Clinic_Project.Models;
using Clinic_Project.Models.SkillAgg;

namespace Clinic_Project.DataAccess.Repositories
{
    public class SkillRepository:ISkillRepository
    {
        private readonly MedicalClinicContext _context;

        public SkillRepository(MedicalClinicContext context)
        {
            _context = context;
        }


        public Skill Get(int skillId)
        {
            
            return _context.Skills.FirstOrDefault(x=>x.Id==skillId)!;
        }
    }
}
