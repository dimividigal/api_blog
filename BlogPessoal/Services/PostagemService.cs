using BlogPessoal.DTOs;
using BlogPessoal.Models;
using BlogPessoal.Repositories;

namespace BlogPessoal.Services;

public class PostagemService
{
    private readonly IPostagemRepository _repository;

    public PostagemService(IPostagemRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Postagem>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Postagem?> GetByIdAsync(long id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<Postagem>> GetByTemaAsync(long temaId)
    {
        return await _repository.GetByTemaAsync(temaId);
    }

    public async Task<IEnumerable<Postagem>> GetByUsuarioAsync(long usuarioId)
    {
        return await _repository.GetByUsuarioAsync(usuarioId);
    }

    public async Task<Postagem> CreateAsync(PostagemDto dto)
    {
        var postagem = new Postagem
        {
            Titulo = dto.Titulo,
            Texto = dto.Texto,
            Data = DateTime.UtcNow,
            TemaId = dto.TemaId,
            UsuarioId = dto.UsuarioId
        };
        return await _repository.CreateAsync(postagem);
    }

    public async Task<Postagem?> UpdateAsync(long id, PostagemDto dto)
    {
        var postagem = await _repository.GetByIdAsync(id);
        if (postagem == null) return null;

        postagem.Titulo = dto.Titulo;
        postagem.Texto = dto.Texto;
        postagem.TemaId = dto.TemaId;
        postagem.UsuarioId = dto.UsuarioId;

        return await _repository.UpdateAsync(postagem);
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var postagem = await _repository.GetByIdAsync(id);
        if (postagem == null) return false;

        await _repository.DeleteAsync(id);
        return true;
    }
}