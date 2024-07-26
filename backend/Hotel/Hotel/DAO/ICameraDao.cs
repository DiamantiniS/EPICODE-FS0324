using Hotel.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hotel.DAO
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
