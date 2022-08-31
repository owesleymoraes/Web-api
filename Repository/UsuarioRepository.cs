
using webapi.Model;
using webapi.Data;
using Microsoft.EntityFrameworkCore;

namespace webapi.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly UsuarioDbContext _usuarioDbContext;
        public UsuarioRepository(UsuarioDbContext usuarioDbContext)
        {
            _usuarioDbContext = usuarioDbContext;
        }

        public void AddUser(Usuario usuario)
        {
            _usuarioDbContext.Add(usuario);
        }

        public void DeleteUser(Usuario usuario)
        {
            _usuarioDbContext.Remove(usuario);
        }

        public async Task<IEnumerable<Usuario>> FindUsers()
        {
            return await _usuarioDbContext.Usuarios.ToListAsync();
        }

        public async Task<Usuario> FindUserById(int id)
        {
            return await _usuarioDbContext.Usuarios.
            Where(x => x.Id == id).
            FirstOrDefaultAsync();
        }

        public void UpdateUser(Usuario usuario)
        {
            _usuarioDbContext.Update(usuario);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _usuarioDbContext.SaveChangesAsync() > 0;
        }

    }
}