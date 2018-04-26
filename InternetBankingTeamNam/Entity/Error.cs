using System;
using System.Collections.Generic;
using System.Text;

namespace InternetBankingTeamNam.Entity
{
    class Error
    {
        private string errorEmpty;
        private string errorLength;
        private string errorCharacter;

        public Error()
        {
        }

        public Error(string errorEmpty, string errorLength, string errorCharacter)
        {
            this.errorEmpty = errorEmpty;
            this.errorLength = errorLength;
            this.errorCharacter = errorCharacter;
        }

        public string ErrorEmpty { get => errorEmpty; set => errorEmpty = value; }
        public string ErrorLength { get => errorLength; set => errorLength = value; }
        public string ErrorCharacter { get => errorCharacter; set => errorCharacter = value; }
    }
}
