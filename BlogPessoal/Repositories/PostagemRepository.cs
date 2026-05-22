using BlogPessoal.Data;
using BlogPessoal.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogPessoal.Repositories;

public class PostagemRepository : IPostagemRepository
{
    private readonly AppDbContext _context;

    public PostagemRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Postagem>> GetAllAsync()
    {
        return await _context.Postagens
            .Include(p => p.Tema)
            .Include(p => p.Usuario)
            .ToListAsync();
    }

    public async Task<Postagem?> GetByIdAsync(long id)
    {
        return await _context.Postagens
            .Include(p => p.Tema)
            .Include(p => p.Usuario)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IEnumerable<Postagem>> GetByTemaAsync(long temaId)
    {
        return await _context.Postagens
            .Include(p => p.Tema)
            .Include(p => p.Usuario)
            .Where(p => p.TemaId == temaId)
            .ToListAsync();
    }

    public async Task<IEnumerable<Postagem>> GetByUsuarioAsync(long usuarioId)
    {
        return await _context.Postagens
            .Include(p => p.Tema)
            .Include(p => p.Usuario)
            .Where(p => p.UsuarioId == usuarioId)
            .ToListAsync();
    }

    public async Task<Postagem> CreateAsync(Postagem postagem)
    {
        _context.Postagens.Add(postagem);
        await _context.SaveChangesAsync();
        return postagem;
    }

    public async Task<Postagem> UpdateAsync(Postagem postagem)
    {
        _context.Postagens.Update(postagem);
        await _context.SaveChangesAsync();
        return postagem;
    }

    public async Task DeleteAsync(long id)
    {
        var postagem = await _context.Postagens.FindAsync(id);
        if (postagem != null)
        {
            _context.Postagens.Remove(postagem);
            await _context.SaveChangesAsync();
        }
    }
}