using System;
using System.Collections.Generic;
using System.Text;

namespace InternetBankingTeamNam.Entity
{
    class User
    {
        private Account account;
        private AccountInformation information;
        private TransactionLog transaction;

        public User()
        {
        }

        public User(Account account, AccountInformation information, TransactionLog transaction)
        {
            this.account = account;
            this.information = information;
            this.transaction = transaction;
        }

        internal Account Account { get => account; set => account = value; }
        internal AccountInformation Information { get => information; set => information = value; }
        internal TransactionLog Transaction { get => transaction; set => transaction = value; }
    }
}
