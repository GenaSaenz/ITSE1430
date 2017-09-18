/*
 * Gena (Annie) Saenz
 * ITSE 1430
 * Lab 1
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Program
    {
        static void Main( string[] args )
        {
            bool quit = false;
            do
            {
                char choice = GetInput();
                switch (choice)
                {
                    //If not case sensitive
                    case 'l':
                    case 'L':
                        ListMovies();
                        break;

                    case 'a':
                    case 'A':
                        AddMovie();
                        break;

                    case 'r':
                    case 'R':
                        RemoveMovie();
                        break;

                    case 'q':
                    case 'Q':
                        quit = true;
                        break;
                };
            } while (!quit);
        }

        private static void ListMovies()
        {
            //Title
            //Description (optional)
            //Length (optional)
            //Owned (Yes or No)
            while (true)
            {
                string msg = $"{movieTitle}\n{movieDescription}\n{movieLength}\n{(movieOwned ? "[Owned]" : "")}";
                if (String.IsNullOrEmpty(msg))
                    Console.WriteLine("There are no movies to display.");
                else if (!String.IsNullOrEmpty(msg))
                    Console.WriteLine(msg);
            };
        }

        private static void AddMovie()
        {
            Console.Write("Enter a title: ");
            movieTitle = Console.ReadLine().Trim();

            if (String.IsNullOrEmpty(movieTitle))
            {
                Console.WriteLine("Please enter a valid movie title.");
                Console.WriteLine("Enter a title: ");
                movieTitle = Console.ReadLine().Trim();
            }  

            Console.Write("Enter a description (optional): ");
            movieDescription = Console.ReadLine().Trim();

            Console.Write("Enter the length in minutes (optional): ");
            movieLength = ReadMovieLength();

            Console.Write("Do you own this movie? (Y/N): ");
            movieOwned = ReadYesNo();

            
        }

        private static void RemoveMovie()
        {
           // do
            //{
                Console.WriteLine("Are you sure you want to delete this movie?");
                removeMovie = ReadYesNo();

                if (removeMovie == true)
                {
                    string msg1 = $"{movieTitle}\n${movieDescription}\n{movieLength}\n{(movieOwned ? "[Owned]" : "")}";
                    msg1.Remove(0);
                }
           // } while (true);

                Console.WriteLine("Your movie has been removed.");
        }

        static char GetInput()
        {
            while (true)
            {
                Console.WriteLine("".PadLeft(20, '-'));
                Console.WriteLine("Main Menu");
                Console.WriteLine("".PadLeft(20, '-'));
                Console.WriteLine("L)ist Movies");
                Console.WriteLine("A)dd Movie");
                Console.WriteLine("R)emove Movie");
                Console.WriteLine("Q)uit");
                Console.WriteLine("".PadLeft(20, '-'));
                Console.WriteLine("".PadLeft(20, '-'));

                string input = Console.ReadLine().Trim();

                
                if (input != null && input.Length != 0)
                {
                    
                    if (String.Compare(input, "A", true) == 0)
                        return 'A';
                                        
                    char letter = Char.ToUpper(input[0]);
                    if (letter == 'L')
                        return 'L';
                    else if (letter == 'A')
                        return 'A';
                    else if (letter == 'R')
                        return 'R';
                    else if (letter == 'Q')
                        return 'Q';
                };

                //Error
                Console.WriteLine("Please choose a valid option");
            };
        }

        static string ReadMovieLength()
        {          
                
                while (true)
                {
                    string input = Console.ReadLine();
                    if (Int32.TryParse(input, out int result))
                    {
                        Console.WriteLine(result);
                        return input;
                    } else
                        Console.WriteLine("You must enter a value >= 0");
                
                };
        }


        static string ReadString( string errorMessage, bool allowEmpty )
        {
            errorMessage = errorMessage ?? "Enter a valid length >= 0 minutes.";
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
                        case 'Y':
                            return true;
                        case 'N':
                            return false;
                    };
                };
                Console.WriteLine("Enter either Y or N");
            } while (true);
        }


        //Product
        static string movieTitle;
        static string movieLength;
        static string movieDescription;
        static bool movieOwned;
        static bool allowEmpty;
        static string errorMessage;
        private static bool removeMovie;
    }
}
