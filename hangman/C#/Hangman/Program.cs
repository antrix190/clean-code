﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, List<string>> d = new Dictionary<int, List<string>>();
            List<string> w = new List<string>();

            var wordsPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent?.FullName + @"\resources\words.in";
            string line;

            // reading text file line by line
            using (StreamReader reader = new StreamReader(wordsPath))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    w.Add(line);
                }
            }

            // sorting words by length
            for (int i = 0; i < w.Count; i++)
            {
                if (!d.ContainsKey(w[i].Length))
                {
                    d.Add(w[i].Length, new List<string>());
                }
                d[w[i].Length].Add(w[i]);
            }

          

            int userInputNumOfLetters;
            while (true)
            {
                Console.WriteLine("Number of letters in the word? ");
                userInputNumOfLetters = Convert.ToInt32(Console.ReadLine());
                if (userInputNumOfLetters < 6)
                {
                    Console.Clear();
                    Console.WriteLine("Please enter a word length 6 or more");
                }
                else if (userInputNumOfLetters > 14)
                {
                    Console.Clear();
                    Console.WriteLine("Please enter a word length 14 or less");
                }
                else
                {
                    break;
                }
            }

            if (d.ContainsKey(userInputNumOfLetters))
            {
                // choose a random word with the given length
                string word = d[userInputNumOfLetters][new Random().Next(d[userInputNumOfLetters].Count)];
                bool[] v = new bool[word.Length];
                int e = 0;
                bool done = true;

                while (e < 10)
                {

                    done = true;
                    for (int i = 0; i < word.Length; ++i)
                    {
                        if (!v[i])
                        {
                            done = false;
                        }
                    }
                    if (done)
                    {
                        break;
                    }

                    Console.WriteLine("Guess a letter: ");
                    char chr = Convert.ToChar(Console.ReadLine()[0]);

                    // TODO check if previously entered
                    bool hit = false;
                    for (int i = 0; i < word.Length; ++i)
                    {
                        if (word[i] == chr && !v[i])
                        {
                            v[i] = true;
                            hit = true;
                        }
                    }
                    if (hit)
                    {
                        Console.WriteLine("Hit!");
                    }
                    else {
                        Console.WriteLine("Missed, mistake {0} out of {1}", e+1, 10);
                        ++e;

                        // drawing hangman
                        Console.WriteLine();
                        if (e > 2) Console.WriteLine("    xxxxxxxxxxxxx");
						else Console.WriteLine();

                        if (e > 3) Console.WriteLine("    x           x");
						else if (e > 1) Console.WriteLine("                x");
						else Console.WriteLine();

                        if (e > 3) Console.WriteLine("    x           x");
						else if (e > 1) Console.WriteLine("                x");
						else Console.WriteLine();

                        if (e > 4) Console.WriteLine("   xxx          x");
						else if (e > 1) Console.WriteLine("                x");
						else Console.WriteLine();

                        if (e > 4) Console.WriteLine("  xxxxx         x");
						else if (e > 1) Console.WriteLine("                x");
						else Console.WriteLine();

                        if (e > 4) Console.WriteLine("   xxx          x");
						else if (e > 1) Console.WriteLine("                x");
						else Console.WriteLine();

                        if (e > 5) Console.WriteLine("    x           x");
						else if (e > 1) Console.WriteLine("                x");
						else Console.WriteLine();

                        if (e > 7) Console.WriteLine("  x x x         x");
						else if (e > 6) Console.WriteLine("  x x           x");
						else if (e > 5) Console.WriteLine("    x           x");
						else if (e > 1) Console.WriteLine("                x");
						else Console.WriteLine();

                        if (e > 7) Console.WriteLine(" x  x  x        x");
						else if (e > 6) Console.WriteLine(" x  x           x");
						else if (e > 5) Console.WriteLine("    x           x");
						else if (e > 1) Console.WriteLine("                x");
						else Console.WriteLine();

                        if (e > 5) Console.WriteLine("    x           x");
						else if (e > 1) Console.WriteLine("                x");
						else Console.WriteLine();

                        if (e > 9) Console.WriteLine("   x x          x");
						else if (e > 8) Console.WriteLine("   x            x");
						else if (e > 1) Console.WriteLine("                x");
						else Console.WriteLine();

                        if (e > 9) Console.WriteLine(" x     x        x");
						else if (e > 8) Console.WriteLine(" x              x");
						else if (e > 1) Console.WriteLine("                x");
						else Console.WriteLine();

                        if (e > 1) Console.WriteLine("                x");
						else Console.WriteLine();

                        if (e > 1) Console.WriteLine("                x");
						else Console.WriteLine();

                        if (e > 0) Console.WriteLine("xxxxxxxxxxxxxxxxxxxxxxxxxxxx");
						else Console.WriteLine();
                        Console.WriteLine();

                    }
                    Console.Write("The word: ");
                    
                    for (int i = 0; i < word.Length; ++i)
                    {
                        if (v[i])
                        {
                            Console.Write(" " + word[i] + " ");
                        }
                        else {
                            Console.Write(" _ ");
                        }
                    }
                    Console.WriteLine();
                }

                // printing final result
                if (done)
                {
                    Console.WriteLine("You won!");
                }
                else {
                    Console.WriteLine("You lost.");
                    Console.WriteLine("The word was: " + word);
                }
            }
            else
            {
                Console.WriteLine("Sorry, no words like that.");
            }

        }
    }
}
