using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;//add

namespace Lab1_ConnectedMode.VALIDATION
{
    public static class Validator
    {
        public static bool IsValid(string id, int size)
        {
            /// if (!Regex.IsMatch(id,@"^\d{7}$"))
            if (!Regex.IsMatch(id, @"^\d{" + size +"}$"))
            {
                return false;
            }

            return true;
        }

        public static bool IsValidName(string name)
        {
            if (name.Length==0)
            {
                return false;
            }
            else
            {
                //for (int i = 0; i < name.Length; i++)
                //{
                //    if ((!Char.IsLetter(name[i])) && (!Char.IsWhithSpace(name[i])))
                //    { return false; }

                //}
            }
            return true;
        }
    }
}
