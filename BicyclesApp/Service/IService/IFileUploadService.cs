using Microsoft.AspNetCore.Components.Forms;

namespace BicyclesApp.Service.IService
{
    public interface IFileUploadService
    {
        Task<string> UploadFile(IBrowserFile file);

        bool DeleteFile(string filePath);
    }
}
