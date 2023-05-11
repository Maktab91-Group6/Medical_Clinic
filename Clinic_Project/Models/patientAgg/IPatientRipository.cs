using Clinic_Project.Models.DoctorAgg;
using Clinic_Project.Models.SkillAgg;
using Clinic_Project.Models.TurnAgg;

namespace Clinic_Project.Models.patientAgg
{
    public interface IPatientRipository
    {
        void Save();
        List<Skill> GetSkills();
        List<Doctor> GetListOfDoctors(int skillId);
        List<Turn> GetTurns(int doctorId);
        Turn GetTurn(int turnId);
    }
}
