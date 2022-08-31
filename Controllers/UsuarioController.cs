
using Microsoft.AspNetCore.Mvc;
using webapi.Model;
using webapi.Repository;

namespace webapi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {

        private readonly IUsuarioRepository _repository;
        public UsuarioController(IUsuarioRepository repository)
        {
            _repository = repository;
        }


        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            var usuarios = await _repository.FindUsers();
            return usuarios.Any()
            ? Ok(usuarios)
            : NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var usuario = await _repository.FindUserById(id);
            return usuario != null
             ? Ok(usuario)
            : NotFound("Usuário não encontrado.");
        }

        [HttpPut("{id}")]
            public async Task<IActionResult> Put(int id, Usuario usuario)
        {

            var usuarioAtualizado = await _repository.FindUserById(id);
            if (usuarioAtualizado == null) return NotFound("Usuario Inexistente.");

            usuarioAtualizado.Nome = usuario.Nome ?? usuarioAtualizado.Nome;
            usuarioAtualizado.DataDeNascimento = usuario.DataDeNascimento != new DateTime()
            ? usuario.DataDeNascimento : usuarioAtualizado.DataDeNascimento; 

            _repository.UpdateUser(usuario);

              return await _repository.SaveChangesAsync()
             ? Ok("Usuario atualizado com sucesso.")
             : BadRequest("Erro ao atualizar o usuário informado.");

        }


        [HttpPost]
        public async Task<IActionResult> PostUser(Usuario usuario)
        {
            _repository.AddUser(usuario);
            return await _repository.SaveChangesAsync()
             ? Ok("Usuario adicionado com sucesso.")
             : BadRequest("Erro ao salvar o usuário");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(int id) 
        {
            var usuarioDelete = await _repository.FindUserById(id);
            if (usuarioDelete == null) return NotFound("Usuario Inexistente.");

              _repository.DeleteUser(usuarioDelete);
            return await _repository.SaveChangesAsync()
             ? Ok("Usuario removido com sucesso.")
             : BadRequest("Erro ao remover o usuário");

        }

    }
}