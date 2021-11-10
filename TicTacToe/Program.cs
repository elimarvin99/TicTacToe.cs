using System;
using System.Collections.Generic;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            //create a board list to be used as the board and change index points in it
            //the list is of string type because the userinput will be "X" or "O".
            var board = new List<string>() { "X", "1", "2", "3", "4", "5", "6", "7", "8", "9" };

            Console.WriteLine("Welcome to Tic Tac Toe!");
            string player2Marker = "";
            var player1Marker = PlayerInput();

            //assign marker to each player        //this is before the while loop because we want it to be only once, not be each turn
            if (player1Marker == "X")
            {
                player2Marker = "O";
            }
            else if (player1Marker == "O")
            {
                player2Marker = "X";
            }
            Console.WriteLine($"Player 1 is {player1Marker}");
            Console.WriteLine($"Player 2 is {player2Marker}");
            //see who goes first
            string turn = ChooseFirst();
            //display who goes first for 3 seconds before moving on to the actual game
            System.Threading.Thread.Sleep(3000);

            var gameOn = true;
            while (gameOn)

                //TODO 1) figure out how when play again the board is reset
                
            {
                
                if (turn != "Player 2")
                {

                    //play out player1's turn
                    Console.Clear();
                    DisplayBoard(board);
                    Console.WriteLine("Player 1:");
                    //get players pick for position
                    var position = PlayerChoice(board);
                    //place the players marker on his position
                    if (SpaceCheck(board, position) == true)
                    {
                        PlaceMarker(board, player1Marker, position);
                    }
                    else if (SpaceCheck(board, position) == false)
                    {
                        PlayerChoice(board);
                        SpaceCheck(board, position);
                    }
                    
                    //check if player has won with his turn
                    if (WinCheck(board, player1Marker))
                    {
                        DisplayBoard(board);
                        Console.WriteLine("Congratulations, Player 1 won the game!");
                        gameOn = false;
                    }
                    else
                    {
                        if (FullBoardCheck(board))
                        {
                            DisplayBoard(board);
                            Console.WriteLine("It's a draw");
                            gameOn = false;
                        }
                        else         //player 1 has finished his turn and has not won or tied
                        {
                            turn = "Player 2";
                        }
                    }
                }
                //if turn to begin with is player 2
                else
                {
                    Console.Clear();
                    DisplayBoard(board);
                    Console.WriteLine("Player 2:");
                    var position = PlayerChoice(board);
                    if (SpaceCheck(board, position))
                    {
                        PlaceMarker(board, player2Marker, position);
                    }
                    else if (SpaceCheck(board, position) == false)
                    {
                        PlayerChoice(board);
                        SpaceCheck(board, position);
                    }
                    
                    if (WinCheck(board, player2Marker))
                    {
                        DisplayBoard(board);
                        Console.WriteLine($"Congratulations, Player 2 has won the game!");
                        gameOn = false;
                    }
                    else
                    {
                        if (FullBoardCheck(board))
                        {
                            DisplayBoard(board);
                            Console.WriteLine("It's a draw");
                            //now we ask the player if they want to play again
                            gameOn = false;

                        }
                        else         //player 2 has finished his turn and has not won or tied
                        {
                            turn = "Player 1";
                        }
                    }
                }
            }
            


        }
        //Write a function that can print out a board. Set up your board as a list, where each index 1-9 corresponds with a number on a number pad, so you get a 3 by 3 board representation.
        public static void DisplayBoard(List<string> board)
        {
            
            Console.WriteLine("   |   |");
            Console.WriteLine(" "+ board[7]+ " | " + board[8] + " | " + board[9]);
            Console.WriteLine("   |   |");
            Console.WriteLine("----------");
            Console.WriteLine("   |   |");
            Console.WriteLine(" " + board[4] + " | " + board[5] + " | " + board[6]);
            Console.WriteLine("   |   |");
            Console.WriteLine("----------");
            Console.WriteLine("   |   |");
            Console.WriteLine(" " + board[1] + " | " + board[2] + " | " + board[3]);
            Console.WriteLine("   |   |");
        }
        //Write a function that can take in a player input and assign their marker as 'X' or 'O
        public static string PlayerInput()
        {
            string userInput = "";
            bool proper = true;
            while (proper)
            {
                Console.WriteLine("Player 1: Do you want to be X or O?");
                userInput = Console.ReadLine().ToUpper();
                if (userInput == "X" || userInput == "O")
                {
                    //figure out how to assign the other variable to the other player
                    //return userInput;      //returns it out of the while loop
                    proper = false;
                           
                }
                else
                {
                    proper = true;
                }
            }
            return userInput;             //returns out of the method
        }
        //Write a function that takes in the board list object, a marker ('X' or 'O'), and a desired position (number 1-9) and assigns it to the board.
        public static void PlaceMarker(List<string> board, string userInput, int position)
        {
            board[position] = userInput;
        }
        //Write a function that takes in a board and checks to see if someone has won. 
        public static bool WinCheck(List<string> board, string mark)
        {
            if (board[7] == mark && board[8] == mark && board[9] == mark)  //across the top
            {
                return true;
            }
            else if (board[4] == mark && board[5] == mark && board[6] == mark)     //across the middle 
            { 
                return true;
            }
            else if (board[1] == mark && board[2] == mark && board[3] == mark)       //across the bottom
            {
                return true;
            }
            else if (board[7] == mark && board[4] == mark && board[1] == mark)        //down the left
            {
                return true;
            } 
            else if (board[8] == mark && board[5] == mark && board[2] == mark)         //down the middle
            {
                return true;
            }
            else if (board[9] == mark && board[6] == mark && board[3] == mark)          //down the right
            {
                return true;
            }
            else if (board[7] == mark && board[5] == mark && board[3] == mark)        //diagonal top left to bottom right
            {
                return true;
            }
            else if (board[9] == mark && board[5] == mark && board[1] == mark)         //diagonal top right to bottom left
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //Write a function that uses the random module to randomly decide which player goes first. Return a string of which player went first.
        public static string ChooseFirst()
        {
            Random r = new Random();
            int rInt = r.Next(0, 2);
            if (rInt == 1)
            
            {
                Console.WriteLine("Player 1 goes first");
                return "Player 1";
                //Console.WriteLine("Player 1 goes first.");
            }
            else
            {
                Console.WriteLine("Player 2 goes first");
                return "Player 2";
                //Console.WriteLine("Player 2 goes first."); 
            }
        }
        //Write a function that returns a boolean indicating whether a space on the board is freely available. we will use this to see if the board is full and it's a tie
        public static bool SpaceCheck(List<string> board, int position)
        {
            //if (board[position] != "X" || board[position] != "O")    //might have to be != X or O, in other words its free from user input.
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
            if (board[position] != "X" && board[position] != "O")  //i.e the chosen spot is a digit, not a marker
            {
                return true; //i.e there is empty space (1-9). its a digit
            }
            else
            {
                Console.WriteLine("Sorry, but you did not pick an empty position, please pick again.");
                return false;
            }
        }
        //Write a method that checks if the board is full and returns a boolean value. True if full, False otherwise.
        //how do we get it to return true only if the whole board is full
        public static bool FullBoardCheck(List<string> board)
        {
            //check if the string list contains something other than x or o
          if (board.Contains("1") || board.Contains("2") || board.Contains("3") || board.Contains("4") || board.Contains("5") || board.Contains("6") || board.Contains("7") || board.Contains("8") || board.Contains("9"))                //(SpaceCheck(board, i))
          {
          return false;     //the board isn't full because there is a place in the list that isn't x or o
          }
          else
            {
                return true;
            }
        }
        //Write a method that asks for a players position (1-9) and than uses the space check method to check if that position is free.
        //if it is return positiom
        public static int PlayerChoice(List<string> board)
        {
            bool loop = true;
            int position = 0; 
            while (loop)      //ask for input that's within the range
            {
                Console.WriteLine("Choose your next position: (1-9)");
                //ask for input that's an integer
                 while (!int.TryParse(Console.ReadLine(), out position))
                {
                    Console.WriteLine("Please enter an Integer");
                }
                if (position > 0 && position < 10 && SpaceCheck(board, position))
                {
                    loop = false;
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter a number between 1 - 9");
                }
            }
            //return players position so it can be placed on the board once we have checked for all conditions
            return position;
        }

        //Write a method that asks a player if he wants to play again and returns a bool 
        public static bool PlayAgain()
        {
            Console.WriteLine("Do you want to play again? Enter Y or N");
            var answer = Console.ReadLine();
            if (answer.ToUpper() == "Y")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }


}
