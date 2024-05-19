namespace BicyclesApp.Service.IService
{
    public interface ILoginBarNotifyService
    {
        event Action RefreshRequested;
        void CallRequestRefresh();
    }
}
