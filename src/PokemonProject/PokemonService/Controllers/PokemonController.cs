using Common.Db.Dto;
using Communications.Dto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PokemonService.Business.Interfaces;

namespace PokemonService.Controllers
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

        [HttpGet]
        public async Task<IActionResult> GetAllPokemon()
        {
            var result = await _pokemonHandler.GetAllPokemon(HttpContext.RequestAborted);
            return Ok(JsonConvert.SerializeObject(result));
        }

        [HttpGet]
        public async Task<IActionResult> GetPokemon(int id)
        {
            var result = await _pokemonHandler.GetPokemon(id, HttpContext.RequestAborted);
            return Ok(JsonConvert.SerializeObject(result));
        }

        [HttpGet]
        public async Task<IActionResult> GetPokemonRange(int from, int to)
        {
            var result = await _pokemonHandler.GetPokemonRange(from, to, HttpContext.RequestAborted);
            return Ok(JsonConvert.SerializeObject(result));
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
