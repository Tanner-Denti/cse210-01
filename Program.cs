// Tanner Denti
// 01 Ponder & Prove: Developer -- Tic-Tac-Toe

using System;
using System.Collections.Generic;

namespace tic_tac_toe
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.Write("Would you like to play a game of tic-tac-toe with a friends? (yes or no) ");
            string userAns = Console.ReadLine().ToLower();
            if (userAns == "yes")
            {
                Console.WriteLine("Here we go!");
                Console.WriteLine("Player 1 is X and Player 2 is O.");
                // initate a list and fill it with the values 1-9 as strings.
                List<string> locations = new List<string>();
                for (int i = 1; i < 10; i++)
                {
                    locations.Add(i.ToString());
                }
                
                PlayGame(locations);
            }
            else
            {
                Console.WriteLine("See ya!");
            }

        }
        static void CreateGrid(List<string> locations)
        {
            Console.WriteLine();
            Console.WriteLine($"{locations[0]}|{locations[1]}|{locations[2]}");
            Console.WriteLine("-+-+-");
            Console.WriteLine($"{locations[3]}|{locations[4]}|{locations[5]}");
            Console.WriteLine("-+-+-");
            Console.WriteLine($"{locations[6]}|{locations[7]}|{locations[8]}");
            Console.WriteLine();
        }
        static void PlayGame(List<string> locations)
        {
            //initiate a variable to keep track of turns. When it is odd it will be player 1's turn. When even player 2.
            int turn = 1;
            int playerNum = 0;
            string mark = "";


            string winCond = CheckWinCondition(locations);
            string CheckDrawV = CheckDraw(locations);

            while (winCond == "C" && CheckDrawV == "C")
            {
                if (turn % 2 == 1)
                {
                    playerNum = 1;
                    mark = "X";
                }
                else if (turn % 2 == 0)
                {
                    playerNum = 2;
                    mark = "O";
                }
                Console.WriteLine($"Player {playerNum}: ");
            
                CreateGrid(locations);

                Console.Write("Enter a location 1-9: ");
                int playerMove = int.Parse(Console.ReadLine());
                locations[playerMove - 1] = mark;


                
                winCond = CheckWinCondition(locations);
                CheckDrawV = CheckDraw(locations);
                turn = turn + 1;
            }

            CreateGrid(locations);
            if (winCond == "X")
            {
                Console.WriteLine("Player 1 wins!");
            }
            else if (winCond == "O")
            {
                Console.WriteLine("Player 2 wins!");
            }
            else
            {
                Console.WriteLine("It's a draw!");
            }

        }
        
        static string CheckWinCondition(List<string> locations)
        {
            if ((locations[0] == locations[1] && locations[1] == locations[2] && locations[2] == "X") || 
                (locations[6] == locations[7] && locations[7] == locations[8] && locations[8] == "X") || 
                (locations[0] == locations[3] && locations[3] == locations[6] && locations[6] == "X") || 
                (locations[2] == locations[5] && locations[5] == locations[8] && locations[8] == "X") || 
                (locations[0] == locations[4] && locations[4] == locations[8] && locations[8] == "X") || 
                (locations[2] == locations[4] && locations[4] == locations[6] && locations[6] == "X") ||
                (locations[1] == locations[4] && locations[4] == locations[7] && locations[7] == "X") || 
                (locations[3] == locations[4] && locations[4] == locations[5] && locations[5] == "X"))
            {
                return "X";
            }
            else if ((locations[0] == locations[1] && locations[1] == locations[2] && locations[2] == "O") || 
                (locations[6] == locations[7] && locations[7] == locations[8] && locations[8] == "O") || 
                (locations[0] == locations[3] && locations[3] == locations[6] && locations[6] == "O") || 
                (locations[2] == locations[5] && locations[5] == locations[8] && locations[8] == "O") || 
                (locations[0] == locations[4] && locations[4] == locations[8] && locations[8] == "O") || 
                (locations[2] == locations[4] && locations[4] == locations[6] && locations[6] == "O") ||
                (locations[1] == locations[4] && locations[4] == locations[7] && locations[7] == "O") || 
                (locations[3] == locations[4] && locations[4] == locations[5] && locations[5] == "O"))
            {
                return "O";
            }
            else
            {
                return "C";
            }
        }
        static string CheckDraw(List<string> locations)
        {
            string winCond = CheckWinCondition(locations);

            if ((locations[0] != "1" && locations[1] != "2" &&
                locations[2] != "3" && locations[3] != "4" &&
                locations[4] != "5" && locations[5] != "6" &&
                locations[6] != "7" && locations[7] != "8" &&
                locations[8] != "9") && winCond == "C")
            {
                return "D";
            }
            else if (winCond == "C")
            {
                return "C";
            }
            else
            {
                return "N";
            }
        }

    }
}