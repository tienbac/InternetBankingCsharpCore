using System;
using System.Collections.Generic;
using System.Text;

namespace InternetBankingTeamNam.Entity
{
    class UserSignUp
    {
        private string username;
        private string password;
        private string bankName;
        private string bankNumber;
        private string salt;
        private long bankBalence;
        private string fullName;
        private int gender;
        private long birthday;
        private string idNumber;
        private string phone;
        private string email;
        private string address;
        private long creadtedAt;
        private long updatedAt;

        public UserSignUp()
        {
        }

        public UserSignUp(string bankName, string bankNumber, long bankBalence, string fullName)
        {
            this.bankName = bankName;
            this.bankNumber = bankNumber;
            this.bankBalence = bankBalence;
            this.fullName = fullName;
        }

        public UserSignUp(string username, string password, string bankName, string bankNumber, string salt, long bankBalence, string fullName, int gender, long birthday, string idNumber, string phone, string email, string address, long creadtedAt)
        {
            this.username = username;
            this.password = password;
            this.bankName = bankName;
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
        }

        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string BankNumber { get => bankNumber; set => bankNumber = value; }
        public string Salt { get => salt; set => salt = value; }

        public string FullName { get => fullName; set => fullName = value; }
        public int Gender { get => gender; set => gender = value; }
        public string IdNumber { get => idNumber; set => idNumber = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Email { get => email; set => email = value; }
        public string Address { get => address; set => address = value; }
        public string BankName { get => bankName; set => bankName = value; }
        public long Birthday { get => birthday; set => birthday = value; }
        public long CreadtedAt { get => creadtedAt; set => creadtedAt = value; }
        public long UpdatedAt { get => updatedAt; set => updatedAt = value; }
        public long BankBalence { get => bankBalence; set => bankBalence = value; }
    }
}
