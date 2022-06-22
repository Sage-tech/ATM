using System;

public class cardHolder
{
    String cardNumber;
    int pin;
    String firstName;
    String lastName;
    double balance;

    public cardHolder(string cardNumber, int pin, string firstName, string lastName,double balance)
    {
        this.cardNumber = cardNumber;
        this.pin = pin;
        this.firstName = firstName;
        this.lastName = lastName;
    
        this.balance = balance;
    }
    public String getNumber()
    { 
    return cardNumber;
    }

    public int getPin()
    { 
    return pin; 
    }
    public String getFristName()
    {
        return firstName;
    }
    public String getLastName()
    {
        return lastName;
    }
    public double getBalance()
    {
        return balance;
    }

    public void setNumber(String newCardNumber)
    {
        cardNumber = newCardNumber;
    }
    public void setPin(int newPin)
    {
        pin = newPin;
    }
    public void setFristName(String newFristName)
    {
        firstName = newFristName;
    }
    public void setLastName(String newLastName)
    {
        lastName = newLastName;
    }
 
    public void setBalance(double newBalance)
    {
        balance = newBalance;
    }

    public static void Main(String[] args)
    {
    void printOptions()
        {
            Console.WriteLine("Please choose from the following options...");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Show Balance");
            Console.WriteLine("4. Exsit");
        }
        void deposit(cardHolder currentUser)
        {
            Console.WriteLine("How much money would you like to deposit: ");
            double deposit = Double.Parse(Console.ReadLine());
            currentUser.setBalance(deposit);
            Console.WriteLine("Thank you ! Your new balance is: "  + currentUser.getBalance());
        }
        void withdraw(cardHolder currentUser)
        {
            Console.WriteLine("How much money would you like to withdraw: ");
            double withdrawl = Double.Parse(Console.ReadLine());
            // check if the user has enough money
            if (currentUser.getBalance() < withdrawl)
            {
                Console.WriteLine("Insufficient balance");
            }
            else
            {
                currentUser.setBalance(currentUser.getBalance() - withdrawl);
                Console.WriteLine("You are good to go, Thank you!");
            }
            }
            void balance(cardHolder currentUser)
            {
                Console.WriteLine("Current balance: " + currentUser.getBalance());
            }
            List<cardHolder> cardHolders = new List<cardHolder>();
            cardHolders.Add(new cardHolder("4532772818527395", 1234, "John", "Smith", 150.33));
            cardHolders.Add(new cardHolder("4532666818527395", 1235, "Sam", "Greg", 100.23));
            cardHolders.Add(new cardHolder("4532555818527395", 4563, "Bill", "Lee", 550.43));
            cardHolders.Add(new cardHolder("4532777818527395", 6664, "Bob", "Billy", 0.93));
            cardHolders.Add(new cardHolder("4532888818527395", 5545, "Dave", "Wither", 99.33));
            cardHolders.Add(new cardHolder("4532222818527395", 9987, "Alex", "Soto", 66.56));
            cardHolders.Add(new cardHolder("4532444818527395", 7676, "Joe", "Dirt", 188.98));

            // Prompt User
            Console.WriteLine("Welcome to the AMT");
            Console.WriteLine("Please insert your debit card:");
            String debitCardNumber = "";
            cardHolder currentUser;

            while (true)
            {
                try
                {
                    debitCardNumber = Console.ReadLine();
                    // check against our db 
                    currentUser = cardHolders.FirstOrDefault(a => a.cardNumber == debitCardNumber);
                if (currentUser != null) { break; }
                else
                 { Console.WriteLine("Card can not be found. Please try again"); }

                 }
                catch { Console.WriteLine("Card can not be found. Please try again"); }
            }
            Console.WriteLine("Please enter your pin: ");
            int userPin = 0;
            while (true)
            {
                try
                {
                    userPin = int.Parse(Console.ReadLine());
                    // check against our db
                    if (currentUser.getPin() == userPin) { break; }
                    else { Console.WriteLine("Incorrect pin. Please try again."); }

                }
                catch { Console.WriteLine("Incorrect pin. Please try again"); }
            }

            Console.WriteLine("Welcome " + currentUser.getFristName());
            int option = 0;
            do
            {
                printOptions();
                try
                {
                    option = int.Parse(Console.ReadLine());
                }
                catch { }
                if (option == 1) { deposit(currentUser); }
                else if (option == 2) { withdraw(currentUser); }
                else if (option == 3) { balance(currentUser); }
                else if (option == 4) { break; }
                else { option = 0; }


            }
            while (option != 4);
            Console.WriteLine("Thank you");
        }
    }

