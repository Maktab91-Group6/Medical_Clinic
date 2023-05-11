using Clinic_Project.DataAccess.DbContext;
using Clinic_Project.Models.DoctorAgg;
using Clinic_Project.Models.patientAgg;
using Clinic_Project.Models.patientAgg.Service;
using Clinic_Project.Models.SkillAgg;
using Clinic_Project.Models.TurnAgg;
using Microsoft.EntityFrameworkCore;

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
           return _clinicalContext.Doctors.Where(x=>x.SkillId== skillId).AsNoTracking().ToList();
        }

        public List<Skill> GetSkills()
        {
           return _clinicalContext.Skills.AsNoTracking().ToList();
        }

        public List<Turn> GetTurns(int doctorId)
        {
           return _clinicalContext.Turns.Where(x=>x.DoctorId==doctorId).AsNoTracking().ToList();
        }

        public void Save()
        {
            _clinicalContext.SaveChanges();
        }

        public Turn GetTurn(int turnId)
        {
            return _clinicalContext.Turns.FirstOrDefault(x => x.Id == turnId)!;
        }

        
    }
}
