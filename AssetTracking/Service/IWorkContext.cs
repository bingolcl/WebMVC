using Data;

namespace Service
{
    public interface IWorkContext
    {
        User CurrentLoginUser { get; set; }     
        User OriginalUserIfImpersonated { get; }
        bool IsAdministrator { get; }
        bool IsSalesManager{ get; }
        bool IsAccountant { get; }
    }
}
