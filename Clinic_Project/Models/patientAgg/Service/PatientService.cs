using Clinic_Project.Models.DoctorAgg;
using Clinic_Project.Models.SkillAgg;
using Clinic_Project.Models.TurnAgg;
using Clinic_Project.Services.LoginService;

namespace Clinic_Project.Models.patientAgg.Service
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRipository _patientRipository;

        public PatientService(IPatientRipository patientRipository)
        {
            _patientRipository = patientRipository;
        }

        public List<Doctor> GetListOfDoctors(int skillId)
        {
          return _patientRipository.GetListOfDoctors(skillId);  
        }

        public List<Skill> GetSkills()
        {
           return _patientRipository.GetSkills();
        }

        public List<Turn> GetTurns(int doctorId)
        {
            return _patientRipository.GetTurns(doctorId);
        }

        public void ReservedTurn(int turnID)
        {
          var turn = _patientRipository.GetTurn(turnID);
          turn.IsReserved = true;
          turn.PatientId = CurrentUser.CurrentUserId;
            _patientRipository.Save();
        }
    }
}
