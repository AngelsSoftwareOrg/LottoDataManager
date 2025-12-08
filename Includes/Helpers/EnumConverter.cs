using System;

namespace LottoDataManager.Includes.Helpers
{
    /// <summary>
    /// Universal enum conversion helpers.
    /// Usage:
    ///   var gm = EnumConverter.ToEnum<GameMode>(value, GameMode.UNKNOWN);
    ///   if (EnumConverter.TryToEnum<GameMode>(value, out var gm)) { ... }
    /// </summary>
    public static class EnumConverter
    {
        /// <summary>
        /// Convert an arbitrary value to the requested enum type.
        /// Returns <paramref name="defaultValue"/> on null or conversion failure.
        /// Accepts enum instances, names (case-insensitive), numeric string, and numeric types.
        /// </summary>
        public static TEnum ToEnum<TEnum>(object value, TEnum defaultValue = default)
            where TEnum : struct, Enum
        {
            if (value == null)
                return defaultValue;

            // Already the right enum
            if (value is TEnum enumValue)
                return enumValue;

            // Strings: try parse by name or numeric text
            if (value is string s)
            {
                if (Enum.TryParse<TEnum>(s, true, out var parsed))
                    return parsed;

                // If it's numeric-like but Enum.TryParse failed (very unlikely), fall through to numeric conversion.
            }

            try
            {
                // Convert numeric types to enum's underlying type, then to enum
                var underlyingType = Enum.GetUnderlyingType(typeof(TEnum));
                var converted = Convert.ChangeType(value, underlyingType);
                var enumObj = Enum.ToObject(typeof(TEnum), converted);

                // Return the casted enum (defined or not). Caller may check Enum.IsDefined if needed.
                return (TEnum)enumObj;
            }
            catch
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// Try-convert an arbitrary value to the requested enum type.
        /// Returns true on success and sets <paramref name="result"/>.
        /// </summary>
        public static bool TryToEnum<TEnum>(object value, out TEnum result)
            where TEnum : struct, Enum
        {
            result = default;

            if (value == null)
                return false;

            if (value is TEnum enumValue)
            {
                result = enumValue;
                return true;
            }

            if (value is string s)
            {
                if (Enum.TryParse<TEnum>(s, true, out var parsed))
                {
                    result = parsed;
                    return true;
                }
            }

            try
            {
                var underlyingType = Enum.GetUnderlyingType(typeof(TEnum));
                var converted = Convert.ChangeType(value, underlyingType);
                var enumObj = Enum.ToObject(typeof(TEnum), converted);
                result = (TEnum)enumObj;
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Returns true if the provided enum value corresponds to a named constant on the enum type.
        /// </summary>
        public static bool IsDefined<TEnum>(TEnum value)
            where TEnum : struct, Enum
        {
            return Enum.IsDefined(typeof(TEnum), value);
        }
    }
}