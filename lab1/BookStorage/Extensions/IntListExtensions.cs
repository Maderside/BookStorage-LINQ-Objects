using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStorage.Extensions
{
    public static class IntListExtensions
    {
        public static string ToString(this List<int> list) 
        {
            return string.Join(",", list.Select(n => n.ToString()).ToArray());
        }
    }
}
