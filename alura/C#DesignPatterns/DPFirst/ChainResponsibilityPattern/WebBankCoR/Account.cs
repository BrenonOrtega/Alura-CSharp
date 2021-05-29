using System.Security;

namespace DPFirst.ChainResponsibilityPattern.WebBankCoR
{
    public class Account
    {
        public string Name {get; set;}
        public double Balance { get; set; }

        internal const string SEPARATOR = "_";
        public Account() {  }

        public Account(double balance) {
            Balance = balance;
        }

        public override bool Equals(object obj)
        {
            return Name.Equals(obj);
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public override string ToString()
        {
            return $"{ Name }{SEPARATOR}{ Balance }";
        }
    }
}
