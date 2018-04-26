using System;
using System.Collections.Generic;
using System.Text;

namespace InternetBankingTeamNam.Security
{
    class TechcomBank : BankInterface
    {
        private static Random random = new Random();
        public string BankNumber()
        {
            const string bnRandom = "0123456789";
            var builder = new StringBuilder();

            for (int i = 0; i < 15; i++)
            {
                var character = bnRandom[random.Next(0, bnRandom.Length)];
                builder.Append(character);
            }

            string bankNumber = "TEC" + builder.ToString();
            return bankNumber;
        }

        public string TransactionCode()
        {
            const string tranCodeS = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            const string tranCodeI = "0123456789";

            StringBuilder builder1 = new StringBuilder();
            StringBuilder builder2 = new StringBuilder();

            for (int i = 0; i < 3; i++)
            {
                var character1 = tranCodeS[random.Next(0, tranCodeS.Length)];
                builder1.Append(character1);
                var character2 = tranCodeI[random.Next(0, tranCodeI.Length)];
                builder2.Append(character2);
            }

            string transcode1 = builder1.ToString();

            string transcode2 = builder2.ToString();

            string code = "TEC" + transcode2 + transcode1;

            return code;
        }
    }

    class VietcomBank : BankInterface
    {
        private static Random random = new Random();
        public string BankNumber()
        {
            const string bnRandom = "0123456789";
            var builder = new StringBuilder();

            for (int i = 0; i < 15; i++)
            {
                var character = bnRandom[random.Next(0, bnRandom.Length)];
                builder.Append(character);
            }

            string bankNumber = "VIE" + builder.ToString();
            return bankNumber;
        }

        public string TransactionCode()
        {
            const string tranCodeS = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            const string tranCodeI = "0123456789";

            StringBuilder builder1 = new StringBuilder();
            StringBuilder builder2 = new StringBuilder();

            for (int i = 0; i < 3; i++)
            {
                var character1 = tranCodeS[random.Next(0, tranCodeS.Length)];
                builder1.Append(character1);
                var character2 = tranCodeI[random.Next(0, tranCodeI.Length)];
                builder2.Append(character2);
            }

            string transcode1 = builder1.ToString();

            string transcode2 = builder2.ToString();

            string code = "VIE" + transcode2 + transcode1;

            return code;
        }
    }

    class TPBank : BankInterface
    {
        private static Random random = new Random();
        public string BankNumber()
        {
            const string bnRandom = "0123456789";
            var builder = new StringBuilder();

            for (int i = 0; i < 15; i++)
            {
                var character = bnRandom[random.Next(0, bnRandom.Length)];
                builder.Append(character);
            }

            string bankNumber = "TPB" + builder.ToString();
            return bankNumber;
        }

        public string TransactionCode()
        {
            const string tranCodeS = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            const string tranCodeI = "0123456789";

            StringBuilder builder1 = new StringBuilder();
            StringBuilder builder2 = new StringBuilder();

            for (int i = 0; i < 3; i++)
            {
                var character1 = tranCodeS[random.Next(0, tranCodeS.Length)];
                builder1.Append(character1);
                var character2 = tranCodeI[random.Next(0, tranCodeI.Length)];
                builder2.Append(character2);
            }

            string transcode1 = builder1.ToString();

            string transcode2 = builder2.ToString();

            string code = "TPB" + transcode2 + transcode1;

            return code;
        }
    }

    class MaritimeBank : BankInterface
    {
        private static Random random = new Random();
        public string BankNumber()
        {
            const string bnRandom = "0123456789";
            var builder = new StringBuilder();

            for (int i = 0; i < 15; i++)
            {
                var character = bnRandom[random.Next(0, bnRandom.Length)];
                builder.Append(character);
            }

            string bankNumber = "MRT" + builder.ToString();
            return bankNumber;
        }

        public string TransactionCode()
        {
            const string tranCodeS = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            const string tranCodeI = "0123456789";

            StringBuilder builder1 = new StringBuilder();
            StringBuilder builder2 = new StringBuilder();

            for (int i = 0; i < 3; i++)
            {
                var character1 = tranCodeS[random.Next(0, tranCodeS.Length)];
                builder1.Append(character1);
                var character2 = tranCodeI[random.Next(0, tranCodeI.Length)];
                builder2.Append(character2);
            }

            string transcode1 = builder1.ToString();

            string transcode2 = builder2.ToString();

            string code = "MRT" + transcode2 + transcode1;

            return code;
        }
    }
}
