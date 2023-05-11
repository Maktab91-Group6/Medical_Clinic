namespace Clinic_Project.Models.SkillAgg.Service
{
    public class SkillService:ISkillServices
    {
        private readonly ISkillRepository _contextRepo;

        public SkillService(ISkillRepository context)
        {
            _contextRepo = context;
        }

        public Skill Get(int id)
        {
            return _contextRepo.Get(id);

        }
    }
}
