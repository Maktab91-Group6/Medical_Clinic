using Clinic_Project.DataAccess.DbContext;
using Clinic_Project.Models.DoctorAgg;
using Clinic_Project.Models.patientAgg;
using Clinic_Project.Models.patientAgg.Service;
using Clinic_Project.Models.SkillAgg;
using Clinic_Project.Models.TurnAgg;

namespace Clinic_Project.DataAccess.Repositories
{
    public class PatientRipository : IPatientRipository
    {
        private readonly MedicalClinicContext _clinicalContext;

        public PatientRipository(MedicalClinicContext clinicalContext)
        {
            _clinicalContext = clinicalContext;
        }

        public List<Doctor> GetListOfDoctors(int skillId)
        {
            throw new NotImplementedException();
        }

        public List<Skill> GetSkills()
        {
            throw new NotImplementedException();
        }

        public List<Turn> GetTurns(int doctorId)
        {
            throw new NotImplementedException();
        }

        public void ReservedTurn(int turnID)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public Turn GetTurn(int turnId)
        {
            throw new NotImplementedException();
        }

        
    }
}
