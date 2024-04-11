using CharacterService.ViewModels;
using CharacterService.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Microsoft.AspNetCore.Authorization;

namespace CharacterService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharactersController : ControllerBase
    {
        private readonly ICharacterRepository _characterRepository;
        public CharactersController(ICharacterRepository characterRepository)
            => _characterRepository = characterRepository;

        [HttpGet]
        [Authorize]
        public async Task<IEnumerable<CharacterViewModel>> GetCharactersAsync()
            => await this._characterRepository.GetCharactersAsync();

        [HttpGet("characterId:int")]
        [Authorize]
        public async Task<ActionResult<CharacterViewModel>> GetCharacterByIdAsync(int characterId)
        {
            var character = await this._characterRepository.GetCharacterByIdAsync(characterId);
            if (character is null)
                return NotFound();
            return Ok(character);
        }

        [HttpGet("characterName:string")]
        [Authorize]
        public async Task<ActionResult<CharacterViewModel>> GetCharacterByNameAsync(string characterName)
        {
            if (string.IsNullOrWhiteSpace(characterName))
                return BadRequest();
            var character = await this._characterRepository.GetCharacterByNameAsync(characterName);
            if (character is null)
                return NotFound();
            return Ok(character);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator,User")]
        public async Task<ActionResult<HttpStatusCode>> CreateNewCharacterAsync(CharacterViewModel newCharacter)
        {
            if (newCharacter is null)
                return BadRequest();
            await this._characterRepository.CreateNewCharacterAsync(newCharacter);
            return HttpStatusCode.Created;
        }

        [HttpPut]
        [Authorize(Roles = "Administrator,User")]
        public async Task<ActionResult<HttpStatusCode>> UpdateCharacterAsync(CharacterViewModel updatedCharacter)
        {
            if (updatedCharacter is null)
                return BadRequest();
            if (!await this._characterRepository.UpdateCharacterAsync(updatedCharacter))
                return HttpStatusCode.InternalServerError;
            return HttpStatusCode.Created;
        }

        [HttpDelete("characterId:int")]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult<HttpStatusCode>> DeleteCharacterByIdAsync(int characterId)
        {
            if (characterId <= 0)
                return BadRequest();
            if (!await this._characterRepository.DeleteCharacterByIdAsync(characterId))
                return NotFound();
            return Ok();
        }

        [HttpDelete("characterName:string")]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult<HttpStatusCode>> DeleteCharacterByIdAsync(string characterName)
        {
            if (string.IsNullOrEmpty(characterName))
                return BadRequest();
            if (!await this._characterRepository.DeleteCharacterByNameAsync(characterName))
                return NotFound();
            return Ok();
        }
    }
}