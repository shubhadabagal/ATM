using System;

public class cardHolder
{
    //define cardHolder and creating some variables
    string cardNum;
    int pin;
    string firstName;
    string lastName;
    double balance;

    //initialize constructor
    public cardHolder(string cardNum, int pin, string firstName, string lastName, double balance) //passing as param
    {
        this.cardNum = cardNum;        //instantiating as objects
        this.pin = pin;
        this.firstName = firstName;
        this.lastName = lastName;
        this.balance = balance;
    }

    //define getters

    public string getNum()
    {
        return cardNum;
    }

    public int getPin()
    {
        return pin;
    }

    public string getFirstName()
    {
        return firstName;
    }

    public string getLastName()
    {
        return lastName;
    }

    public double getBalance()
    {
        return balance;
    }

    //define setters

    public void setNum(string newCardNum)
    {
        cardNum = newCardNum;
    }

    public void setPin(int newPin)
    {
        pin = newPin;
    }

    public void setFirstName(String newFirstName)
    {
        firstName = newFirstName;
    }

    public void setLastName(String newLastName)
    {
        lastName = newLastName;
    }

    public void setBalance(double newBalance)
    {
        balance = newBalance;
    }

    //creating main method to run ATM

    public static void Main(string[] args)
    {
        //define few functions

        void printOptions()  //gives options to the user once they successfully logged in
        {
            Console.WriteLine("Please choose from one of the following options...");
            Console.WriteLine("1. Deposite");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Show Balance");
            Console.WriteLine("4. Exit");
        }

        void deposit(cardHolder currentUser)
        {
            Console.WriteLine("How much money would you like to deposit: ");
            double deposit = Double.Parse(Console.ReadLine());
            currentUser.setBalance(deposit);
            Console.WriteLine("Thank you for your $$. Your new balance is: " + currentUser.getBalance());
        }

        void withdraw(cardHolder currentUser)
        {
            Console.WriteLine("How much money would you like to withdraw: ");
            double withdrawal = Double.Parse(Console.ReadLine());
            //Check if the user has enough money
            if (currentUser.getBalance() < withdrawal)
            {
                Console.WriteLine("Insufficient balance :(");
            }
            else
            {
                //double newBalance = currentUser.getBalance() - withdrawal;
                currentUser.setBalance(currentUser.getBalance() - withdrawal);
                Console.WriteLine("You are good to go! Thank you :)");
            }
        }

        void balance(cardHolder currentUser)
        {
            Console.WriteLine("Current balance: " + currentUser.getBalance());
        }


        //setting a default library of user to call upon
        //creating a list of users

        List<cardHolder> cardHolders = new List<cardHolder>();
        cardHolders.Add(new cardHolder("3786545327654976", 2344,"John", "Green", 150.30));
        cardHolders.Add(new cardHolder("4657545337656444", 4444, "Alex", "Cooper", 159.26));
        cardHolders.Add(new cardHolder("9234054533765643", 1111, "Betty", "Ross", 172.27));
        cardHolders.Add(new cardHolder("2134050033785688", 7777, "Nick", "Haul", 179.26));

        //Promt user

        Console.WriteLine("Welcome to SimpleATM");
        Console.WriteLine("Please insert your debit card: ");
        string debitCardNum = "";
        cardHolder currentUser;

        //validating card
        while(true)
        {
            try
            {
                debitCardNum = Console.ReadLine();
                //Check against our db

                currentUser = cardHolders.FirstOrDefault(a => a.cardNum == debitCardNum);
                if(currentUser != null) { break;}
                else { Console.WriteLine("Card not recognized. Please try again"); }
            }
            catch { Console.WriteLine("Card not recognized. Please try again"); }
        }

        Console.WriteLine("Please enter your pin: ");
        int userPin = 0;
        while (true)
        {
            try
            {
                userPin = int.Parse(Console.ReadLine());
                if (currentUser.getPin() == userPin) { break; }
                else { Console.WriteLine("Incorrect Pin. Please try again"); }
            }
            catch { Console.WriteLine("Incorrect Pin. Please try again"); }
        }

        Console.WriteLine("Welcome " + currentUser.getFirstName() + " :)");
        int option = 0;
        do
        {
            printOptions();
            try
            {
                option = int.Parse(Console.ReadLine());
            }
            catch { }
            if(option == 1) { deposit(currentUser); }
            else if (option == 2) { withdraw(currentUser); }
            else if (option == 3) { balance(currentUser); }
            else if (option == 4) { break; }
            else { option = 0; }
        }
        while (option != 4);

        Console.WriteLine("Thank you! Have a nice day :)");

    }

}