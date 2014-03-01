namespace BankAccount
{
    public class Company : Customer
    {
        public Company(string name, string vatnumber)
            : base(name)
        {
            this.VATNumber = vatnumber;
        }

        public string VATNumber { get; private set; }
    }
}
