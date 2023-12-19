using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ThePasswordValidator
{
    internal class PasswordValidator
    {
        public static bool Validate(string password)
        {
            if (password.Length < 6) return false;
            if (password.Length > 13) return false;
            if (!HasUpperCase(password)) return false;
            if (!HasLowerCase(password)) return false;
            if (!HasDigit(password)) return false;
            if (Contains(password, 'T')) return false;
            if (Contains(password, '&')) return false;

            return true;
        }

        private static bool HasUpperCase(string password)
        {
            foreach (char c in password)
                if (char.IsUpper(c)) return true;

            return false;
        }
        private static bool HasLowerCase(string password)
        {
            foreach (char c in password)
                if (char.IsLower(c)) return true;

            return false;
        }
        private static bool HasDigit(string password)
        {
            foreach (char c in password)
                if (char.IsDigit(c)) return true;

            return false;
        }
        private static bool Contains(string password, char letter)
        {
            foreach (char c in password)
                if (c == letter) return true;

            return false;
        }
    }
}
