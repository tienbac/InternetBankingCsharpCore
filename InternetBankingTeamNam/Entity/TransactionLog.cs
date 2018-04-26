using System;
using System.Collections.Generic;
using System.Text;

namespace InternetBankingTeamNam.Entity
{
    class TransactionLog
    {
        private string transactionCode;
        private string transactionTitle;
        private string bankNumber;
        private long money;
        private long transactionDate;
        private string receiveBankNumber;
        private string transactionNote;

        public TransactionLog()
        {
        }

        public TransactionLog(string transactionCode, string transactionTitle, string bankNumber, long money, long transactionDate, string receiveBankNumber, string transactionNote)
        {
            this.transactionCode = transactionCode;
            this.transactionTitle = transactionTitle;
            this.bankNumber = bankNumber;
            this.money = money;
            this.transactionDate = transactionDate;
            this.receiveBankNumber = receiveBankNumber;
            this.transactionNote = transactionNote;
        }

        public TransactionLog(string transactionCode, string transactionTitle, string bankNumber, long money, long transactionDate)
        {
            this.transactionCode = transactionCode;
            this.transactionTitle = transactionTitle;
            this.bankNumber = bankNumber;
            this.money = money;
            this.transactionDate = transactionDate;
        }

        public string TransactionCode { get => transactionCode; set => transactionCode = value; }
        public string TransactionTitle { get => transactionTitle; set => transactionTitle = value; }
        public string BankNumber { get => bankNumber; set => bankNumber = value; }
        public long Money { get => money; set => money = value; }
        public long TransactionDate { get => transactionDate; set => transactionDate = value; }
        public string ReceiveBankNumber { get => receiveBankNumber; set => receiveBankNumber = value; }
        public string TransactionNote { get => transactionNote; set => transactionNote = value; }
    }
}
