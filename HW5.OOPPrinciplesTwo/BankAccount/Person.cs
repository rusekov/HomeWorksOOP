namespace BankAccount
{
    public class Person : Customer
    {
        public Person(string name, string idnumber)
            : base(name)
        {
            this.IDNumber = idnumber;
        }

        public string IDNumber { get; private set; }
    }
}
