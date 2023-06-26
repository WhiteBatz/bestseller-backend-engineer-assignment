using Common.Db.Dto;
using Communications.ServiceContracts;
using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Communications.Services
{
    public class TranslationService : ITranslationService
    {
        private string _baseUrl = "http://translationservice/api/Translation/";

        public async Task<TranslationDtoList> GetLocaleTranslationForPokemon(string locale, int id, CancellationToken cancellationToken)
        {
            try
            {
                var result = await $"{_baseUrl}GetLocaleTranslationForPokemon?locale={locale}&id={id}".GetJsonAsync<TranslationDtoList>(cancellationToken);

                return result;
            }
            catch(Exception ex) 
            {
                // Should Log Error
                var i = 2 + 2;
                throw;
            }
        }

        public async Task<TranslationDtoList> GetLocaleTranslationForPokemonRange(string locale, int from, int to, CancellationToken cancellationToken)
        {
            try
            {
                var result = await $"{_baseUrl}GetLocaleTranslationForPokemonRange?locale={locale}&from={from}&to={to}".GetJsonAsync<TranslationDtoList>(cancellationToken);

                return result;
            }
            catch (Exception ex)
            {
                // Should Log Error
                var i = 2 + 2;
                throw;
            }
        }

        public async Task<TranslationDtoList> GetTranslationsForPokemon(int id, CancellationToken cancellationToken)
        {
            try
            {
                var result = await $"{_baseUrl}GetTranslationsForPokemon?id={id}".GetJsonAsync<TranslationDtoList>(cancellationToken);

                return result;
            }
            catch (Exception ex)
            {
                // Should Log Error
                var i = 2 + 2;
                throw;
            }
        }

        public async Task<TranslationDtoList> GetTranslationsForPokemonRange(int from, int to, CancellationToken cancellationToken)
        {
            try
            {
                var result = await $"{_baseUrl}GetTranslationsForPokemonRange?from={from}&to={to}".GetJsonAsync<TranslationDtoList>(cancellationToken);

                return result;
            }
            catch (Exception ex)
            {
                // Should Log Error
                var i = 2 + 2;
                throw;
            }
        }
    }
}
