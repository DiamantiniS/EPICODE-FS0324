using Hotel.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hotel.Interfaces
{
    public interface ICameraService
    {
        Task<IEnumerable<Camera>> GetAllRooms();
        Task<Camera> GetRoomByNumber(int numero);
        Task AddRoom(Camera camera);
        Task UpdateRoom(Camera camera);
        Task DeleteRoom(int numero);
    }
}
