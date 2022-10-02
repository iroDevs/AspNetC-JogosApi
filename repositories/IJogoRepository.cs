using Jogos_API.Models;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jogos_API.repositories
{
    public interface IJogoRepository
    {
        Task<IEnumerable<Jogo>> Get();

        Task<Jogo> Get(int id);

        Task<Jogo> Create(Jogo jogo);

        Task<Jogo> Update(Jogo jogo);

        Task<Jogo> Delete(int id);
    }
}
