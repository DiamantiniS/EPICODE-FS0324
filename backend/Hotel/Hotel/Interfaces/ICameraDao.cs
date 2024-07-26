using Hotel.Models;
using ProgettoS6GestionaleHotelSabrinaCinque.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hotel.Interfaces
{
    public interface ICameraDao
    {
        IEnumerable<Camera> GetAll();
        Camera GetById(int id);
        void Add(Camera camera);
        void Update(Camera camera);
        void Delete(int id);
    }
}
