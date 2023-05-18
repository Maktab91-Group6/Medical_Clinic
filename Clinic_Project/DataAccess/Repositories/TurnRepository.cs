using Clinic_Project.DataAccess.DbContext;
using Clinic_Project.Models;
using Clinic_Project.Models.TurnAgg;
using Serilog;

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
	        Log.ForContext("SqlCrud", "ADD").ForContext("TrunId", entity.Id).Debug(messageTemplate:"Adding Turn Initiated");
	        _context.Turns.Add(entity);
			Log.ForContext("SqlCrud", "ADD").ForContext("TrunId",entity.Id).Information(messageTemplate: "Turn Added Successfully");

		}

		public void Save()
        {
            
            _context.SaveChanges();
        }
    }
}
