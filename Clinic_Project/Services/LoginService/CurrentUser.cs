namespace Clinic_Project.Services.LoginService
{
    public static class CurrentUser
    {
        public static int? CurrentUserId { get; set; }
        public static bool DoctorCheck { get; set; }
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
