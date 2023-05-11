namespace Clinic_Project.Models.DoctorAgg
{
    public interface IDoctorRepository
    {
        Doctor Get(int id);
        void Save();
    }
}
