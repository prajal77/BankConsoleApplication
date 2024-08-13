using BankPresentation;

class Program
{
    //Application execution starts here
    static void Main()
    {
        //Dispaly title
        System.Console.WriteLine("**********Harsh Bank*************");
        System.Console.WriteLine("::Login Page::");

        //declare variables to store username and password;
        string userName= null, password= null;

        //read userName from keyword
        System.Console.Write("Username:");
        userName = System.Console.ReadLine();


        //read password from keyboard only if username is entered
        if(userName != "")
        { 
            //read Password from keyword
            System.Console.Write("Password:");
            password = System.Console.ReadLine();
        }
        //check username and password

        if (userName.ToLower() == "system" && password.ToLower() == "manager")
        {
            int mainMenuChoice = -1;
            do
            {
                System.Console.WriteLine("::: Main Menu Here");
                System.Console.WriteLine("1. Customers");
                System.Console.WriteLine("2. Accounts");
                System.Console.WriteLine("3. Funds Transfer");
                System.Console.WriteLine("4. Funds Transfer Statement");
                System.Console.WriteLine("5. Account Statement");
                System.Console.WriteLine("0. Exit");

                System.Console.Write("Enter your choice: ");
                mainMenuChoice = int.Parse(System.Console.ReadLine());

                //switch-case to check menu choice
                switch (mainMenuChoice)
                {
                    case 1: CustomerMain();
                        break;
                    case 2:AccountsMenu();
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                }
            } while (mainMenuChoice != 0);
        }
        else
        {
            System.Console.WriteLine("Invalid Input");
        }

        //about to exit
        System.Console.WriteLine("Thank you! visit again");
        System.Console.ReadKey();

    }

    static void CustomerMain()
    {
        //variable to store customer menu choice
        int customerMenuChoice = -1;

        //do while loop starts
        do
        {
            //print customers menu
            System.Console.WriteLine("\n:::Customer menu:::");
            System.Console.WriteLine("1. Add Customer");
            System.Console.WriteLine("2. Delete Customer");
            System.Console.WriteLine("3. Update Customer");
            System.Console.WriteLine("4. Search Customer");
            System.Console.WriteLine("5. View Customer");
            System.Console.WriteLine("0. Back to Main Menu ");


            System.Console.Write("Enter choice:");
            customerMenuChoice = System.Convert.ToInt32(System.Console.ReadLine());

            //switch case
            switch(customerMenuChoice)
            {
                case 1: CustomerPresentation.AddCustomer();
                    break;
                case 5: CustomerPresentation.ViewCustomers();
                    break; 
            }


        } while (customerMenuChoice != 0);

    }

    static void AccountsMenu()
    {
        //variable to store customer menu choice
        int accountMenuChoice = -1;

        //do while loop starts
        do
        {
            //print customers menu
            System.Console.WriteLine("\n:::Account menu:::");
            System.Console.WriteLine("1. Add Account");
            System.Console.WriteLine("2. Delete Account");
            System.Console.WriteLine("3. Update Account");
            System.Console.WriteLine("4. View Account");
            System.Console.WriteLine("0. Back to Main Menu ");


            System.Console.Write("Enter choice:");
            accountMenuChoice = System.Convert.ToInt32(System.Console.ReadLine());

        } while (accountMenuChoice != 0);


    }
}