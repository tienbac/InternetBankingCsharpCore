using System;
using System.Collections.Generic;
using System.Text;

namespace InternetBankingTeamNam.Security
{
    public enum PasswordScore
    {
        Blank = 0,
        VeryWeak = 1,
        Weak = 2,
        Medium = 3,
        Strong = 4,
        VeryStrong = 5,
    }
    class CheckPasswordScore
    {
        public static PasswordScore CheckStrength(string inputPass)
        {
            int score = 0;
            if (inputPass.Length < 1)
            {
                return PasswordScore.Blank;
            }
            if (inputPass.Length < 6)
            {
                return PasswordScore.VeryWeak;
            }
            if (inputPass.Length >= 6)
            {
                score++;
            }
            if (inputPass.Length >= 10)
            {
                score++;
            }
            if (Regex.Match(inputPass, @"[0-9]", RegexOptions.ECMAScript).Success)
            {
                score++;
            }
            if (Regex.Match(inputPass, @"[a-z]", RegexOptions.ECMAScript).Success ||
                Regex.Match(inputPass, @"[A-Z]", RegexOptions.ECMAScript).Success)
            {
                score++;
            }
            if (Regex.Match(inputPass, @"[!@#$%^&*()_+=\[{\]};:<>|./?,-]", RegexOptions.ECMAScript).Success)
            {
                score++;
            }
            return (PasswordScore)score;
        }
    }
}
