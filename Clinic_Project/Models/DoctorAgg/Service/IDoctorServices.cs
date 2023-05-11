namespace Clinic_Project.Models.DoctorAgg.Service
{
    public interface IDoctorServices
    {
        void SetTurns(DateTime startJob, DateTime endJob);
        void SetSkill(int id);
        
    }
}
