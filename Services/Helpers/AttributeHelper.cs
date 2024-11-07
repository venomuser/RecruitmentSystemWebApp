using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Services.Helpers
{
    public static class AttributeHelper
    {
        /// <summary>
        /// If <paramref name="Enum"/> has <see cref="DisplayAttribute"/> defined, this will return <see cref="DisplayAttribute.Name"/>. Otherwise, <see langword="null" /> will be returned.
        /// </summary>
        /// <returns><see cref="string"/> containing <see cref="DisplayAttribute.Name"/> if defined. Otherwise, will return <see langword="null" /></returns>
        public static string GetDisplayName<T>(this T Enum) where T : System.Enum
            => Enum.GetEnumAttribute<T, DisplayAttribute>()?.Name;
        /// <summary>
        /// If <paramref name="Enum"/> has <see cref="DisplayAttribute"/> defined, this will return <see cref="DisplayAttribute.Description"/>. Otherwise, <see langword="null" /> will be returned.
        /// </summary>
        /// <returns><see cref="string"/> containing <see cref="DisplayAttribute.Description"/> if defined. Otherwise, will return <see langword="null" /></returns>
        public static string GetDescription<T>(this T Enum) where T : System.Enum
            => Enum.GetEnumAttribute<T, DisplayAttribute>()?.Description;
        /// <summary>
        /// Returns <see cref="DisplayAttribute"/> from <paramref name="Enum"/> if defined. Otherwise will return <see langword="null" />.
        /// </summary>
        public static DisplayAttribute GetDisplayAttribute<T>(this T Enum) where T : System.Enum
            => Enum.GetEnumAttribute<T, DisplayAttribute>();
        public static TAttribute GetEnumAttribute<TEnum, TAttribute>(this TEnum Enum)
            where TEnum : System.Enum
            where TAttribute : System.Attribute
        {
            var MemberInfo = typeof(TEnum).GetMember(Enum.ToString());
            return MemberInfo[0].GetCustomAttribute<TAttribute>();
        }

        public static TEnum GetEnumValueFromDisplayName<TEnum>(string displayName) where TEnum : System.Enum
        {
            foreach (var enumValue in Enum.GetValues(typeof(TEnum)))
            {
                // Cast enumValue to TEnum and then to Enum to use GetEnumAttribute extension method
                var displayAttribute = ((TEnum)enumValue).GetEnumAttribute<TEnum, DisplayAttribute>();
                if (displayAttribute?.Name == displayName)
                {
                    return (TEnum)enumValue;
                }
            }
            //throw new ArgumentException($"No {typeof(TEnum).Name} with Display Name '{displayName}' found.");
            TEnum en = (TEnum)Enum.Parse(typeof(TEnum), displayName,true);
            return en;
        }


    }
}