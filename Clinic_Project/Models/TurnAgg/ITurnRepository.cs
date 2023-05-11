namespace Clinic_Project.Models.TurnAgg
{
    public interface ITurnRepository
    {
        void Add(Turn entity);
        void Save();
    }
}
