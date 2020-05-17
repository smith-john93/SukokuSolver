using System;

namespace problem3
{
    class Program
    {
        static void Main(string[] args)
        {

            int i = 1;
            //puzzle 1
            int[,] Puzzle = new int[9, 9] { { -1, 3,-1, 2, 7, 4,-1, 8,-1 },
                                        { -1,-1,-1,-1, 5,-1,-1,-1,-1 },
                                        { -1,-1, 8, 1,-1, 3, 4,-1,-1 },
                                        {  8,-1, 7,-1,-1,-1, 6,-1, 4 },
                                        {  3, 2,-1,-1, 9,-1,-1, 7, 1 },
                                        {  9,-1, 4,-1,-1,-1, 3,-1, 2 },
                                        { -1,-1, 3, 8,-1, 9, 2,-1,-1 },
                                        { -1,-1,-1,-1, 1,-1,-1,-1,-1 },
                                        { -1, 9,-1, 3, 2, 5,-1, 6,-1 } };

            SudokuSolver solver = new SudokuSolver(Copy(Puzzle));
            solver.Run(i);
            Estimation estimate = new Estimation();
            long result = 0;

            for(int j = 0; j<1000; j++)
            {
                result += estimate.runEstimation(Copy(Puzzle));
            }

            Console.WriteLine($"Estimation of puzzle {i++}: {result / 1000} nodes visited");
            Console.WriteLine("\n");

            //puzzle 2
            Puzzle = new int[9, 9] { { -1, 9,-1,-1, 8,-1, 7, 2,-1 },
                                        {  3,-1,-1,-1,-1, 2,-1,-1, 1 },
                                        {  5,-1, 2,-1,-1,-1, 9,-1,-1 },
                                        { -1, 1,-1, 6,-1, 5,-1,-1,-1 },
                                        {  9,-1,-1,-1,-1,-1,-1,-1, 7 },
                                        { -1,-1,-1, 9,-1, 4,-1, 8,-1 },
                                        { -1,-1, 1,-1,-1,-1, 2,-1, 4 },
                                        {  4,-1,-1, 7,-1,-1,-1,-1, 3 },
                                        { -1, 8, 7,-1, 6,-1,-1, 5,-1 } };
            solver.SetBoard(Copy(Puzzle));
            solver.Run(i);
            result = 0;
            for (int j = 0; j < 1000; j++)
            {
                result += estimate.runEstimation(Copy(Puzzle));
            }

            Console.WriteLine($"Estimation of puzzle {i++}: {result / 1000} nodes visited");
            Console.WriteLine("\n");

            //puzzle 3
            Puzzle = new int[9, 9] { { -1,-1, 8, 1,-1,-1,-1, 4, 9 },
                                        { -1, 2,-1,-1,-1,-1, 3,-1,-1 },
                                        {  7,-1,-1,-1,-1, 8,-1,-1,-1 },
                                        {  1,-1,-1,-1,-1, 6,-1,-1,-1 },
                                        {  9,-1,-1,-1,-1, 5,-1,-1,-1 },
                                        {  5, 7, 4,-1,-1, 2, 9, 6,-1 },                                   
                                        {  8,-1,-1, 2,-1, 3,-1,-1, 1 },
                                        {  6,-1,-1, 7,-1, 4,-1,-1, 8 },
                                        { -1, 4, 9,-1,-1,-1, 7, 3,-1 } };
            solver.SetBoard(Copy(Puzzle));
            solver.Run(i);
            result = 0;
            for (int j = 0; j < 1000; j++)
            {
                result += estimate.runEstimation(Copy(Puzzle));
            }

            Console.WriteLine($"Estimation of puzzle {i++}: {result / 1000} nodes visited");
            Console.WriteLine("\n");

            //puzzle 4
            Puzzle = new int[9, 9] { { -1, 5,-1,-1,-1,-1, 4,-1,-1 },
                                        {  8,-1,-1, 6,-1,-1, 3,-1, 1 },
                                        { -1,-1,-1,-1, 2, 9,-1, 8, 7 },
                                        { -1, 6,-1,-1,-1,-1, 7,-1,-1 },
                                        { -1,-1, 4,-1, 9,-1, 1,-1,-1 },
                                        { -1,-1, 3,-1,-1,-1,-1, 9,-1 },
                                        {  2, 9,-1, 5, 6,-1,-1,-1,-1 },
                                        { -1,-1, 1,-1,-1, 8,-1,-1, 2 },
                                        { -1,-1, 8,-1,-1,-1,-1, 4,-1 } };
            solver.SetBoard(Copy(Puzzle));
            solver.Run(i);
            result = 0;
            for (int j = 0; j < 1000; j++)
            {
                result += estimate.runEstimation(Copy(Puzzle));
            }

            Console.WriteLine($"Estimation of puzzle {i++}: {result / 1000} nodes visited");
            Console.WriteLine("\n");

            //puzzle 5
            Puzzle = new int[9, 9] { {  9,-1,-1, 5,-1, 7, 3,-1, 8 },
                                        { -1, 5,-1,-1, 9,-1,-1, 6,-1 },
                                        {  1,-1,-1,-1,-1,-1,-1,-1,-1 },
                                        {  8,-1,-1,-1,-1,-1,-1,-1, 2 },
                                        { -1, 9,-1,-1, 1,-1,-1, 7,-1 },
                                        {  3,-1,-1,-1,-1,-1,-1,-1, 5 },
                                        { -1,-1,-1,-1,-1,-1,-1,-1, 6 },
                                        { -1, 6,-1,-1, 5,-1,-1, 4,-1 },
                                        {  7,-1, 8, 1,-1, 9,-1,-1, 3 } };
            solver.SetBoard(Copy(Puzzle));
            solver.Run(i);
            result = 0;
            for (int j = 0; j < 1000; j++)
            {
                result += estimate.runEstimation(Copy(Puzzle));
            }

            Console.WriteLine($"Estimation of puzzle {i++}: {result / 1000} nodes visited");
            Console.WriteLine("\n");

            //puzzle 6
            Puzzle = new int[9, 9] { { -1,-1, 3,-1,-1, 4, 5,-1,-1 },
                                        { -1,-1,-1,-1, 9,-1,-1,-1,-1 },
                                        { -1,-1, 7, 3,-1,-1, 6,-1,-1 },
                                        {  8,-1,-1, 7,-1, 5, 3,-1,-1 },
                                        { -1, 7,-1,-1, 3,-1,-1, 8,-1 },
                                        { -1,-1, 5, 6,-1, 2,-1,-1, 9 },
                                        { -1,-1, 2,-1,-1, 6, 7,-1,-1 },
                                        { -1,-1,-1,-1, 1,-1,-1,-1,-1 },
                                        { -1,-1, 1, 9,-1,-1, 2,-1,-1 } };
            solver.SetBoard(Copy(Puzzle));
            solver.Run(i);
            result = 0;
            for (int j = 0; j < 1000; j++)
            {
                result += estimate.runEstimation(Copy(Puzzle));
            }

            Console.WriteLine($"Estimation of puzzle {i++}: {result / 1000} nodes visited");
            Console.WriteLine("\n");

        }

        public static int[,] Copy(int[,] puzzle)
        {
            int[,] temp = new int[9, 9];
            for(int i = 0; i<9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    temp[i, j] = puzzle[i, j];
                }
            }
            return temp;
        }
    }
}
