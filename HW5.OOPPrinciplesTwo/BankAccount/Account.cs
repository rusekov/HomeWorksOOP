namespace BankAccount
{
    public abstract class Account
    {
        public Account(Customer customer, decimal balance, decimal monthlyInterestRate)
        {
            this.Customer = customer;
            this.Balance = balance;
            this.MonthlyInterestRate = monthlyInterestRate;
        }

        public Customer Customer { get; private set; }

        public decimal Balance { get; protected set; }

        public decimal MonthlyInterestRate { get; set; }

        public void Deposit(decimal money)
        {
            this.Balance += money;
        }

        public virtual decimal CalculateInterestForMonths(int months)
        {
            return this.MonthlyInterestRate * months;
        }
    }
}
