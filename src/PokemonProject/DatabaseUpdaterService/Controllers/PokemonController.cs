using Common.Db.Dto;
using Communications.Dto;
using DatabaseUpdaterService.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseUpdaterService.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class PokemonController : ControllerBase
    {
        private readonly ILogger<PokemonController> _logger;
        private readonly IPokemonHandler _pokemonHandler;

        public PokemonController(ILogger<PokemonController> logger, IPokemonHandler pokemonHandler)
        {
            _logger = logger;
            _pokemonHandler = pokemonHandler;
        }
        
        [HttpPut]
        public async Task<IActionResult> AddPokemon([FromBody] PokemonDto dto)
        {
            await _pokemonHandler.AddPokemon(dto, HttpContext.RequestAborted);
            return Ok();
        }


        [HttpPost]
        public async Task<IActionResult> EditPokemon([FromBody] PokemonDto dto)
        {
            await _pokemonHandler.EditPokemon(dto, HttpContext.RequestAborted);
            return Ok();
        }


        [HttpPost]
        public async Task<IActionResult> DeletePokemons([FromBody] IdList ids)
        {
            await _pokemonHandler.DeletePokemons(ids, HttpContext.RequestAborted);
            return Ok();
        }
    }
}
