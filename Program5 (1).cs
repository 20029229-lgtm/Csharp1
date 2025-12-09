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

            // Replaced arrays with dynamic Lists
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
                Console.Write("Enter customer name: ");
                name.Add(Console.ReadLine());

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
                    Console.Write("Are you a reseller? (y/n): ");   // CHANGE 1
                    tempReseller = Console.ReadLine().ToLower();

                    // CHANGE 1 → convert y/n to yes/no
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
            Console.WriteLine($"Average order charge: ${average:F2}");   // CHANGE 2

            Console.WriteLine($"Lowest charge: ${min} by {minName}");
            Console.WriteLine($"Highest charge: ${max} by {maxName}");

            Console.WriteLine("\nThank you for using Sydney Coffee Program!");
        }
    }
}
