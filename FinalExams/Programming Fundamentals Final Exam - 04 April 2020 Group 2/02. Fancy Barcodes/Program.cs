using System;
using System.Text.RegularExpressions;

namespace _02._Fancy_Barcodes
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Regex regex = new Regex(@"^@[#]{1,}([A-Z][A-Za-z\d]{4,}[A-Z])@[#]{1,}$");

            for (int i = 0; i < n; i++)
            {
                string barcode = Console.ReadLine();

                if (regex.IsMatch(barcode))
                {
                    Regex numReg = new Regex(@"\d+");
                    Match match = regex.Match(barcode);
                    if (numReg.IsMatch(match.Value))
                    {
                        MatchCollection mc = numReg.Matches(match.Value);
                        string group = string.Empty;
                        foreach (Match item in mc)
                        {
                            group += item;
                        }
                        Console.WriteLine($"Product group: {group}");
                    }
                    else
                    {
                        Console.WriteLine($"Product group: 00");
                    }   
                }
                else
                {
                    Console.WriteLine("Invalid barcode");
                }

            }
        }
    }
}
