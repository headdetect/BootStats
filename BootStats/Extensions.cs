using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootStats
{
    public static class Extensions
    {

        /// <summary>
        /// Converts an object to a primitive (or any struct that implements IConvertable) 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj">The obj.</param>
        /// <returns></returns>
        public static T AsPrimitive<T>(this object obj) where T : struct, IConvertible
        {
            return (T) Convert.ChangeType(obj, typeof (T));
        }
    }
}
