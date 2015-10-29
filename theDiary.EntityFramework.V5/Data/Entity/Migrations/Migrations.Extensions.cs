using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Model;
using System.Data.Entity.Migrations.Sql;
using System.Data.Entity.Migrations.Utilities;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Data.Entity.Migrations
{
    internal static class EnumerableExtensions
    {
        public static bool ItemsEqual<T>(this IEnumerable<T> items, object other)
        {
            if (other == null) 
                return false;
            
            Debug.Assert(other is IEnumerable<T>, "other must be IEnumerable<T>");
            var others = (IEnumerable<T>)other;
            return items != null 
                && items.Count() == others.Count() 
                && items.All(others.Contains);
        }    }
}
