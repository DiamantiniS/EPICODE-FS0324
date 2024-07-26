using Hotel.Models;


namespace Hotel.Interfaces
{
    public interface IClienteDao
    {
        IEnumerable<Cliente> GetAll();
        Cliente GetById(int id);
        void Add(Cliente cliente);
        void Update(Cliente cliente);
        void Delete(int id);
    }
}
