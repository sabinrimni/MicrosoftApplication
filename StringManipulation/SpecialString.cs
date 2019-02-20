using System;

namespace StringManipulation
{
    public class SpecialString
    {
        private readonly char[] _sString;

        public SpecialString(string s)
        {
            if (ReferenceEquals(s, null)) throw new ArgumentNullException();
            _sString = s.ToCharArray();
        }

        public static implicit operator SpecialString(string s) => new SpecialString(s);

        public static SpecialString operator <<(SpecialString s, int steps)
        {
            if (ReferenceEquals(s, null) || s._sString.Length < steps) throw new InvalidOperationException();
            if (steps <= 0) return s;

            for (var i = 0; i < steps; i++)
            {
                var tempChar = s._sString[s._sString.Length - 1];

                for (var j = s._sString.Length - 1; j > 0; j--)
                {
                    s._sString[j] = s._sString[j - 1];
                }

                s._sString[0] = tempChar;
            }

            return s;
        }

        public static SpecialString operator >>(SpecialString s, int steps)
        {
            if (ReferenceEquals(s, null) || s._sString.Length < steps) throw new InvalidOperationException();
            if (steps <= 0) return s;

            for (var i = 0; i < steps; i++)
            {
                var tempChar = s._sString[0];

                for (var j = 0; j < s._sString.Length - 1; j++)
                {
                    s._sString[j] = s._sString[j + 1];
                }

                s._sString[s._sString.Length - 1] = tempChar;
            }

            return s;
        }

        public static bool operator ==(SpecialString s1, SpecialString s2)
        {
            if (ReferenceEquals(s1, null) || ReferenceEquals(s2, null)) throw new InvalidOperationException();
            if (s1._sString.Length != s2._sString.Length) return false;

            var result = true;
            for (var i = 0; i <= s1._sString.Length - 1; i++)
            {
                if (s1._sString[i] == s2._sString[i]) continue;

                result = false;
                break;
            }

            return result;
        }

        public static bool operator !=(SpecialString s1, SpecialString s2)
        {
            return !(s1 == s2);
        }

        public override string ToString()
        {
            return new string(_sString);
        }
    }
}
