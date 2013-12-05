using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandboxConsole.Logic
{
    static class StringHelper
    {
        internal static string ReverseString(string inString)
        {
            char[] chars = inString.ToCharArray();
            Array.Reverse(chars);
            return String.Join("", chars);
        }
    }
}
