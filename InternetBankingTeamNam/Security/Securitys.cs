using System;
using System.Collections.Generic;
using System.Text;

namespace InternetBankingTeamNam.Security
{
    class Securitys
    {
        private static Random random = new Random();
        public static String MD5Crypto(string input)
        {
            StringBuilder builder = new StringBuilder();
            string dataEncrypt = "";

            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] data = md5.ComputeHash(new UTF8Encoding().GetBytes(input));

                for (int i = 0; i < data.Length; i++)
                {
                    builder.Append(data[i].ToString("x2"));
                }

                dataEncrypt = builder.ToString();
            }

            return dataEncrypt;
        }

        public static String Salt()
        {
            string salt = "";
            StringBuilder builder = new StringBuilder();

            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                byte[] data = new byte[10];

                for (int i = 0; i < 6; i++)
                {
                    rng.GetBytes(data);
                    char character = (char)data[0];
                    builder.Append(character);
                }

                salt = builder.ToString();
            }

            return salt;
        }

        public static String VerificationCode()
        {
            string verifiCode1 = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string verifiCode2 = "0123456789";
            StringBuilder builder1 = new StringBuilder();
            StringBuilder builder2 = new StringBuilder();

            for (int i = 0; i < 3; i++)
            {
                var character = verifiCode1[random.Next(0, verifiCode1.Length)];
                builder1.Append(character);

                var character2 = verifiCode2[random.Next(0, verifiCode2.Length)];
                builder2.Append(character2);
            }

            string code1 = builder1.ToString();
            string code2 = builder2.ToString();

            string verifiCode = code1 + code2;

            return verifiCode;
        }

        public static string BankNumber()
        {
            const string bnRandom = "0123456789";
            var builder = new StringBuilder();

            for (int i = 0; i < 15; i++)
            {
                var character = bnRandom[random.Next(0, bnRandom.Length)];
                builder.Append(character);
            }

            string bankNumber = builder.ToString();
            return bankNumber;
        }
        public static string Suggestions1(string inputU)
        {
            const string sugRandom = "0123456789";
            var builder = new StringBuilder();
            for (int i = 0; i < 3; i++)
            {
                var character = sugRandom[random.Next(0, sugRandom.Length)];
                builder.Append(character);
            }

            string after = builder.ToString();
            string userSugg = inputU + after;
            return userSugg;
        }

        public static string Suggestions2(string inputU)
        {
            const string sugRandom = "0123456789";
            var builder = new StringBuilder();
            for (int i = 0; i < 2; i++)
            {
                var character = sugRandom[random.Next(0, sugRandom.Length)];
                builder.Append(character);
            }

            string after = builder.ToString();
            string userSugg = inputU + after;
            return userSugg;
        }

        public static string TransactionCode(string bankCode)
        {
            string transactionCode = "";
            switch (bankCode)
            {
                case "TEC":
                    TechcomBank tec = new TechcomBank();
                    transactionCode = tec.TransactionCode();
                    break;
                case "VIE":
                    VietcomBank vie = new VietcomBank();
                    transactionCode = vie.TransactionCode();
                    break;
                case "TPB":
                    TPBank tpb = new TPBank();
                    transactionCode = tpb.TransactionCode();
                    break;
                case "MRT":
                    MaritimeBank mrt = new MaritimeBank();
                    transactionCode = mrt.TransactionCode();
                    break;
            }
            return transactionCode;
        }
    }
}
