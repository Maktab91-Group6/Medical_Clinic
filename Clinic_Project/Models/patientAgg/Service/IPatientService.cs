using Clinic_Project.Models.DoctorAgg;
using Clinic_Project.Models.SkillAgg;
using Clinic_Project.Models.TurnAgg;
using System.Net;

namespace Clinic_Project.Models.patientAgg.Service
{
    public interface IPatientService
    {

       List<Skill> GetSkills();
       List<Doctor> GetListOfDoctors(int skillId);
       List<Turn> GetTurns(int doctorId);
       void ReservedTurn(int turnID);
      
    }
}
