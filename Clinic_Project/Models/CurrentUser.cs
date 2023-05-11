namespace Clinic_Project.Models
{
    public static class CurrentUser
    {
        public static int CurrentUserId { get; set; }
        public static void SetCurrentUser(int id)
        {
            CurrentUserId = id;
        }
        public static void RemoveCurrentUser()
        {
            CurrentUserId = default;
        }
    }

    
}
