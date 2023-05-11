using Clinic_Project.DataAccess.DbContext;
using Clinic_Project.Models.DoctorAgg;

namespace Clinic_Project.DataAccess.Repositories
{
    public class DoctorRepository:IDoctorRepository
    {
        private readonly MedicalClinicContext _context;

        public DoctorRepository(MedicalClinicContext context)
        {
            _context = context;
        }

        public Doctor Get(int id)
        {
            
            return _context.Doctors.FirstOrDefault(x=>x.Id==id)!;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
