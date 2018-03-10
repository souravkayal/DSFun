using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementationFun
{

    public static class StringExtension
    {

        public static string TO_UPPER(this string Value)
        {
            return Value.ToUpper();
        }

        public static string[] TO_SPLIT(this string Value, Char SplitChar)
        {
            return Value.Split(SplitChar);
        }
    }

    /// <summary>
    /// Original Class with some property
    /// </summary>
    public class OriginalClass
    {
        public string prop1 { get; set; }
    }

    /// <summary>
    /// Extended function of Original Class.
    /// </summary>
    public static class ExtendedOriginal
    {

        public static OriginalClass ExtendedFunction(this OriginalClass Original)
        {
            return Original;
        }
    }

}
