using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MethodExtensionExample.Extensions
{
    public static class IEnumerableExtension
    {
        public static Dictionary<string, object> ToColumnsArray<T>(this IEnumerable<T> targetObject)
        {
            Dictionary<string, object> col = new Dictionary<string, object>();

            //goes through each property of the class
            foreach (PropertyInfo prop in typeof(T).GetProperties())
            {
                List<object> tempValues = new List<object>();

                //now retrieving every value and adding to the temporary list 
                foreach (var item in targetObject)
                    tempValues.Add(prop.GetValue(item, null));

                //when all values are in the array, convert it to an native array of the type of the property
                //in this case we are only evaluating for int, boolean and string. (The only options for our custom legacy DAL)
                switch (prop.PropertyType.Name.ToLower())
                {
                    case "int32":
                    case "int16":
                        col.Add(prop.Name, tempValues.Select(x => (int)x).ToArray<int>());
                        break;
                    case "boolean":
                        col.Add(prop.Name, tempValues.Select(x => (bool)((bool)x) ? 1 : 0).ToArray<int>());
                        break;

                    //the default case is string
                    case "string":
                    default:
                        col.Add(prop.Name, tempValues.Select(x => x.ToString()).ToArray<string>());
                        break;
                }
            }
            return col;
        }
    }
}
