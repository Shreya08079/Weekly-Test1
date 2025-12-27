using System;

class Program
{
    static void Main(string[] args)
    {
        // #region MediSure Clinic
        // BillingService billService = new BillingService();

        // while (true)
        // {
        //     Console.WriteLine("\n========= MediSure Clinic Billing ==========");
        //     Console.WriteLine("1. Create New Bill");
        //     Console.WriteLine("2. View Last Bill");
        //     Console.WriteLine("3. Clear Last Bill");
        //     Console.WriteLine("4. Exit");
        //     Console.Write("Enter choice: ");

        //     string choice = Console.ReadLine() ?? "";

        //     switch (choice)
        //     {
        //         case "1":
        //             billService.CreateBill();
        //             break;

        //         case "2":
        //             billService.ViewLastBill();
        //             break;

        //         case "3":
        //             billService.ClearLastBill();
        //             break;

        //         case "4":
        //             Console.WriteLine("Thank you. Application closed.");
        //             return;

        //         default:
        //             Console.WriteLine("Invalid choice.");
        //             break;
        //     }
        // }
        // #endregion

        #region QuickMart

        TransactionService service = new TransactionService();

        while (true)
        {
            Console.WriteLine("\n================== QuickMart Traders ==================");
            Console.WriteLine("1. Create New Transaction (Enter Purchase & Selling Details)");
            Console.WriteLine("2. View Last Transaction");
            Console.WriteLine("3. Calculate Profit/Loss (Recompute & Print)");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your option: ");

            string choice = Console.ReadLine() ?? "";

            switch (choice)
            {
                case "1":
                    service.CreateTransaction();
                    break;

                case "2":
                    service.ViewLastTransaction();
                    break;

                case "3":
                    service.RecalculateProfitLoss();
                    break;

                case "4":
                    Console.WriteLine("\nThank you. Application closed normally.");
                    return;

                default:
                    Console.WriteLine("Invalid option. Please choose between 1 and 4.");
                    break;
            }
        }
    }
}

        #endregion