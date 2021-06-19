using System;
using System.Collections.Generic;


namespace Assignment2_ScrabbleScorer_csharp
{
    class Program
    {
        //Here is the original OldPointStructure dictionay
        public static Dictionary<int, string> oldPointStructure = new Dictionary<int, string>()
        {
            {1, "A, E, I, O, U, L, N, R, S, T"},
            {2, "D, G"},
            {3, "B, C, M, P" },
            {4, "F, H, V, W, Y" },
            {5, "K" },
            {8, "J, X" },
            {10, "Q, Z" }
        };

        //Code your Transform method here

        static Dictionary<char, int> newPointStructure = new Dictionary<char, int>();

        public static void Transform()
        {
            foreach (KeyValuePair<int, string> letter in oldPointStructure)
            {
                if(letter.Key == 1)
                {
                    string[] temp = letter.Value.ToLower().Split(", ");
                    string tempStr = string.Join("", temp);
                    char[] newVals = tempStr.ToCharArray();

                    for (int i = 0; i < newVals.Length; i++)
                    {
                        newPointStructure.Add(newVals[i], 1);
                    }
                }
                if (letter.Key == 2)
                {
                    string[] temp = letter.Value.ToLower().Split(", ");
                    string tempStr = string.Join("", temp);
                    char[] newVals = tempStr.ToCharArray();

                    for (int i = 0; i < newVals.Length; i++)
                    {
                        newPointStructure.Add(newVals[i], 2);
                    }
                }
                if (letter.Key == 3)
                {
                    string[] temp = letter.Value.ToLower().Split(", ");
                    string tempStr = string.Join("", temp);
                    char[] newVals = tempStr.ToCharArray();

                    for (int i = 0; i < newVals.Length; i++)
                    {
                        newPointStructure.Add(newVals[i], 3);
                    }
                }
                if (letter.Key == 4)
                {
                    string[] temp = letter.Value.ToLower().Split(", ");
                    string tempStr = string.Join("", temp);
                    char[] newVals = tempStr.ToCharArray();

                    for (int i = 0; i < newVals.Length; i++)
                    {
                        newPointStructure.Add(newVals[i], 4);
                    }
                }
                if (letter.Key == 5)
                {
                    string[] temp = letter.Value.ToLower().Split(", ");
                    string tempStr = string.Join("", temp);
                    char[] newVals = tempStr.ToCharArray();

                    for (int i = 0; i < newVals.Length; i++)
                    {
                        newPointStructure.Add(newVals[i], 5);
                    }
                }
                if (letter.Key == 8)
                {
                    string[] temp = letter.Value.ToLower().Split(", ");
                    string tempStr = string.Join("", temp);
                    char[] newVals = tempStr.ToCharArray();

                    for (int i = 0; i < newVals.Length; i++)
                    {
                        newPointStructure.Add(newVals[i], 8);
                    }
                }
                if (letter.Key == 10)
                {
                    string[] temp = letter.Value.ToLower().Split(", ");
                    string tempStr = string.Join("", temp);
                    char[] newVals = tempStr.ToCharArray();

                    for (int i = 0; i < newVals.Length; i++)
                    {
                        newPointStructure.Add(newVals[i], 10);
                    }
                }
            }
            newPointStructure.Add(' ', 0);
        }
        //Code your Scoring Option methods here

        //SimpleScorer-----
        public static void SimpleScorer(string someString)
        {
            int charCount = 0;
            foreach(char a in someString)
            {
                if(a == ' ')
                {
                    charCount += 0;
                }
                else
                {
                    charCount++;
                }     
            }
            Console.WriteLine($"Your score for \"{someString}\" : {charCount}");
        }

        //BonusVowels-----
        public static void BounsVowels(string anotherString)
        {
            int pointCount = 0;
            foreach(char x in anotherString)
            {
                if (x == 'a' || x == 'e' || x == 'i' || x == 'o' || x == 'u')
                {
                    pointCount += 3;
                }
                else if(x == ' ')
                {
                    pointCount += 0;
                } 
                else
                {
                    pointCount++;
                }
            }
            Console.WriteLine($"Your score for \"{anotherString}\" : {pointCount}");
        }

        //ScrabbleScorer-----
        public static void ScrabbleScorer(string scrabbleString)
        {
            if(newPointStructure.Count == 0)
            {
                Transform();
            }
            

            string tempString = scrabbleString;
            char[] charScore = tempString.ToCharArray();
            int points = 0;
            for (int i = 0; i < charScore.Length; i++)
            {
                foreach (KeyValuePair<char, int> eval in newPointStructure)
                {
                    if (eval.Key == charScore[i])
                    {
                        points += eval.Value;
                    }
                }
            }
            Console.WriteLine($"Your score for \"{scrabbleString}\" : {points}");
        }
                    
        //Code your ScoringAlgorithms method here
        public static void ScoringAlgorithms(string insertString, string choice)
        {  
            int selection = -1;
            while(selection == -1)
            {
                
                if (Int32.TryParse(choice, out selection))
                {
                    if (selection == 1)
                    {
                        ScrabbleScorer(insertString);
                    }
                    if (selection == 2)
                    {
                        SimpleScorer(insertString);
                    }
                    if (selection == 3)
                    {
                        BounsVowels(insertString);
                    }
                }
            }
        }

        //Code your InitialPrompt method here
        public static string InitialPrompt()
        {
            Console.WriteLine("Welcome to the Scarbble score calculator!\n");
            Console.WriteLine("which scoring algorithm would you like to use?\n");
            Console.WriteLine(" 1 - The traditional scoring algorithm\n 2 - Simple Score: Each letter is worth 1 point.\n 3 - Bonus Vowels: Vowels are worth 3 pts, and consonats are 1 pt.\n");
            bool isValid = false;
            string enterScoreSys;
            do
            {
                Console.WriteLine("Enter 1, 2, or 3: ");
                enterScoreSys = Console.ReadLine().ToLower();
                if(enterScoreSys == "1" || enterScoreSys == "2" || enterScoreSys == "3")
                {
                    isValid = true;
                }
                else
                {
                    Console.WriteLine("Please enter only 1, 2, or 3.");
                }
            } while (!isValid);
            
            return enterScoreSys;
        }

        //Code your RunProgram method here
        public static void RunProgram()
        {
            string algSelect = InitialPrompt();
            int stopCount = 0;
            string insertStr;
            bool isValid = false;
            
            do
            {
                do
                {
                    Console.WriteLine("Please enter a word, or \"Stop\" to quit: ");
                    insertStr = Console.ReadLine().ToLower();
                    for (int i = 0; i < insertStr.Length; i++)
                    {
                        char check = insertStr[i];
                        if (check >= 'a' && check <= 'z' || check == ' ')
                        {
                            isValid = true;
                        }
                        else
                        {
                            isValid = false;
                            Console.WriteLine("Please only enter valid english alphabet characters.");
                            break;
                        }
                    }
                } while (!isValid);
               
                
                if (insertStr == "stop")
                {
                    stopCount++;
                }
                else
                {
                    ScoringAlgorithms(insertStr, algSelect);
                }
            } while (stopCount < 1);
        }


        static void Main(string[] args)
        {
            //Call your RunProgram method here
                RunProgram();
            
        }
    }
}
