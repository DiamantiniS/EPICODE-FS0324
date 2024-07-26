using Diama_sHotel.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Diama_sHotel.Interfaces
{
    public interface ICameraService
    {
        Task AddCameraAsync(Camera camera);
        Task<Camera> GetCameraByIdAsync(int id);
        Task<IEnumerable<Camera>> GetAllCamereAsync();
        Task UpdateCameraAsync(Camera camera);
        Task DeleteCameraAsync(int id);
    }
}
