using Jogos_API.Models;
using Jogos_API.repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jogos_API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class JogoController : ControllerBase
    {
        private readonly IJogoRepository _jogo;

        public JogoController(IJogoRepository jogo)
        {
            _jogo = jogo;
        }
        [HttpGet]
   
        public async Task<IEnumerable<Jogo>> GetJogo()
        {
            return await _jogo.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Jogo>> GetJogoById(int id)
        {
            var JogoToGet = await _jogo.Get(id);

            if (JogoToGet == null)
            {
                return NotFound();
            }

            return await _jogo.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult> CreateJogo([FromBody] Jogo jogo)
        {
            try
            {
               await _jogo.Create(jogo);
                
                return Accepted();


            }catch(InvalidCastException e)
            {
                return BadRequest(e);
            }
        }
        [HttpDelete("{id}")]

        public async Task<ActionResult> DeleteJogo(int id)
        {
           var JogoToDelete = await _jogo.Get(id);

            if (JogoToDelete == null)
            {
                return NotFound();
            }

                try
                {
                    await _jogo.Delete(JogoToDelete.Id);
                    return Accepted();

                }
                catch (InvalidCastException e)
                {
                    return BadRequest(e);
                }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateJogo(int id, [FromBody] Jogo jogo)
        {
            var JogoToUpdate = await _jogo.Get(id);

            if (JogoToUpdate == null)
            {
                return NotFound();
            }

            try
            {
                await _jogo.Update(jogo);

                return Accepted();


            }
            catch (InvalidCastException e)
            {
                return BadRequest(e);
            }
        }

    }
}
