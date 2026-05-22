using BlogPessoal.Models;

namespace BlogPessoal.Repositories;

public interface ITemaRepository
{
    Task<IEnumerable<Tema>> GetAllAsync();
    Task<Tema?> GetByIdAsync(long id);
    Task<Tema> CreateAsync(Tema tema);
    Task<Tema> UpdateAsync(Tema tema);
    Task DeleteAsync(long id);
}