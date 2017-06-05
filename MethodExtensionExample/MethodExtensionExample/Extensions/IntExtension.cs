using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodExtensionExample.Extensions
{
    public static class IntExtension
    {
        public static bool IsGreaterThan(this int number, int a)
        {
            return number > a;
        }

        public static bool IsBetween(this int number, int a, int b)
        {
            return a <= number && number <= b;
        } 
    }
}
