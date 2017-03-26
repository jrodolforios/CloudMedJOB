using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace MediCloud.BusinessProcess.Util
{
    public class SearchUtil
    {
        public static bool CheckAllFields<T>(T x,string termo)
        {
            var result = searchAllFields(x.GetType()).ToList();
            bool encontrou = false;
            result.ForEach(y =>
            {
                var value = y.GetValue(x);

                if (value.ToString().Contains(termo))
                    encontrou = true;
            });

            return encontrou;
        }

        public static IEnumerable<PropertyInfo> searchAllFields(Type t)
        {
            var visitedTypes = new HashSet<Type>();
            var result = new List<PropertyInfo>();
            InternalVisit(t, visitedTypes, result);
            return result;
        }

        private static void InternalVisit(Type t, HashSet<Type> visitedTypes, IList<PropertyInfo> result)
        {
            if (visitedTypes.Contains(t))
            {
                return;
            }

            if (!IsPrimitive(t))
            {
                visitedTypes.Add(t);
                foreach (var property in t.GetProperties())
                {
                    if (IsPrimitive(property.PropertyType))
                    {
                        result.Add(property);
                    }
                    InternalVisit(property.PropertyType, visitedTypes, result);
                }
            }
        }

        private static bool IsPrimitive(Type t)
        {
            // TODO: put any type here that you consider as primitive as I didn't
            // quite understand what your definition of primitive type is
            return new[] {
            typeof(string),
            typeof(char),
            typeof(byte),
            typeof(sbyte),
            typeof(ushort),
            typeof(short),
            typeof(uint),
            typeof(int),
            typeof(ulong),
            typeof(long),
            typeof(float),
            typeof(double),
            typeof(decimal),
            typeof(DateTime),
        }.Contains(t);
        }
    }
}