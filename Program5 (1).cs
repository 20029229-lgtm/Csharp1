using System;
using System.Collections.Generic;

namespace SydneyCoffee
{
    class Program
    {
        static void Main(string[] args)
        {
            // Let user decide how many customers to enter
            Console.Write("Enter number of customers: ");
            int n = Convert.ToInt32(Console.ReadLine());

            // Lists for data storage
            List<string> name = new List<string>();
            List<int> quantity = new List<int>();
            List<string> reseller = new List<string>();
            List<double> charge = new List<double>();

            double price;
            double min = 99999999;
            string minName = "";
            double max = -1;
            string maxName = "";

            // Welcome message
            Console.WriteLine("\n\t\t*** Welcome to Sydney Coffee Program ***\n");

            // Loop to get inputs
            for (int i = 0; i < n; i++)
            {
                // CHANGE A: Name validation (cannot be empty)
                string tempName;
                do
                {
                    Console.Write("Enter customer name: ");
                    tempName = Console.ReadLine().Trim();

                    if (tempName == "")
                        Console.WriteLine("Name cannot be empty. Please enter again.");

                } while (tempName == "");

                name.Add(tempName);

                int q = 0;
                // Quantity validation
                do
                {
                    Console.Write("Enter number of coffee bean bags (1–200): ");
                    q = Convert.ToInt32(Console.ReadLine());

                    if (q < 1 || q > 200)
                    {
                        Console.WriteLine("Invalid input! Please enter between 1 and 200.");
                    }

                } while (q < 1 || q > 200);

                quantity.Add(q);

                // price calculation
                if (q <= 5)
                    price = 36 * q;
                else if (q <= 15)
                    price = 34.5 * q;
                else
                    price = 32.7 * q;

                // Reseller input validation
                string tempReseller;
                do
                {
                    Console.Write("Are you a reseller? (y/n): ");
                    tempReseller = Console.ReadLine().ToLower();

                    if (tempReseller == "y") tempReseller = "yes";
                    if (tempReseller == "n") tempReseller = "no";

                    if (tempReseller != "yes" && tempReseller != "no")
                    {
                        Console.WriteLine("Invalid input! Please enter y or n.");
                    }

                } while (tempReseller != "yes" && tempReseller != "no");

                reseller.Add(tempReseller);

                // Apply discount + round
                double finalCharge;

                if (tempReseller == "yes")
                    finalCharge = Math.Round(price * 0.8, 2); // 20% discount
                else
                    finalCharge = Math.Round(price, 2);

                charge.Add(finalCharge);

                Console.WriteLine($"Total charge for {name[i]} is ${finalCharge}");
                Console.WriteLine("-----------------------------------------------------");

                // Track min/max
                if (finalCharge < min)
                {
                    min = finalCharge;
                    minName = name[i];
                }

                if (finalCharge > max)
                {
                    max = finalCharge;
                    maxName = name[i];
                }
            }

            // Summary Output
            Console.WriteLine("\n============= SUMMARY REPORT =============");

            double sum = 0;
            for (int i = 0; i < n; i++)
            {
                sum += charge[i];
            }

            double average = sum / n;
            Console.WriteLine($"Average order charge: ${average:F2}");

            Console.WriteLine($"Lowest charge: ${min} by {minName}");
            Console.WriteLine($"Highest charge: ${max} by {maxName}");

            // CHANGE B: Summary table
            Console.WriteLine("\n----- Customer Order Summary Table -----");
            Console.WriteLine("Name\tQuantity\tReseller\tCharge");

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"{name[i]}\t{quantity[i]}\t\t{reseller[i]}\t\t${charge[i]}");
            }

            Console.WriteLine("\nThank you for using Sydney Coffee Program!");
        }
    }
}
