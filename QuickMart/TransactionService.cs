using System;

public class TransactionService
{
    public static SaleTransaction? LastTransaction;
    public static bool HasLastTransaction = false;

    // 1️ Create New Transaction
    public void CreateTransaction()
    {
        SaleTransaction ts = new SaleTransaction();

        Console.Write("Enter Invoice No: ");
        ts.InvoiceNo = Console.ReadLine() ?? "";
        if (string.IsNullOrWhiteSpace(ts.InvoiceNo))
        {
            Console.WriteLine("Invoice No cannot be empty.");
            return;
        }
        
        //Customer Name
        Console.Write("Enter Customer Name: ");
        ts.CustomerName = Console.ReadLine() ?? "";


        //Item Name
        Console.Write("Enter Item Name: ");
        ts.ItemName = Console.ReadLine() ?? "";


        //Quantity 
        Console.Write("Enter Quantity: ");
        ts.Quantity = Convert.ToInt32(Console.ReadLine());
        if (ts.Quantity <= 0)
        {
            Console.WriteLine("Quantity must be greater than zero.");
            return;
        }
        //Purchase Amount
        Console.Write("Enter Purchase Amount (total): ");
        ts.PurchaseAmount = Convert.ToDecimal(Console.ReadLine());
        if (ts.PurchaseAmount <= 0)
        {
            Console.WriteLine("Purchase Amount must be greater than zero.");
            return;
        }

        //Selling Amount
        Console.Write("Enter Selling Amount (total): ");
        ts.SellingAmount = Convert.ToDecimal(Console.ReadLine());
        if (ts.SellingAmount < 0)
        {
            Console.WriteLine("Selling Amount cannot be negative.");
            return;
        }

        CalculateProfitLoss(ts);

        LastTransaction = ts;
        HasLastTransaction = true;

        Console.WriteLine("\nTransaction saved successfully.");
        PrintCalculation(ts);
        
    }

    // 2️ View Last Transaction
    public void ViewLastTransaction()
    {
        if (!HasLastTransaction || LastTransaction == null)
        {
            Console.WriteLine("No transaction available. Please create a new transaction first.");
            return;
        }

        Console.WriteLine("\n -- Last Transaction --");
        Console.WriteLine($"InvoiceNo: {LastTransaction.InvoiceNo}");
        Console.WriteLine($"Customer: {LastTransaction.CustomerName}");
        Console.WriteLine($"Item: {LastTransaction.ItemName}");
        Console.WriteLine($"Quantity: {LastTransaction.Quantity}");
        Console.WriteLine($"Purchase Amount: {LastTransaction.PurchaseAmount:F2}");
        Console.WriteLine($"Selling Amount: {LastTransaction.SellingAmount:F2}");
        Console.WriteLine($"Status: {LastTransaction.ProfitOrLossStatus}");
        Console.WriteLine($"Profit/Loss Amount: {LastTransaction.ProfitOrLossAmount:F2}");
        Console.WriteLine($"Profit Margin (%): {LastTransaction.ProfitMarginPercent:F2}");
        Console.WriteLine("--------------------------------------------");
    }

    // 3 Recalculate Profit / Loss
    public void RecalculateProfitLoss()
    {
        if (!HasLastTransaction || LastTransaction == null)
        {
            Console.WriteLine("No transaction available. Please create a new transaction first.");
            return;
        }

        CalculateProfitLoss(LastTransaction);
        PrintCalculation(LastTransaction);
    }

    // Calculation Logic
    private void CalculateProfitLoss(SaleTransaction ts)
    {
        if (ts.SellingAmount > ts.PurchaseAmount)
        {
            ts.ProfitOrLossStatus = "PROFIT";
            ts.ProfitOrLossAmount = ts.SellingAmount - ts.PurchaseAmount;
        }
        else if (ts.SellingAmount < ts.PurchaseAmount)
        {
            ts.ProfitOrLossStatus = "LOSS";
            ts.ProfitOrLossAmount = ts.PurchaseAmount - ts.SellingAmount;
        }
        else
        {
            ts.ProfitOrLossStatus = "BREAK-EVEN";
            ts.ProfitOrLossAmount = 0;
        }

        ts.ProfitMarginPercent =
            (ts.ProfitOrLossAmount / ts.PurchaseAmount) * 100;
    }

    // Print Calculation Summary
    private void PrintCalculation(SaleTransaction ts)
    {
        Console.WriteLine($"Status: {ts.ProfitOrLossStatus}");
        Console.WriteLine($"Profit/Loss Amount: {ts.ProfitOrLossAmount:F2}");
        Console.WriteLine($"Profit Margin (%): {ts.ProfitMarginPercent:F2}");
    }
}
