using System;
using System.Collections.Generic;
using System.Text;

namespace InternetBankingTeamNam.Entity
{
    class ValidEntity
    {
        private bool check;
        private string error;

        public ValidEntity(bool check, string error)
        {
            this.check = check;
            this.error = error;
        }

        public bool Check { get => check; set => check = value; }
        public string Error { get => error; set => error = value; }
    }
}
