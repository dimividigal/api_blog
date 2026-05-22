using BlogPessoal.DTOs;
using BlogPessoal.Models;
using BlogPessoal.Repositories;

namespace BlogPessoal.Services;

public class TemaService
{
    private readonly ITemaRepository _repository;

    public TemaService(ITemaRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Tema>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Tema?> GetByIdAsync(long id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<Tema> CreateAsync(TemaDto dto)
    {
        var tema = new Tema
        {
            Descricao = dto.Descricao
        };
        return await _repository.CreateAsync(tema);
    }

    public async Task<Tema?> UpdateAsync(long id, TemaDto dto)
    {
        var tema = await _repository.GetByIdAsync(id);
        if (tema == null) return null;

        tema.Descricao = dto.Descricao;
        return await _repository.UpdateAsync(tema);
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var tema = await _repository.GetByIdAsync(id);
        if (tema == null) return false;

        await _repository.DeleteAsync(id);
        return true;
    }
}