using System;
using System.Collections.Generic;
using System.Text;

namespace problem3
{
    public class SudokuSolver
    {
        private int[,] board;
        public SudokuSolver(int[,] board)
        {
            this.board = board;
        }


        public void SetBoard(int[,] board)
        {
            this.board = board;
        }

        public void Run(int num)
        {

            Console.WriteLine($"Solving Puzzle {num}: ");
            PrintBoard(board);
            Console.WriteLine("");
            
            if(SolveSudoku(board))
            {
                Console.WriteLine("");
                Console.WriteLine("Solved Puzzle:");
                PrintBoard(board);
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("No solution found");
                Console.WriteLine("");
            }
        }

        /// <summary>
        /// Recursively solves the local sudoku board
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        private bool SolveSudoku(int[,] board)
        {
            bool complete = true;

            //check to see if any cell on the board contains -1
            foreach(int value in board)
            {
                if(value == -1)
                {
                    complete = false;
                }
            }

            if (complete)
            {
                //no cells contian -1. The board is solved
                return true;
            }

            //get our current position on the board
            Tuple<int, int> position = GetPosition(board);

            int x = position.Item1;
            int y = position.Item2;

            for (int i = 1; i<10; i++)
            {
                //set this board position to i [i will always be a possible sudoku value
                board[x, y] = i;

                //Check to see if this value is allowed
                if (Promising(x, y, board))
                {
                    //this value was allowed, recusivley solve the board
                    if (SolveSudoku(board))
                    {
                        //we found a valid solution, return true
                        return true;
                    }
                    else
                    {
                        //this did not contribute to a valis solution
                        board[x, y] = -1;
                    }
                }
                else
                {
                    //this value is not promising
                    board[x, y] = -1;
                }
            }
            return false;
        }

        /// <summary>
        /// Checks to see if the value we set is a valid move
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="board"></param>
        /// <returns></returns>
        private bool Promising(int x, int y, int[,] board)
        {
            //make sure the value we set is not the same as any in this row
            for(int i=0; i<9; i++)
            {
                if (i == y)
                    continue;
                if (board[x, i] == board[x, y])
                    return false;
            }

            //check to make sure the value we set is not the same as any in this column
            for (int j = 0; j < 9; j++)
            {
                if (j == x)
                    continue;
                if (board[j,y] == board[x, y])
                    return false;
            }

            int column = x - (x % 3);
            int row = y - (y % 3);

            //make sure the value we set is unique in it's square
            for(int i = column; i<column+3; i++)
            {
                for(int j = row; j<row+3;j++)
                {
                    if (i == x && j == y)
                        continue;
                    if (board[i, j] == board[x, y])
                        return false;
                }
            }
                return true;
        }

        /// <summary>
        /// Returns the position of the first empty cell on the sudoku board
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        private Tuple<int, int> GetPosition(int[,] board)
        {
            //get the dimensions of the board
            int width = board.GetLength(0);
            int height = board.GetLength(1);

            //iterate over the x-axis of the board
            for (int x = 0; x < width; ++x)
            {
                //iterate over the y-axis of the board
                for (int y = 0; y < height; ++y)
                {
                    if (board[x, y].Equals(-1))
                        return Tuple.Create(x, y);
                }
            }

            //there are no empty cells, return an impossible position
            return Tuple.Create(-1, -1);
        }

        /// <summary>
        /// prints the sudoku board in it's current state
        /// </summary>
        /// <param name="board"></param>
        private void PrintBoard(int[,] board)
        {
            int i = 0;
            foreach (int value in board)
            {
                if (value == -1)
                    Console.Write($"|   |");
                else
                    Console.Write($"| {value} |");

                if (i % 8 == 0 && i != 0)
                    Console.Write("\n");

                i++;

                if (i == 9)
                    i = 0;

            }
        }
    }
}
