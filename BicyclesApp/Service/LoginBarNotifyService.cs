using BicyclesApp.Service.IService;

namespace BicyclesApp.Service
{
    public class LoginBarNotifyService : ILoginBarNotifyService
    {
        public event Action RefreshRequested;

        public void CallRequestRefresh()
        {
            RefreshRequested?.Invoke();
        }
    }
}
