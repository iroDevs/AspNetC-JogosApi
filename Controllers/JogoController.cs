using Jogos_API.Models;
using Jogos_API.repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jogos_API.Controllers
{
    public class JogoController
    {
        private readonly IJogoRepository _jogo;

        public JogoController(IJogoRepository jogo)
        {
            _jogo = jogo;
        }
        [HttpGet]
        [Route("/jogo)")]
        public async Task<IEnumerable<Jogo>> GetJogo()
        {
            return await _jogo.Get();
        }

        [HttpGet("jogo/{id}")]
        public async Task<ActionResult<Jogo>> GetJogoById(int id)
        {
            return await _jogo.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<string>> CreateJogo([FromBody] Jogo jogo)
        {
            try
            {
               await _jogo.Create(jogo);
                
                return "registro criado com sucesso";


            }catch(InvalidCastException e)
            {
                return $"erro ao criar o jogo , erro: {e}";
            }
        }
        [HttpDelete]

        public async Task<ActionResult<string>> DeleteJogo(int id)
        {
           var JogoToDelete = await _jogo.Get(id);

            if (JogoToDelete == null)
            {
                return "registro de jogo não encontrado";
            }

                try
                {
                    await _jogo.Delete(JogoToDelete.Id);
                    return "registro Deletado com sucesso";

                }
                catch (InvalidCastException e)
                {
                    return $"erro ao Deletar o jogo , erro: {e}";
                }
        }

        [HttpPut]
        public async Task<ActionResult<string>> UpdateJogo(int id, [FromBody] Jogo jogo)
        {
            var JogoToUpdate = await _jogo.Get(id);

            if (JogoToUpdate == null)
            {
                return "registro de jogo não encontrado";
            }

            try
            {
                await _jogo.Update(jogo);

                return "registro criado com sucesso";


            }
            catch (InvalidCastException e)
            {
                return $"erro ao criar o jogo , erro: {e}";
            }
        }

    }
}
