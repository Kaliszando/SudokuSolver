using System;
using SudokuSolverApp.controller;
using SudokuSolverApp.model;

namespace SudokuSolverApp.View
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            SudokuGrid testGrid = new SudokuGrid(new int[,]
            {
                {6, 0, 0, 1, 0, 8, 2, 0, 3},
                {0, 2, 0, 0, 4, 0, 0, 9, 0},
                {8, 0, 3, 0, 0, 5, 4, 0, 0},
                {5, 0, 4, 6, 0, 7, 0, 0, 9},
                {0, 3, 0, 0, 0, 0, 0, 5, 0},
                {7, 0, 0, 8, 0, 3, 1, 0, 2},
                {0, 0, 1, 7, 0, 0, 9, 0, 6},
                {0, 8, 0, 0, 3, 0, 0, 2, 0},
                {3, 0, 2, 9, 0, 4, 0, 0, 5}
            });
            SudokuSolver solver = new SudokuSolver(testGrid);
            Console.WriteLine(solver.ToString());
            solver.Solve();
            Console.WriteLine(solver.ToString());
        }
    }
}