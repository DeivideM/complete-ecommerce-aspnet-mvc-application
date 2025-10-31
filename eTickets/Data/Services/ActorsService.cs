using eTickets.Models;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Data.Services;

public class ActorsService : IActorsService
{
    private readonly AppDbContext _context;

    public ActorsService(AppDbContext context) => _context = context;
    public async Task AddAsync(Actor actor)
    {
        await _context.Actors.AddAsync(actor);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Actor actor)
    {
        //var result = await _context.Actors.FirstOrDefaultAsync(a => a.Id == id);
        if (actor != null)
        {
            _context.Actors.Remove(actor);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Actor>> GetAllAsync()
    {
        var data = await _context.Actors.ToListAsync();
        return data;
    }

    public async Task<Actor> GetByIdAsync(int id)
    {
        var result = await _context.Actors.FirstOrDefaultAsync(a => a.Id == id);
        return result;
    }

    public async Task<Actor> UpdateAsync(int id, Actor newActor)
    {
        // Busca o registro existente no banco
        //var existingActor = await _context.Actors.FindAsync(id);

        // Se não encontrou, lança uma exceção (ou retorna false, conforme sua lógica)
        //if (existingActor == null)
        //    throw new KeyNotFoundException($"Actor with ID {id} not found.");

        // Atualiza apenas os campos necessários
        //existingActor.FullName = actor.FullName;
        //existingActor.ProfilePictureURL = actor.ProfilePictureURL;
        //existingActor.Bio = actor.Bio;
        // ... adicione os outros campos que podem ser atualizados

        // Salva as alterações
        //await _context.SaveChangesAsync();

        _context.Update(newActor);
        await _context.SaveChangesAsync();
        return newActor;
    }
}
