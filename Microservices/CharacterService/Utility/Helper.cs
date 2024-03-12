using Microsoft.IdentityModel.Protocols;

namespace CharacterService.Utility
{
    public static class Helper
    {
        public static object? CreateObjectFromEnum<T>(T enumType)
        {
            if (enumType == null)
                throw new ArgumentNullException(nameof(enumType));

            var classType = GetCorrespondingClassType(enumType.GetType()) 
                ?? throw new ArgumentException("Invalid enum type or cannot find corresponding class", nameof(enumType));
            return Activator.CreateInstance(classType);
        }

        private static Type? GetCorrespondingClassType(Type enumType)
        {
            var baseName = enumType.Name.Replace("Enum", "");

            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                var classType = assembly.GetType(baseName);
                if (classType != null)
                    return classType;
            }
            throw new ArgumentException("Invalid enum type or cannot find corresponding class", nameof(enumType));
        }
    }
}
