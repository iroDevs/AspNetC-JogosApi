using Jogos_API.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jogos_API.repositories
{
   
    public class JogoRepository : IJogoRepository
    {
        public readonly JogoContext _context;
        public JogoRepository(JogoContext context)
        {
            _context = context;
        }
        public async Task<Jogo> Create(Jogo jogo)
        {
           _context.Jogos.Add(jogo);
           await  _context.SaveChangesAsync();
            
             return jogo;
        }

        public async Task<string> Delete(int id)
        {
            var JogoToDelete = await _context.Jogos.FindAsync(id);
            _context.Jogos.Remove(JogoToDelete);
            await _context.SaveChangesAsync();
            return "Elemento removido";
        }

        public async Task<IEnumerable<Jogo>> Get()
        {
            return await _context.Jogos.ToListAsync();
        }

        public async Task<Jogo> Get(int id)
        {
            var JogoToReturn = await _context.Jogos.FindAsync(id);
            return JogoToReturn;
        }

        public async Task<string> Update(Jogo jogo)
        {
            _context.Entry(jogo).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return "elemento alterado";
        }
    }
}
