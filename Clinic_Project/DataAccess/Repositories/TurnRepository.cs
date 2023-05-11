using Clinic_Project.DataAccess.DbContext;
using Clinic_Project.Models;
using Clinic_Project.Models.TurnAgg;

namespace Clinic_Project.DataAccess.Repositories
{
    public class TurnRepository:ITurnRepository
    {
        private readonly MedicalClinicContext _context;

        public TurnRepository(MedicalClinicContext context)
        {
            _context = context;
        }

        public void Add(Turn entity)
        {
            
            _context.Turns.Add(entity);
        }

        public void Save()
        {
            
            _context.SaveChanges();
        }
    }
}
