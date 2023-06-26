using GatewayService.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace GatewayService.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class TranslationController : ControllerBase
    {
        private readonly ILogger<TranslationController> _logger;
        private readonly ITranslationHandler _translationHandler;

        public TranslationController(ILogger<TranslationController> logger, ITranslationHandler translationHandler)
        {
            _logger = logger;
            _translationHandler = translationHandler;
        }

        [HttpGet]
        public async Task<IActionResult> GetTranslationsForPokemon(int id)
        {
            var result = await _translationHandler.GetTranslationsForPokemon(id, HttpContext.RequestAborted);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetTranslationsForPokemonRange(int from, int to)
        {
            var result = await _translationHandler.GetTranslationsForPokemonRange(from, to, HttpContext.RequestAborted);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetLocaleTranslationForPokemon(string locale, int id)
        {
            var result = await _translationHandler.GetLocaleTranslationForPokemon(locale, id, HttpContext.RequestAborted);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetLocaleTranslationForPokemonRange(string locale, int from, int to)
        {
            var result = await _translationHandler.GetLocaleTranslationForPokemonRange(locale, from, to, HttpContext.RequestAborted);
            return Ok(result);
        }
    }
}
