
using webapi.Model;

namespace webapi.Repository
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> FindUsers();

        Task<Usuario> FindUserById(int id);
        void AddUser(Usuario usuario);
        void UpdateUser(Usuario usuario);
        void DeleteUser(Usuario usuario);
        
        Task<bool> SaveChangesAsync();
    }
}