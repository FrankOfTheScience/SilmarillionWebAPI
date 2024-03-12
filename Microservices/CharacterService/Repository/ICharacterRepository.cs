using CharacterService.EF.Models;
using CharacterService.ViewModels;

namespace CharacterService.Repository
{
    public interface ICharacterRepository
    {
        Task<IEnumerable<CharacterViewModel>> GetCharactersAsync();
        Task<CharacterViewModel?> GetCharacterByIdAsync(int id);
        Task<CharacterViewModel?> GetCharacterByNameAsync(string name);
        Task<bool> CreateNewCharacterAsync(CharacterViewModel character);
        Task<bool> UpdateCharacterAsync(CharacterViewModel character);
        Task<bool> DeleteCharacterByIdAsync(int id);
        Task<bool> DeleteCharacterByNameAsync(string name);
    }
}
