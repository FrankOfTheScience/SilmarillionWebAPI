using CharacterService.EF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace CharacterService.EF
{
    public class CharactersDbContext : DbContext
	{
        public DbSet<Character> Characters { get; set; }
		public DbSet<CharacterClass> CharactersClass { get; set; }
        public DbSet<CharacterRace> CharacterRace { get; set; }

        public CharactersDbContext()
		{ }
        public CharactersDbContext(DbContextOptions<CharactersDbContext> dbContextOptions) : base(dbContextOptions)
        {
			try
			{
                var dbCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
				if (dbCreator != null) 
				{
					if (!dbCreator.CanConnect()) dbCreator.Create();
					if (!dbCreator.HasTables()) dbCreator.CreateTables();
				}
			}
			catch (Exception e)
			{
				// TODO : Manage Exception
				throw;
			}
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Character>()
                .Property(c => c.Abilities)
                .HasConversion(
                    value => string.Join(",", value),
                    value => value.Split(',', StringSplitOptions.RemoveEmptyEntries)
                );
            modelBuilder.Entity<CharacterClass>()
               .Property(c => c.CommonAbilities)
               .HasConversion(
                   value => string.Join(",", value),
                   value => value.Split(',', StringSplitOptions.RemoveEmptyEntries)
               );
            modelBuilder.Entity<CharacterRace>()
               .Property(c => c.CommonAbilities)
               .HasConversion(
                   value => string.Join(",", value),
                   value => value.Split(',', StringSplitOptions.RemoveEmptyEntries)
               );

            modelBuilder.Entity<CharacterClass>().HasData(
				new CharacterClass
				{
					Id = 1,
					ClassName = Models.Enums.CharacterClassEnum.Bard,
					CommonAbilities = new List<string> { "Bardic Inspiration", "Bardic Knowledge", "Arcana" },
					StrengthModifier = 0,
					IntelligenceModifier = 0,
					DexterityModifier = 2,
					ConstitutionModifier = 0,
					CharismaModifier = 2,
					WisdomModifier = 0
				},
                new CharacterClass
                {
                    Id = 2,
                    ClassName = Models.Enums.CharacterClassEnum.Druid,
                    CommonAbilities = new List<string> { "Wild", "Spells", "Animal Companion" },
					StrengthModifier = 0,
                    IntelligenceModifier = 2,
                    DexterityModifier = 0,
                    ConstitutionModifier = 0,
                    CharismaModifier = 0,
                    WisdomModifier = 2
                },
                new CharacterClass
                {
                    Id = 3,
                    ClassName = Models.Enums.CharacterClassEnum.Paladine,
                    CommonAbilities = new List<string> { "Devotion Aurea", "Smite", "Arcana" },
                    StrengthModifier = 2,
                    IntelligenceModifier = 0,
                    DexterityModifier = 0,
                    ConstitutionModifier = 0,
                    CharismaModifier = 2,
                    WisdomModifier = 0
                },
                new CharacterClass
                {
                    Id = 4,
                    ClassName = Models.Enums.CharacterClassEnum.Ranger,
                    CommonAbilities = new List<string> { "Favored Enemy", "Favored Terrain", "Follow Traces" },
                    StrengthModifier = 0,
                    IntelligenceModifier = 0,
                    DexterityModifier = 2,
                    ConstitutionModifier = 0,
                    CharismaModifier = 0,
                    WisdomModifier = 2
                },
                new CharacterClass
                {
                    Id = 5,
                    ClassName = Models.Enums.CharacterClassEnum.Thief,
                    CommonAbilities = new List<string> { "Sneak Attack", "Thieving Skills", "Reflexes Talents" },
                    StrengthModifier = 0,
                    IntelligenceModifier = 2,
                    DexterityModifier = 2,
                    ConstitutionModifier = 0,
                    CharismaModifier = 0,
                    WisdomModifier = 0
                },
                new CharacterClass
                {
                    Id = 6,
                    ClassName = Models.Enums.CharacterClassEnum.Warrior,
                    CommonAbilities = new List<string> { "Combat Style", "Basic Attack Bonus", "Fighting Manouvers" },
                    StrengthModifier = 2,
                    IntelligenceModifier = 0,
                    DexterityModifier = 0,
                    ConstitutionModifier = 2,
                    CharismaModifier = 0,
                    WisdomModifier = 0
                }
            );
            modelBuilder.Entity<CharacterRace>().HasData(
                new CharacterRace
                {
                    Id = 1,
                    RaceName = Models.Enums.CharacterRaceEnum.Dwarf,
                    CommonAbilities = new List<string> { "Darkvision", "Robust Resilience", "Familiarity with Tools" },
                    StrengthModifier = 0,
                    IntelligenceModifier = 0,
                    DexterityModifier = 0,
                    ConstitutionModifier = 2,
                    CharismaModifier = -2,
                    WisdomModifier = 1
                },
                new CharacterRace
                {
                    Id = 2,
                    RaceName = Models.Enums.CharacterRaceEnum.Elf,
                    CommonAbilities = new List<string> { "Darkvision", "Keen Senses", "Trance" },
                    StrengthModifier = 0,
                    IntelligenceModifier = 1,
                    DexterityModifier = 2,
                    ConstitutionModifier = 0,
                    CharismaModifier = 0,
                    WisdomModifier = 0
                },
                new CharacterRace
                {
                    Id = 3,
                    RaceName = Models.Enums.CharacterRaceEnum.Hobbit,
                    CommonAbilities = new List<string> { "Luck", "Hiding Naturally", "Quick" },
                    StrengthModifier = -2,
                    IntelligenceModifier = 0,
                    DexterityModifier = 2,
                    ConstitutionModifier = 0,
                    CharismaModifier = 0,
                    WisdomModifier = 0
                },
                new CharacterRace
                {
                    Id = 4,
                    RaceName = Models.Enums.CharacterRaceEnum.Human,
                    CommonAbilities = new List<string> { "Versatile Talent", "Weapons Training", "Polyglot" },
                    StrengthModifier = 0,
                    IntelligenceModifier = 0,
                    DexterityModifier = 0,
                    ConstitutionModifier = 0,
                    CharismaModifier = 0,
                    WisdomModifier = 0
                },
                new CharacterRace
                {
                    Id = 5,
                    RaceName = Models.Enums.CharacterRaceEnum.Orc,
                    CommonAbilities = new List<string> { "Darkvision", "Robust Resilience", "Fury" },
                    StrengthModifier = 2,
                    IntelligenceModifier = -2,
                    DexterityModifier = 2,
                    ConstitutionModifier = 1,
                    CharismaModifier = 0,
                    WisdomModifier = 0
                },
                new CharacterRace
                {
                    Id = 6,
                    RaceName = Models.Enums.CharacterRaceEnum.Wizard,
                    CommonAbilities = new List<string> { "Spell Caster", "Invoked Arcana", "Score Boost" },
                    StrengthModifier = -2,
                    IntelligenceModifier = 0,
                    DexterityModifier = 0,
                    ConstitutionModifier = 0,
                    CharismaModifier = 2,
                    WisdomModifier = 0
                }
            );
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			var configurations = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json")
				.Build();

			var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
			var dbName = Environment.GetEnvironmentVariable("DB_NAME");
            var dbUser = Environment.GetEnvironmentVariable("DB_USER");
            var dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD");
            var connectionString = string.Format(configurations.GetConnectionString("CharactersDbContext"), dbHost, dbName, dbUser, dbPassword);

			optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
