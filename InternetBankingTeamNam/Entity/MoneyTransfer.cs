using System;
using System.Collections.Generic;
using System.Text;

namespace InternetBankingTeamNam.Entity
{
    class MoneyTransfer
    {
        private string transCodeSend;
        private string transCodeRece;
        private string titleSend;
        private string titleRece;
        private string bankNumSend;
        private string bankNumRece;
        private long money;
        private long balenSend;
        private long balenRece;
        private long date;
        private string note;
        private int idSend;
        private int idRece;

        public MoneyTransfer()
        {
        }

        public MoneyTransfer(string transCodeSend, string transCodeRece, string titleSend, string titleRece, string bankNumSend, string bankNumRece, long money, long balenSend, long balenRece, long date, string note, int idSend, int idRece)
        {
            this.transCodeSend = transCodeSend;
            this.transCodeRece = transCodeRece;
            this.titleSend = titleSend;
            this.titleRece = titleRece;
            this.bankNumSend = bankNumSend;
            this.bankNumRece = bankNumRece;
            this.money = money;
            this.balenSend = balenSend;
            this.balenRece = balenRece;
            this.date = date;
            this.note = note;
            this.idSend = idSend;
            this.idRece = idRece;
        }

        public string TransCodeSend { get => transCodeSend; set => transCodeSend = value; }
        public string TransCodeRece { get => transCodeRece; set => transCodeRece = value; }
        public string TitleSend { get => titleSend; set => titleSend = value; }
        public string TitleRece { get => titleRece; set => titleRece = value; }
        public string BankNumSend { get => bankNumSend; set => bankNumSend = value; }
        public string BankNumRece { get => bankNumRece; set => bankNumRece = value; }
        public long Money { get => money; set => money = value; }
        public long BalenSend { get => balenSend; set => balenSend = value; }
        public long BalenRece { get => balenRece; set => balenRece = value; }
        public long Date { get => date; set => date = value; }
        public string Note { get => note; set => note = value; }
        public int IdSend { get => idSend; set => idSend = value; }
        public int IdRece { get => idRece; set => idRece = value; }


    }
}
