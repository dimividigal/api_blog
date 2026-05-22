using BlogPessoal.Models;

namespace BlogPessoal.Repositories;

public interface IPostagemRepository
{
    Task<IEnumerable<Postagem>> GetAllAsync();
    Task<Postagem?> GetByIdAsync(long id);
    Task<IEnumerable<Postagem>> GetByTemaAsync(long temaId);
    Task<IEnumerable<Postagem>> GetByUsuarioAsync(long usuarioId);
    Task<Postagem> CreateAsync(Postagem postagem);
    Task<Postagem> UpdateAsync(Postagem postagem);
    Task DeleteAsync(long id);
}