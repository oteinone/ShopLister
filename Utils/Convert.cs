using System;
using System.Linq;

namespace ShopLister.Utils
{
    public static class SLConvert
    {
        public static T ListSortToEnum<T>(string value)
        {
            try
             {
                return (T) Enum.Parse(typeof(T), value, true);
             }
             catch (Exception)
             {
                throw new Exception($"'{value}' is not a valid order property. Correct values are {string.Join(",", Enum.GetValues(typeof(T)).Cast<Enum>())}");
             }
        }
    }
}