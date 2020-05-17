using System;
using System.Collections.Generic;
using System.Text;

namespace problem3
{
    public class Estimation
    {
      
        /// <summary>
        /// estimates how many nodes are going to be visited to solve this sudoku puzzle        
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        public int runEstimation(int[,] board)
        {
            //tracker for how many nodes have been visited
            int numNodes = 1;

            int promiseCount = 1;
            int mprod = 1;
            bool anyEmpty = true;

            //get the dimensions of the board
            int width = board.GetLength(0);
            int height = board.GetLength(1);

            Random rand = new Random();

            while (promiseCount != 0 && anyEmpty)
            {
                anyEmpty = false;

                //iterate over the board to check for empty cells in the sudoku board
                for(int i =0; i<9;i++)
                {                   
                    for(int j = 0; j<9; j++)
                    {

                        if (board[i, j] == -1)
                        {
                            //we found an empty cell, set the flag and break
                            anyEmpty = true;                            
                            break;
                        }
                    }
                    
                    if (anyEmpty)
                    {
                        //we found an empty cell, break out of the for loop
                        break;
                    }
                }

                if(anyEmpty)
                {
                    mprod = mprod * promiseCount;
                    numNodes = numNodes + (mprod * 9);
                    promiseCount = 0;

                    //get a tuple of the position on the board
                    Tuple<int, int> tuple = GetPosition(board);

                    //create a list to hold promiseChildren
                    List<int> promiseChildren = new List<int>(); 

                    for(int i = 1; i<10; i++)
                    {
                        board[tuple.Item1, tuple.Item2] = i;
                        
                        //check to see if i is a valid move
                        if (Promising(tuple.Item1, tuple.Item2, board))
                        {
                            //i was a valid move, add it to the list and incriment the counter
                            promiseChildren.Add(i);
                            promiseCount++;
                        }
                    }
                    
                    if (promiseCount != 0)
                    {
                        //if we found any promising values, randomly set one of them
                        int pos = rand.Next() % promiseChildren.Count;
                        board[tuple.Item1, tuple.Item2] = promiseChildren[pos];
                    }
                }

            }
                return numNodes;
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
            for (int i = 0; i < 9; i++)
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
                if (board[j, y] == board[x, y])
                    return false;
            }

            int column = x - (x % 3);
            int row = y - (y % 3);

            //make sure the value we set is unique in it's square
            for (int i = column; i < column + 3; i++)
            {
                for (int j = row; j < row + 3; j++)
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

    }
}
