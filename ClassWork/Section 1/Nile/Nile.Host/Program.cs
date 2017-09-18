/*
 * Gena (Annie) Saenz
 * ITSE 1430
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nile.Host 
{
    class Program {
        static void Main( string[] args )
        {
            bool quit = false;
            do
            {
                char choice = GetInput();
                switch (choice)
                {
                    //If not case sensitive
                    case 'a':
                    case 'A': AddProduct(); break;

                    case 'l':
                    case 'L': ListProducts(); break;

                    case 'q':
                    case 'Q': quit = true; break;
                };
            } while (!quit);
        }

        private static void ListProducts()
        {
            //Name $price [Discontinued]
            //Description
            //string msg = String.Format("{0}\t\t\t${1}\t\t{2}", productName, productPrice,
            //    productDiscontinued ? "[Discontinued]" : "");
            //  Console.WriteLine("{0}\t\t\t${1}\t\t{2}", productName, productPrice,
            //     productDiscontinued ? "[Discontinued]" : "");

            //Option 3 - Do this way
            string msg = $"{productName}\t\t\t${productPrice}\t\t{(productDiscontinued ? "[Discontinued]" : "")}";
            Console.WriteLine(msg);
            Console.WriteLine(productDescription);
        }

        private static void AddProduct()
        {
            Console.Write("Enter product name: ");
            productName = Console.ReadLine().Trim();

            //Ensure not empty

            Console.Write("Enter price (> 0): ");
            productPrice = ReadDecimal();

            Console.Write("Enter optional description: ");
            productDescription = Console.ReadLine().Trim();

            Console.Write("Is it discontinued (Y/N): ");
            productDiscontinued = ReadYesNo();
        }

        static char GetInput()
        {
            while (true)
            {
                Console.WriteLine("Main Menu");
                Console.WriteLine("".PadLeft(10, '-'));
                Console.WriteLine("A)dd Product");
                Console.WriteLine("L)ist Products");
                Console.WriteLine("Q)uit");

                string input = Console.ReadLine().Trim();

                //Option 1 = string literal
                //if (input != "")

                //Option 2 - string field
                //if (input != String.Empty)

                //Option 3 - length
                if (input != null && input.Length != 0)
                {
                    //String comparison
                    if (String.Compare(input, "A", true) == 0)
                        return 'A';

                    //Char comparison
                    char letter = Char.ToUpper(input[0]);
                    if (letter == 'A')
                        return 'A';
                    else if (letter == 'L')
                        return 'L';
                    else if (letter == 'Q')
                        return 'Q';
                };

                //Error
                Console.WriteLine("Please choose a valid option");
            };
        }

        /// <summary>
        /// Reads a decimal from Console.</summary>
        /// <returns>The decimal value.</returns>
        static decimal ReadDecimal()
        {
            do
            {
                string input = Console.ReadLine();

               // decimal result;
                if (Decimal.TryParse(input, out decimal result))
                    return result;

                Console.WriteLine("Enter a valid decimal");
            } while (true);
        }

        static string ReadString(string errorMessage, bool allowEmpty)
        {
            //if (errorMessage == null)
            //errorMessage = "Enter a valid string";
            //else
            //  errorMessage = errorMessage.Trim(),
            //Null coalesce
            errorMessage = errorMessage ?? "Enter a valid string";

            //Null conditional 
            errorMessage = errorMessage?.Trim();
            do
            {
                string input = Console.ReadLine();
                if (String.IsNullOrEmpty(input) && allowEmpty)
                    return "";
                else if (!String.IsNullOrEmpty(input))
                    return input;

                Console.WriteLine(errorMessage);
                
            } while (true);
        }

        static bool ReadYesNo()
        {
            do
            {
                string input = Console.ReadLine();

                if (!String.IsNullOrEmpty(input))
                {
                    switch (Char.ToUpper(input[0]))
                    {
                        case 'Y': return true;
                        case 'N': return false;
                    };
                };
                Console.WriteLine("Enter either Y or N");
            } while (true);
        }


        //Product
        static string productName;
        static decimal productPrice;
        static string productDescription;
        static bool productDiscontinued;
    }
}

