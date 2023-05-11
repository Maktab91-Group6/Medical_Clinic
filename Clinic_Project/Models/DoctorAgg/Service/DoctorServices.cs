using Clinic_Project.Models.SkillAgg;
using Clinic_Project.Services.LoginService;

namespace Clinic_Project.Models.DoctorAgg.Service
{
    public class DoctorServices:IDoctorServices
    {
        private readonly IDoctorRepository _doctorRepo;
        private readonly ISkillRepository _skillRepo;

        public DoctorServices(IDoctorRepository doctorRepo, ISkillRepository skillRepo)
        {
            _doctorRepo = doctorRepo;
            _skillRepo = skillRepo;
        }

        public void SetTurns(DateTime startJob, DateTime endJob)
        {
            var doctor = _doctorRepo.Get(CurrentUser.CurrentUserId);
            
            var durationTime=endJob-startJob;
            var durationTimeTotalMinutes = (int)durationTime.TotalMinutes/30;
            var startTurn = startJob;
            for (var i = 0; i < durationTimeTotalMinutes; i++)
            {
                doctor!.Turns.Add(new Turn(startTurn,startTurn.AddMinutes(30),doctor.Id));
                startTurn = startTurn.AddMinutes(30);
            }
            _doctorRepo.Save();
        }

        public void SetSkill(int id)
        {
            var doctor = _doctorRepo.Get(CurrentUser.CurrentUserId);
            var skill = _skillRepo.Get(id);
            doctor.Skill = skill;
            _doctorRepo.Save();
        }
    }
}
