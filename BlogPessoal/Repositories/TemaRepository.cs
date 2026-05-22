using BlogPessoal.Data;
using BlogPessoal.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogPessoal.Repositories;

public class TemaRepository : ITemaRepository
{
    private readonly AppDbContext _context;

    public TemaRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Tema>> GetAllAsync()
    {
        return await _context.Temas.ToListAsync();
    }

    public async Task<Tema?> GetByIdAsync(long id)
    {
        return await _context.Temas.FindAsync(id);
    }

    public async Task<Tema> CreateAsync(Tema tema)
    {
        _context.Temas.Add(tema);
        await _context.SaveChangesAsync();
        return tema;
    }

    public async Task<Tema> UpdateAsync(Tema tema)
    {
        _context.Temas.Update(tema);
        await _context.SaveChangesAsync();
        return tema;
    }

    public async Task DeleteAsync(long id)
    {
        var tema = await _context.Temas.FindAsync(id);
        if (tema != null)
        {
            _context.Temas.Remove(tema);
            await _context.SaveChangesAsync();
        }
    }
}