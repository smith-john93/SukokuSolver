using System;
using System.Collections.Generic;
using System.Text;

namespace problem3
{
    public class nqueens
    {
        int N;
        public nqueens(int boardSize)
        {
            N = boardSize;
        }

        public bool promising(bool[,] board, int x, int y)
        {
            for (int i = 0; i <= x; i++)
            {
                if (i == x)
                    continue;
                if (board[i, y])
                {
                    return false;
                }

                if (i <= y && board[x - i, y - i])
                {
                    return false;
                }
                if(y + i < N && board[x - i, y + i])
                {
                    return false;
                }
            }
            return true;
        }

        public void setN(int boardSize)
        {
            N = boardSize;
        }

        public int estimate(bool[,] board, int x)
        {
            Random rand = new Random();
            int i = 1;
            int numNodes = 1;
            int m = 1;
            int mprod = 1;
            
            while(m!= 0 & i != 0)
            {
                mprod = mprod * m;
                numNodes = numNodes + (mprod * N);
                i++;

                m = 0;
                List<int> promisingChildren = new List<int>();
                for (int j = 0; j < N; j++)
                {
                    board[x, j] = true;
                    if (promising(board, x, j))
                    {
                        m++;
                        promisingChildren.Add(j);
                        board[x, j] = false;
                    }
                }

                if(m!=0)
                {
                    board[x, promisingChildren[rand.Next() % promisingChildren.Count]] = true;
                    x++;
                }
            }
            return numNodes;
        }
    }
}
