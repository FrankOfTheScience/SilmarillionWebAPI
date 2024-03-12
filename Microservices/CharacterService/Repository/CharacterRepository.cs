using CharacterService.EF;
using CharacterService.EF.Models;
using CharacterService.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CharacterService.Repository
{
    public class CharacterRepository : ICharacterRepository
    {
        private readonly CharactersDbContext _dbContext;
        public CharacterRepository(CharactersDbContext dbContext)
            => this._dbContext = dbContext;

        public async Task<bool> CreateNewCharacterAsync(CharacterViewModel viewModelCharacter)
        {
            try
            {
                if (viewModelCharacter is null)
                    return false;

                var characterClass = _dbContext.CharactersClass.FirstOrDefault(x => x.ClassName.Equals(viewModelCharacter.CharacterClass));
                var characterRace = _dbContext.CharacterRace.FirstOrDefault(x => x.RaceName.Equals(viewModelCharacter.CharacterRace));
                if (characterClass == null || characterRace == null)
                {
                    Random random = new Random();
                    characterClass = _dbContext.CharactersClass.Find(random.Next(1, 5));
                    characterRace = _dbContext.CharacterRace.Find(random.Next(1, 5));
                }

                var character = new Character(
                   viewModelCharacter.Name,
                   viewModelCharacter.Alignment,
                   characterClass!,
                   characterRace!,
                   viewModelCharacter.Health,
                   viewModelCharacter.Equipment,
                   viewModelCharacter.Strength,
                   viewModelCharacter.Intelligence,
                   viewModelCharacter.Dexterity,
                   viewModelCharacter.Constitution,
                   viewModelCharacter.Charisma,
                   viewModelCharacter.Wisdom,
                   viewModelCharacter.Abilities.ToList());

                await this._dbContext.Characters.AddAsync(character);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                // TODO: Implement error management
                throw;
            }
        }

        public async Task<bool> DeleteCharacterByIdAsync(int id)
        {
            try
            {
                if (id <= 0)
                    return false;
                
                var character = await this._dbContext.Characters.FindAsync(id);
                if (character == null)
                    return false;
                this._dbContext.Remove(character);
                
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                // TODO: Implement error management
                throw;
            }
        }

        public async Task<bool> DeleteCharacterByNameAsync(string name)
        {
            try
            {
                if (string.IsNullOrEmpty(name))
                    return false;

                var character = await _dbContext.Characters.Where(x => x.Name == name).FirstOrDefaultAsync();
                if (character == null)
                    return false;
                this._dbContext.Remove<Character>(character);

                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                // TODO: Implement error management
                throw;
            }
        }

        public async Task<CharacterViewModel?> GetCharacterByIdAsync(int id)
        {
            try
            {
                var retrievedCharacter = await _dbContext.Characters.FindAsync(id);
                if (retrievedCharacter == null)
                    return null;

                return new CharacterViewModel
                {
                    Name = retrievedCharacter.Name,
                    Alignment = retrievedCharacter.Alignment,
                    Abilities = retrievedCharacter.Abilities,
                    CharacterClass = retrievedCharacter.CharacterClass.ClassName,
                    CharacterRace = retrievedCharacter.CharacterRace.RaceName,
                    Charisma = retrievedCharacter.Charisma,
                    Constitution = retrievedCharacter.Constitution,
                    Dexterity = retrievedCharacter.Dexterity,
                    Equipment = retrievedCharacter.Equipment,
                    Intelligence = retrievedCharacter.Intelligence,
                    Strength = retrievedCharacter.Strength,
                    Wisdom = retrievedCharacter.Wisdom,
                };
            }
            catch (Exception)
            {
                // TODO: Implement error management
                throw;
            }
        }

        public async Task<CharacterViewModel?> GetCharacterByNameAsync(string name)
        {
            try
            {
                if (string.IsNullOrEmpty(name))
                    return null;

                var retrievedCharacter = await _dbContext.Characters.FirstOrDefaultAsync(x => x.Name == name);
                if (retrievedCharacter == null)
                    return null;

                return new CharacterViewModel
                {
                    Name = retrievedCharacter.Name,
                    Alignment = retrievedCharacter.Alignment,
                    Abilities = retrievedCharacter.Abilities,
                    CharacterClass = retrievedCharacter.CharacterClass.ClassName,
                    CharacterRace = retrievedCharacter.CharacterRace.RaceName,
                    Charisma = retrievedCharacter.Charisma,
                    Constitution = retrievedCharacter.Constitution,
                    Dexterity = retrievedCharacter.Dexterity,
                    Equipment = retrievedCharacter.Equipment,
                    Intelligence = retrievedCharacter.Intelligence,
                    Strength = retrievedCharacter.Strength,
                    Wisdom = retrievedCharacter.Wisdom
                };
            }
            catch (Exception)
            {
                // TODO: Implement error management
                throw;
            }
        }

        public async Task<IEnumerable<CharacterViewModel>> GetCharactersAsync()
        {
            try
            {
                var retrievedCharacters = await _dbContext.Characters.ToListAsync();
                if (retrievedCharacters.Count == 0)
                    return Enumerable.Empty<CharacterViewModel>();

                var characters = new List<CharacterViewModel>();
                retrievedCharacters.ForEach(x => characters.Add(new CharacterViewModel {
                    Name = x.Name,
                    Alignment = x.Alignment,
                    Abilities = x.Abilities,
                    CharacterClass = x.CharacterClass.ClassName,
                    CharacterRace = x.CharacterRace.RaceName,
                    Charisma = x.Charisma,
                    Constitution = x.Constitution,
                    Dexterity = x.Dexterity,
                    Equipment = x.Equipment,
                    Intelligence = x.Intelligence,
                    Strength = x.Strength,
                    Wisdom = x.Wisdom
                }));
                return characters;
            }
            catch (Exception)
            {
                // TODO: Implement error management
                throw;
            }
        }

        public async Task<bool> UpdateCharacterAsync(CharacterViewModel viewModelCharacter)
        {
            try
            {
                if (viewModelCharacter == null)
                    return false;

                var characterClass = _dbContext.CharactersClass.FirstOrDefault(x => x.ClassName.Equals(viewModelCharacter.CharacterClass));
                var characterRace = _dbContext.CharacterRace.FirstOrDefault(x => x.RaceName.Equals(viewModelCharacter.CharacterRace));
                if (characterClass == null || characterRace == null)
                {
                    Random random = new Random();
                    characterClass = _dbContext.CharactersClass.Find(random.Next(1, 5));
                    characterRace = _dbContext.CharacterRace.Find(random.Next(1, 5));
                }

                var character = new Character(
                    viewModelCharacter.Name,
                    viewModelCharacter.Alignment,
                    characterClass!,
                    characterRace!,
                    viewModelCharacter.Health,
                    viewModelCharacter.Equipment,
                    viewModelCharacter.Strength,
                    viewModelCharacter.Intelligence,
                    viewModelCharacter.Dexterity,
                    viewModelCharacter.Constitution,
                    viewModelCharacter.Charisma,
                    viewModelCharacter.Wisdom,
                    viewModelCharacter.Abilities.ToList());

                _dbContext.Update(character);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                // TODO: Implement error management
                throw;
            }
        }
    }
}
