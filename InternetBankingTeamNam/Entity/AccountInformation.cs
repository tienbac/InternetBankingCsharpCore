using System;
using System.Collections.Generic;
using System.Text;

namespace InternetBankingTeamNam.Entity
{
    class AccountInformation
    {
        private string bankNumber;
        private string salt;
        private int bankBalence;
        private string fullName;
        private int gender;
        private string birthday;
        private string idNumber;
        private string phone;
        private string email;
        private string address;
        private string creadtedAt;
        private string updatedAt;

        public AccountInformation()
        {
        }

        public AccountInformation(string bankNumber, string salt, int bankBalence, string fullName, int gender, string birthday, string idNumber, string phone, string email, string address, string creadtedAt, string updatedAt)
        {
            this.bankNumber = bankNumber;
            this.salt = salt;
            this.bankBalence = bankBalence;
            this.fullName = fullName;
            this.gender = gender;
            this.birthday = birthday;
            this.idNumber = idNumber;
            this.phone = phone;
            this.email = email;
            this.address = address;
            this.creadtedAt = creadtedAt;
            this.updatedAt = updatedAt;
        }

        public string BankNumber { get => bankNumber; set => bankNumber = value; }
        public string Salt { get => salt; set => salt = value; }
        public int BankBalence { get => bankBalence; set => bankBalence = value; }
        public string FullName { get => fullName; set => fullName = value; }
        public int Gender { get => gender; set => gender = value; }
        public string Birthday { get => birthday; set => birthday = value; }
        public string IdNumber { get => idNumber; set => idNumber = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Email { get => email; set => email = value; }
        public string Address { get => address; set => address = value; }
        public string CreadtedAt { get => creadtedAt; set => creadtedAt = value; }
        public string UpdatedAt { get => updatedAt; set => updatedAt = value; }

        /* private int bankNumber, accountId, bankBalence, gender;
        private string salt, fullName, birthday, idNumber, phone, email, address, createdAt, updatedAt; */


    }
}
