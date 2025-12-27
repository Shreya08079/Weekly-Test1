using System;

public class BillingService
{
    // Billing Details
    public static PatientBill? LastBill;
    public static bool HasLastBill = false;

    //Creating Bill
    public void CreateBill()
    {
        PatientBill bill = new PatientBill();
        //Bill ID
        Console.Write("Enter Bill ID: ");
        bill.BillId = Console.ReadLine() ?? "";
        //Validating Bill ID
        if (string.IsNullOrWhiteSpace(bill.BillId))
        {
            Console.WriteLine("Bill ID cannot be empty.");
            return;
        }
        //Patient Name
        Console.Write("Enter Patient Name: ");
        bill.PatientName = Console.ReadLine() ?? "";

        Console.Write("Does the patient have insurance? (y/n): ");
        bill.HasInsurance = Console.ReadLine()?.ToLower() == "y";

        Console.Write("Enter Consultation Fee: ");
        bill.ConsultationFee = Convert.ToDecimal(Console.ReadLine());

        Console.Write("Enter Lab Charges: ");
        bill.LabCharges = Convert.ToDecimal(Console.ReadLine());

        Console.Write("Enter Medicine Charges: ");
        bill.MedicineCharges = Convert.ToDecimal(Console.ReadLine());

        bill.GrossAmount =
            bill.ConsultationFee +
            bill.LabCharges +
            bill.MedicineCharges;

        bill.DiscountAmount = bill.HasInsurance
            ? bill.GrossAmount * 0.10m
            : 0;

        bill.FinalPayable = bill.GrossAmount - bill.DiscountAmount;

        LastBill = bill;
        HasLastBill = true;

        Console.WriteLine("\nBill Created Successfully!");
        Console.WriteLine($"Gross Amount: {bill.GrossAmount}");
        Console.WriteLine($"Discount: {bill.DiscountAmount}");
        Console.WriteLine($"Final Payable: {bill.FinalPayable}");
    }

    public void ViewLastBill()
    {
        if (!HasLastBill || LastBill == null)
        {
            Console.WriteLine("No bill available.");
            return;
        }

        Console.WriteLine("\n***** Last Bill *****");
        Console.WriteLine($"Bill ID: {LastBill.BillId}");
        Console.WriteLine($"Patient Name: {LastBill.PatientName}");
        Console.WriteLine($"Insurance: {LastBill.HasInsurance}");
        Console.WriteLine($"Consultation Fee: {LastBill.ConsultationFee}");
        Console.WriteLine($"Lab Charges: {LastBill.LabCharges}");
        Console.WriteLine($"Medicine Charges: {LastBill.MedicineCharges}");
        Console.WriteLine($"Gross Amount: {LastBill.GrossAmount}");
        Console.WriteLine($"Discount Amount: {LastBill.DiscountAmount}");
        Console.WriteLine($"Final Payable: {LastBill.FinalPayable}");
    }

    public void ClearLastBill()
    {
        LastBill = null;
        HasLastBill = false;
        Console.WriteLine("Last bill cleared.");
    }
}
